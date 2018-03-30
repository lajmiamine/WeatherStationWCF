using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

using WeatherStation.AppData;

namespace WeatherStation.Models
{
    public class NodeModel
    {
        [Required]
        [Display(Name = "Identifiant du noeud")]
        public int IdImplanter_noeud_secteur { get; set; }

        [Required]
        [Display(Name = "Adresse du noeud")]
        public int AdresseNoeud { get; set; }

        [Required]
        [Display(Name = "Latitude")]
        public string Latitude { get; set; }

        [Required]
        [Display(Name = "Longitude")]
        public string Longitude { get; set; }

        [Required]
        [Display(Name = "periode")]
        public int periode { get; set; }

        [Required]
        [Display(Name = "voltage")]
        public int voltage { get; set; }

        [Required]
        [Display(Name = "codeActivation")]
        public int codeActivation { get; set; }

        [Required]
        [Display(Name = "codeCommunication")]
        public int codeCommunication { get; set; }

        [HiddenInput]
        [Display(Name = "Secteur Conjoint")]
        public SectorModel secteur { get; set; }

        [HiddenInput]
        [Display(Name = "Parcelle Nom")]
        public string NomParcelle { get; set; }

        [HiddenInput]
        [Display(Name = "Secteur Nom")]
        public string NomSecteur { get; set; }

        [HiddenInput]
        [Display(Name = "Date Implementation")]
        public DateTime DateImplementation { get; set; }

        [Required]
        [Display(Name = "Type du Node")]
        public int NodeType { get; set; }

        [Required]
        [Display(Name = "Icône")]
        public string Icon { get; set; }

        [Required]
        [Display(Name = "Visibilité")]
        public bool Visible { get; set; }
    }

    public interface INodeService
    {
        List<NodeModel> GetNodesByIdSector(int idSector);
        List<NodeModel> GetMarkersByIdParcel(int idParcel);
        List<NodeModel> GetListeByTypeNodeIdExploit(int typeNode, int idExpl);
        NodeModel GetInfoNodeById(int idNode);
    }

    public class NodeService : INodeService
    {
        AgricultureEntities entities = new AgricultureEntities();

