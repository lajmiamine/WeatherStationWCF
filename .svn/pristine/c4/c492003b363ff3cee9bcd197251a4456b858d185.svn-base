using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using WeatherStation.Models;

namespace WeatherStation.Controllers
{
    public class ProjectController : Controller
    {
        public IProjectService projetService { get; set; }

        protected override void Initialize(RequestContext requestContext)
        {
            if (projetService == null) { projetService = new ProjectService(); }
            base.Initialize(requestContext);
        }

        public ActionResult ChoixProjet()
        {
            PassModel model = TempData["Data"] as PassModel;
            List<ProjectModel> projetList = projetService.GetAll(model.idUser);
            if (model.admin)
            {
                return PartialView("AdminProjectChoice", projetList);
            }
            return View("ChoixProjet", projetList);
        }

    }
}
