using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeatherStation.AppData;

namespace WeatherStation.Models
{
    #region Models

    public class EvapoTranspiration0Model
    {
        [HiddenInput(DisplayValue = false)]
        public int IdBilan { get; set; }

        [Required]
        [Display(Name = "Date Bilan")]
        public DateTime DateBilan { get; set; }

        [Required]
        [Display(Name = "ET0")]
        public double? EToi { get; set; }

        //[Display(Name = "Noeud Climat Père")]
        //public NodeClimatModel ParentNode { get; set; }

        [Required]
        [Display(Name = "Id Exploitation")]
        public int IdExploitation { get; set; }

        [Required]
        [Display(Name = "Name Exploitation")]
        public string NameExploitation { get; set; }
    }
    #endregion

    #region Services

    public interface IEToService
    {
        List<EvapoTranspiration0Model> GetET0ListByIdParcelOneWeek(int idExploitation, string startTime);
        List<EvapoTranspiration0Model> GetET0ListByIdParcelOneMonth(int idExploitation, string startTime);
    }

    public class EToService : IEToService
    {
        static AgricultureEntities agriEntities = new AgricultureEntities();
        static EvapoTranspiration0Model eto = new EvapoTranspiration0Model();

        public List<EvapoTranspiration0Model> GetET0ListByIdParcelOneWeek(int idExploitation, string startTime) //Sun Aug 17 2014 10:19:58 GMT+0100 //18/08/2014 00:00:00
        {
            DateTime startDate = DateTime.ParseExact(startTime.Remove(24), "ddd MMM dd yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            if (startDate.Day == DateTime.Now.Day)
            {
                startDate = startDate.AddDays(-7);
            }
            DateTime endDate = startDate.AddDays(7);
            var bilans1 = agriEntities.Bilan.Where(x => x.implanter_culture_parcelle.parcelle.exploitation.IdExploitation == idExploitation);
            var bilans2 = bilans1.GroupBy(x => x.DateBilan);
            var bilans3 = bilans2.Where(x => x.FirstOrDefault(y => y.DateBilan.Value >= startDate.Date) != null && x.FirstOrDefault(y => y.DateBilan <= endDate.Date) != null);
            //var bilans3 = bilans2.FirstOrDefault();
            List<EvapoTranspiration0Model> bilanList = new List<EvapoTranspiration0Model>();
            foreach (var bilan in bilans3)
            {
                bilanList.Add(new EvapoTranspiration0Model
                {
                    IdBilan = bilan.FirstOrDefault().IdBilan,
                    DateBilan = bilan.FirstOrDefault().DateBilan.Value,
                    EToi = bilan.FirstOrDefault().EToi.Value,
                    IdExploitation = bilan.FirstOrDefault().implanter_culture_parcelle.parcelle.exploitation.IdExploitation,
                    NameExploitation = bilan.FirstOrDefault().implanter_culture_parcelle.parcelle.exploitation.NomExploitation
                });
            }
            if (bilans1.Count() == 0)
            {
                bilanList.Add(new EvapoTranspiration0Model
                {
                    IdExploitation = idExploitation
                });
            }
            return bilanList;
        }

        public List<EvapoTranspiration0Model> GetET0ListByIdParcelOneMonth(int idExploitation, string startTime) //Sun Aug 17 2014 10:19:58 GMT+0100 //18/08/2014 00:00:00
        {
            DateTime startDate = DateTime.ParseExact(startTime.Remove(24), "ddd MMM dd yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            DateTime _startDate = new DateTime(startDate.Year, startDate.Month, 1);
            DateTime endDate = _startDate.AddDays(30);
            var bilans1 = agriEntities.Bilan.Where(x => x.implanter_culture_parcelle.parcelle.exploitation.IdExploitation == idExploitation);
            var bilans2 = bilans1.OrderBy(x => x.DateBilan).GroupBy(x => x.DateBilan);
            var bilans3 = bilans2.Where(x => x.FirstOrDefault(y => y.DateBilan.Value >= _startDate.Date) != null && x.FirstOrDefault(y => y.DateBilan <= endDate.Date) != null);
            List<EvapoTranspiration0Model> bilanList = new List<EvapoTranspiration0Model>();

            for (var day = 1; day <= 30; day++)
            {
                var bilan = bilans3.FirstOrDefault(x => x.FirstOrDefault(y => y.DateBilan == _startDate) != null);
                if (bilan != null)
                {
                    bilanList.Add(new EvapoTranspiration0Model
                    {
                        IdBilan = bilan.FirstOrDefault().IdBilan,
                        DateBilan = bilan.FirstOrDefault().DateBilan.Value,
                        EToi = bilan.FirstOrDefault().EToi.Value,
                        IdExploitation = bilan.FirstOrDefault().implanter_culture_parcelle.parcelle.exploitation.IdExploitation,
                        NameExploitation = bilan.FirstOrDefault().implanter_culture_parcelle.parcelle.exploitation.NomExploitation
                        //ImplCultureParcelle = new ImplCultureParcelleService().GetByIdFromBilan(bilan.FK_IdImplCultureParcelle)
                        //ParentNode = new ImplNoeudClimatService().GetNodeClimatById(nodeClimat.IdImplanter_noeud_secteur)
                    });
                }
                else
                {
                    bilanList.Add(new EvapoTranspiration0Model
                    {
                        //IdBilan = bilan.FirstOrDefault().IdBilan,
                        DateBilan = _startDate,
                        EToi = null,
                        IdExploitation = idExploitation,
                        //ParentNode = new ImplNoeudClimatService().GetNodeClimatById(nodeClimat.IdImplanter_noeud_secteur)
                    });
                }
                _startDate = _startDate.AddDays(1);
            }
            return bilanList;
        }
    }
    #endregion
}