using System.Web.Mvc;

namespace Site.Areas.Cadastro
{
    public class CadastroAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Cadastro";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Cadastro_default",
                "Cadastro/{controller}/{action}/{id}/{acao}",
                new { action = "Index", id = UrlParameter.Optional, acao = UrlParameter.Optional }
            );

            context.MapRoute(
                "Cadastro_menu",
                "Cadastro/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
