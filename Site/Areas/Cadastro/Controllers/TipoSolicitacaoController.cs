using Millenium.Application.Interfaces;
using Millenium.Domain.Entity;
using Site.Areas.Administrativa.Models;
using Site.Areas.Cadastro.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site.Areas.Cadastro.Controllers
{
    [Authorize(Roles = "SUPER ADMINISTRADOR, GESTOR")]
    public class TipoSolicitacaoController : Controller
    {
        private readonly ITipoSolicitacaoAppService _tipoSolicitacaoApp;

        public TipoSolicitacaoController(
            ITipoSolicitacaoAppService tipoSolicitacaoApp)
        {
            _tipoSolicitacaoApp = tipoSolicitacaoApp;
        }


        //
        // GET: /Cadastro/TipoSolicitacao/

        public ActionResult Index()
        {
            var vm = new TipoSolicitacaoViewModel();
            @ViewBag.MyInitialValue = "display:none";
            Session["ListaExportacaoTipoSolicitacao"] = new List<TipoSolicitacaoViewModel>();
            return View("Index", vm);
        }

        [HttpGet]
        public ActionResult Edit()
        {
            var vm = new TipoSolicitacaoViewModel { Ativo = true };
            return View("Edit", vm);
        }

        [HttpGet]
        public ActionResult Buscar(TipoSolicitacaoViewModel vm, string descricao, string ativo, string button)
        {
            var lista = _tipoSolicitacaoApp.ObterTiposSolicitacoesAtivos();

            switch (button)
            {
                case "Buscar":
                    ModelState.Clear();
                    vm = new TipoSolicitacaoViewModel();

                    foreach (var TipoSolicitacaoVm in lista.Select(item => new TipoSolicitacaoViewModel
                    {
                        Id = item.IdTipoSolicitacao,
                        Descricao = item.Descricao,
                        Ativo = (bool)item.Ativo
                    }))
                    {
                        vm.ListaTipoSolicitacoes.Add(TipoSolicitacaoVm);
                    }
                    Session["ListaExportacaoTipoSolicitacao"] = vm.ListaTipoSolicitacoes;
                    @ViewBag.MyInitialValue = "display:block";
                    return View("Index", vm);
                case "Exportar":
                    var listaExportacao = (List<TipoSolicitacaoViewModel>)Session["ListaExportacaoTipoSolicitacao"];
                    ExportarParaExcel(listaExportacao);
                    vm.ListaTipoSolicitacoes = new List<TipoSolicitacaoViewModel>();
                    Session["ListaExportacaoTipoSolicitacao"] = new List<TipoSolicitacaoViewModel>();
                    @ViewBag.MyInitialValue = "display:none";
                    return View("Index", vm);
            }

            return null;
        }

        [HttpGet]
        public ActionResult RetornarPorId(string id)
        {
            var vm = new TipoSolicitacaoViewModel();

            var obj = _tipoSolicitacaoApp.GetById(Convert.ToInt32(id));

            if (obj.IdTipoSolicitacao == 0)
            {
                @ViewBag.MyInitialValue = "display:block";
                return View("Index", vm);
            }
            vm.Id = obj.IdTipoSolicitacao;
            vm.Descricao = obj.Descricao;
            vm.Ativo = (bool)obj.Ativo;

            return View("Edit", vm);
        }

        [HttpPost]
        public ActionResult SalvarTipoSolicitacao(TipoSolicitacaoViewModel vm)
        {
            if (!ModelState.IsValid) return View("Edit", vm);

            var resultado = vm.IdView != "" ? "Editar" : "Salvar";

            switch (resultado)
            {
                case "Salvar":
                    ViewBag.Mensagem = Salvar(vm) ? Properties.Resource.Salvar : Properties.Resource.Erro;
                    break;

                case "Editar":
                    ViewBag.Mensagem = Editar(vm) ? Properties.Resource.Editar : Properties.Resource.Erro;
                    break;
            }

            ViewBag.ActionVoltar = "/Cadastro/TipoSolicitacao/Index";
            ViewBag.NovoRegistro = "/Cadastro/TipoSolicitacao/Edit";
            ViewBag.NomeTela = "TipoSolicitacao";
            ModelState.Clear();

            return View("~/Areas/Administrativa/Views/Home/Sucesso.cshtml");

        }

        #region Métodos

        public bool Salvar(TipoSolicitacaoViewModel vm)
        {
            try
            {
                var obj = new TipoSolicitacao
                {
                    Descricao = vm.Descricao,
                    IdUsuarioCriacao = Convert.ToInt32(Session["UsuarioLogado"]),
                    DataHoraCriacao = DateTime.Now,
                    Ativo = vm.Ativo
                };

                _tipoSolicitacaoApp.Add(obj);
            }
            catch (Exception ex)
            {
                throw new FormatException(ex.Message);
            }

            return true;
        }

        public bool Editar(TipoSolicitacaoViewModel vm)
        {
            try
            {
                var obj = _tipoSolicitacaoApp.GetById(vm.Id);
                obj.IdTipoSolicitacao = vm.Id;
                obj.Descricao = vm.Descricao;
                obj.Ativo = vm.Ativo;
                obj.IdUsuarioAlteracao = Convert.ToInt32(Session["UsuarioLogado"]);

                _tipoSolicitacaoApp.Update(obj);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public void ExportarParaExcel(List<TipoSolicitacaoViewModel> lista)
        {
            var TipoSolicitacaos = new DataTable("dataTableTipoSolicitacao");
            TipoSolicitacaos.Columns.Add("Descrição", typeof(string));
            TipoSolicitacaos.Columns.Add("Ativo", typeof(string));

            foreach (var t in lista)
            {
                TipoSolicitacaos.Rows.Add(t.Descricao, t.AtivoGrid);
            }

            var grid = new GridView { DataSource = TipoSolicitacaos };
            grid.DataBind();

            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=ArquivoExcelTipoSolicitacaos.xls");
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
            ViewBag.ActionVoltar = "/Cadastro/TipoSolicitacao/Index";
            ViewBag.ActionExcluir = "/Cadastro/TipoSolicitacao/ExcluirTipoSolicitacao";
            ViewBag.NomeTela = "TipoSolicitacao";
            vm.IdExclusao = Convert.ToInt32(id);

            return View("~/Areas/Administrativa/Views/Home/Excluir.cshtml", vm);
        }

        [HttpPost]
        public ActionResult ExcluirTipoSolicitacao(ExcluirViewModel evm, string sim, string nao)
        {
            var vm = new TipoSolicitacaoViewModel();

            if (sim == null)
            {
                @ViewBag.MyInitialValue = "display:none";
                @ViewBag.MensagemErro = "display:none";
                return View("Index", vm);
            }
            
            _tipoSolicitacaoApp.Remove(_tipoSolicitacaoApp.GetById(evm.IdExclusao));
            @ViewBag.MyInitialValue = "display:none";
            return View("Index", vm);
        }

        #endregion

    }
}

