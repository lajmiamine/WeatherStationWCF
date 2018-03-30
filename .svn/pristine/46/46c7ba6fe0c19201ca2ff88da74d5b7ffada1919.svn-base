using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

using WeatherStation.AppData;

namespace WeatherStation.Models
{
    public class VanneModel
    {
        [HiddenInput(DisplayValue = true)]
        public int IdElectrovanne { get; set; }

        [Required]
        [Display(Name = "Latitude")]
        public string Latitude { get; set; }

        [Required]
        [Display(Name = "Longitude")]
        public string Longitude { get; set; }

        [Required]
        [Display(Name = "Numéro")]
        public int Nombre { get; set; }

        [Required]
        [Display(Name = "Debit en L")]
        public double DebitL { get; set; }

        [Required]
        [Display(Name = "Debit en mm")]
        public double DebitMM { get; set; } 

        [Required]
        [Display(Name = "Irrigation Node ID")]
        public int IdImplanter_noeud_secteur { get; set; }

        [Required]
        [Display(Name = "Season Start")]
        public DateTime DebutSaison { get; set; }

        [Required]
        [Display(Name = "Season End")]
        public DateTime FinSaison { get; set; }

        [Required]
        [DataType(DataType.Custom)]
        [Display(Name = "list of calendars")]
        public List<CalendarModel> Calendars { get; set; }
    }

    public interface IVanneService
    {
        List<VanneModel> GetElectroByIdIrrigNode(int idIrrigNode);
        List<VanneModel> GetElectroByIdIrrigNodeThisDay(int idNoeudIrrig);
        VanneModel GetElectrovanneFromCalendar(int idCal);
        VanneModel GetElectroByIdIrrigNodeByNumber(int idIrrigNode, int number);
    }

    public class VanneService : IVanneService
    {
        AgricultureEntities entities = new AgricultureEntities();

        public List<VanneModel> GetElectroByIdIrrigNode(int idIrrigNode)
        {
            var electroList = entities.electrovanne.Where(x => x.FK_IdImlpNoeudIrrigation == idIrrigNode);
            List<VanneModel> _electroList = new List<VanneModel>();
            foreach (var _electro in electroList)
            {
                _electroList.Add(new VanneModel
                {
                    IdElectrovanne = _electro.IdElectrovanne,
                    Latitude = _electro.Latitude,
                    Longitude = _electro.Longitude,
                    Nombre = _electro.Nombre,
                    DebitL = _electro.DebitL.Value,
                    DebitMM = _electro.DebitMM.Value,
                    DebutSaison = _electro.secteur.parcelle.implanter_culture_parcelle.DebutSaison.Value,
                    FinSaison = _electro.secteur.parcelle.implanter_culture_parcelle.FinSaison.Value,
                    IdImplanter_noeud_secteur = _electro.implanter_noeudirrigation_exploitation.IdImplanter_noeud_secteur,
                    Calendars = new CalendarService().GetCalendarByIdElect(_electro.IdElectrovanne)
                });
            }
            return _electroList;
        }

        public List<VanneModel> GetElectroByIdIrrigNodeThisDay(int idNoeudIrrig)
        {
            var electroList = entities.electrovanne.Where(x => x.FK_IdImlpNoeudIrrigation == idNoeudIrrig);
            List<VanneModel> _electroList = new List<VanneModel>();
            foreach (var _electro in electroList)
            {
                _electroList.Add(new VanneModel
                {
                    IdElectrovanne = _electro.IdElectrovanne,
                    //Latitude = _electro.Latitude,
                    //Longitude = _electro.Longitude,
                    //Nombre = _electro.Nombre,
                    DebitL = _electro.DebitL.Value,
                    //DebitMM = _electro.DebitMM.Value,
                    //Secteur = new SectorService().GetFromElectroById(_electro.FK_IdSecteur),
                    //IrrigationNode = new ImplNoeudIrrigationService().GetNodeIrrigation(_electro.FK_IdImlpNoeudIrrigation),
                    Calendars = new CalendarService().GetCalendarByIdElectThisDay(_electro.IdElectrovanne)
                });
            }
            return _electroList;
        }

        public VanneModel GetElectrovanneFromCalendar(int idElect)
        {
            var _elect = entities.electrovanne.FirstOrDefault(x => x.IdElectrovanne == idElect);
            return new VanneModel
            {
                IdElectrovanne = _elect.IdElectrovanne,
                DebitL = _elect.DebitL.Value,
                DebutSaison = _elect.secteur.parcelle.implanter_culture_parcelle.DebutSaison.Value,
                FinSaison = _elect.secteur.parcelle.implanter_culture_parcelle.FinSaison.Value,
            };
        }

        public VanneModel GetElectroByIdIrrigNodeByNumber(int idNoeudIrrig, int number)
        {
            var elec = entities.electrovanne.FirstOrDefault(x => x.FK_IdImlpNoeudIrrigation == idNoeudIrrig && x.Nombre == number);
            return new VanneModel
            {
                IdElectrovanne = elec.IdElectrovanne,
                Latitude = elec.Latitude,
                Longitude = elec.Longitude,
                Nombre = elec.Nombre,
                DebitL = elec.DebitL.Value,
                DebitMM = elec.DebitMM.Value,
                //Secteur = new SectorService().GetById(_elect.FK_IdSecteur),
                IdImplanter_noeud_secteur = elec.implanter_noeudirrigation_exploitation.IdImplanter_noeud_secteur,
                //Rampes = new RampeService().GetRampesByIdElectro(elec.IdElectrovanne),
            };
        }
    }
}