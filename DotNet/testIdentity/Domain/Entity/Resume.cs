using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Domain.Entity
{
    public class Resume
    {
        [Key]
        public int idResume { get; set; }

        public String Location { get; set; }

        public String Education { get; set; }

        public Ressource Ressources;
    }
}