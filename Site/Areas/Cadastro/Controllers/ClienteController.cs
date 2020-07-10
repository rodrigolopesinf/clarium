using Millenium.Application.Interfaces;
using Millenium.Domain.Entity;
using Site.Areas.Administrativa.Models;
using Site.Areas.Cadastro.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site.Areas.Cadastro.Controllers
{
    [Authorize(Roles = "SUPER ADMINISTRADOR, GESTOR")]
    public class ClienteController : Controller
    {
        private readonly IClienteAppService _clienteApp;
        private readonly IContatoAppService _contatoApp;
        private readonly ISituacaoClienteAppService _situacaoClienteApp;
        private readonly ITipoClienteAppService _tipoClienteApp;
        private readonly ITipoSolicitacaoAppService _tipoSolicitacaoApp;
        private readonly IEnderecoAppService _enderecoApp;

        public ClienteController(
            IClienteAppService clienteApp,
            IContatoAppService contatoApp,
            ISituacaoClienteAppService situacaoClienteApp,
            ITipoClienteAppService tipoClienteApp,
            ITipoSolicitacaoAppService tipoSolicitacaoApp,
            IEnderecoAppService enderecoApp)
        {
            _clienteApp = clienteApp;
            _contatoApp = contatoApp;
            _situacaoClienteApp = situacaoClienteApp;
            _tipoClienteApp = tipoClienteApp;
            _tipoSolicitacaoApp = tipoSolicitacaoApp;
            _enderecoApp = enderecoApp;
        }

        //
        // GET: /Cadastro/Cliente/

        public ActionResult Index()
        {
            var vm = new ClienteViewModel();
            vm = CarregarDropDownList(vm, false);
            @ViewBag.MyInitialValue = "display:none";
            @ViewBag.MensagemErro = "display:none";
            Session["ListaExportacaoCliente"] = new List<ClienteViewModel>();
            return View("Index", vm);
        }

        [HttpGet]
        public ActionResult Edit()
        {
            var vm = new ClienteViewModel { Ativo = true, FaturaEmail = true };
            vm = CarregarDropDownList(vm, true, idSituacaoCliente: 1);
            vm.SituacaoCliente.IdSituacaoCliente = 1;
            vm.EnderecoViewModel.Obrigatorio = true;
            vm.TipoRazao = true;

            vm.TipoSolicitacaoViewModel = new TipoSolicitacaoViewModel();

            @ViewBag.Pf = "display:none";
            @ViewBag.Pj = "display:block";
            @ViewBag.Patrimonio = "display:none";
            @ViewBag.Mensagem = "display:none";
            @ViewBag.Imprimir = "display:none";

            return View("Edit", vm);
        }

        [HttpPost]
        public ActionResult Salvar(ClienteViewModel vm, EnderecoViewModel evm, ContatoViewModel cvm, string IdsMaquina, string button)
        {
            var resultado = vm.IdClienteView != "" ? "Editar" : "Salvar";
            var acao = "";

            switch (resultado)
            {
                case "Salvar":
                    SalvarCliente(evm, cvm, vm);
                    acao = "1";
                    break;

                case "Editar":
                    EditarCliente(evm, cvm, vm);
                    acao = "1";
                    break;
            }

            const string strSeparador = "/";
            vm.IdCliente = _clienteApp.ObterClientesAtivos().FirstOrDefault(x => x.Cnpj == vm.Cnpj || x.Cpf == vm.Cpf).IdCliente;
            Response.Redirect(url: "~/Cadastro/Cliente/RetornarPorId/" + vm.IdCliente + strSeparador + acao);

            return null;
        }

        [HttpGet]
        public ActionResult Buscar(ClienteViewModel vm, string ativo, string button)
        {
            var obj = new Cliente();
            obj.Cpf = !String.IsNullOrEmpty(vm.Cpf) ? vm.Cpf : String.Empty;
            obj.Cnpj = !String.IsNullOrEmpty(vm.Cnpj) ? vm.Cnpj : String.Empty;
            obj.Nome = !String.IsNullOrEmpty(vm.Nome) ? vm.Nome : String.Empty;
            obj.IdSituacaoCliente = vm.IdSituacaoCliente;

            var lista = _clienteApp.ObterClientesAtivos();

            switch (button)
            {
                case "Buscar":
                    ModelState.Clear();
                    vm = new ClienteViewModel();
                    foreach (var Vm in lista.Select(item => new ClienteViewModel
                    {
                        IdCliente = item.IdCliente,
                        CodigoCliente = item.CodigoCliente,
                        Nome = item.Cnpj != null ? item.NomeFantasia : item.Nome,
                        SituacaoCliente = { Descricao = item.SituacaoCliente.Descricao },
                        Ativo = item.Ativo
                    }))
                    {
                        vm.ListaClientes.Add(Vm);
                    }

                    vm = CarregarDropDownList(vm, false);
                    @ViewBag.MensagemErro = "display:none";
                    @ViewBag.MyInitialValue = "display:block";
                    Session["ListaExportacaoCliente"] = vm.ListaClientes;
                    return View("Index", vm);
                case "Exportar":
                    var listaExportacao = (List<ClienteViewModel>)Session["ListaExportacaoCliente"];
                    ExportarParaExcel(listaExportacao);
                    vm.ListaClientes = new List<ClienteViewModel>();
                    Session["ListaExportacaoCliente"] = new List<ClienteViewModel>();
                    @ViewBag.MyInitialValue = "display:none";
                    @ViewBag.MensagemErro = "display:none";
                    vm = CarregarDropDownList(vm, false);
                    return View("Index", vm);
            }

            return null;
        }

        [HttpGet]
        public ActionResult RetornarPorId(string id, string acao)
        {
            var vm = new ClienteViewModel();

            var cliente = _clienteApp.GetById(Convert.ToInt32(id));
            var endereco = _enderecoApp.GetById((int)cliente.IdEndereco);

            vm.EnderecoViewModel.Endereco.IdEndereco = endereco.IdEndereco;
            vm.EnderecoViewModel.Endereco.Logradouro = endereco.Logradouro;
            vm.EnderecoViewModel.Endereco.Numero = endereco.Numero;
            vm.EnderecoViewModel.Endereco.Complemento = endereco.Complemento;
            vm.EnderecoViewModel.Endereco.Cep = endereco.Cep;
            vm.EnderecoViewModel.Endereco.Cidade = endereco.Cidade;
            vm.EnderecoViewModel.Endereco.Estado = endereco.Estado;
            vm.EnderecoViewModel.DescricaoBairro = endereco.Bairro;
            vm.EnderecoViewModel.Obrigatorio = true;

            if (cliente.IdContato != null)
            {
                var contato = _contatoApp.GetById((int)cliente.IdContato);
                vm.ContatoViewModel.Contato.IdContato = contato.IdContato;
                vm.ContatoViewModel.Contato.Nome = contato.Nome;
                vm.ContatoViewModel.Contato.Celular = contato.Celular;
                vm.ContatoViewModel.Contato.CelularSecundario = contato.CelularSecundario;
                vm.ContatoViewModel.Contato.Email = contato.Email;
                vm.ContatoViewModel.Contato.Site = contato.Site;
            }


            vm.EmailPrincipal = cliente.EmailPrincipal;
            vm.TelefonePrincipal = cliente.TelefonePrincipal;
            vm.RamalPrincipal = cliente.RamalPrincipal;
            vm.TelefoneSecundario = cliente.TelefoneSecundario;
            vm.RamalSecundario = cliente.RamalSecundario;
            vm.TipoCliente.IdTipoCliente = cliente.TipoCliente.IdTipoCliente;
            vm.SituacaoCliente.IdSituacaoCliente = cliente.SituacaoCliente.IdSituacaoCliente;
            vm.IdCliente = cliente.IdCliente;
            vm.CodigoCliente = cliente.CodigoCliente;
            vm.NomeFantasia = cliente.NomeFantasia;
            vm.RazaoSocial = cliente.RazaoSocial;
            vm.Nome = cliente.Nome;
            vm.Cpf = cliente.Cpf;
            vm.Cnpj = cliente.Cnpj;
            vm.FaturaEmail = cliente.FaturaEmail;
            vm.Observacao = cliente.Observacao;
            vm.Ativo = cliente.Ativo;
            vm.DiaVencimento = cliente.DiaVencimento;
            vm.DataHoraCriacao = cliente.DataHoraCriacao;
            vm.IdUsuarioCriacao = cliente.IdUsuarioCriacao;

            if (!String.IsNullOrEmpty(vm.Cpf))
            {
                vm.TipoRazao = false;
                ViewBag.Pf = "display:block";
                @ViewBag.Pj = "display:none";
            }
            else
            {
                vm.TipoRazao = true;
                ViewBag.Pf = "display:none";
                @ViewBag.Pj = "display:block";
            }
            @ViewBag.Imprimir = "display:block";

            vm = CarregarDropDownList(vm, false, cliente.TipoCliente.IdTipoCliente, cliente.SituacaoCliente.IdSituacaoCliente);

            @ViewBag.Mensagem = acao != null ? "display:block" : "display:none";

            return View("Edit", vm);
        }

        [HttpGet]
        public ActionResult RedirecionarTipoSolicitacao(string id)
        {
            Response.Redirect("~/Cadastro/TipoSolicitacao/RetornarPorId/" + id);
            return null;
        }

        #region Métodos

        public void SalvarCliente(EnderecoViewModel evm, ContatoViewModel cvm, ClienteViewModel vm)
        {
            var obj = new Cliente
            {
                Endereco =
                {
                    IdEndereco = evm.Endereco.IdEndereco,
                    Logradouro = evm.Endereco.Logradouro,
                    Numero = evm.Endereco.Numero,
                    Complemento = evm.Endereco.Complemento,
                    Cep = evm.Endereco.Cep,
                    Cidade = evm.Endereco.Cidade,
                    Estado = evm.Endereco.Estado,
                    Bairro = evm.DescricaoBairro
                },
                Contato = {
                    IdContato = cvm.Contato.IdContato,
                    Nome = cvm.Contato.Nome,
                    Celular = cvm.Contato.Celular,
                    CelularSecundario = cvm.Contato.CelularSecundario,
                    Email = cvm.Contato.Email,
                    Site = cvm.Contato.Site,
                    Ativo = true,
                    IdUsuarioCriacao = Convert.ToInt32(Session["UsuarioLogado"]),
                    DataHoraCriacao = DateTime.Now
                },

                CodigoCliente = vm.CodigoCliente,
                IdTipoCliente = vm.IdTipoCliente,
                NomeFantasia = vm.NomeFantasia,
                RazaoSocial = vm.RazaoSocial,
                Nome = vm.Nome,
                Cpf = vm.Cpf,
                Cnpj = vm.Cnpj,
                TelefonePrincipal = vm.TelefonePrincipal,
                RamalPrincipal = vm.RamalPrincipal,
                TelefoneSecundario = vm.TelefoneSecundario,
                RamalSecundario = vm.RamalSecundario,
                EmailPrincipal = vm.EmailPrincipal,
                IdCliente = vm.IdCliente,
                IdEndereco = evm.Endereco.IdEndereco,
                IdContato = cvm.Contato.IdContato,
                IdSituacaoCliente = vm.SituacaoCliente.IdSituacaoCliente,
                FaturaEmail = vm.FaturaEmail,
                Observacao = vm.Observacao,
                Ativo = vm.Ativo,
                DiaVencimento = vm.DiaVencimento,
                IdUsuarioCriacao = Convert.ToInt32(Session["UsuarioLogado"]),
                DataHoraCriacao = DateTime.Now
            };

            _clienteApp.Add(obj);
        }

        public void EditarCliente(EnderecoViewModel evm, ContatoViewModel cvm, ClienteViewModel vm)
        {
            Cliente clienteOld = _clienteApp.GetById(vm.IdCliente);

            clienteOld.Endereco.IdEndereco = evm.Endereco.IdEndereco;
            clienteOld.Endereco.Logradouro = evm.Endereco.Logradouro;
            clienteOld.Endereco.Numero = evm.Endereco.Numero;
            clienteOld.Endereco.Complemento = evm.Endereco.Complemento;
            clienteOld.Endereco.Cep = evm.Endereco.Cep;
            clienteOld.Endereco.Cidade = evm.Endereco.Cidade;
            clienteOld.Endereco.Estado = evm.Endereco.Estado;
            clienteOld.Endereco.Bairro = evm.DescricaoBairro;

            clienteOld.CodigoCliente = vm.CodigoCliente;
            clienteOld.IdTipoCliente = vm.TipoCliente.IdTipoCliente;
            clienteOld.NomeFantasia = vm.NomeFantasia;
            clienteOld.RazaoSocial = vm.RazaoSocial;
            clienteOld.Nome = vm.Nome;
            clienteOld.Cpf = vm.Cpf;
            clienteOld.Cnpj = vm.Cnpj;
            clienteOld.TelefonePrincipal = vm.TelefonePrincipal;
            clienteOld.RamalPrincipal = vm.RamalPrincipal;
            clienteOld.TelefoneSecundario = vm.TelefoneSecundario;
            clienteOld.RamalSecundario = vm.RamalSecundario;
            clienteOld.EmailPrincipal = vm.EmailPrincipal;
            clienteOld.IdCliente = vm.IdCliente;
            clienteOld.IdEndereco = evm.Endereco.IdEndereco;
            clienteOld.IdContato = cvm.Contato.IdContato;
            clienteOld.IdSituacaoCliente = vm.SituacaoCliente.IdSituacaoCliente;
            clienteOld.FaturaEmail = vm.FaturaEmail;
            clienteOld.Observacao = vm.Observacao;
            clienteOld.Ativo = vm.Ativo;
            clienteOld.DiaVencimento = vm.DiaVencimento;
            clienteOld.IdUsuarioAlteracao = Convert.ToInt32(Session["UsuarioLogado"]);
            clienteOld.DataHoraAlteracao = DateTime.Now;

            clienteOld.Contato.Nome = cvm.Contato.Nome;
            clienteOld.Contato.Celular = cvm.Contato.Celular;
            clienteOld.Contato.CelularSecundario = cvm.Contato.CelularSecundario;
            clienteOld.Contato.Email = cvm.Contato.Email;
            clienteOld.Contato.Site = cvm.Contato.Site;
            clienteOld.Contato.Ativo = true;

            if (clienteOld.Contato.IdContato == 0)
            {
                clienteOld.Contato.IdUsuarioCriacao = Convert.ToInt32(Session["UsuarioLogado"]);
                clienteOld.Contato.DataHoraCriacao = DateTime.Now;
                _contatoApp.Add(clienteOld.Contato);
            }
            else
            {
                Contato contatoOld = _contatoApp.GetById(clienteOld.Contato.IdContato);
                clienteOld.Contato.IdUsuarioCriacao = contatoOld.IdUsuarioCriacao;
                clienteOld.Contato.DataHoraCriacao = contatoOld.DataHoraCriacao;
                clienteOld.Contato.IdUsuarioAlteracao = Convert.ToInt32(Session["UsuarioLogado"]);
                clienteOld.Contato.DataHoraAlteracao = DateTime.Now;
            }

            _clienteApp.Update(clienteOld);
        }

        public ClienteViewModel CarregarDropDownList(ClienteViewModel vm, bool cadastro, int idTipoCliente = 0, int idSituacaoCliente = 0, int idTipoSolicitacao = 0)
        {
            #region TipoCliente

            var listaTipoCliente = _tipoClienteApp.GetAll();

            foreach (var obj in listaTipoCliente)
            {
                vm.IdTipoCliente = obj.IdTipoCliente;
                vm.DescricaoTipoCliente = obj.Descricao;
                vm.ListaTipoCliente.Add(new SelectListItem { Text = vm.DescricaoTipoCliente, Value = vm.IdTipoCliente.ToString(CultureInfo.InvariantCulture) });
            }

            vm.IdTipoCliente = idTipoCliente;

            #endregion

            #region Situação do Cliente

            var listaSituacaoCliente = _situacaoClienteApp.GetAll();

            foreach (var obj in listaSituacaoCliente)
            {
                vm.IdSituacaoCliente = obj.IdSituacaoCliente;
                vm.DescricaoSituacaoCliente = obj.Descricao;
                vm.ListaSituacaoCliente.Add(new SelectListItem { Text = vm.DescricaoSituacaoCliente, Value = vm.IdSituacaoCliente.ToString(CultureInfo.InvariantCulture) });
            }

            vm.IdSituacaoCliente = idSituacaoCliente;

            #endregion

            #region Tipo de Solicitação

            var listaTipoSolicitacao = _tipoSolicitacaoApp.GetAll();

            foreach (var obj in listaTipoSolicitacao)
            {
                vm.IdTipoSolicitacao = obj.IdTipoSolicitacao;
                vm.DescricaoTipoSolicitacao = obj.Descricao;
                vm.ListaTipoSolicitacao.Add(new SelectListItem { Text = vm.DescricaoTipoSolicitacao, Value = vm.IdTipoSolicitacao.ToString(CultureInfo.InvariantCulture) });
            }

            vm.IdTipoSolicitacao = idTipoSolicitacao;

            #endregion

            return vm;
        }

        public List<TipoSolicitacaoViewModel> ListaTipoSolicitacaoViewModel(int idCliente)
        {
            var lista = _tipoSolicitacaoApp.GetAll();
            return lista.Select(item => new TipoSolicitacaoViewModel
            {
                Id = item.IdTipoSolicitacao
            }).ToList();
        }

        public void ExportarParaExcel(List<ClienteViewModel> lista)
        {
            var clientes = new DataTable("dataTableCliente");
            clientes.Columns.Add("Código Cliente", typeof(string));
            clientes.Columns.Add("Nome", typeof(string));
            clientes.Columns.Add("Situação", typeof(string));
            clientes.Columns.Add("Ativo", typeof(string));

            foreach (var t in lista)
            {
                clientes.Rows.Add(t.CodigoCliente, t.Nome, t.SituacaoCliente.Descricao, t.AtivoGrid);
            }

            var grid = new GridView { DataSource = clientes };
            grid.DataBind();

            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=ArquivoExcelClientes.xls");
            Response.ContentType = "application/ms-excel";

            Response.Charset = "";
            var sw = new StringWriter();
            var htw = new HtmlTextWriter(sw);

            grid.RenderControl(htw);

            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }

        #endregion

        #region Excluir

        public ActionResult Excluir(ExcluirViewModel evm, string id)
        {
            var lista = _clienteApp.GetAll();

            if (lista.Any())
            {
                var vm = new ClienteViewModel();
                @ViewBag.MensagemErro = "display:block";
                @ViewBag.MyInitialValue = "display:none";
                return View("Index", vm);
            }

            ViewBag.ActionVoltar = "/Cadastro/Cliente/Index";
            ViewBag.ActionExcluir = "/Cadastro/Cliente/ExcluirCliente";
            ViewBag.NomeTela = "Cliente";
            evm.IdExclusao = Convert.ToInt32(id);

            return View("~/Areas/Administrativa/Views/Home/Excluir.cshtml", evm);
        }

        [HttpPost]
        public ActionResult ExcluirCliente(ExcluirViewModel evm, string sim, string nao)
        {
            var vm = new ClienteViewModel();

            if (sim == null) return View("Index", vm);

            var obj = new Cliente
            {
                IdUsuarioExclusao = Convert.ToInt32(Session["UsuarioLogado"]),
                IdCliente = Convert.ToInt32(evm.IdExclusao)
            };

            _clienteApp.Remove(obj);
            @ViewBag.MyInitialValue = "display:none";
            return View("Index", vm);
        }

        #endregion
    }
}
