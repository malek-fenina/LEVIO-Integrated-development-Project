using Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IdentityServer.Models
{
    public class Client
    {
        [Key]
        public int idClient { get; set; }

        public String Nom { get; set; }

        public String Prenom { get; set; }

        public int NbrRessource { get; set; }

        public int NbrProjetActif { get; set; }

        public String TypeClient { get; set; }

    }

}