        public List<NodeModel> GetNodesByIdSector(int idSector)
        {
            var test = entities.implanter_noeud_exploitation.Where(x => x.FK_Id_secteur == idSector);
            List<NodeModel> nodesList = new List<NodeModel>();
            foreach (var node in test)
            {
                nodesList.Add(new NodeModel
                {
                    IdImplanter_noeud_secteur = node.IdImplanter_noeud_secteur,
                    AdresseNoeud = node.AdresseNoeud.Value,
                    codeActivation = node.CodeActivation.Value,
                    codeCommunication = node.CodeActivation.Value,
                    DateImplementation = (DateTime)node.DateImplementation,
                    Latitude = node.Latitude,
                    Longitude = node.Longitude,
                    periode = node.periode.Value,
                    voltage = node.Voltage.Value,
                    NodeType = node.Type.Value,
                });
            }
            return nodesList;
        }
        public List<NodeModel> GetListeByTypeNodeIdExploit(int typeNode, int idExpl)
        {
            var nodeClimat = entities.implanter_noeud_exploitation.Where(x => x.secteur.parcelle.exploitation.IdExploitation == idExpl && x.Type == typeNode);
            List<NodeModel> ListeNoeuds = new List<NodeModel>();
            foreach (var element in nodeClimat)
            {
                ListeNoeuds.Add(new NodeModel
                {
                    IdImplanter_noeud_secteur = element.IdImplanter_noeud_secteur,
                    AdresseNoeud = element.AdresseNoeud.Value,
                    codeActivation = element.CodeActivation.Value,
                    codeCommunication = element.CodeActivation.Value,
                    DateImplementation = (DateTime)element.DateImplementation,
                    Latitude = element.Latitude,
                    Longitude = element.Longitude,
                    periode = element.periode.Value,
                    voltage = element.Voltage.Value,
                    NomSecteur = element.secteur.NomSecteur,
                    NomParcelle = element.secteur.parcelle.NomParcelle,
                });
            }
            return ListeNoeuds;
        }
        public List<NodeModel> GetMarkersByIdParcel(int idParcel)
        {
            //int detectIrrigation = -1;
            //int compteur = 0;
            //int idNoeudIrrig = 0;
            //List<int> _type = new List<int>();
            //List<int> ids = new List<int>();
            //List<Double> lat = new List<Double>();
            //List<Double> lng = new List<Double>();
            //List<string> url = new List<string>();
            //List<string> infos = new List<string>();

            List<NodeModel> markers = new List<NodeModel>();
            var secteurList = new SectorService().GetSectorsByIdParcel(idParcel);
            if (secteurList != null)
            {
                foreach (var secteur in secteurList)
                {
                    var noeudList = entities.implanter_noeud_exploitation.Where(x => x.FK_Id_secteur == secteur.IdSecteur);
                    if (noeudList != null)
                    {
                        foreach (var noeud in noeudList)
                        {
                            if (noeud.Latitude != null && noeud.Longitude != null)
                            {
                                markers.Add(new NodeModel
                                {
                                    IdImplanter_noeud_secteur = noeud.IdImplanter_noeud_secteur,
                                    Latitude = noeud.Latitude.Trim(),
                                    Longitude = noeud.Longitude.Trim(),
                                    codeActivation = noeud.CodeActivation.Value,
                                    codeCommunication = noeud.CodeCommunication.Value,
                                    voltage = noeud.Voltage.Value,
                                    DateImplementation = noeud.DateImplementation.Value,
                                    NodeType = noeud.Type.Value,
                                    Visible = (noeud.Type.Value == 1 && noeud.secteur.parcelle.exploitation.projet.proprietaire.Climat.Value) ? true 
                                               : (noeud.Type.Value == 2 && noeud.secteur.parcelle.exploitation.projet.proprietaire.Sol.Value) ? true
                                               : (noeud.Type.Value == 3 && noeud.secteur.parcelle.exploitation.projet.proprietaire.Plante.Value) ? true
                                               : (noeud.Type.Value == 4 && noeud.secteur.parcelle.exploitation.projet.proprietaire.Irrigation.Value) ? true
                                               : false,
                                    Icon = (noeud.Type.Value == 1 && noeud.secteur.parcelle.exploitation.projet.proprietaire.Climat.Value) ? "../../Content/images/rouge.png"
                                            : (noeud.Type.Value == 2 && noeud.secteur.parcelle.exploitation.projet.proprietaire.Sol.Value) ? "../../Content/images/orange.png"
                                            : (noeud.Type.Value == 3 && noeud.secteur.parcelle.exploitation.projet.proprietaire.Plante.Value) ? "../../Content/images/vert.png"
                                            : (noeud.Type.Value == 4 && noeud.secteur.parcelle.exploitation.projet.proprietaire.Irrigation.Value) ? "../../Content/images/bleu.png"
                                            : "",
                                });

                                //lat.Add(new Operations().StrToDouble(noeud.Latitude, '.'));
                                //lng.Add(new Operations().StrToDouble(noeud.Longitude, '.'));
                                //ids.Add(noeud.IdImplanter_noeud_secteur);
                                //string info = "codeActivation: <p>" + noeud.CodeActivation.ToString().Trim() + "</p>";
                                //info += "codeCommunication: <p>" + noeud.CodeCommunication.ToString().Trim() + "</p>";
                                //info += "DateImplementation: <p>" + noeud.DateImplementation.ToString().Trim() + "</p>";
                                //info += "voltage: <p>" + noeud.Voltage.ToString().Trim() + "</p>";
                                //if (entities.implanter_noeudclimat_exploitation.Where(x => x.IdImplanter_noeud_secteur == noeud.IdImplanter_noeud_secteur).Count() != 0)
                                //{
                                //    url.Add("../../Content/images/rouge.png");
                                //    info += "type: <p>Climat</p>";
                                //    _type.Add(1);
                                //}
                                //if (entities.implanter_noeudsol_exploitation.Where(x => x.IdImplanter_noeud_secteur == noeud.IdImplanter_noeud_secteur).Count() != 0)
                                //{
                                //    url.Add("../../Content/images/vert.png");
                                //    info += "type: <p>Sol</p>";
                                //    _type.Add(2);
                                //}
                                //if (entities.implanter_noeudplante_exploitation.Where(x => x.IdImplanter_noeud_secteur == noeud.IdImplanter_noeud_secteur).Count() != 0)
                                //{
                                //    url.Add("../../Content/images/orange.png");
                                //    info += "type: <p>Plante</p>";
                                //    _type.Add(4);
                                //}
                                //if (entities.implanter_noeudirrigation_exploitation.Where(x => x.IdImplanter_noeud_secteur == noeud.IdImplanter_noeud_secteur).Count() != 0)
                                //{
                                //    url.Add("../../Content/images/bleu.png");
                                //    info += "type: <p>Irrigation</p>";
                                //    _type.Add(3);
                                //    detectIrrigation = compteur;
                                //    idNoeudIrrig = noeud.IdImplanter_noeud_secteur;
                                //}
                                //infos.Add(info);
                            }
                        }
                    }
                }
            }
            return markers;
        }

        public NodeModel GetInfoNodeById(int idNode)
        {
            var node = entities.implanter_noeud_exploitation.FirstOrDefault(x => x.IdImplanter_noeud_secteur == idNode);
            return new NodeModel
            {
                IdImplanter_noeud_secteur = node.IdImplanter_noeud_secteur,
                AdresseNoeud = node.AdresseNoeud.Value,
                codeActivation = node.CodeActivation.Value,
                codeCommunication = node.CodeActivation.Value,
                DateImplementation = (DateTime)node.DateImplementation,
                Latitude = node.Latitude,
                Longitude = node.Longitude,
                periode = node.periode.Value,
                voltage = node.Voltage.Value,
                NodeType = node.Type.Value,
                NomSecteur = node.secteur.NomSecteur

            };
        }
    }
}