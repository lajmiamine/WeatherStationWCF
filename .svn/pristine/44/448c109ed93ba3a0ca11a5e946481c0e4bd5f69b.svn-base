using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using WeatherStation.Models;

namespace WeatherStation.Controllers
{
    public class ExploitationController : Controller
    {
        public IExploitationService exploitationService { get; set; }

        protected override void Initialize(RequestContext requestContext)
        {
            if (exploitationService == null) { exploitationService = new ExploitationService(); }
            base.Initialize(requestContext);
        }

        //
        // GET: /Exploitation/

        public ActionResult ChoixExploitation()
        {
            PassModel model = TempData["Project"] as PassModel;
            List<ExploitationModel> exploitList = exploitationService.GetExploitationsByIdProject(model.idUser);
            if (model.admin)
            {
                return PartialView("AdminExploitationChoice", exploitList);
            }
            return View("ChoixExploitation", exploitList);
        }
    }
}
