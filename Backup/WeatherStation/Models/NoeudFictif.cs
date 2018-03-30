using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using WeatherStation.AppData;

namespace WeatherStation.Models
{
    public class NoeudFictif
    {
        [Required]
        [Display(Name = "Identifiant du noeud Fictif")]
        public int Id_noeud_Fictif { get; set; }

        [Required]
        [Display(Name = "Identifiant du noeud réel")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Latitude")]
        public string Latitude { get; set; }

        [Required]
        [Display(Name = "Longitude")]
        public string Longitude { get; set; }

        [HiddenInput]
        [Display(Name = "Parcelle Nom")]
        public string NomParcelle { get; set; }

        [HiddenInput]
        [Display(Name = "Nom Propriétaire")]
        public string NomPropriétaire { get; set; }

        [HiddenInput]
        [Display(Name = "Exploitation Nom")]
        public string NomExploitation { get; set; }

        [HiddenInput]
        [Display(Name = "Secteur Nom")]
        public string NomSecteur { get; set; }

        [HiddenInput]
        [Display(Name = "Date Implementation")]
        public DateTime DateImplementation { get; set; }

        [Required]
        [Display(Name = "Periode")]
        public int periode { get; set; }

        
        [Required]
        [Display(Name = "Icône")]
        public string Icon { get; set; }

        [Required]
        [Display(Name = "Visibilité")]
        public bool Visible { get; set; }
    }


    public interface INodeFictifService
    {
        List<NoeudFictif> GetNodeFictifByTypeNodeIdExploit(int idExpl);
    }
    public class NodeFictifService : INodeFictifService
    {
        AgricultureEntities entities = new AgricultureEntities();

        public List<NoeudFictif> GetNodeFictifByTypeNodeIdExploit(int idExpl)
        {
            var nodeClimatFictif = entities.implanter_noeudclimatfictive_exploitation.Where(x => x.FK_IdExp == idExpl);
            List<NoeudFictif> ListeNoeudFictif = new List<NoeudFictif>();
            foreach (var element in nodeClimatFictif)
            {
               ListeNoeudFictif.Add(new NoeudFictif
                {
                    Id_noeud_Fictif = element.IdNodeCF,
                    Id = (int)element.FK_IdNodeC,
                    //codeActivation = element.CodeActivation.Value,
                    //codeCommunication = element.CodeActivation.Value,
                    //DateImplementation = (DateTime)element.DateImplementation,
                    Latitude = element.Latitude,
                    Longitude = element.Longitude,
                    Visible = true,
                    periode =(int) element.implanter_noeudclimat_exploitation.implanter_noeud_exploitation.periode,
                    //voltage = element.Voltage.Value,
                    NomParcelle = element.implanter_noeudclimat_exploitation.implanter_noeud_exploitation.secteur.parcelle.NomParcelle,
                    NomSecteur = element.implanter_noeudclimat_exploitation.implanter_noeud_exploitation.secteur.NomSecteur,
                    NomPropriétaire = element.implanter_noeudclimat_exploitation.implanter_noeud_exploitation.secteur.parcelle.exploitation.projet.proprietaire.NomProprietaire,
                    //element.implanter_noeudclimat_exploitation.implanter_noeud_exploitation.secteur.parcelle.exploitation.projet.proprietaire.NomProprietaire,
                    NomExploitation = element.implanter_noeudclimat_exploitation.implanter_noeud_exploitation.secteur.parcelle.exploitation.NomExploitation,
                    Icon = "../../Content/images/noeud_fictif.png",
                });
            }
            return ListeNoeudFictif;
        }

      
    }

}