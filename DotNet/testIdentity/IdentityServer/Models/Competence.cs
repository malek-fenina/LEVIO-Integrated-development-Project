using Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentityServer.Models
{
    public class Competence
    {
        [Key]
        public int idCompetence { get; set; }
        [Required(ErrorMessage = "Ce champ est obligatoire")]
        [StringLength(30)]
        public String Label { get; set; }
        public int Dificulty { get; set; }

        public String RessourceName { get; set; }

        //public List<Ressource> Ressources { get; set; }

        public List<Project> Projects { get; set; }

        public Categorie Categories;
        [Display(Name ="Ressource")]
        public int idRessource { get; set; }

          public Ressource ressources { get; set; }
        // [ForeignKey("ressource")]
        // public int IdRessource { get; set; }
        //  public ICollection<Ressource> ressources { get; set; }

         public IEnumerable<SelectListItem> Ressourcess { get; set; }
    }
} 