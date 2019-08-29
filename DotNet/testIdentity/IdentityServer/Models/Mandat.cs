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
    public class Mandat
    {
        [Key]
        public int idMandat { get; set; }

        public Domain.Entity.Project project { get; set; }
        [ForeignKey("project")]
        public int idProject { get; set; }

        public Ressource ressource { get; set; }
        [ForeignKey("ressource")]
        public int IdRessource { get; set; }

        [DataType(DataType.Date)]
        public DateTime date_debut { get; set; }
        [DataType(DataType.Date)]
        public DateTime date_fin { get; set; }
        //public bool archive { get; set; }
        public String NomMandat { get; set; }
        public IEnumerable<SelectListItem> Projects { get; set; }
        public IEnumerable<SelectListItem> Ressources { get; set; }

    }
}