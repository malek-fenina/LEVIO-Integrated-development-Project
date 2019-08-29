using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Domain.Entity
{
    public class Note
    {
        [Key]
        public int idNote { get; set; }

        public String Contenu { get; set; }

        public Term Terms;
    }
}