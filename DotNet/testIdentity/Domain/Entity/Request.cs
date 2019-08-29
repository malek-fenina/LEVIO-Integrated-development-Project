using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Domain.Entity
{
    public class Request
    {
        [Key]
        public int idRequest { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateRequest { get; set; }

        public String Education { get; set; }

        public Project Project { get; set; }

        public Client Clients { get; set; }

        public List<Requirement> Requirements { get; set; }
    }
}