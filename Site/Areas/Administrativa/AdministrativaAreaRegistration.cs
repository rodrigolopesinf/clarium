using System.Web.Mvc;

namespace Site.Areas.Administrativa
{
    public class AdministrativaAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Administrativa";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Administrativa_default",
                "Administrativa/{controller}/{action}/{id}",
                new { controller = "Conta", action = "Login", id = UrlParameter.Optional }
            );

            context.MapRoute(
                "Administrativa_menu",
                "Administrativa/{controller}/Index/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
