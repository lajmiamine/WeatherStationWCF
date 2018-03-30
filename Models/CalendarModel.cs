using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

using WeatherStation.AppData;

namespace WeatherStation.Models
{
    #region Models

    public class CalendarModel
    {
        [Required]
        [Display(Name = "id electrovanne")]
        public int Id_Calendar { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "DateTime Irrigation")]
        public DateTime DateDebut_Irrigation { get; set; }

        [Required]
        [DataType(DataType.Duration)]
        [Display(Name = "Periode Irrigation")]
        public int Duree_Irrigation { get; set; }

        [Required]
        [DataType(DataType.Custom)]
        [Display(Name = "Electrovanne Père")]
        public VanneModel Electrovanne { get; set; }
    }

    #endregion

    #region Services

    public interface ICalendarService
    {
        List<CalendarModel> GetCalendarByIdElect(int idElect);
        List<CalendarModel> GetCalendarByIdElectThisDay(int idElect);
        List<CalendarModel> GetCalendarByIdParcelThisDay(int idParcel);
        List<CalendarModel> GetCalendarByIdParcelOneDay(int idParcel, string startTime);

        //List<CalendarModel> GetCalendarByIdInterval(int idNoeudIrrig, DateTime deb, DateTime fin);
        //List<CalendarModel> GetCalendarByIdLastWeek(int idNoeudIrrig);
        //List<CalendarModel> GetCalendarByIdIrrig(int idNoeudIrrig);
        //List<CalendarModel> GetCalendarByIdElect1(int idElect, DateTime startDate, DateTime endDate);
        //List<CalendarModel> GetCalendarByIdElect2(int idNoeudIrrig, DateTime startDate1, DateTime endDate1);
        //List<CalendarModel> GetCalendarByIdNodeSeasonByDay(int id_Noeud, DateTime startDate);

        //List<CalendarModel> GetCalendarByIdElectOneDay(int idElect, string startTime);
        //List<CalendarModel> GetCalendarByIdElectOneMonth(int idElect, string startTime);

        //List<CalendarModel> GetCalendarByIdExplThisDay(int idElect);
        //List<CalendarModel> GetCalendarByIdExplOneDay(int idExpl, string startTime);
        //List<CalendarModel> GetCalendarByIdExplOneMonth(int idExpl, string startTime);
        //List<CalendarModel> GetCalendarByIdExplOneMonthByDay(int idExpl, string startTime);
        //List<CalendarModel> GetCalendarByIdExplSeasonByDay(int idExpl, DateTime startTime);

        //List<CalendarModel> GetCalendarByIdParcelOneDay(int idParcel, DateTime startTime);
        //List<CalendarModel> GetCalendarByIdParcelOneMonthByDay(int idParcel, string startTime);
        //List<CalendarModel> GetCalendarByIdParcelSaison(int idParcel, DateTime startTime);

        int CreateVanneCalendar(int idNoeudIrrig, int number, string start, string end, string recurrenceRule, string isAllDay);
        int UpdateVanneCalendar(int idNoeudIrrig, int prev_number, int number, string start, string end, int taskId, string recurrenceRule, string isAllDay);
        int RemoveVanneCalendar(int idNoeudIrrig, int number, string start, string end);
    }

    #endregion

    public class CalendarService : ICalendarService
    {
        AgricultureEntities agriEntities = new AgricultureEntities();

        public List<CalendarModel> GetCalendarByIdElect(int idElect)
        {
            var calendars = agriEntities.calendirer_irrigation.Where(x => x.FK_IdElectrovanne == idElect);
            List<CalendarModel> _calendars = new List<CalendarModel>();
            foreach (var cal in calendars)
            {
                _calendars.Add(new CalendarModel
                {
                    DateDebut_Irrigation = cal.Datedebut.Value,
                    Duree_Irrigation = cal.Duree.Value,
                });
            }
            return _calendars;
        }

        public List<CalendarModel> GetCalendarByIdElectThisDay(int idElect)
        {
            DateTime thisDay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            var calendars = agriEntities.calendirer_irrigation.Where(x => x.FK_IdElectrovanne == idElect
                                                                        && DateTime.Compare(x.Datedebut.Value, thisDay) >= 0);
            List<CalendarModel> _calendars = new List<CalendarModel>();
            if (calendars != null)
            {
                foreach (var cal in calendars)
                {
                    _calendars.Add(new CalendarModel
                    {
                        Id_Calendar = cal.IdCalendrier,
                        DateDebut_Irrigation = cal.Datedebut.Value,
                        Duree_Irrigation = cal.Duree.Value,
                    });
                }
            }
            return _calendars;
        }

        public List<CalendarModel> GetCalendarByIdParcelThisDay(int idParcel)
        {
            DateTime thisDay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            var calendars = agriEntities.calendirer_irrigation.Where(x => x.electrovanne.secteur.parcelle.IdParcelle == idParcel
                                                                        && DateTime.Compare(x.Datedebut.Value, thisDay) >= 0);
            List<CalendarModel> _calendars = new List<CalendarModel>();
            if (calendars.Count() != 0)
            {
                foreach (var cal in calendars)
                {
                    _calendars.Add(new CalendarModel
                    {
                        Id_Calendar = cal.IdCalendrier,
                        DateDebut_Irrigation = cal.Datedebut.Value,
                        Duree_Irrigation = cal.Duree.Value,
                        Electrovanne = new VanneService().GetElectrovanneFromCalendar(cal.FK_IdElectrovanne)
                    });
                }
            }
            return _calendars;
        }

        public List<CalendarModel> GetCalendarByIdParcelOneDay(int idParcel, string startTime)
        {
            DateTime startDate = DateTime.ParseExact(startTime.Remove(24), "ddd MMM dd yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            DateTime firstDay = new DateTime(startDate.Year, startDate.Month, startDate.Day);
            DateTime endDay = new DateTime(startDate.Year, startDate.Month, startDate.Day, 23, 59, 59);
            var calendars = agriEntities.calendirer_irrigation.Where(x => x.electrovanne.secteur.parcelle.IdParcelle == idParcel
                                                                        && DateTime.Compare(x.Datedebut.Value, firstDay) >= 0
                                                                        && DateTime.Compare(x.Datedebut.Value, endDay) <= 0);
            List<CalendarModel> _calendars = new List<CalendarModel>();
            if (calendars.Count() != 0)
            {
                foreach (var cal in calendars)
                {
                    _calendars.Add(new CalendarModel
                    {
                        Id_Calendar = cal.IdCalendrier,
                        DateDebut_Irrigation = cal.Datedebut.Value,
                        Duree_Irrigation = cal.Duree.Value,
                        Electrovanne = new VanneService().GetElectrovanneFromCalendar(cal.FK_IdElectrovanne)
                    });
                }
            }
            return _calendars;
        }

        public int CreateVanneCalendar(int idNoeudIrrig, int number, string start, string end, string recurrenceRule, string isAllDay)
        {
            var vanne = agriEntities.electrovanne.SingleOrDefault(x => x.FK_IdImlpNoeudIrrigation == idNoeudIrrig && x.Nombre == number);
            DateTime startDate = DateTime.ParseExact(start.Remove(24), "ddd MMM dd yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture); //Wed Feb 05 2014 00:00:00 GMT+0100
            DateTime endtDate = DateTime.ParseExact(end.Remove(24), "ddd MMM dd yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture); //Wed Feb 05 2014 00:00:00 GMT+0100
            double m = (endtDate - startDate).TotalMinutes;
            calendirer_irrigation cal = new calendirer_irrigation
            {
                FK_IdElectrovanne = vanne.IdElectrovanne,
                Datedebut = startDate,
                Duree = (int)(endtDate - startDate).TotalMinutes
            };
            try
            {
                agriEntities.calendirer_irrigation.AddObject(cal);
                return agriEntities.SaveChanges();
            }
            catch (ApplicationException ex)
            {
                throw new ApplicationException(
                    "An error occurred when saving changes.", ex);
            }
        }

        public int UpdateVanneCalendar(int idNoeudIrrig, int prev_number, int number, string start, string end, int taskId, string recurrenceRule, string isAllDay)
        {
            var vanne = agriEntities.electrovanne.SingleOrDefault(x => x.FK_IdImlpNoeudIrrigation == idNoeudIrrig && x.Nombre == prev_number);
            DateTime startDate = DateTime.ParseExact(start.Remove(24), "ddd MMM dd yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture); //Wed Feb 05 2014 00:00:00 GMT+0100
            DateTime endtDate = DateTime.ParseExact(end.Remove(24), "ddd MMM dd yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture); //Wed Feb 05 2014 00:00:00 GMT+0100
            int n = (int)Math.Ceiling(Math.Log10(taskId)), rest = 0;
            switch (n)
            {
                case 2:
                    rest = taskId % 10;
                    break;
                case 3:
                    rest = taskId % 100;
                    break;
                case 4:
                    rest = taskId % 1000;
                    break;
                case 5:
                    rest = taskId % 10000;
                    break;
                default:
                    break;
            }
            //FREQ=DAILY;COUNT=1;WKST=SU;BYMONTHDAY=11s

            var cals = agriEntities.calendirer_irrigation.Where(x => x.FK_IdElectrovanne == vanne.IdElectrovanne);
            calendirer_irrigation cal = null;
            int compt = 1;
            foreach (var _cal in cals)
            {
                if ((DateTime.Compare(_cal.Datedebut.Value, startDate) == 0) || (DateTime.Compare(_cal.Datedebut.Value.AddMinutes(_cal.Duree.Value), endtDate) == 0) ||
                    (compt == rest))
                {
                    cal = _cal;
                    break;
                }
                compt++;
            }
            if (cal != null)
            {
                try
                {
                    cal.Datedebut = startDate;
                    double mn = (endtDate - startDate).TotalMinutes;
                    int mn1 = (int)Math.Truncate(mn);
                    cal.Duree = mn1;
                    if (prev_number != number)
                    {
                        cal.FK_IdElectrovanne = new VanneService().GetElectroByIdIrrigNodeByNumber(idNoeudIrrig, number).IdElectrovanne;
                    }
                }
                catch (ApplicationException ex)
                {
                    throw new ApplicationException(
                        "An error occurred when saving changes.", ex);
                }
            }
            return agriEntities.SaveChanges();
        }

        public int RemoveVanneCalendar(int idNoeudIrrig, int number, string start, string end)
        {
            var vanne = agriEntities.electrovanne.SingleOrDefault(x => x.FK_IdImlpNoeudIrrigation == idNoeudIrrig && x.Nombre == number);
            DateTime startDate = DateTime.ParseExact(start.Remove(24), "ddd MMM dd yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture); //Wed Feb 05 2014 00:00:00 GMT+0100
            DateTime endtDate = DateTime.ParseExact(end.Remove(24), "ddd MMM dd yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture); //Wed Feb 05 2014 00:00:00 GMT+0100

            var cals = agriEntities.calendirer_irrigation.Where(x => x.FK_IdElectrovanne == vanne.IdElectrovanne);
            calendirer_irrigation cal = null;
            foreach (var _cal in cals)
            {
                if ((DateTime.Compare(_cal.Datedebut.Value, startDate) == 0) && (_cal.Duree.Value == Math.Truncate((endtDate - startDate).TotalMinutes)))
                {
                    cal = _cal;
                    break;
                }
            }
            if (cal != null)
            {
                try
                {
                    agriEntities.calendirer_irrigation.DeleteObject(cal);
                }
                catch (ApplicationException ex)
                {
                    throw new ApplicationException(
                        "An error occurred when saving changes.", ex);
                }
            }
            return agriEntities.SaveChanges();
        }
    }

}