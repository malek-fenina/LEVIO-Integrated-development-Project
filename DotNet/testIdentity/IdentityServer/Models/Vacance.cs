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
    public class Vacance
    {
        [Key]
        public int VacanceId { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date_Debut { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date_Fin { get; set; }

        public TypeHoliday typeholiday { get; set; }
        public String RessourceName { get; set; }
        //public int idRessource { get; set; }
        //[ForeignKey("idRessource")]
        //public virtual Ressource ress { get; set; }
        [Display(Name = "Ressource")]
        public int idRessource { get; set; }

        public Ressource ressources { get; set; }
        public IEnumerable<SelectListItem> Ressourcess { get; set; }

    }
}