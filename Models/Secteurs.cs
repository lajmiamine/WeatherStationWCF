using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models.App_Data;

namespace Models
{
    public class Secteurs
    {
        AgricultureEntities entities = new AgricultureEntities();

        public int IdSecteur { get; set; }
        public string AdresseSecteur { get; set; }
        public string NomSecteur { get; set; }
        public string DescriptionSecteur { get; set; }
        public int FK_IdParcelle { get; set; }

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
    }
}
