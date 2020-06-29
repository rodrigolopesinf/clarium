using System;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace Millenium.Util
{
    public static class Util
    {
        public static void ConverterParametroEmNulo(SqlCommand cmd)
        {
            foreach (SqlParameter parameter in cmd.Parameters)
            {
                if (parameter.Value == null)
                {
                    parameter.Value = DBNull.Value;
                }
            }
        }
    }

    public static class DisableHtmlControlExtension
    {
        public static MvcHtmlString DisableIf(this MvcHtmlString htmlString, Func<bool> expression)
        {
            if (!expression.Invoke()) return htmlString;
            var html = htmlString.ToString();
            const string disabled = "\"disabled\"";
            html = html.Insert(html.IndexOf(">",
                StringComparison.Ordinal), " disabled= " + disabled);
            return new MvcHtmlString(html);
        }
    }

    public static class RequiredHtmlControlExtension
    {
        public static MvcHtmlString RequiredIf(this MvcHtmlString htmlString, Func<bool> expression)
        {
            if (!expression.Invoke()) return htmlString;
            var html = htmlString.ToString();
            const string required = "\"required\"";
            html = html.Insert(html.IndexOf(">",
                StringComparison.Ordinal), " required = " + required);
            return new MvcHtmlString(html);
        }
    }
}
