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
        WaterConsumptionList GetCalendarOfAllParcelsByIdExplOneDay(int idExpl, string startTime);
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

        public WaterConsumptionList GetCalendarOfAllParcelsByIdExplOneDay(int idExpl, string startTime)
        {
            List<ParcelModel> parcels = new ParcelleService().GetParcelsByIdExploitation(idExpl);
            List<double> quantityList = new List<double>();


            foreach (var parcel in parcels)
            {
                List<CalendarModel> cals = new CalendarService().GetCalendarByIdParcelOneDay(parcel.IdParcelle, startTime);
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
                DateConsumption = DateTime.ParseExact(startTime.Remove(24), "ddd MMM dd yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture),
                QuantityConsumptionList = quantityList
            };

        }
    }
    #endregion
}