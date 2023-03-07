using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.Threading;
using System.Globalization;

namespace ExpeditionHelper_SOL.Controllers
{
    public class BaseController : Controller
    {
        //
        // GET: /Base/

        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            if (RouteData.Values["lang"] != null && !string.IsNullOrWhiteSpace(RouteData.Values["lang"].ToString()))
            {
                // modification de la culture dans les données de la route
                var lang = RouteData.Values["lang"].ToString();
                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(lang);
            }
            else
            {
                // chargement de la culture depuis un cookie
                var cookie = HttpContext.Request.Cookies["ExpeditionHelper_SOL.CurrentUICulture"];
                var langHeader = string.Empty;
                if (cookie != null)
                {
                    // modification de la culture avec la valeur dans le cookie
                    langHeader = cookie.Value;
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(langHeader);
                }
                else
                {
                    // utilisation de la langue par défaut du navigateur si la culture n'est pas spécifiée
                    langHeader = HttpContext.Request.UserLanguages[0];
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(langHeader);
                }
                // modification de la culture dans les données de la route
                RouteData.Values["lang"] = langHeader;
            }

            // sauvegarde de la culture dans un cookie
            HttpCookie _cookie = new HttpCookie("ExpeditionHelper_SOL.CurrentUICulture", Thread.CurrentThread.CurrentUICulture.Name);
            _cookie.Expires = DateTime.Now.AddYears(1);
            HttpContext.Response.SetCookie(_cookie);

           return base.BeginExecuteCore(callback, state);
        }

    }
}