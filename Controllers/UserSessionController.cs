using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Script.Serialization;
using System.Globalization;
using WeatherStation.Models;

namespace WeatherStation.Controllers
{
    public class UserSessionController : Controller
    {
        public IExploitationService exploitationService { get; set; }
        public IParcelleService parcelleService { get; set; }
        public ISecteurService secteurService { get; set; }
        public INodeService nodeService { get; set; }
        public INodeClimatService climatNodeService { get; set; }
        public IMesuresClimatService mesuresClimatService { get; set; }
        public IEToService et0Service { get; set; }
        public IMesuresIrrigationService mesuresIrrigationService { get; set; }
        public IVanneService electrovanneService { get; set; }
        public INotificationService notificationService { get; set; }
        public INodeFictifService noeudfictifService { get; set; }
        protected override void Initialize(RequestContext requestContext)
        {
            if (exploitationService == null) { exploitationService = new ExploitationService(); }
            if (parcelleService == null) { parcelleService = new ParcelleService(); }
            if (secteurService == null) { secteurService = new SectorService(); }
            if (nodeService == null) { nodeService = new NodeService(); }
            if (climatNodeService == null) { climatNodeService = new NodeClimatService(); }
            if (mesuresClimatService == null) { mesuresClimatService = new MesuresClimatService(); }
            if (et0Service == null) { et0Service = new EToService(); }
            if (mesuresIrrigationService == null) { mesuresIrrigationService = new MesuresIrrigationService(); }
            if (electrovanneService == null) { electrovanneService = new VanneService(); }
            if (notificationService == null) { notificationService = new NotificationService(); }
            if (noeudfictifService == null) { noeudfictifService = new NodeFictifService(); }
            base.Initialize(requestContext);
        }

        // GET: /UserSession/

        public ActionResult Index()
        {
            PassModel model = Session["Exploit"] as PassModel;
            int idExploitation = model.idUser;
            ExploitationModel _exploitationModel = exploitationService.GetExploitationById(idExploitation);
            return View("Index", _exploitationModel);
        }

        /************************** Exploitation **********************************/

        public ActionResult LandViewUser(int idExpl)
        {
            ExploitationModel _exploitationModel = exploitationService.GetExploitationById(idExpl);
            return PartialView("LandViewUser", _exploitationModel);
        }

        [HttpGet] // can be HttpPost
        public JsonResult ContourExpoitation(int idExpl)
        {
            var path = exploitationService.GetContourExploitationById(idExpl);
            return Json(path, JsonRequestBehavior.AllowGet);
        }

        public ActionResult InfoExploitation(int idExpl)
        {
            ExploitationModel _exploitationModel = exploitationService.GetInfoExploitationById(idExpl);
            return PartialView("InfoExploitation", _exploitationModel);
        }

        /*************************************** Parcelles *****************************/

        public ActionResult InfoParcelle(int idParcel)
        {
            ParcelModel parcelleinfoo = parcelleService.GetInfoParcelById(idParcel);
            return PartialView("InfoParcelle", parcelleinfoo);
        }

