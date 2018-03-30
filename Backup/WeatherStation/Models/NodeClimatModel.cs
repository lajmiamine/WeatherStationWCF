using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WeatherStation.AppData;

namespace WeatherStation.Models
{
    public class NodeClimatModel : NodeModel
    {
        //climat//
        [Required]
        [Display(Name = "seuilVitesseVent")]
        public double seuilVitesseVent { get; set; }

        [Required]
        [Display(Name = "seuilTemperatureAir")]
        public double seuilInfTemperatureAir { get; set; }

        [Required]
        [Display(Name = "seuilTemperatureAir")]
        public double seuilSuppTemperatureAir { get; set; }

        [Required]
        [Display(Name = "seuilHumiditeAir")]
        public double seuilHumiditeAirSupp { get; set; }

        [Required]
        [Display(Name = "seuilHumiditeAir")]
        public double seuilHumiditeAirInf { get; set; }

        [Required]
        [Display(Name = "seuilPluviometrie")]
        public double seuilPluviometrie { get; set; }

        [Required]
        [Display(Name = "tempéerature")]
        public bool Temperature { get; set; }

        [Required]
        [Display(Name = "Humidité")]
        public bool Humidite { get; set; }

        [Required]
        [Display(Name = "Pluviometrie")]
        public bool Pluviometrie { get; set; }

        [Required]
        [Display(Name = "Rayonnement")]
        public bool Rayonnement { get; set; }

        [Required]
        [Display(Name = "vitesse du vent")]
        public bool Vitessevent { get; set; }

        [Required]
        [Display(Name = "sens du vent")]
        public bool sensvent { get; set; }
        //[Required]
        //[Display(Name = "Liste des Mesures Moyennes")]
        //public List<MesuresMoyClimatModel> mesuresMoyennes { get; set; }
    }

    public class NodeClimatTemperatureModel : NodeModel
    {
        [Required]
        [Display(Name = "seuilTemperatureAir")]
        public double seuilInfTemperatureAir { get; set; }

        [Required]
        [Display(Name = "seuilTemperatureAir")]
        public double seuilSuppTemperatureAir { get; set; }
    }

    public class NodeClimatHumidityModel : NodeModel
    {
        [Required]
        [Display(Name = "seuilHumiditeAir")]
        public double seuilHumiditeAirInf { get; set; }

        [Required]
        [Display(Name = "seuilHumiditeAir")]
        public double seuilHumiditeAirSupp { get; set; }
    }

    public class NodeClimatCapture : NodeModel
    {
        [Required]
        [Display(Name = "tempéerature")]
        public bool Temperature { get; set; }

        [Required]
        [Display(Name = "Humidité")]
        public bool Humidite { get; set; }

        [Required]
        [Display(Name = "Pluviometrie")]
        public bool Pluviometrie { get; set; }

        [Required]
        [Display(Name = "Rayonnement")]
        public bool Rayonnement { get; set; }

        [Required]
        [Display(Name = "vitesse du vent")]
        public bool Vitessevent { get; set; }

        [Required]
        [Display(Name = "sens du vent")]
        public bool sensvent { get; set; }
    }

    public interface INodeClimatService
    {
        NodeClimatTemperatureModel GetSeuilsTemperatureNodeClimatById(int idNode);
        NodeClimatCapture GetSensorsNodeClimatById(int idNode);
    }

    public class NodeClimatService : INodeClimatService
    {
        AgricultureEntities entities = new AgricultureEntities();

        public NodeClimatTemperatureModel GetSeuilsTemperatureNodeClimatById(int idNode)
        {
            var test = entities.implanter_noeudclimat_exploitation.FirstOrDefault(x => x.IdImplanter_noeud_secteur == idNode);
            if (test != null)
            {
                NodeClimatTemperatureModel _implNode = new NodeClimatTemperatureModel
                {
                    IdImplanter_noeud_secteur = idNode,
                    seuilSuppTemperatureAir = test.SeuilSuppTemp.Value,
                    seuilInfTemperatureAir = test.SeuilInfTemp.Value,
                };
                return _implNode;
            }
            else
            {
                return null;
            }
        }

        public NodeClimatHumidityModel GetSeuilsHumidityNodeClimatById(int idNode)
        {
            var test = entities.implanter_noeudclimat_exploitation.FirstOrDefault(x => x.IdImplanter_noeud_secteur == idNode);
            if (test != null)
            {
                return new NodeClimatHumidityModel
                {
                    IdImplanter_noeud_secteur = idNode,
                    seuilHumiditeAirSupp = test.SeuilSuppHumidite.Value,
                    seuilHumiditeAirInf = test.SeuilInfHumidite.Value,
                };
            }
            else
            {
                return null;
            }
        }

        public NodeClimatCapture GetSensorsNodeClimatById(int idNode)
        {
            var test = entities.implanter_noeudclimat_exploitation.FirstOrDefault(x => x.IdImplanter_noeud_secteur == idNode);
            if (test != null)
            {
                return new NodeClimatCapture
                {
                    Temperature = test.Temperature.Value,
                    Humidite = test.Humidite.Value,
                    Pluviometrie = test.Pluviometrie.Value,
                    Rayonnement = test.Rayonnement.Value,
                    Vitessevent = test.vitessevent.Value,
                    sensvent = test.sensvent.Value,
                };
            }
            else
            {
                return null;
            }
        }
        
    }
}