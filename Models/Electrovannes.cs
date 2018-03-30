using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models.App_Data;

namespace Models
{
    public class Electrovannes
    {
        AgricultureEntities entities = new AgricultureEntities();

        public int IdElectrovanne { get; set; }
        public int FK_IdSecteur { get; set; }
        public int FK_IdImlpNoeudIrrigation { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

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
    }
}
