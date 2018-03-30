using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models.App_Data;

namespace Models
{
    public class Project
    {
        AgricultureEntities entities = new AgricultureEntities();

        /*Attributs*/
        public List<Exploitation> Exploitations { get; set; }
        public List<Parcelles> Parcelles { get; set; }
        public List<Secteurs> Secteurs { get; set; }
        public List<Noeuds> Noeuds { get; set; }
        public List<Electrovannes> Electrovannes { get; set; }

        /*Constructors*/
        public Project() { }
        public Project(int IdProjet)
        {
            Exploitations = GetExploitationList(IdProjet);
            Parcelles = GetAllParcellesList(IdProjet);
            Secteurs = GetAllSecteursList(IdProjet);
            Noeuds = GetAllNoeuddsList(IdProjet);
            Electrovannes = GetAllElectrovannesList(IdProjet);
        }

        /*Getting Exploitations*/
        public List<Exploitation> GetExploitationList(int IdProjet)
        {
            List<Exploitation> exploitations = new List<Exploitation>();
            var explois = entities.exploitation.Where(x => x.FK_IdProjet == IdProjet);
            foreach (var exploi in explois)
            {
                int a = 0;
                var parcelles = entities.parcelle.Where(x => x.FK_IdExploitation == exploi.IdExploitation);
                foreach (var parcelle in parcelles)
                {
                    var secteurs = entities.secteur.Where(x => x.FK_IdParcelle == parcelle.IdParcelle);
                    foreach (var secteur in secteurs)
                    {
                        var noeuds = entities.implanter_noeud_exploitation.Where(x => x.FK_Id_secteur == secteur.IdSecteur);
                        foreach (var noeud in noeuds)
                        {
                            a++;
                        }
                    }
                }
                exploitations.Add(new Exploitation()
                {
                    IdExploitation = exploi.IdExploitation,
                    NomExploitation = exploi.NomExploitation.Trim(),
                    DescriptionExploitation = exploi.DescriptionExploitation.Trim(),
                    DateAjoutExploitation = (DateTime) exploi.DateAjoutExploitation,
                    AdresseExploitation = exploi.AdresseExploitation.Trim(),
                    FK_IdProjet = (int) exploi.FK_IdProjet,
                    NombreNoeuds = a
                });
            }
            return exploitations;
        }
        /*Getting Parcelles*/
        public List<Parcelles> GetParcellesList(int IdExploitation)
        {
            List<Parcelles> listParcelles = new List<Parcelles>();
            var parcelles = entities.parcelle.Where(x => x.FK_IdExploitation == IdExploitation);
            foreach (var par in parcelles)
            {
                listParcelles.Add(new Parcelles()
                {
                    IdParcelle = par.IdParcelle,
                    AdresseParcelle = par.AdresseParcelle.Trim(),
                    NomParcelle = par.NomParcelle.Trim(),
                    CouleurParcelle = par.CouleurParcelle,
                    FK_IdExploitation = par.FK_IdExploitation
                });
            }
            return listParcelles;
        }
        public List<Parcelles> GetAllParcellesList(int IdProjet)
        {
            List<Parcelles> FulllistParcelles = new List<Parcelles>();
            foreach (Exploitation e in GetExploitationList(IdProjet))
            {
                List<Parcelles> list = GetParcellesList(e.IdExploitation);
                foreach (Parcelles p in list)
                {
                    FulllistParcelles.Add(p);
                }
            }
            return FulllistParcelles;
        }
        /*Getting Secteurs*/
        public List<Secteurs> GetSecteursList(int IdParcelle)
        {
            List<Secteurs> listSecteurs = new List<Secteurs>();
            var secteurs = entities.secteur.Where(x => x.FK_IdParcelle == IdParcelle);
            foreach (var sec in secteurs)
            {
                listSecteurs.Add(new Secteurs()
                {
                    IdSecteur = sec.IdSecteur,
                    AdresseSecteur = sec.AdresseSecteur,
                    NomSecteur = sec.NomSecteur.Trim(),
                    DescriptionSecteur = sec.DescriptionSecteur.Trim(),
                    FK_IdParcelle = sec.FK_IdParcelle
                });
            }
            return listSecteurs;
        }
        public List<Secteurs> GetAllSecteursList(int IdProjet)
        {
            List<Secteurs> FulllistSecteurs = new List<Secteurs>();
            foreach (Parcelles e in GetAllParcellesList(IdProjet))
            {
                List<Secteurs> list = GetSecteursList(e.IdParcelle);
                foreach (Secteurs p in list)
                {
                    FulllistSecteurs.Add(p);
                }
            }
            return FulllistSecteurs;
        }
        /*Getting Noeuds*/
        public List<Noeuds> GetNoeudsList(int IdSecteur)
        {
            List<Noeuds> listNoeuds = new List<Noeuds>();
            var noeuds = entities.implanter_noeud_exploitation.Where(x => x.FK_Id_secteur == IdSecteur);
            foreach (var n in noeuds)
            {
                listNoeuds.Add(new Noeuds()
                {
                    IdImplanter_noeud_secteur = n.IdImplanter_noeud_secteur,
                    Type = (int) n.Type,
                    Latitude = n.Latitude.Trim(),
                    Longitude = n.Longitude.Trim(),
                    FK_Id_secteur = n.FK_Id_secteur
                });
            }
            return listNoeuds;
        }
        public List<Noeuds> GetAllNoeuddsList(int IdProjet)
        {
            List<Noeuds> FulllistNoeuds = new List<Noeuds>();
            foreach (Secteurs e in GetAllSecteursList(IdProjet))
            {
                List<Noeuds> list = GetNoeudsList(e.IdSecteur);
                foreach (Noeuds p in list)
                {
                    FulllistNoeuds.Add(p);
                }
            }
            return FulllistNoeuds;
        }
        /*Getting Electrovannes*/
        public List<Electrovannes> GetElectrovannesList(int IdSecteur)
        {
            List<Electrovannes> listElectrovannes = new List<Electrovannes>();
            var electrovannes = entities.electrovanne.Where(x => x.FK_IdSecteur == IdSecteur);
            foreach (var e in electrovannes)
            {
                listElectrovannes.Add(new Electrovannes()
                {
                    IdElectrovanne = e.IdElectrovanne,
                    FK_IdSecteur = (int)e.FK_IdSecteur,
                    FK_IdImlpNoeudIrrigation = e.FK_IdImlpNoeudIrrigation,
                    Latitude = e.Latitude.Trim(),
                    Longitude = e.Longitude.Trim()
                });
            }
            return listElectrovannes;
        }
        public List<Electrovannes> GetAllElectrovannesList(int IdProjet)
        {
            List<Electrovannes> FulllistNoeuds = new List<Electrovannes>();
            foreach (Secteurs e in GetAllSecteursList(IdProjet))
            {
                List<Electrovannes> list = GetElectrovannesList(e.IdSecteur);
                foreach (Electrovannes p in list)
                {
                    FulllistNoeuds.Add(p);
                }
            }
            return FulllistNoeuds;
        }
    }
}
