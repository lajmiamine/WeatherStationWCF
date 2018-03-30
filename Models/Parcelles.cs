using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models.App_Data;

namespace Models
{
    public class Parcelles
    {
        AgricultureEntities entities = new AgricultureEntities();

        public int IdParcelle { get; set; }
        public string AdresseParcelle { get; set; }
        public string NomParcelle { get; set; }
        public string CouleurParcelle { get; set; }
        public int FK_IdExploitation { get; set; }

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
    }
}
