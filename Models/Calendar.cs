using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models.App_Data;

namespace Models
{
    public class Calendar
    {
        AgricultureEntities entities = new AgricultureEntities();

        public DateTime Datedebut { get; set; }
        public int Duree { get; set; }
        public int FK_IdElectrovanne { get; set; }
        public int IdCalendrier { get; set; }

        public List<Calendar> GetCalendar(int IdElectrovanne)
        {
            List<Calendar> Calendar = new List<Calendar>();
            var calendrier = entities.calendirer_irrigation.Where(x => x.FK_IdElectrovanne == IdElectrovanne);
            foreach (var c in calendrier)
            {
                Calendar.Add(new Calendar()
                {
                    Datedebut = (DateTime)c.Datedebut,
                    Duree = (int)c.Duree,
                    FK_IdElectrovanne = c.FK_IdElectrovanne,
                    IdCalendrier = c.IdCalendrier
                });
            }
            return Calendar;
        }

        public List<Calendar> GetCalendarByStation(int IdImplanter_noeud_secteur)
        {
            List<Calendar> CalendarByStation = new List<Calendar>();
            var listOfElectrovannes = entities.electrovanne.Where(x => x.FK_IdImlpNoeudIrrigation == IdImplanter_noeud_secteur);
            foreach (var e in listOfElectrovannes)
            {
                var calendrier = entities.calendirer_irrigation.Where(x => x.FK_IdElectrovanne == e.IdElectrovanne);
                foreach (var c in calendrier)
                {
                    CalendarByStation.Add(new Calendar()
                    {
                        Datedebut = (DateTime)c.Datedebut,
                        Duree = (int)c.Duree,
                        FK_IdElectrovanne = c.FK_IdElectrovanne,
                        IdCalendrier = c.IdCalendrier
                    });
                }
            }
            return CalendarByStation;
        }
    }
}
