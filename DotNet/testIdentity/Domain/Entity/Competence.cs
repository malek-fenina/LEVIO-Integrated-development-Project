using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace Domain.Entity
{
    public class Competence
    {
        [Key]
        public int idCompetence { get; set; }
        [Required(ErrorMessage = "Ce champ est obligatoire")]
        [StringLength(30)]
        public String Label { get; set; }
        public int Dificulty { get; set; }

        //public List<Ressource> Ressources { get; set; }

        public List<Project> Projects { get; set; }

        public Categorie Categories;
        //public Ressource ressource { get; set; }
        // [ForeignKey("ressource")]
        //public int IdRessource { get; set; }
        // public IEnumerable<SelectListItem>  Ressources { get; set; }

        // virtual public ICollection<Ressource> ressources { get; set; }
        //  [ForeignKey("ressource")]
        //public int idRessource { get; set; }
        public int idRessource { get; set; }
        [ForeignKey("idRessource")]
        public virtual Ressource ress { get; set; }

    }
}