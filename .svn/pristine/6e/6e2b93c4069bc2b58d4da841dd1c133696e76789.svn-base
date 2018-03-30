using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

using WeatherStation.AppData;

namespace WeatherStation.Models
{
    public class ProjectModel
    {
        [Required]
        [Display(Name = "Nom du projet")]
        public string NomProjet { get; set; }

        [Required]
        [Display(Name = "Description du projet")]
        public string DescriptionProjet { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int IdProjet { get; set; }

        [Required]
        [Display(Name = "Date de l'ajout du projet")]
        public DateTime DateAjoutProjet { get; set; }

        [HiddenInput(DisplayValue = false)]
        [Display(Name = "Propriétaire Père")]
        public LogOnModel Proprietaire_Pere { get; set; }

        [HiddenInput(DisplayValue = false)]
        [Display(Name = "Nom du Proprietaire")]
        public string NomProprietaire { get; set; }
    }

    public interface IProjectService
    {
        List<ProjectModel> GetAll(int idUser);
        ProjectModel GetProjectByIdFromExploitation(int idProject);
    }

    public class ProjectService : IProjectService
    {
        AgricultureEntities entities = new AgricultureEntities();

        public List<ProjectModel> GetAll(int idUser)
        {
            List<ProjectModel> projetList = new List<ProjectModel>();
            var listProj = entities.projet.Where(x => x.FK_IdProprietaire == idUser);
            foreach (var element in listProj)
                projetList.Add(
                    new ProjectModel
                    {
                        IdProjet = element.IdProjet,
                        NomProjet = element.NomProjet.TrimEnd(),
                        DescriptionProjet = element.DescriptionProjet.TrimEnd(),
                        DateAjoutProjet = (DateTime)element.DateAjoutExploitation
                    });
            return projetList;
        }

        public ProjectModel GetProjectByIdFromExploitation(int idProject)
        {
            var _project = entities.projet.FirstOrDefault(x => x.IdProjet == idProject);
            ProjectModel projetList = new ProjectModel
            {
                IdProjet = _project.IdProjet,
                NomProjet = _project.NomProjet.TrimEnd(),
                DescriptionProjet = _project.DescriptionProjet.TrimEnd(),
                DateAjoutProjet = _project.DateAjoutExploitation.Value,
                NomProprietaire = _project.proprietaire.NomProprietaire,
            };
            return projetList;
        }
    }
}