using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models.App_Data;

namespace Models
{
    public class Projet
    {
        AgricultureEntities entities = new AgricultureEntities();

        public int idProjet { get; set; }
        public string NomProjet { get; set; }
        public string DescriptionProjet { get; set; }
        public DateTime DateAjoutExploitation { get; set; }
        public int FK_IdProprietaire { get; set; }

        public List<Projet> GetProjetsList(int idProp)
        {
            List<Projet> projets = new List<Projet>();
            var projs = entities.projet.Where(x => x.FK_IdProprietaire == idProp);
            foreach (var proj in projs)
            {
                projets.Add(new Projet() { 
                    idProjet = proj.IdProjet,
                    NomProjet = proj.NomProjet,
                    DescriptionProjet = proj.DescriptionProjet,
                    DateAjoutExploitation = (DateTime) proj.DateAjoutExploitation,
                    FK_IdProprietaire = (int) proj.FK_IdProprietaire
                });
            }
            return projets;
        }
    }
}
