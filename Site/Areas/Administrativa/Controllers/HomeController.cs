using System.Web.Mvc;
using System.Web.Security;

namespace Site.Areas.Administrativa.Controllers
{
    [Authorize(Roles = "SUPER ADMINISTRADOR, GESTOR, OPERADOR")]
    public class HomeController : Controller
    {
        #region Chamadas Views

        [HttpGet]
        public ActionResult Index()
        {
            if (!Request.IsAuthenticated)
            {
                FormsAuthentication.RedirectToLoginPage("Administrativa");
            }

            return View();
        }

        [HttpGet]
        public JsonResult GetListaData()
        {
            //var la = new VisitaBll().GetListaQtdVisitasPorMes();
            //var lv = new VisitaBll().GetListaQtdVisitasPorMesAvulso();
            //var li = new VisitaBll().GetListaQtdVisitasPorMesInstalacao();
            //var lr = new VisitaBll().GetListaQtdVisitasPorMesRetirada();
            //var result = new[]
            //{
            //    new[]
            //    {
            //        la[0].Jan, la[0].Fev, la[0].Mar, la[0].Abr, la[0].Mai, la[0].Jun, la[0].Jul, la[0].Ago, la[0].Set,
            //        la[0].Out, la[0].Nov, la[0].Dez,
            //    },
            //    new[]
            //    {
            //        lv[0].Jan, lv[0].Fev, lv[0].Mar, lv[0].Abr, lv[0].Mai, lv[0].Jun, lv[0].Jul, lv[0].Ago, lv[0].Set,
            //        lv[0].Out, lv[0].Nov, lv[0].Dez,
            //    },
            //    new[]
            //    {
            //        li[0].Jan, li[0].Fev, li[0].Mar, li[0].Abr, li[0].Mai, li[0].Jun, li[0].Jul, li[0].Ago, li[0].Set,
            //        li[0].Out, li[0].Nov, li[0].Dez,
            //    },
            //    new[]
            //    {
            //        lr[0].Jan, lr[0].Fev, lr[0].Mar, lr[0].Abr, lr[0].Mai, lr[0].Jun, lr[0].Jul, lr[0].Ago, lr[0].Set,
            //        lr[0].Out, lr[0].Nov, lr[0].Dez
            //    }
            //};

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}
