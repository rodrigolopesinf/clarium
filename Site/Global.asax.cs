using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace Site
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
            if (HttpContext.Current.User == null) return;
            if (!HttpContext.Current.User.Identity.IsAuthenticated) return;
            if (!(HttpContext.Current.User.Identity is FormsIdentity)) return;
            var id = (FormsIdentity)HttpContext.Current.User.Identity;
            var ticket = id.Ticket;
            var userData = ticket.UserData;
            var roles = userData.Split(',');
            HttpContext.Current.User = new GenericPrincipal(id, roles);
        }

        public void Session_End(object sender, EventArgs e)
        {
            // Forçando o abandono de sessão.
            Session.Abandon();
            Session["UsuarioLogado"] = null;
            Session["NivelUsuarioLogado"] = null;
        }
    }
}