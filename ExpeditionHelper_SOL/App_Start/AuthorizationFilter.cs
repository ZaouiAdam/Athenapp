using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace ExpeditionHelper_SOL.App_Start
{
    public class AuthorizationFilter : AuthorizeAttribute, IAuthorizationFilter
    {
        //public override void OnAuthorization(AuthorizationContext filterContext)
        //{
        //    if (filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true)
        //        || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
        //    {
        //        // Don't check for authorization as AllowAnonymous filter is applied to the action or controller  
        //        return;
        //    }

        //    // Check for authorization  
        //    if (HttpContext.Current.Session == null || HttpContext.Current.Session["Droit_Application"] == null || HttpContext.Current.Session["Droit_Application"].Equals(false))
        //    {
        //        filterContext.Result = new RedirectResult("~/fr-FR/Connexion/Connexion");
        //    }
        //    else if (HttpContext.Current.Session["Droit_Application"].ToString() == "LOGOUT")
        //    {
        //        filterContext.Result = new RedirectResult("~/fr-FR/Connexion/Connexion");
        //    }
        //    else
        //    {
        //        //Si c'est un IT alors on a accès à toutes les fonctionnalités
        //        if (HttpContext.Current.Session["Type_Connexion"].Equals("Acces_Admin"))
        //        {
        //            return;
        //        }
        //        //Si c'est un IT alors on a accès à toutes les fonctionnalités
        //        if (HttpContext.Current.Session["Type_Connexion"].Equals("Acces_Expedition"))
        //        {
        //            return;
        //        }

        //        //On récupère le nom du controlleur et de l'action
        //        String controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
        //        String action = filterContext.ActionDescriptor.ActionName;

        //        //Si c'est le profil Lecture
        //        if (HttpContext.Current.Session["Type_Connexion"].Equals("Acces_Public"))
        //        {
        //            if ((controller == "EtapeLecture") || (controller == "Version" && action != "Edit" && action != "Create" && action != "Delete"))
        //            {
        //                return;
        //            }
        //            else
        //            {
        //                filterContext.Result = new ViewResult
        //                {
        //                    ViewName = "~/Views/Shared/Access_denied.cshtml"
        //                };
        //            }
        //        }

        //    }
        //}
    }
}