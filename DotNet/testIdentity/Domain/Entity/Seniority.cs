using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Domain.Entity
{
    public class Seniority
    {
        [Key]
        public int idSeniority { get; set; }
        public String Label { get; set; }

        public List<Ressource>Ressources { get; set; }
    }
}