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
    public class Project
    
    {
        [Key]
        public int idProject { get; set; }

        public String Nom { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime Date_Debut { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime Date_Fin { get; set; }

        public int NbrRessourceTotal { get; set; }

        public int NbrRessourceLevio { get; set; }

        public String Image { get; set; }
        public String CompetenceName { get; set; }

        public String LastName { get; set; }
        [Display(Name = "ClientName")]
        public int IdClient { get; set; }
        public Users Users { get; set; }

        public List<Level> Levels { get; set; }

        [Display(Name = "Competence")]
        public int idCompetence { get; set; }
        public Competence Competences { get; set; }

        public ProjectType projectTypes { get; set; }

        public IEnumerable<SelectListItem> Clientss { get; set; }
        public IEnumerable<SelectListItem> Competencess { get; set; }

    }
}