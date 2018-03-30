using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

using WeatherStation.AppData;

namespace WeatherStation.Models
{
    public class ParcelModel
    {
        [HiddenInput(DisplayValue = false)]
        public int IdParcelle { get; set; }

        [Required]
        [Display(Name = "Nom de la parcelle")]
        public string NomParcelle { get; set; }

        [Required]
        [Display(Name = "Description de la parcelle")]
        public string DescriptionParcelle { get; set; }

        [Required]
        [Display(Name = "Adresse de la parcelle")]
        public string AdresseParcelle { get; set; }

        [Required]
        [Display(Name = "Couleur de la parcelle")]
        public string CouleurParcelle { get; set; }

        [Required]
        [Display(Name = "capacité au champ ")]
        public double Occ { get; set; }

        [Required]
        [Display(Name = "point de flétrissement")]
        public double Opfp { get; set; }

        [Required]
        [Display(Name = "Surface de la parcelle")]
        public double Surface { get; set; }

        [Required]
        [Display(Name = "Type du sol de la parcelle")]
        public string TypeSol { get; set; }

        [Required]
        [Display(Name = "Date de l'ajout de la parcelle")]
        public DateTime? DateAjoutParcelle { get; set; }

        [Display(Name = "Exploitation Père")]
        public ExploitationModel ExploitationPère { get; set; }

        [Display(Name = "Exploitation Père")]
        public string NomExploitationMere { get; set; }

        [HiddenInput(DisplayValue = false)]
        [Display(Name = "Exploitation Foreign Key")]
        public int FK_IdExploitation { get; set; }

        [Display(Name = "Liste des secteurs de la parcelle")]
        public List<SectorModel> SecteursParcelle { get; set; }

        [Display(Name = "Liste des secteurs de la parcelle")]
        public int NombreSecteursFilles { get; set; }
    }

    public interface IParcelleService
    {
        List<ParcelModel> GetParcelsByIdExploitation(int idExp);
        object GetContourParcelsById(int idParcel);
        ParcelModel GetParcelById(int idParcel);
        ParcelModel GetInfoParcelById(int idParcel);
    }

    public class ParcelleService : IParcelleService
    {
        AgricultureEntities entities = new AgricultureEntities();

        public List<ParcelModel> GetParcelsByIdExploitation(int idExp)
        {
            var _parcelleList = entities.parcelle.Where(w => w.FK_IdExploitation == idExp);
            List<ParcelModel> parcelleList = new List<ParcelModel>();
            foreach (var item in _parcelleList)
            {
                parcelleList.Add(
                    new ParcelModel
                    {
                        IdParcelle = item.IdParcelle,
                        NomParcelle = item.NomParcelle.TrimEnd(),
                        AdresseParcelle = item.AdresseParcelle.TrimEnd(),
                        DateAjoutParcelle = item.DateAjoutParcelle,
                        DescriptionParcelle = item.DescriptionParcelle.TrimEnd(),
                        CouleurParcelle = item.CouleurParcelle.TrimEnd(),
                        SecteursParcelle = new SectorService().GetSectorsByIdParcel(item.IdParcelle)
                    }
                );
            }
            return parcelleList;
        }

        public Object GetContourParcelsById(int idParcel)
        {
            var _parcelle = entities.parcelle.FirstOrDefault(x => x.IdParcelle == idParcel);
            string adresseParcelle = _parcelle.AdresseParcelle;
            if (adresseParcelle != null)
            {
                string[] points = adresseParcelle.Split(',');
                List<Double> extrems = new List<Double>();
                List<List<Double>> data = new List<List<Double>>();
                var i = 0;
                foreach (var point in points)
                {
                    extrems.Add(new Operations().StrToDouble(point, '.'));
                    i++;
                }
                var j = 1;
                int compteur = 0;
                Double pointEx = 0;
                Double lat = 0;
                Double lng = 0;
                foreach (var point in extrems)
                {
                    if (j == 2)
                    {
                        compteur += 1;
                        lng += point;
                        List<Double> test = new List<Double>();
                        test.Add(pointEx);
                        test.Add(point);
                        data.Add(test);
                        j = 1;
                    }
                    else
                    {
                        pointEx = point;
                        lat += point;
                        j++;
                    }
                }
                lat = lat / compteur;
                lng = lng / compteur;
                var info = "<strong>" + _parcelle.NomParcelle.Trim() + "</strong><br /><br />";
                info += "Description de la parcelle: <p>" + _parcelle.DescriptionParcelle.Trim() + "</p>";
                info += "Date de l'ajout de la parcelle: <p>" + _parcelle.DateAjoutParcelle.ToString().Trim() + "</p>";
                info += "Le nombre de secteur dans cette parcelle: <p>" + _parcelle.secteur.Count() + "</p>";
                string color;
                switch (_parcelle.CouleurParcelle.Trim())
                {
                    case "red":
                        color = "#FF0000";
                        break;

                    case "orange":
                        color = "#FF8800";
                        break;

                    case "green":
                        color = "#008000";
                        break;

                    case "blue":
                        color = "#000080";
                        break;

                    case "violet":
                        color = "#800080";
                        break;

                    case "yellow":
                        color = "#FFFF00";
                        break;

                    default:
                        color = "#FFFFFF";
                        break;
                }
                var name = _parcelle.NomParcelle.Trim();
                return new
                {
                    latlng = data,
                    lattitude = lat,
                    longitude = lng,
                    nom = name,
                    info = info,
                    couleur = color
                };
            }
            else
            {
                return new
                {
                    latlng = 0,
                    lattitude = 0,
                    longitude = 0,
                    nom = 0,
                    info = 0,
                    couleur = 0
                };
            }
        }

        public ParcelModel GetParcelById(int idParcel)
        {
            var par = entities.parcelle.FirstOrDefault(x => x.IdParcelle == idParcel);
            return new ParcelModel
            {
                IdParcelle = idParcel,
                NomParcelle = par.NomParcelle.TrimEnd(),
                AdresseParcelle = par.AdresseParcelle.TrimEnd(),
                DateAjoutParcelle = par.DateAjoutParcelle,
                DescriptionParcelle = par.DescriptionParcelle.TrimEnd(),
                Occ = par.Occ.Value,
                Opfp = par.Opfp.Value,
                Surface = par.Surface.Value,
                //ExploitationPère = new ExploitationService().GetExploitationById(par.FK_IdExploitation),
                NomExploitationMere = par.exploitation.NomExploitation,
                FK_IdExploitation = par.FK_IdExploitation,
                SecteursParcelle = new SectorService().GetSectorsByIdParcel(par.IdParcelle),
            };
        }

        public ParcelModel GetInfoParcelById(int idParcel)
        {
            var par = entities.parcelle.FirstOrDefault(x => x.IdParcelle == idParcel);
            return new ParcelModel
            {
                IdParcelle = idParcel,
                NomParcelle = par.NomParcelle.TrimEnd(),
                AdresseParcelle = par.AdresseParcelle.TrimEnd(),
                DateAjoutParcelle = par.DateAjoutParcelle,
                DescriptionParcelle = par.DescriptionParcelle.TrimEnd(),
                Occ = par.Occ.Value,
                Opfp = par.Opfp.Value,
                Surface = par.Surface.Value,
                NomExploitationMere = par.exploitation.NomExploitation,
                NombreSecteursFilles = par.secteur.Count,
            };
        }
    }
}