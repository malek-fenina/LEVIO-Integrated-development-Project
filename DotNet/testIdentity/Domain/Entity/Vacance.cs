using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Domain.Entity
{
    public class Vacance
    {
        public int VacanceId { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date_Debut { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date_Fin { get; set; }

        public TypeHoliday typeholiday { get; set; }

        public int idRessource { get; set; }
        [ForeignKey("idRessource")]
        public virtual Ressource rr { get; set; }

    }
}