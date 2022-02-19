using Millenium.Application.Interfaces;
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
using iTextSharp.text;
using iTextSharp.text.pdf;

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
            var vm = new SolicitacaoViewModel()
            {
                IdNivelUsuario = Convert.ToInt32(Session["NivelUsuarioLogado"])
            };
            vm = CarregarDropdownCliente(vm, false);
            Session["ListaExportacaoSolicitacao"] = new List<SolicitacaoViewModel>();
            @ViewBag.MyInitialValue = "display:none";
            return View("Index", vm);
        }

        private SolicitacaoViewModel CarregarDropdownCliente(SolicitacaoViewModel vm, bool cadastro)
        {
            var usuario = _usuarioApp.GetById(Convert.ToInt32(Session["UsuarioLogado"]));
            vm = CarregarDropDownList(vm, cadastro, usuario.IdCliente != null ? (int)usuario.IdCliente : 0);
            return vm;
        }

        [HttpGet]
        public ActionResult Edit()
        {
            var vm = new SolicitacaoViewModel
            {
                Status = "Pendente",
                EnderecoViewModel = new EnderecoViewModel() { Obrigatorio = false },
                IdNivelUsuario = Convert.ToInt32(Session["NivelUsuarioLogado"])
            };
            vm = CarregarDropdownCliente(vm, true);
            @ViewBag.Butons = "text-align:right";
            return View("Edit", vm);
        }

        [HttpGet]
        public ActionResult Buscar(SolicitacaoViewModel vm, string descricao, string ativo, string button)
        {
            var lista = _solicitacaoApp.ObterSolicitacoesAtivas().ToList();

            if (!string.IsNullOrEmpty(vm.Nome))
                lista = lista.Where(x => x.Nome.Contains(vm.Nome)).ToList();

            if (!string.IsNullOrEmpty(vm.Cpf))
                lista = lista.Where(x => x.Cpf == vm.Cpf).ToList();

            if (vm.IdClienteSolicitacao != 0)
                lista = lista.Where(x => x.IdCliente == vm.IdClienteSolicitacao).ToList();

            vm = CarregarDropdownCliente(vm, false);
            vm.IdNivelUsuario = Convert.ToInt32(Session["NivelUsuarioLogado"]);

            switch (button)
            {
                case "Buscar":
                    ModelState.Clear();
                    Session["ListaExportacaoSolicitacao"] = RetornarListaSolicitacao(vm, lista);
                    @ViewBag.MyInitialValue = "display:block";
                    break;
                case "Exportar":
                    ExportarParaExcel(RetornarListaSolicitacao(vm, lista));
                    vm.ListaSolicitacoes = new List<SolicitacaoViewModel>();
                    Session["ListaExportacaoSolicitacao"] = new List<SolicitacaoViewModel>();
                    @ViewBag.MyInitialValue = "display:none";
                    break;
            }
            return View("Index", vm);
        }

        private List<SolicitacaoViewModel> RetornarListaSolicitacao(SolicitacaoViewModel vm, List<Solicitacao> lista)
        {
            foreach (var item in lista)
            {
                var cliente = _clienteApp.GetById((int)item.IdCliente);
                vm.ListaSolicitacoes.Add(new SolicitacaoViewModel()
                {
                    IdSolicitacao = item.IdSolicitacao,
                    Cliente = { Nome = cliente.CodigoCliente + " - " + cliente.Cnpj != null ? cliente.NomeFantasia : cliente.Nome },
                    Nome = item.Nome,
                    Cpf = item.Cpf,
                    Resposta = item.Resposta
                });
            }

            return vm.ListaSolicitacoes;
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

            vm.Status = String.IsNullOrEmpty(obj.Resposta) ? "Pendente" : "Concluído";
            vm.IdSolicitacao = obj.IdSolicitacao;
            vm.IdClienteSolicitacao = (int)obj.IdCliente;
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
            vm.IdNivelUsuario = Convert.ToInt32(Session["NivelUsuarioLogado"]);

            vm = CarregarDropDownList(vm, false, (int)obj.IdCliente, obj.IdTipoSolicitacao);

            @ViewBag.Butons = Convert.ToInt32(Session["NivelUsuarioLogado"]) == 3 && vm.Resposta != String.Empty ? "display:none" : "text-align:right";

            return View("Edit", vm);
        }

        [HttpGet]
        public ActionResult Imprimir(string id)
        {
            var filePath = ExportToPDF(_solicitacaoApp.GetById(Convert.ToInt32(id)));
            var file = new FileInfo(filePath);

            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=solicitacao.pdf");
            Response.Charset = "";
            Response.ContentType = "Application/pdf";
            Response.TransmitFile(file.FullName);
            Response.End();

            return null;
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
            vm.EnderecoViewModel.Desabilita = vm.Resposta != String.Empty && Convert.ToInt32(Session["NivelUsuarioLogado"]) == 3;
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
                    IdCliente = vm.IdClienteSolicitacao,
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
                string mensagem = " <br/> O cliente " + vm.Cliente.NomeFantasia + "gerou a solicitação de número " + vm.IdSolicitacao;

                new Email(obj, "consulta@milleniumpesquisas.com.br", "Nova solicitação do cliente", mensagem);
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
                solicitacaoOld.IdCliente = vm.IdClienteSolicitacao;
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

                var mensagem = " <br/> Sua solicitação está concluída, acesse http://www.milleniumpesquisas.com.br/ para visualizar a resposta. ";
                new Email(solicitacaoOld, vm.Cliente.EmailPrincipal, "Resposta de solicitação de pesquisa", mensagem);
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
                vm.IdClienteSolicitacao = obj.IdCliente;
                vm.NomeClienteSolicitacao = obj.CodigoCliente + " - " + (obj.Cnpj != null ? obj.NomeFantasia : obj.Nome);
                vm.ListaClienteSolicitacao.Add(new SelectListItem { Text = vm.NomeClienteSolicitacao, Value = vm.IdClienteSolicitacao.ToString(CultureInfo.InvariantCulture) });
            }

            vm.IdClienteSolicitacao = idCliente;

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
            tiposCliente.Columns.Add("Cliente", typeof(string));
            tiposCliente.Columns.Add("Nome", typeof(string));
            tiposCliente.Columns.Add("CPF", typeof(string));

            foreach (var t in lista)
            {
                tiposCliente.Rows.Add(t.Cliente.Nome, t.Nome, t.Cpf);
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

        #region PDF

        public string ExportToPDF(Solicitacao solicitacao)
        {
            var pdfDocument = new Document();
            var pdfFile = string.Format("{0}{1}.pdf", Path.GetTempPath(), "solicitacao");

            var pdfWriter = PdfWriter.GetInstance(pdfDocument, new FileStream(pdfFile, FileMode.Create));
            pdfWriter.PageEvent = new PDFFooter();
            pdfDocument.Open();

            FontFactory.RegisterDirectory("C:\\WINDOWS\\Fonts");
            var font = FontFactory.GetFont("Times-Italic", 14);

            var paragraph = new Paragraph("CONFIDENCIAL", FontFactory.GetFont("Times-Italic", 22, 1, BaseColor.RED))
            {
                Alignment = Element.ALIGN_CENTER
            };
            pdfDocument.Add(paragraph);

            pdfDocument.Add(Chunk.NEWLINE);

            paragraph = new Paragraph("Data da Solicitação: " + solicitacao.DataHoraCriacao.ToString("dd/MM/yyyy"), font)
            {
                Alignment = Element.ALIGN_RIGHT
            };
            pdfDocument.Add(paragraph);

            paragraph = new Paragraph("Nº: " + solicitacao.NumeroSequencial, font)
            {
                Alignment = Element.ALIGN_RIGHT
            };
            pdfDocument.Add(paragraph);

            pdfDocument.Add(Chunk.NEWLINE);

            paragraph = new Paragraph("NOME: " + solicitacao.Nome, font)
            {
                Alignment = Element.ALIGN_JUSTIFIED
            };
            pdfDocument.Add(paragraph);

            pdfDocument.Add(Chunk.NEWLINE);

            paragraph = new Paragraph("LOCAL DE NASCIMENTO: " + solicitacao.Local, font)
            {
                Alignment = Element.ALIGN_JUSTIFIED
            };
            pdfDocument.Add(paragraph);

            pdfDocument.Add(Chunk.NEWLINE);

            paragraph = new Paragraph("NASCIMENTO: " + solicitacao.DataNascimento.ToString("dd/MM/yyyy"), font)
            {
                Alignment = Element.ALIGN_JUSTIFIED
            };
            pdfDocument.Add(paragraph);

            pdfDocument.Add(Chunk.NEWLINE);

            paragraph = new Paragraph("NOME DA MÃE: " + solicitacao.NomeMae, font)
            {
                Alignment = Element.ALIGN_JUSTIFIED
            };
            pdfDocument.Add(paragraph);

            pdfDocument.Add(Chunk.NEWLINE);

            paragraph = new Paragraph("NOME DO PAI: " + solicitacao.NomePai, font)
            {
                Alignment = Element.ALIGN_JUSTIFIED
            };
            pdfDocument.Add(paragraph);

            pdfDocument.Add(Chunk.NEWLINE);

            paragraph = new Paragraph("IDENTIDADE: " + solicitacao.Rg, font)
            {
                Alignment = Element.ALIGN_JUSTIFIED
            };
            pdfDocument.Add(paragraph);

            pdfDocument.Add(Chunk.NEWLINE);

            paragraph = new Paragraph("CPF: " + solicitacao.Cpf, font)
            {
                Alignment = Element.ALIGN_JUSTIFIED
            };
            pdfDocument.Add(paragraph);

            pdfDocument.Add(Chunk.NEWLINE);

            paragraph = new Paragraph("PESQUISA SOCIAL: " + solicitacao.Resposta, font)
            {
                Alignment = Element.ALIGN_JUSTIFIED
            };
            pdfDocument.Add(paragraph);

            pdfDocument.Close();
            return pdfFile;
        }

        #endregion

    }
}