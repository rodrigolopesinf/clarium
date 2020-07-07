﻿using Millenium.Application.Interfaces;
using Millenium.Domain.Entity;
using Millenium.Infra.Data.Email;
using Site.Areas.Administrativa.Models;
using Site.Areas.Cadastro.Models;
using Site.Areas.Pesquisa.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site.Areas.Pesquisa.Controllers
{
    [Authorize(Roles = "SUPER ADMINISTRADOR, GESTOR, OPERADOR")]
    public class SolicitacaoController : Controller
    {
        private readonly ISolicitacaoAppService _solicitacaoApp;
        private readonly IClienteAppService _clienteApp;
        private readonly ITipoSolicitacaoAppService _tipoSolicitacaoApp;
        private readonly IEnderecoAppService _enderecoApp;
        private readonly IUsuarioAppService _usuarioApp;

        public SolicitacaoController(
            ISolicitacaoAppService solicitacaoApp,
            IClienteAppService clienteApp,
            ITipoSolicitacaoAppService tipoSolicitacaoApp,
            IEnderecoAppService enderecoApp,
            IUsuarioAppService usuarioApp)
        {
            _solicitacaoApp = solicitacaoApp;
            _clienteApp = clienteApp;
            _tipoSolicitacaoApp = tipoSolicitacaoApp;
            _enderecoApp = enderecoApp;
            _usuarioApp = usuarioApp;
        }

        //
        // GET: /Pesquisa/Solicitacao/

        public ActionResult Index()
        {
            var vm = new SolicitacaoViewModel();
            var usuario = _usuarioApp.GetById(Convert.ToInt32(Session["UsuarioLogado"]));
            vm = CarregarDropDownList(vm, false, usuario.IdCliente != null ? (int)usuario.IdCliente : 0);
            Session["ListaExportacaoSolicitacao"] = new List<SolicitacaoViewModel>();
            @ViewBag.MyInitialValue = "display:none";
            return View("Index", vm);
        }

        [HttpGet]
        public ActionResult Edit()
        {
            var vm = new SolicitacaoViewModel();
            vm.Status = "Pendente";
            vm = CarregarDropDownList(vm, true);
            vm.EnderecoViewModel.Obrigatorio = false;
            return View("Edit", vm);
        }

        [HttpGet]
        public ActionResult Buscar(SolicitacaoViewModel vm, string descricao, string ativo, string button)
        {
            var lista = _solicitacaoApp.ObterSolicitacoesAtivas();

            if (!String.IsNullOrEmpty(vm.Nome))
                lista = lista.Where(x => x.Nome.Contains(vm.Nome));

            if(!String.IsNullOrEmpty(vm.Cpf))
                lista = lista.Where(x => x.Cpf == vm.Cpf);

            if (vm.IdCliente != 0)
                lista = lista.Where(x => x.IdCliente == vm.IdCliente);

            switch (button)
            {
                case "Buscar":
                    ModelState.Clear();
                    vm = new SolicitacaoViewModel();

                    foreach (var item in lista)
                    {
                        var cliente = _clienteApp.GetById((int)item.IdCliente);
                        vm.ListaSolicitacoes.Add(new SolicitacaoViewModel()
                        {
                            IdSolicitacao = item.IdSolicitacao,
                            Cliente = { Nome = cliente.CodigoCliente + " - " + cliente.Cnpj != null ? cliente.NomeFantasia : cliente.Nome },
                            Nome = item.Nome,
                            Cpf = item.Cpf
                        });
                    }

                    Session["ListaExportacaoSolicitacao"] = vm.ListaSolicitacoes;
                    @ViewBag.MyInitialValue = "display:block";
                    return View("Index", vm);
                case "Exportar":
                    var listaExportacao = (List<SolicitacaoViewModel>)Session["ListaExportacaoSolicitacao"];
                    ExportarParaExcel(listaExportacao);
                    vm.ListaSolicitacoes = new List<SolicitacaoViewModel>();
                    Session["ListaExportacaoSolicitacao"] = new List<SolicitacaoViewModel>();
                    @ViewBag.MyInitialValue = "display:none";
                    return View("Index", vm);

            }

            return null;
        }

        [HttpGet]
        public ActionResult RetornarPorId(string id)
        {
            var vm = new SolicitacaoViewModel();

            var obj = _solicitacaoApp.GetById(Convert.ToInt32(id));

            if (obj.IdSolicitacao == 0)
            {
                @ViewBag.MyInitialValue = "display:none";
                return View("Index", vm);
            }

            PreencherEndereco(vm, obj);

            vm.Status = String.IsNullOrEmpty(obj.Resposta) ? "Pendente" : "Concluído" ;
            vm.IdSolicitacao = obj.IdSolicitacao;
            vm.IdCliente = (int)obj.IdCliente;
            vm.Cpf = obj.Cpf;
            vm.DataNascimento = obj.DataNascimento;
            vm.IdTipoSolicitacao = obj.IdTipoSolicitacao;
            vm.Nome = obj.Nome;
            vm.Pai = obj.NomePai;
            vm.Mae = obj.NomeMae;
            vm.Rg = obj.Rg;
            vm.DataHoraCriacao = obj.DataHoraCriacao;
            vm.IdUsuarioCriacao = obj.IdUsuarioCriacao;
            vm.NumeroSequencial = obj.NumeroSequencial;
            vm.Local = obj.Local;
            vm.Resposta = obj.Resposta;

            vm = CarregarDropDownList(vm, false, (int)obj.IdCliente, obj.IdTipoSolicitacao);

            return View("Edit", vm);
        }

        private void PreencherEndereco(SolicitacaoViewModel vm, Solicitacao obj)
        {
            var endereco = _enderecoApp.GetById((int)obj.IdEndereco);
            vm.EnderecoViewModel.Endereco.IdEndereco = endereco.IdEndereco;
            vm.EnderecoViewModel.Endereco.Logradouro = endereco.Logradouro;
            vm.EnderecoViewModel.Endereco.Numero = endereco.Numero;
            vm.EnderecoViewModel.Endereco.Complemento = endereco.Complemento;
            vm.EnderecoViewModel.Endereco.Cep = endereco.Cep;
            vm.EnderecoViewModel.Endereco.Cidade = endereco.Cidade;
            vm.EnderecoViewModel.Endereco.Estado = endereco.Estado;
            vm.EnderecoViewModel.DescricaoBairro = endereco.Bairro;
            vm.EnderecoViewModel.Obrigatorio = false;
        }

        [HttpPost]
        public ActionResult SalvarSolicitacao(SolicitacaoViewModel vm, EnderecoViewModel evm)
        {
            if (!ModelState.IsValid) return View("Edit", vm);

            var resultado = vm.IdSolicitacaoView != "" ? "Editar" : "Salvar";

            switch (resultado)
            {
                case "Salvar":
                    ViewBag.Mensagem = Salvar(vm, evm) ? Properties.Resource.Salvar : Properties.Resource.Erro;
                    break;

                case "Editar":
                    ViewBag.Mensagem = Editar(vm, evm) ? Properties.Resource.Editar : Properties.Resource.Erro;
                    break;
            }

            ViewBag.ActionVoltar = "/Pesquisa/Solicitacao/Index";
            ViewBag.NovoRegistro = "/Pesquisa/Solicitacao/Edit";
            ViewBag.NomeTela = "Solicitação";
            ModelState.Clear();

            return View("~/Areas/Administrativa/Views/Home/Sucesso.cshtml");

        }

        #region Métodos

        public bool Salvar(SolicitacaoViewModel vm, EnderecoViewModel evm)
        {
            try
            {
                var obj = new Solicitacao
                {
                    IdCliente = vm.IdCliente,
                    IdTipoSolicitacao = vm.IdTipoSolicitacao,
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
                    IdSolicitacao = vm.IdSolicitacao,
                    IdEndereco = evm.Endereco.IdEndereco,
                    Nome = vm.Nome,
                    NomeMae = vm.Mae,
                    NomePai = vm.Pai,
                    DataNascimento = vm.DataNascimento,
                    Cpf = vm.Cpf,
                    Rg = vm.Rg,
                    Local = vm.Local,
                    Resposta = vm.Resposta,
                    DataHoraCriacao = DateTime.Now,
                    IdUsuarioCriacao = Convert.ToInt32(Session["UsuarioLogado"])
                };

                GerarNumeroSequencial(obj);

                _solicitacaoApp.Add(obj);

                new Email(obj, _usuarioApp.GetById(Convert.ToInt32(Session["UsuarioLogado"])));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return true;
        }

        public bool Editar(SolicitacaoViewModel vm, EnderecoViewModel evm)
        {
            try
            {
                Solicitacao solicitacaoOld = _solicitacaoApp.GetById(vm.IdSolicitacao);
                solicitacaoOld.IdCliente = vm.IdCliente;
                solicitacaoOld.IdTipoSolicitacao = vm.IdTipoSolicitacao;
                
                solicitacaoOld.NumeroSequencial = vm.NumeroSequencial;
                solicitacaoOld.Sequencia = vm.Sequencia;
                solicitacaoOld.Ano = vm.Ano;

                solicitacaoOld.Endereco.IdEndereco = evm.Endereco.IdEndereco;
                solicitacaoOld.Endereco.Logradouro = evm.Endereco.Logradouro;
                solicitacaoOld.Endereco.Numero = evm.Endereco.Numero;
                solicitacaoOld.Endereco.Complemento = evm.Endereco.Complemento;
                solicitacaoOld.Endereco.Cep = evm.Endereco.Cep;
                solicitacaoOld.Endereco.Cidade = evm.Endereco.Cidade;
                solicitacaoOld.Endereco.Estado = evm.Endereco.Estado;
                solicitacaoOld.Endereco.Bairro = evm.DescricaoBairro;

                solicitacaoOld.IdSolicitacao = vm.IdSolicitacao;
                solicitacaoOld.IdEndereco = evm.Endereco.IdEndereco;
                solicitacaoOld.Nome = vm.Nome;
                solicitacaoOld.NomeMae = vm.Mae;
                solicitacaoOld.NomePai = vm.Pai;
                solicitacaoOld.DataNascimento = vm.DataNascimento;
                solicitacaoOld.Cpf = vm.Cpf;
                solicitacaoOld.Rg = vm.Rg;
                solicitacaoOld.Local = vm.Local;
                solicitacaoOld.Resposta = vm.Resposta;
                solicitacaoOld.DataHoraCriacao = DateTime.Now;
                solicitacaoOld.IdUsuarioCriacao = Convert.ToInt32(Session["UsuarioLogado"]);

                _solicitacaoApp.Update(solicitacaoOld);

                new Email(solicitacaoOld, _usuarioApp.GetById(Convert.ToInt32(Session["UsuarioLogado"])));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return true;
        }

        public void GerarNumeroSequencial(Solicitacao obj)
        {
            var idCliente = (int)obj.IdCliente;
            var cliente = _clienteApp.GetById(idCliente);
            obj.Ano = DateTime.Now.Year;
            obj.Sequencia = GetSequencial(obj.Ano, idCliente);           

            obj.NumeroSequencial = cliente.CodigoCliente + " - " + obj.Sequencia + "/" + obj.Ano;
        }

        public int GetSequencial(int ano, int idCliente)
        {
            var sequencia = 1;
            var codSequencial = _solicitacaoApp.GetAll().LastOrDefault(x => x.IdCliente == idCliente);

            if (codSequencial != null)
            {
                if (!(ano > codSequencial.Ano))
                    sequencia = codSequencial.Sequencia + sequencia;
            }

            return sequencia;
        }

        public SolicitacaoViewModel CarregarDropDownList(SolicitacaoViewModel vm, bool cadastro, int idCliente = 0, int idTipoSolicitacao = 0)
        {
            #region Cliente

            var listaCliente = _clienteApp.GetAll();

            foreach (var obj in listaCliente)
            {
                vm.IdCliente = obj.IdCliente;
                vm.NomeCliente = obj.CodigoCliente + " - " + (obj.Cnpj != null ? obj.NomeFantasia : obj.Nome);
                vm.ListaCliente.Add(new SelectListItem { Text = vm.NomeCliente, Value = vm.IdCliente.ToString(CultureInfo.InvariantCulture) });
            }

            vm.IdCliente = idCliente;

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

        public void ExportarParaExcel(List<SolicitacaoViewModel> lista)
        {
            var tiposCliente = new DataTable("dataTableSolicitacao");
            tiposCliente.Columns.Add("Descrição", typeof(string));
            tiposCliente.Columns.Add("Ativo", typeof(string));

            foreach (var t in lista)
            {
                tiposCliente.Rows.Add(t.Cliente, t.Cpf);
            }

            var grid = new GridView { DataSource = tiposCliente };
            grid.DataBind();

            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=ArquivoExcelTiposCliente.xls");
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

        public ActionResult Excluir(ExcluirViewModel vm, string id)
        {
            ViewBag.ActionVoltar = "/Pesquisa/Solicitacao/Index";
            ViewBag.ActionExcluir = "/Pesquisa/Solicitacao/ExcluirSolicitacao";
            ViewBag.NomeTela = "Tipo de Cliente";
            vm.IdExclusao = Convert.ToInt32(id);

            return View("~/Areas/Administrativa/Views/Home/Excluir.cshtml", vm);
        }

        [HttpPost]
        public ActionResult ExcluirSolicitacao(ExcluirViewModel evm, string sim, string nao)
        {
            var vm = new SolicitacaoViewModel();

            if (sim == null)
            {
                @ViewBag.MyInitialValue = "display:none";
                @ViewBag.MensagemErro = "display:none";
                return View("Index", vm);
            }

            _solicitacaoApp.Remove(_solicitacaoApp.GetById(evm.IdExclusao));
            @ViewBag.MyInitialValue = "display:none";
            return View("Index", vm);
        }

        #endregion

    }
}