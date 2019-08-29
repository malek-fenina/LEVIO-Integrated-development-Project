using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
   public  class Mandat
    {
        [Key]
        public int idMandat { get; set; }

        public Project project { get; set; }
        [ForeignKey("project")]
        public int idProject { get; set; }

        public Ressource ressource { get; set; }
        [ForeignKey("ressource")]
        public int IdRessource { get; set; }

        [DataType(DataType.Date)]
        public DateTime date_debut { get; set; }
        [DataType(DataType.Date)]
        public DateTime date_fin { get; set; }

       // public bool archive { get; set; }
        public String NomMandat  { get; set; }


    }
}