        [HttpGet] // can be HttpPost
        public JsonResult contourParcelle(int idParcel)
        {
            var path = parcelleService.GetContourParcelsById(idParcel);
            return Json(path, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SecteursNoeudsUser(int idParcel)
        {
            ParcelModel parcelle = parcelleService.GetParcelById(idParcel);
            return PartialView("SecteursNoeudsUser", parcelle);
        }

        /*************************** Secteur ************************************/

        public ActionResult InfoSecteur(int idSector)
        {
            SectorModel _secteurinfo = secteurService.GetInfoSectorById(idSector);
            return PartialView("InfoSecteur", _secteurinfo);
        }

        [HttpGet] // can be HttpPost
        public JsonResult contourSecteur(int idSector)
        {
            var path = secteurService.GetContourSectorById(idSector);
            return Json(path, JsonRequestBehavior.AllowGet);
        }

        //********************************Node*****************************************/

        [HttpGet] // can be HttpPost
        public JsonResult enumMarker(int idParcel)
        {
            List<NodeModel> markers = nodeService.GetMarkersByIdParcel(idParcel);
            return Json(markers, JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult InfoNods(int idNode)
        {
            NodeModel _noeudinfo = nodeService.GetInfoNodeById(idNode);
            return PartialView("InfoNods", _noeudinfo);
        }

        public ActionResult SeuilsTemperature(int idNoeudClimat)
        {
            NodeClimatTemperatureModel Valeurs_seuils = climatNodeService.GetSeuilsTemperatureNodeClimatById(idNoeudClimat);
            return Json(Valeurs_seuils, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SeuilsHumidity(int idNoeudClimat)
        {
            NodeClimatTemperatureModel Valeurs_seuils = climatNodeService.GetSeuilsTemperatureNodeClimatById(idNoeudClimat);
            return Json(Valeurs_seuils, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ListCapteurByNodeClimat(int idNoeudClimat)
        {
            NodeClimatCapture Valeurs_seuils = climatNodeService.GetSensorsNodeClimatById(idNoeudClimat);
            return Json(Valeurs_seuils, JsonRequestBehavior.AllowGet);
        }
        
        //**********************************List Node *************************************************//

        public ActionResult ListeNoeudParExploitation(int typeNode, int idExpl)
        {
            List<NodeModel> _noeudinfo = nodeService.GetListeByTypeNodeIdExploit(typeNode, idExpl);
            switch (typeNode)
            {
                case 1:
                    return PartialView("ListeDesNoeudsClimat", _noeudinfo);
                case 2:
                    return PartialView("ListeDesNoeudsSol", _noeudinfo);
                case 3:
                    return PartialView("ListeDesNoeudsPlante", _noeudinfo);
                case 4:
                    return PartialView("ListeNoeudIrrigation", _noeudinfo);
                default:
                    return PartialView("ListeDesNoeuds", _noeudinfo);
            }
        }
        //*******************Node Climat*************************************************/


        public ActionResult EvapoTranspirationByIdExploitationThisWeek(int idExploit, string startTime)
        {
            List<MesuresMoyClimatModel> et0Parcel = mesuresClimatService.GetMesuresMoyClimatByIdExploitationOneWeek(idExploit, startTime);
            return PartialView("EvapoTranspirationByParcel", et0Parcel);
        }

        public JsonResult EvapoTranspirationByParcelOneWeek(int idParcel, string startTime) //Sun Aug 17 2014 10:19:58 GMT+0100
        {
            List<MesuresMoyClimatModel> ETParcel = mesuresClimatService.GetMesuresMoyClimatByIdExploitationOneWeek(idParcel, startTime);
            return Json(ETParcel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult EvapoTranspirationByParcelOneMonth(int idParcel, string startTime) //Sun Aug 17 2014 10:19:58 GMT+0100
        {
            List<MesuresMoyClimatModel> ETParcel = mesuresClimatService.GetMesuresMoyClimatByIdExploitationOneMonth(idParcel, startTime);
            return Json(ETParcel, JsonRequestBehavior.AllowGet);
        }

        /******************* Temperature ***********************************/

        public ActionResult TemperatureClimat(int idNoeudClimat, string startTime)
        {
            List<MesuresTemperatureClimatModel> mesuresT = mesuresClimatService.GetMesuresTemperatureByIdClimatByDayByMinute(idNoeudClimat, startTime);
            return PartialView("TemperatureClimat", mesuresT);
        }

        public JsonResult TemperatureClimatByIntervalOneHour(int idNoeudClimat, string startTime)
        {
            List<MesuresTemperatureClimatModel> mesuresT = mesuresClimatService.GetMesureTemperatureByIdClimatByMinute(idNoeudClimat, startTime);
            return Json(mesuresT, JsonRequestBehavior.AllowGet);
        }

        public JsonResult TemperatureClimatByIntervalOneDay(int idNoeudClimat, string startTime)
        {
            List<MesuresTemperatureClimatModel> mesuresT = mesuresClimatService.GetMesuresTemperatureByIdClimatByDayByMinute(idNoeudClimat, startTime);
            return Json(mesuresT, JsonRequestBehavior.AllowGet);
        }

        public JsonResult TemperatureClimatByIntervalOneWeek(int idNoeudClimat, string startTime)
        {
            List<MesuresTemperatureClimatModel> mesuresT = mesuresClimatService.GetMesureTemperatureByWeekByMinute(idNoeudClimat, startTime);
            return new LargeJsonResult() { Data = mesuresT, MaxJsonLength = Int32.MaxValue };
        }

        public JsonResult TemperatureClimatByIntervalOneMonth(int idNoeudClimat, string startTime)
        {
            List<MesuresTemperatureMoyClimatModel> mesureMC = mesuresClimatService.GetMesuresMoyByIdClimatByMonthByDay(idNoeudClimat, startTime);
            return Json(mesureMC, JsonRequestBehavior.AllowGet);
        }

        public JsonResult TemperatureClimatByInterval(int idNoeudClimat, string startTime, string endTime)
        {
            List<MesuresTemperatureClimatModel> mesuresT = mesuresClimatService.GetMesuresByIdClimatByIntervalByMinute(idNoeudClimat, startTime, endTime);
            return new LargeJsonResult() { Data = mesuresT, MaxJsonLength = Int32.MaxValue };
        }

        /******************* Humidité ***********************************/

        public ActionResult HumiditeClimat(int idNoeudClimat, string startTime)
        {
            List<MesuresHumiditeClimat> mesuresH = mesuresClimatService.GetMesuresHumiditeByIdClimatByDayByMinute(idNoeudClimat, startTime);
            return PartialView("HumiditeClimat", mesuresH);
        }

        public JsonResult HumiditeClimatByIntervalOneHour(int idNoeudClimat, string startTime)
        {
            List<MesuresHumiditeClimat> mesuresT = mesuresClimatService.GetMesureHumditeByIdClimatByMinute(idNoeudClimat, startTime);
            return Json(mesuresT, JsonRequestBehavior.AllowGet);
        }

        public JsonResult HumiditeClimatByIntervalOneDay(int idNoeudClimat, string startTime)
        {
            List<MesuresHumiditeClimat> mesuresT = mesuresClimatService.GetMesuresHumiditeByIdClimatByDayByMinute(idNoeudClimat, startTime);
            return Json(mesuresT, JsonRequestBehavior.AllowGet);
        }

        public ActionResult HumiditeClimatByIntervalOneWeek(int idNoeudClimat, string startTime)
        {
            List<MesuresHumiditeClimat> mesuresT = mesuresClimatService.GetMesureHumiditeByWeekByMinute(idNoeudClimat, startTime);
            return new LargeJsonResult() { Data = mesuresT, MaxJsonLength = Int32.MaxValue };
        }

        public JsonResult HumiditeClimatByInterval(int idNoeudClimat, string startTime, string endTime)
        {
            List<MesuresHumiditeClimat> mesuresT = mesuresClimatService.GetMesuresHumditeByIdClimatByIntervalByMinute(idNoeudClimat, startTime, endTime);
            return new LargeJsonResult() { Data = mesuresT, MaxJsonLength = Int32.MaxValue };
        }

        //************************************pluviométrie *************************************//

        public ActionResult PluviometrieClimat(int idNoeudClimat, string startTime)
        {
            List<MesuresPluviometrieClimat> mesuresP = mesuresClimatService.GetMesuresPluviometrieByIdClimatByDayByMinute(idNoeudClimat, startTime);
            return PartialView("PluviometrieClimat", mesuresP);
        }
        public JsonResult PluviometrieClimatByIntervalOneDay(int idNoeudClimat, string startTime)
        {
            List<MesuresPluviometrieClimat> mesuresT = mesuresClimatService.GetMesuresPluviometrieByIdClimatByDayByMinute(idNoeudClimat, startTime);
            return Json(mesuresT, JsonRequestBehavior.AllowGet);
        }
        public JsonResult PluviometrieClimatByIntervalOneHour(int idNoeudClimat, string startTime)
        {
            List<MesuresPluviometrieClimat> mesuresT = mesuresClimatService.GetMesurePluviometrieByIdClimatByMinute(idNoeudClimat, startTime);
            return Json(mesuresT, JsonRequestBehavior.AllowGet);
        }

        public ActionResult PluviometrieClimatByIntervalOneWeek(int idNoeudClimat, string startTime)
        {
            List<MesuresPluviometrieClimat> mesuresT = mesuresClimatService.GetMesurePluviometrieByWeekByMinute(idNoeudClimat, startTime);
            return new LargeJsonResult() { Data = mesuresT, MaxJsonLength = Int32.MaxValue };
        }
        public JsonResult PluviometrieClimatByInterval(int idNoeudClimat, string startTime, string endTime)
        {
            List<MesuresPluviometrieClimat> mesuresT = mesuresClimatService.GetMesuresPluviometrieByIdClimatByIntervalByMinute(idNoeudClimat, startTime, endTime);
            return new LargeJsonResult() { Data = mesuresT, MaxJsonLength = Int32.MaxValue };
        }
        //***************************************rayonnement solaire *************************************/

        public ActionResult RayonnementSolaireClimat(int idNoeudClimat, string startTime)
        {
            List<MesuresRayonnementClimat> mesureR = mesuresClimatService.GetMesuresRayonnementByIdClimatByDayByMinute(idNoeudClimat, startTime);
            return PartialView("RayonnementSolaireClimat", mesureR);
        }

        public JsonResult RayonnementClimatByIntervalOneDay(int idNoeudClimat, string startTime)
        {
            List<MesuresRayonnementClimat> mesuresT = mesuresClimatService.GetMesuresRayonnementByIdClimatByDayByMinute(idNoeudClimat, startTime);
            return Json(mesuresT, JsonRequestBehavior.AllowGet);
        }
        public JsonResult RayonnementSolaireClimatByIntervalOneHour(int idNoeudClimat, string startTime)
        {
            List<MesuresRayonnementClimat> mesuresT = mesuresClimatService.GetMesureRayonnementByIdClimatByMinute(idNoeudClimat, startTime);
            return Json(mesuresT, JsonRequestBehavior.AllowGet);
        }
        public ActionResult RayonnementClimatByIntervalOneWeek(int idNoeudClimat, string startTime)
        {
            List<MesuresRayonnementClimat> mesuresT = mesuresClimatService.GetMesureRayonnementByWeekByMinute(idNoeudClimat, startTime);
            return new LargeJsonResult() { Data = mesuresT, MaxJsonLength = Int32.MaxValue };
        }

        public JsonResult RayonnementClimatByInterval(int idNoeudClimat, string startTime, string endTime)
        {
            List<MesuresRayonnementClimat> mesuresT = mesuresClimatService.GetMesuresRayonnementByIdClimatByIntervalByMinute(idNoeudClimat, startTime, endTime);
            return new LargeJsonResult() { Data = mesuresT, MaxJsonLength = Int32.MaxValue };
        }

        //***************************************vitesse vent **************************************//
        //vitesse vent
        public ActionResult VitesseVentClimat(int idNoeudClimat, string startTime)
        {
            List<MesuresVitesseVentClimat> mesureR = mesuresClimatService.GetMesuresVitesseVentByIdClimatByDayByMinute(idNoeudClimat, startTime);
            return PartialView("VitesseVentClimat", mesureR);
        }
        public JsonResult VitesseVentClimatByIntervalOneDay(int idNoeudClimat, string startTime)
        {
            List<MesuresVitesseVentClimat> mesuresT = mesuresClimatService.GetMesuresVitesseVentByIdClimatByDayByMinute(idNoeudClimat, startTime);
            return Json(mesuresT, JsonRequestBehavior.AllowGet);
        }
        public JsonResult VitesseVentClimatByIntervalOneHour(int idNoeudClimat, string startTime)
        {
            List<MesuresVitesseVentClimat> mesuresT = mesuresClimatService.GetMesureVitesseVentByIdClimatByMinute(idNoeudClimat, startTime);
            return Json(mesuresT, JsonRequestBehavior.AllowGet);
        }
        //***************************************sens du vent ********************************************//

        public ActionResult SensVentClimat(int idNoeudClimat, string startTime)
        {
            List<MesuresSensVentClimat> mesureR = mesuresClimatService.GetMesuresSensVentByIdClimatByDayByMinute(idNoeudClimat, startTime);
            return PartialView("SensVentClimat", mesureR);
        }

        public JsonResult SensVentClimatByIntervalOneDay(int idNoeudClimat, string startTime)
        {
            List<MesuresSensVentClimat> mesuresT = mesuresClimatService.GetMesuresSensVentByIdClimatByDayByMinute(idNoeudClimat, startTime);
            return Json(mesuresT, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SensVentClimatByIntervalOneHour(int idNoeudClimat, string startTime)
        {
            List<MesuresSensVentClimat> mesuresT = mesuresClimatService.GetMesureSensVentByIdClimatByMinute(idNoeudClimat, startTime);
            return Json(mesuresT, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SensVentClimatByIntervalOneWeek(int idNoeudClimat, string startTime)
        {
            List<MesuresSensVentClimat> mesuresT = mesuresClimatService.GetMesureSensVentByWeekByMinute(idNoeudClimat, startTime);
            return new LargeJsonResult() { Data = mesuresT, MaxJsonLength = Int32.MaxValue };
        }
        public JsonResult SensVentClimatByInterval(int idNoeudClimat, string startTime, string endTime)
        {
            List<MesuresSensVentClimat> mesuresT = mesuresClimatService.GetMesuresSensVentByIdClimatByIntervalByMinute(idNoeudClimat, startTime, endTime);
            return new LargeJsonResult() { Data = mesuresT, MaxJsonLength = Int32.MaxValue };
        }
        public ActionResult VitesseVentClimatByIntervalOneWeek(int idNoeudClimat, string startTime)
        {
            List<MesuresVitesseVentClimat> mesuresT = mesuresClimatService.GetMesureVitesseVentByWeekByMinute(idNoeudClimat, startTime);
            return new LargeJsonResult() { Data = mesuresT, MaxJsonLength = Int32.MaxValue };
        }
        public JsonResult VitesseVentClimatByInterval(int idNoeudClimat, string startTime, string endTime)
        {
            List<MesuresVitesseVentClimat> mesuresT = mesuresClimatService.GetMesuresVitesseVentByIdClimatByIntervalByMinute(idNoeudClimat, startTime, endTime);
            return new LargeJsonResult() { Data = mesuresT, MaxJsonLength = Int32.MaxValue };
        }

        /**************************************** Courbes Superposées ***********************************/

        public ActionResult MesuresClimat(int idNoeudClimat, Boolean temp, Boolean hum, Boolean pluv, Boolean ray, Boolean vitessevent, Boolean sensvent)
        {
            List<MesuresClimatChoix> mesures = mesuresClimatService.GetAllMesuresByIdClimatByDayByMinute(idNoeudClimat, temp, hum, pluv, ray, vitessevent, sensvent);
            return PartialView("MesuresClimat_courbessuper", mesures);
        }

        public ActionResult MesuresClimat2(int idNoeudClimat, Boolean temp, Boolean hum, Boolean pluv, Boolean ray, Boolean vitessevent, Boolean sensvent)
        {
            List<MesuresClimatChoix> mesures_ = mesuresClimatService.GetAllMesuresByIdClimatByDayByMinute(idNoeudClimat, temp, hum, pluv, ray, vitessevent, sensvent);
            return PartialView("MesuresClimat_courbessepare", mesures_);
        }
        public JsonResult MesureClimatByWeek(int idNoeudClimat, string startTime)
        {
            List<MesuresClimatModel> mesuresT = mesuresClimatService.GetMesureByWeekByMinute(idNoeudClimat, startTime);
            return new LargeJsonResult() { Data = mesuresT, MaxJsonLength = Int32.MaxValue };
        }
        public JsonResult AllMesureClimatByInterval(int idNoeudClimat, string startTime, string endTime)
        {
            List<MesuresClimatModel> mesuresT = mesuresClimatService.GetAllMesuresByIdClimatByIntervalByMinute(idNoeudClimat, startTime, endTime);
            return new LargeJsonResult() { Data = mesuresT, MaxJsonLength = Int32.MaxValue };
        }
        public JsonResult AllMesuresClimatByIntervalOneDay(int idNoeudClimat, string startTime)
        {
            List<MesuresClimatModel> mesuresT = mesuresClimatService.GetAllMesuresByIdClimatByDayByMinute(idNoeudClimat, startTime);
            return Json(mesuresT, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AllClimatByIntervalOneHour(int idNoeudClimat, string startTime)
        {
            List<MesuresClimatModel> mesuresT = mesuresClimatService.GetMesureByIdClimatByMinute(idNoeudClimat, startTime);
            return Json(mesuresT, JsonRequestBehavior.AllowGet);
        }
        
        //public JsonResult MesureClimatByWeek(int idNoeudClimat, string startTime)
        //{
        //    List<MesuresClimat> mesuresT = mesuresClimatService.GetMesureByWeekByMinute(idNoeudClimat, startTime);
        //    return new LargeJsonResult() { Data = mesuresT, MaxJsonLength = Int32.MaxValue };
        //}
        //public JsonResult AllMesureClimatByInterval(int idNoeudClimat, string startTime, string endTime)
        //{
        //    List<MesuresClimat> mesuresT = mesuresClimatService.GetALLMesuresByIdClimatByIntervalByMinute(idNoeudClimat, startTime, endTime);
        //    return new LargeJsonResult() { Data = mesuresT, MaxJsonLength = Int32.MaxValue };
        //}

        /*************************** Irrigation *********************************************************/

        public ActionResult IrrigCalendar(int idNoeudIrrig)
        {
            List<VanneModel> irrigElectrovannes = electrovanneService.GetElectroByIdIrrigNode(idNoeudIrrig);
            return PartialView("IrrigCalendar", irrigElectrovannes);
        }

        public JsonResult createOneEvent(int idNoeudIrrig, int number, string start, string end, string recurrenceRule, string isAllDay)
        {
            int code = new CalendarService().CreateVanneCalendar(idNoeudIrrig, number, start, end, recurrenceRule, isAllDay);
            string _message = String.Empty;
            if (code == 1)
            {
                _message = "Successful Add";
            }
            else if (code == 2)
            {
                _message = "Add Error";
            }
            else if (code == 3)
            {
                _message = "Add Timing Error";
            }
            else
            {
                _message = "an occured Add Error";
            }
            return Json(new { message = _message }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult updateOneEvent(int idNoeudIrrig, int prev_number, int number, string start, string end, int taskId, string recurrenceRule, string isAllDay)
        {
            int code = new CalendarService().UpdateVanneCalendar(idNoeudIrrig, prev_number, number, start, end, taskId, recurrenceRule, isAllDay);
            string _message = String.Empty;
            if (code == 1)
            {
                _message = "Successful Update";
            }
            else if (code == 2)
            {
                _message = "Saving Error";
            }
            else if (code == 3)
            {
                _message = "Timing Error";
            }
            else
            {
                _message = "an occured Error";
            }
            return Json(new { message = _message }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult removeOneEvent(int idNoeudIrrig, int number, string start, string end)
        {
            int code = new CalendarService().RemoveVanneCalendar(idNoeudIrrig, number, start, end);
            string _message = String.Empty;
            if (code == 1)
            {
                _message = "Successful Remove";
            }
            else if (code == 2)
            {
                _message = "Remove Error";
            }
            else if (code == 3)
            {
                _message = "Timing Error";
            }
            else
            {
                _message = "an occured Error";
            }
            return Json(new { message = _message }, JsonRequestBehavior.AllowGet);
        }

        //Consommation Eau Par Parcelle
        public ActionResult ConsommationJournalièreToutesParcelle(int idExpl)
        {
            WaterConsumptionList wc = mesuresIrrigationService.GetCalendarOfAllParcelsByIdExplThisDay(idExpl);
            return PartialView("ConsommationJournalièreToutesParcelle", wc);
        }

        public JsonResult ConsommationJournalièreToutesParcellesOneDay(int idExpl, string startTime)
        {
            WaterConsumptionList wc = mesuresIrrigationService.GetCalendarOfAllParcelsByIdExplOneDay(idExpl, startTime, false);
            return Json(wc, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ConsommationJournalièreToutesParcellesOneMonth(int idExpl, string startTime)
        {
            List<WaterConsumptionList> wc = mesuresIrrigationService.GetCalendarOfAllParcelsByIdExplOneMonth(idExpl, startTime);
            return Json(wc, JsonRequestBehavior.AllowGet);
        }

        // GET api/values
        public JsonResult Get()
        {
            List<MesuresTemperatureClimatModel> wc = mesuresClimatService.GetData();
            return Json(wc, JsonRequestBehavior.AllowGet);
        }

        //noeud fictif
        public JsonResult NoeudFictif(int idExpl)
        {
            List<NoeudFictif> markersNodeFictif = noeudfictifService.GetNodeFictifByTypeNodeIdExploit(idExpl);
            return Json(markersNodeFictif, JsonRequestBehavior.AllowGet);
        }



        //get notification 

        public JsonResult GetNotif()
        {
           var notif =  notificationService.GetData();
           return Json(notif,JsonRequestBehavior.AllowGet);
        }

        public JsonResult Notification(int idExp)
        {
            var notif = notificationService.GetNotificationByIdExp(idExp);
            return Json(notif, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SetVisibilityNotif(int idExp, List<int> notifs)
        {
            string _message = String.Empty;
            int code = notificationService.SetNotificationVisibilityById(idExp, notifs);
            if (code == 1)
            {
                _message = "Success";
            }
            else if (code == 2)
            {
                _message = "Saving Error";
            }
            else if (code == 3)
            {
                _message = "Timing Error";
            }
            else
            {
                _message = "an occured Error";
            }

            return Json(_message, JsonRequestBehavior.AllowGet);

        }
        public ActionResult AllNotifications(int idExp)
        {
            List<Notification> ListNotif = notificationService.GetNotificationByIdExp(idExp);
            return PartialView("ListNotifications", ListNotif);
        }
    }
}
