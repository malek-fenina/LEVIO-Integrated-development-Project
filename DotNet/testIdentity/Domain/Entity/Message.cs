using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Domain.Entity
{
    public class Message
    {
        [Key]
        public int idMessage { get; set; }

        public String Contenu { get; set; }

        public bool Received { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Date { get; set; }

        public int UsersId { get; set; }

        [ForeignKey("UsersId")]
        public Users users;

        public MessageType messageTypes { get; set; }
    }
}