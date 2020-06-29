//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Web.Mvc;
//using System.Web.UI;
//using Site.Areas.Faturamento.Models;
//using Millenium.Domain;
//using Millenium.Model;

//namespace Site.Areas.Faturamento.Controllers
//{
//    [Authorize(Roles = "SUPER ADMINISTRADOR, GESTOR")]
//    public class GerarController : Controller
//    {
//        //
//        // GET: /Faturamento/Gerar/

//        public ActionResult Index()
//        {
//            var vm = new FaturamentoViewModel();
//            @ViewBag.Nome = "display:none";
//            @ViewBag.MyInitialValue = "display:none";
//            @ViewBag.Consolidar = "display:none";
//            vm.TipoFaturamento = true;
//            return View("Index", vm);
//        }

//        [HttpGet]
//        public JsonResult GetClientes(string q)
//        {
//            var bll = new ClienteBll();
//            var data = bll.GetClientes(q);
//            var jsonResult = data.Select(results => new { id = results.IdCliente, name = results.Nome });
//            return Json(jsonResult, JsonRequestBehavior.AllowGet);
//        }

//        [HttpGet]
//        public ActionResult Gerar(FaturamentoViewModel vm, string IdsClientes, string button)
//        {
//            var bll = new FaturamentoBll();
//            var listaCliente = new List<Cliente>();
//            var idCliente = IdsClientes != "" ? Convert.ToInt32(IdsClientes) : 0;

//            if (button == "Gerar")
//            {
//                vm = RetornarFaturamentoViewModel(vm, bll.ListarFaturamentos(idCliente, vm.DataInicio), listaCliente, idCliente);
//                return View("Index", vm);
//            }
//            if (button == "Consolidar")
//            {
//                var idUsuarioCriacao = Convert.ToInt32(Session["UsuarioLogado"].ToString());
//                bll.Consolidar(bll.ListarFaturamentos(idCliente, vm.DataInicio), vm.DataInicio, idUsuarioCriacao);
//            }
//            if (button == "Gerar Demonstrativo")
//            {
//                string mimeType;
//                var resultado = GerarDemonstrativoDoses(idCliente, vm.DataInicio, out mimeType);
//                return File(resultado, mimeType);
//            }
//            if (button == "Exportar")
//            {
//                Response.ClearContent();
//                Response.Buffer = true;
//                Response.AddHeader("content-disposition", "attachment; filename=" + vm.DataInicio.ToString("MM/yyyy") + ".txt");
//                Response.ContentType = "text/plain";

//                Response.Charset = "";

//                Response.Output.Write(bll.ExportarFaturamento(bll.ListarFaturamentos(idCliente, vm.DataInicio), vm.DataInicio.ToString("MM/yyyy")));
//                Response.Flush();
//                Response.End();
//            }

//            vm = RetornarFaturamentoViewModel(vm, bll.ListarFaturamentos(idCliente, vm.DataInicio), listaCliente, idCliente);

//            return View("Index", vm);
//        }

//        public FaturamentoViewModel RetornarFaturamentoViewModel(FaturamentoViewModel vm, List<Millenium.Model.Faturamento> lista, List<Cliente> listaCliente, int idCliente)
//        {
//            foreach (var faturamentoVm in lista.Select(item => new FaturamentoViewModel
//            {
//                Cliente = { IdCliente = item.Cliente.IdCliente, QuantidadeCortesia = item.Cliente.QuantidadeCortesia, PrecoDose = item.Cliente.PrecoDose },
//                NomeCliente = item.NomeCliente,
//                CodigoCliente = item.CodigoCliente,
//                ValorTotal = item.ValorTotal,
//                QuantidadeDosesSimples = item.QuantidadeDosesSimples,
//                QuantidadeDosesDuplas = item.QuantidadeDosesDuplas,
//                QuantidadeDosesTeste = item.QuantidadeDosesTeste,
//                Consolidado = item.Consolidado
//            }))
//            {
//                vm.ListaFaturamentos.Add(faturamentoVm);
//            }

//            if (idCliente != 0)
//            {
//                var cliente = new Cliente { IdCliente = idCliente, Nome = lista[0].NomeCliente };
//                listaCliente.Add(cliente);
//                @ViewBag.Nome = "display:block";
//                @ViewBag.Consolidar = "display:block";
//            }
//            else
//            {
//                @ViewBag.Nome = "display:none";
//                @ViewBag.Consolidar = vm.ListaFaturamentos.Count > 0 ? "display:block" : "display:none";
//            }

//            vm.ListaClientes = listaCliente;
//            vm.DataInicioString = "";
//            vm.TipoFaturamento = true;

//            return vm;
//        }

//        #region Demonstrativo de Doses

//        public byte[] GerarDemonstrativoDoses(int idCliente, DateTime dataInicio, out string mimeType)
//        {
//            var bll = new FaturamentoBll();
//            var lista = bll.ListarFaturamentos(idCliente, dataInicio);

//            var relatorio = new FaturamentoBll(lista);
//            relatorio.Gerar();
//            mimeType = relatorio.MimeType;
//            return relatorio.Bytes;
//        }

//        #endregion
//    }
//}
