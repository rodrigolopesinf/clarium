using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using HtmlHelper = System.Web.Mvc.HtmlHelper;

namespace Millenium.Util
{
    public static class MenuHelper
    {

        /// <summary>
        /// As duas properties abaixo serão utilizadas para criar o menu princial e o menu com o link para as
        /// visões do sistema.
        /// </summary>
        public static List<IMenu> SiteMainMenu { get; set; }
        public static List<IMenu> SiteViewApp { get; set; }

        /// <summary>
        /// Método responsável por criar o helper. Este método irá retornar uma string com o conteúdo do menu
        /// da aplicação.
        /// Observação: Inserir nas referências do projetos as seguintes DLL's:
        /// System.Web; System.Web.Mvc
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="menuMain"></param>
        /// <param name="menuView"></param>
        /// <returns></returns>
        public static MvcHtmlString SiteMenuList(this HtmlHelper helper, List<IMenu> menuMain, List<IMenu> menuView)
        {
            try
            {
                SiteMainMenu = menuMain;
                SiteViewApp = menuView;

                if (SiteMainMenu == null || SiteMainMenu.Count == 0)
                    return MvcHtmlString.Empty;

                return MvcHtmlString.Create(DMenuItems(helper));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método responsável por criar a string do Menu dinâmico
        /// </summary>
        /// <param name="helper"></param>
        /// <returns></returns>
        private static string DMenuItems(HtmlHelper helper)
        {
            try
            {
                var tagFinal = "";

                var mainMenu = SiteMainMenu.Where(p => p.MenuPaiId.Equals(0));

                foreach (var main in mainMenu)
                {
                    var tagLiSub = "";
                    var liSubFinal = new TagBuilder("li");
                    var liView = new TagBuilder("li");
                    var liSub = new TagBuilder("li");
                    var ulSub = new TagBuilder("ul");
                    var divSub = new TagBuilder("div");
                    var liFinal = new TagBuilder("li");
                    var ulFinal = new TagBuilder("ul");
                    var dvFinal = new TagBuilder("div");

                    var subMenu = SiteMainMenu.Where(p => p.MenuPaiId.Equals(main.Id));

                    foreach (var sub in subMenu)
                    {
                        var viewApp = SiteViewApp.Where(p => p.MenuPaiId.Equals(sub.Id));

                        liSub.InnerHtml = String.Empty;
                        divSub.InnerHtml = String.Empty;
                        ulSub.InnerHtml = String.Empty;

                        foreach (var view in viewApp)
                        {
                            liView.InnerHtml = helper.ActionLink(view.Descricao, view.Route, view.Controller).ToHtmlString();
                            ulSub.InnerHtml += liView.ToString();
                        }

                        liSub.InnerHtml = helper.RouteLink(sub.Descricao, sub.Route,
                            new { controller = sub.Controller, action = sub.Action }).ToHtmlString();

                        if (ulSub.InnerHtml != "")
                            liSubFinal.InnerHtml = liSub.InnerHtml + ulSub;
                        else
                            liSubFinal.InnerHtml = liSub.InnerHtml;

                        ulFinal.InnerHtml = liSubFinal.ToString();

                        tagLiSub += ulFinal.InnerHtml;
                    }

                    ulFinal.InnerHtml = tagLiSub;

                    //dvFinal.InnerHtml = ulFinal.ToString();

                    if (main.Route != "" && main.Route != null)
                    {
                        liFinal.InnerHtml = helper.RouteLink(main.Descricao, main.Route,
                            new { controller = main.Controller, action = main.Action }).ToHtmlString();
                    }
                    else
                    {
                        liFinal.InnerHtml = "<a href='javascript:;' data-toggle='collapse' data-target='#" + main.Controller + "'>" + main.Descricao + "<i class='fa fa-fw fa-caret-down'></i></a>";
                        ulFinal.AddCssClass("collapse");
                        ulFinal.GenerateId(main.Controller);
                    }

                    if (tagLiSub != "")
                        liFinal.InnerHtml += ulFinal.ToString();
                    tagFinal += liFinal.ToString();
                }

                return tagFinal;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
