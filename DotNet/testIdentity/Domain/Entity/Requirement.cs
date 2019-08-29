using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Domain.Entity
{
    public class Requirement
    {
        [Key]
        public int idRequirement{ get; set; }

        public Request Requests;
    }
}