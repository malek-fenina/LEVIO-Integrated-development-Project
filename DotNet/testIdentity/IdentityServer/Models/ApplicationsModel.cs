using Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IdentityServer.Models
{
    public class ApplicationsModel
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime Date { get; set; }
        public States State { get; set; }
        public String Description { get; set; }
        public Ressource Ressource { get; set; }
        public int IdUser { get; set; }
        [ForeignKey("IdUser")]
        public Users users;
    }
}