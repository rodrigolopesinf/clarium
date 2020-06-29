using Millenium.Application.Interfaces;
using Millenium.Domain.Response;
using Site.Areas.Administrativa.Models;
using System;
using System.Globalization;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Site.Areas.Administrativa.Controllers
{
    public class ContaController : Controller
    {
        private readonly IUsuarioAppService _usuarioApp;

        public ContaController(IUsuarioAppService usuarioApp)
        {
            _usuarioApp = usuarioApp;
        }

        #region Chamadas Views
        //
        // GET: /Conta/
        //

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        #endregion

        #region Actions

        [HttpPost]
        public ActionResult Autenticar(FormCollection f, LoginModels m)
        {
            if (!ModelState.IsValid) return View("Login");
            var response = new UsuarioResponse().RetornaMensagem(_usuarioApp.AutenticarUsuario(f["Login"], f["Senha"]));

            if(!response.Existe)
            {
                ViewBag.Mensagem = response.Mensagem;
                return View("Login");
            }

            var userId = response.Usuario.IdUsuario.ToString(CultureInfo.InvariantCulture);
            Session["UsuarioLogado"] = userId;
            Session["NivelUsuarioLogado"] = response.Usuario.Nivel.IdNivel;
            var roles = response.Usuario.Nivel.Descricao;
            CreateAuthorizeTicket(response.Usuario.Nome, roles);
            return Redirect("~/Administrativa/Home/Index");
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            Session["UsuarioLogado"] = null;
            Session["NivelUsuarioLogado"] = null;
            return RedirectToAction("Login", "Conta");
        }

        public void CreateAuthorizeTicket(string userId, string role)
        {
            var authTicket = new FormsAuthenticationTicket(1, userId, DateTime.Now, DateTime.Now.AddMinutes(30), false, role);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(authTicket));
            Response.Cookies.Add(cookie);

        }

        #endregion
    }
}

