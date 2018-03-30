using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

using WeatherStation.AppData;

namespace WeatherStation.Models
{
    public class SectorModel
    {
        [HiddenInput(DisplayValue = false)]
        public int IdSecteur { get; set; }

        [Required]
        [Display(Name = "Nom de la secteur")]
        public string NomSecteur { get; set; }

        [Required]
        [Display(Name = "Description de la secteur")]
        public string DescriptionSecteur { get; set; }

        [Required]
        [Display(Name = "Adresse de la secteur")]
        public string AdresseSecteur { get; set; }

        [Required]
        [Display(Name = "Date de l'ajout de la secteur")]
        public DateTime? DateAjoutSecteur { get; set; }

        [Required]
        [Display(Name = "Parcelle Parent")]
        public ParcelModel Parcelle { get; set; }

        [Required]
        [Display(Name = "Parcelle Id")]
        public int IdParcelle { get; set; }

        [Required]
        [Display(Name = "Parcelle nom")]
        public string NomParcelle { get; set; }

        [Required]
        [Display(Name = "Exploitation nom")]
        public string NomExploitation { get; set; }

        [Required]
        [Display(Name = "Children Nodes")]
        public List<NodeModel> ChildrenNodes { get; set; }
    }

    public interface ISecteurService
    {
        List<SectorModel> GetSectorsByIdParcel(int idParcel);
        SectorModel GetInfoSectorById(int idSector);
        object GetContourSectorById(int idSector);
    }

    public class SectorService : ISecteurService
    {
        AgricultureEntities entities = new AgricultureEntities();

        public List<SectorModel> GetSectorsByIdParcel(int idParcelle)
        {
            var listsect = entities.secteur.Where(x => x.FK_IdParcelle == idParcelle);
            List<SectorModel> secteurList = new List<SectorModel>();
            foreach (var element in listsect)
            {
                List<NodeModel> inm = new NodeService().GetNodesByIdSector(element.IdSecteur);
                secteurList.Add(new SectorModel
                {
                    IdSecteur = element.IdSecteur,
                    NomSecteur = element.NomSecteur.TrimEnd(),
                    DescriptionSecteur = element.DescriptionSecteur.TrimEnd(),
                    DateAjoutSecteur = element.DateAjoutSecteur,
                    AdresseSecteur = element.AdresseSecteur.TrimEnd(),
                    ChildrenNodes = inm,
                });
            }
            return secteurList;
        }

        public SectorModel GetInfoSectorById(int idSector)
        {
            var _sec = entities.secteur.FirstOrDefault(x => x.IdSecteur == idSector);
            return new SectorModel
            {
                AdresseSecteur = _sec.AdresseSecteur.TrimEnd(),
                DateAjoutSecteur = _sec.DateAjoutSecteur,
                DescriptionSecteur = _sec.DescriptionSecteur.TrimEnd(),
                IdSecteur = _sec.IdSecteur,
                NomSecteur = _sec.NomSecteur.TrimEnd(),
                NomParcelle = _sec.parcelle.NomParcelle.TrimEnd(),
                NomExploitation = _sec.parcelle.exploitation.NomExploitation.Trim()
            };
        }

        public object GetContourSectorById(int idSector)
        {
            var sec = entities.secteur.FirstOrDefault(x => x.IdSecteur == idSector);
            if (sec.AdresseSecteur == null)
            {
                return null;
            }
            else
            {
                string[] points = entities.secteur.FirstOrDefault(x => x.IdSecteur == idSector).AdresseSecteur.Split(',');
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
                var info = "<strong>" + sec.NomSecteur.Trim() + "</strong><br /><br />";
                info += "Description de la parcelle: <p>" + sec.DescriptionSecteur.Trim() + "</p>";
                info += "Date de l'ajout de la parcelle: <p>" + sec.DateAjoutSecteur.ToString().Trim() + "</p>";
                string color;
                switch (sec.parcelle.CouleurParcelle.Trim())
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
                var name = sec.NomSecteur.Trim();

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
        }
    }
}