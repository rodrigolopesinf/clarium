using System.Web.Mvc;

namespace Site.Areas.Faturamento
{
    public class FaturamentoAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Faturamento";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Faturamento_default",
                "Faturamento/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
                );
            context.MapRoute(
                "Faturamento_menu",
                "Faturamento/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
