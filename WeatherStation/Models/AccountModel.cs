using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

using WeatherStation.AppData;

namespace WeatherStation.Models
{
    public class LogOnModel
    {
        [HiddenInput]
        [Display(Name = "User Identity")]
        public int UserIdentity { get; set; }

        [Required]
        [Display(Name = "Nom de l'utilisateur")]
        public string Utilisateur { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string Mot_de_passe { get; set; }

        [Display(Name = "souvenez-vous de moi?")]
        public bool RememberMe { get; set; }
    }

    public class PassModel
    {
        [HiddenInput]
        [Display(Name = "User Identity")]
        public int idUser { get; set; }

        [HiddenInput]
        [Display(Name = "admin or not")]
        public bool admin { get; set; }
    }

    public interface IMembershipService
    {
        LogOnModel GetByNamePasswd(string nameProp, string passwdProp);
    }

    public class AccountMembershipService : IMembershipService
    {
        static AgricultureEntities entities = new AgricultureEntities();


        public LogOnModel GetByNamePasswd(string nameProp, string passwdProp)
        {
            var _prop = entities.proprietaire.FirstOrDefault(x => x.NomProprietaire == nameProp && x.PasswordProprietaire == passwdProp);
            if (_prop != null)
            {
                return new LogOnModel
                {
                    UserIdentity = _prop.IdProprietaire,
                    Utilisateur = _prop.NomProprietaire.TrimEnd(),
                    Mot_de_passe = _prop.PasswordProprietaire.TrimEnd()
                };
            }
            else return null;
        }
    }
}