using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Domain.Entity
{
    public class Responsable:Users
    {
        [Key]
        public int idResponsable { get; set; }

        public String Nom { get; set; }

        public String Prenom { get; set; }
    }
}