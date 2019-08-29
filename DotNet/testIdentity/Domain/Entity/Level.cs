using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain.Entity
{
    public class Level
    {
        public int LevelId { get; set; }

        public int Niveau { get; set; }
        public int NbrAnnéesExperience { get; set; }

        public List<Project> Projects { get; set; }

        public List<Ressource> Ressources { get; set; }
    }
}