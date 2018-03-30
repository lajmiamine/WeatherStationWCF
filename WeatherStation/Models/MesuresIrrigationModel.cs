using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherStation.Models
{
    public class WaterConsumptionList
    {
        public int IdConsumption { get; set; }
        public DateTime DateConsumption { get; set; }
        public List<double> QuantityConsumptionList { get; set; }
    }

    #region Services
    public interface IMesuresIrrigationService
    {
        // Water Consumption
        WaterConsumptionList GetCalendarOfAllParcelsByIdExplThisDay(int idExpl);
        WaterConsumptionList GetCalendarOfAllParcelsByIdExplOneDay(int idExpl, string startTime, bool fromMonth);
        List<WaterConsumptionList> GetCalendarOfAllParcelsByIdExplOneMonth(int idExpl, string startTime);
    }

    public class MesuresIrrigationService : IMesuresIrrigationService
    {
        public WaterConsumptionList GetCalendarOfAllParcelsByIdExplThisDay(int idExpl)
        {
            List<ParcelModel> parcels = new ParcelleService().GetParcelsByIdExploitation(idExpl);
            List<double> quantityList = new List<double>();
            foreach (var parcel in parcels)
            {
                List<CalendarModel> cals = new CalendarService().GetCalendarByIdParcelThisDay(parcel.IdParcelle);
                double quantity = 0;
                foreach (var cal in cals)
                {
                    quantity += cal.Electrovanne.DebitL * cal.Duree_Irrigation / 60;
                }
                quantityList.Add(quantity);
            }
            return new WaterConsumptionList
            {
                IdConsumption = idExpl,
                DateConsumption = DateTime.Now.Date,
                QuantityConsumptionList = quantityList
            };
        }

        public WaterConsumptionList GetCalendarOfAllParcelsByIdExplOneDay(int idExpl, string startTime, bool fromMonth)
        {
            List<ParcelModel> parcels = new ParcelleService().GetParcelsByIdExploitation(idExpl);
            List<double> quantityList = new List<double>();
            
            foreach (var parcel in parcels)
            {
                List<CalendarModel> cals = new CalendarService().GetCalendarByIdParcelOneDay(parcel.IdParcelle, startTime, fromMonth);
                double quantity = 0;
                foreach (var cal in cals)
                {
                    quantity += cal.Electrovanne.DebitL * cal.Duree_Irrigation / 60;
                }
                quantityList.Add(quantity);
            }

            DateTime startDate;
            if (!fromMonth)
            {
                //Wed Oct 15 2014 00:00:00 GMT-0700 (Pacific Standard Time)
                startDate = DateTime.ParseExact(startTime.Remove(24), "ddd MMM dd yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            }
            else
            {
                startDate = DateTime.ParseExact(startTime, "M/d/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            }

            return new WaterConsumptionList
            {
                IdConsumption = idExpl,
                DateConsumption = startDate,
                QuantityConsumptionList = quantityList
            };

        }

        public List<WaterConsumptionList> GetCalendarOfAllParcelsByIdExplOneMonth(int idExpl, string startTime)
        {
            List<WaterConsumptionList> monthConsumption = new List<WaterConsumptionList>();
            DateTime startDate = DateTime.ParseExact(startTime.Remove(24), "ddd MMM dd yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            foreach (DateTime date in AllDatesInMonth(startDate.Year, startDate.Month))
            {
                WaterConsumptionList oneDayConsumption = new WaterConsumptionList();
                oneDayConsumption = GetCalendarOfAllParcelsByIdExplOneDay(idExpl, date.ToShortDateString(), true);
                monthConsumption.Add(oneDayConsumption);
            }
            return monthConsumption;
        }

        private static IEnumerable<DateTime> AllDatesInMonth(int year, int month)
        {
            int days = DateTime.DaysInMonth(year, month);
            for (int day = 1; day <= days; day++)
            {
                yield return new DateTime(year, month, day);
            }
        }
    }
    #endregion
}