using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Domain.Entity
{
    public class Client:Users
    {
        [Key]
        public int idClient { get; set; }

        public String Nom { get; set; }

        public String Prenom { get; set; }

        public int NbrRessource { get; set; }

        public int NbrProjetActif { get; set; }

        public String TypeClient { get; set; }

        public List<Request> Requests { get; set; }
        //public List<Project> Projects { get; set; }

        public ClientType clientTypes { get; set; }

    }
}