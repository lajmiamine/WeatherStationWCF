using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models.App_Data;

namespace Models
{
    public class Noeuds
    {
        AgricultureEntities entities = new AgricultureEntities();

        public int IdImplanter_noeud_secteur { get; set; }
        public int Type { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int FK_Id_secteur { get; set; }

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
    }
}
