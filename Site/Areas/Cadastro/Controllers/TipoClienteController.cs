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
    public class TipoClienteController : Controller
    {
        private readonly ITipoClienteAppService _tipoClienteApp;

        public TipoClienteController(
            ITipoClienteAppService tipoClienteApp)
        {
            _tipoClienteApp = tipoClienteApp;
        }

        //
        // GET: /Cadastro/TipoCliente/

        public ActionResult Index()
        {
            var vm = new TipoClienteViewModel();
            Session["ListaExportacaoTipoCliente"] = new List<TipoClienteViewModel>();
            @ViewBag.MyInitialValue = "display:none";
            return View("Index", vm);
        }

        [HttpGet]
        public ActionResult Edit()
        {
            var vm = new TipoClienteViewModel { Ativo = true };
            return View("Edit", vm);
        }

        [HttpGet]
        public ActionResult Buscar(TipoClienteViewModel vm, string descricao, string ativo, string button)
        {
            var lista = _tipoClienteApp.ObterTiposClientesPelaDescricao(descricao);

            switch (button)
            {
                case "Buscar":
                    ModelState.Clear();
                    vm = new TipoClienteViewModel();

                    foreach (var tipoClienteVm in lista.Select(item => new TipoClienteViewModel
                    {
                        IdTipoCliente = item.IdTipoCliente,
                        Descricao = item.Descricao,
                        Ativo = (bool)item.Ativo
                    }))
                    {
                        vm.ListaTipoClientes.Add(tipoClienteVm);
                    }
                    Session["ListaExportacaoTipoCliente"] = vm.ListaTipoClientes;
                    @ViewBag.MyInitialValue = "display:block";
                    return View("Index", vm);
                case "Exportar":
                    var listaExportacao = (List<TipoClienteViewModel>)Session["ListaExportacaoTipoCliente"];
                    ExportarParaExcel(listaExportacao);
                    vm.ListaTipoClientes = new List<TipoClienteViewModel>();
                    Session["ListaExportacaoTipoCliente"] = new List<TipoClienteViewModel>();
                    @ViewBag.MyInitialValue = "display:none";
                    return View("Index", vm);

            }

            return null;
        }

        [HttpGet]
        public ActionResult RetornarPorId(string id)
        {
            var vm = new TipoClienteViewModel();

            var obj = _tipoClienteApp.GetById(Convert.ToInt32(id));

            if (obj.IdTipoCliente == 0)
            {
                @ViewBag.MyInitialValue = "display:none";
                return View("Index", vm);
            }

            vm.IdTipoCliente = obj.IdTipoCliente;
            vm.Descricao = obj.Descricao;
            vm.Ativo = (bool)obj.Ativo;

            return View("Edit", vm);
        }

        [HttpPost]
        public ActionResult SalvarTipoCliente(TipoClienteViewModel vm)
        {
            if (!ModelState.IsValid) return View("Edit", vm);

            var resultado = vm.IdTipoClienteView != "" ? "Editar" : "Salvar";

            switch (resultado)
            {
                case "Salvar":
                    ViewBag.Mensagem = Salvar(vm) ? Properties.Resource.Salvar : Properties.Resource.Erro;
                    break;

                case "Editar":
                    ViewBag.Mensagem = Editar(vm) ? Properties.Resource.Editar : Properties.Resource.Erro;
                    break;
            }

            ViewBag.ActionVoltar = "/Cadastro/TipoCliente/Index";
            ViewBag.NovoRegistro = "/Cadastro/TipoCliente/Edit";
            ViewBag.NomeTela = "Tipo de Cliente";
            ModelState.Clear();

            return View("~/Areas/Administrativa/Views/Home/Sucesso.cshtml");

        }

        #region Métodos

        public bool Salvar(TipoClienteViewModel vm)
        {
            try
            {
                var obj = new TipoCliente
                {
                    Descricao = vm.Descricao,
                    IdUsuarioCriacao = Convert.ToInt32(Session["UsuarioLogado"]),
                    DataHoraCriacao = DateTime.Now,
                    Ativo = vm.Ativo
                };

                _tipoClienteApp.Add(obj);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool Editar(TipoClienteViewModel vm)
        {
            try
            {
                var obj = _tipoClienteApp.GetById(vm.IdTipoCliente);
                obj.IdTipoCliente = vm.IdTipoCliente;
                obj.Descricao = vm.Descricao;
                obj.Ativo = vm.Ativo;
                obj.IdUsuarioAlteracao = Convert.ToInt32(Session["UsuarioLogado"]);

                _tipoClienteApp.Update(obj);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public void ExportarParaExcel(List<TipoClienteViewModel> lista)
        {
            var tiposCliente = new DataTable("dataTableTipoCliente");
            tiposCliente.Columns.Add("Descrição", typeof(string));
            tiposCliente.Columns.Add("Ativo", typeof(string));

            foreach (var t in lista)
            {
                tiposCliente.Rows.Add(t.Descricao, t.AtivoGrid);
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
            ViewBag.ActionVoltar = "/Cadastro/TipoCliente/Index";
            ViewBag.ActionExcluir = "/Cadastro/TipoCliente/ExcluirTipoCliente";
            ViewBag.NomeTela = "Tipo de Cliente";
            vm.IdExclusao = Convert.ToInt32(id);

            return View("~/Areas/Administrativa/Views/Home/Excluir.cshtml", vm);
        }

        [HttpPost]
        public ActionResult ExcluirTipoCliente(ExcluirViewModel evm, string sim, string nao)
        {
            var vm = new TipoClienteViewModel();

            if (sim == null)
            {
                @ViewBag.MyInitialValue = "display:none";
                @ViewBag.MensagemErro = "display:none";
                return View("Index", vm);
            }

            _tipoClienteApp.Remove(_tipoClienteApp.GetById(evm.IdExclusao));
            @ViewBag.MyInitialValue = "display:none";
            return View("Index", vm);
        }

        #endregion

    }
}
