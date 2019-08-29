using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Domain.Entity
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
     
        public List<Level> Levels { get; set; }

        public int idCompetence { get; set; }
        [ForeignKey("idCompetence")]
        public virtual Competence Productor1 { get; set; }
        public ProjectType projectTypes { get; set; }

        // foreign key       
        public int IdClient { get; set; } // ? nullable

        [ForeignKey("IdClient")]
        public virtual Users Productor { get; set; }
    }
}