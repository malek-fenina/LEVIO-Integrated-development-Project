using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Domain.Entity
{
    public class Ressource : Users
    {
        [Key]
        public int idRessource { get; set; }

        public String Nom { get; set; }

        public String Prenom { get; set; }
        public String Image { get; set; }



        public List<Competence> Competences { get; set; }

        public List<Vacance> Vacances { get; set; }

        public BusinessSector BusinessSectors { get; set; }

        public String Senioritys { get; set; }
        public String CV { get; set; }
        public String note { get; set; }


        public RessourceType ressourceTypes { get; set; }
        public RessourceState ressourceStates { get; set; }
        public Profile profil { get; set; }

    }
}