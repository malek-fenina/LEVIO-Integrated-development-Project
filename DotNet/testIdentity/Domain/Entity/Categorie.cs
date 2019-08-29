using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Domain.Entity
{
    public class Categorie
    {

        [Key]
        public int idCategorie { get; set; }

        public String Label { get; set; }

        public List<Competence> Competences { get; set; }
    }
}