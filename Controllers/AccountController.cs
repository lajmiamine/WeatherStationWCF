using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using WeatherStation.Models;
using System.Web.Routing;

namespace WeatherStation.Controllers
{
    public class AccountController : Controller
    {

        public IMembershipService membershipService { get; set; }

        protected override void Initialize(RequestContext requestContext)
        {
            if (membershipService == null) { membershipService = new AccountMembershipService(); }

            base.Initialize(requestContext);
        }

        // **************************************
        // URL: /Account/LogOn
        // **************************************

        public ActionResult LogOn()
        {
            HttpContext.Session.Clear();
            return View();
        }

        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            if (model.Utilisateur == "admin" && model.Mot_de_passe == "admin")
            {
                return RedirectToAction("choixUtilisateur");
            }
            else
            {
                LogOnModel _model = membershipService.GetByNamePasswd(model.Utilisateur, model.Mot_de_passe);
                if (_model != null)
                {
                    TempData["Data"] = new PassModel { idUser = _model.UserIdentity, admin = false };
                    return RedirectToAction("ChoixProjet", "Project");
                    //return PartialView("ChoixProjett", new PassModel { idUser = _model.UserIdentity, admin = false });
                }
                else
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                    return View(model);
                }
            }
        }

    }
}
