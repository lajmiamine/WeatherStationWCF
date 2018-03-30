using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Models;
using Models.App_Data;
using System.Data.Objects;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class Service1 : IService1
    {
        AgricultureEntities entities = new AgricultureEntities();

        public int GetIdProp(string login, string passwd)
        {
            return entities.proprietaire.FirstOrDefault(x => x.NomProprietaire == login && x.PasswordProprietaire == passwd).IdProprietaire;
        }

        public List<Mesures> GetMesures(string idStation)
        {
            //List<Mesures> mTemp = new List<Mesures>();
            //mTemp.AddRange(new List<Mesures>() { new Mesures
            //{
            //    IdMesureClimat = 1,
            //    DateMesure = new DateTime(2015, 07, 25),
            //    TemperatureClimat = (float)25.0
            //}, new Mesures
            //{
            //    IdMesureClimat = 2,
            //    DateMesure = new DateTime(2015, 07, 26),
            //    TemperatureClimat = (float)26.0
            //}, new Mesures
            //{
            //    IdMesureClimat = 3,
            //    DateMesure = new DateTime(2015, 07, 27),
            //    TemperatureClimat = (float)27.0
            //}, new Mesures
            //{
            //    IdMesureClimat = 4,
            //    DateMesure = new DateTime(2015, 07, 28),
            //    TemperatureClimat = (float)28.0
            //}, new Mesures
            //{
            //    IdMesureClimat = 5,
            //    DateMesure = new DateTime(2015, 07, 29),
            //    TemperatureClimat = (float)29.0
            //}});

            DateTime startDate = new DateTime(2014, 01, 05)
                        , endDate = new DateTime(2014, 01, 06);

            var mTemp1 = entities.mesure_noeudclimat.Where(x => x.mesure_noeud.FK_IdImplNoeud == 134);
            var mTemp = mTemp1.Where(x => x.mesure_noeud.DateMesureNoeud.Value >= startDate && x.mesure_noeud.DateMesureNoeud.Value <= endDate);
            List<Mesures> mTemp2 = mTemp.Select(x => new Mesures
            {
                // delete millisecond fields from DateTime attribute
                DateMesure = x.mesure_noeud.DateMesureNoeud.Value, // EntityFunctions.AddSeconds(EntityFunctions.AddMilliseconds(x.mesure_noeud.DateMesureNoeud.Value, -x.mesure_noeud.DateMesureNoeud.Value.Millisecond).Value, -x.mesure_noeud.DateMesureNoeud.Value.Second).Value,
                IdMesureClimat = x.IdMesureNoeud,
                TemperatureClimat = x.TemperatureAir.Value,
            }).ToList();

            return mTemp2;
        }


        public string GetNumber(string n)
        {
            return "hello " + n;
        }


        public List<Projet> GetProjects(string IdProp)
        {
            int id = Int32.Parse(IdProp);
            return new Projet().GetProjetsList(id);
        }

        public List<Exploitation> GetExploitations(string IdProjet)
        {
            int id = Int32.Parse(IdProjet);
            return new Exploitation().GetExploitationList(id);
        }


        public List<Parcelles> GetParcelles(string IdExploitation)
        {
            int id = Int32.Parse(IdExploitation);
            return new Parcelles().GetParcellesList(id);
        }


        public List<Secteurs> GetSecteurs(string IdParcelle)
        {
            int id = Int32.Parse(IdParcelle);
            return new Secteurs().GetSecteursList(id);
        }

        public List<Noeuds> GetNoeuds(string IdSecteur)
        {



            int id = Int32.Parse(IdSecteur);
            return new Noeuds().GetNoeudsList(id);
        }

        public List<Electrovannes> GetElectrovannes(string IdSecteur)
        {
            int id = Int32.Parse(IdSecteur);
            return new Electrovannes().GetElectrovannesList(id);
        }

        public List<Calendar> GetCalendar(string IdElectrovanne)
        {
            int id = Int32.Parse(IdElectrovanne);
            return new Calendar().GetCalendar(id);
        }

        public List<Calendar> GetCalendarByStation(string IdStation)
        {
            int id = Int32.Parse(IdStation);
            return new Calendar().GetCalendarByStation(id);
        }


        public Project ExploitationsGetter(string IdProjet)
        {
            int id = Int32.Parse(IdProjet);
            return new Project(id);
        }
    }
}
