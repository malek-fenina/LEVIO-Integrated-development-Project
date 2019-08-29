using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentityServer.Models
{
    public class MessageModels
    {
        [Key]
        public int idMessage { get; set; }

        public String Contenu { get; set; }

        public bool Received { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public string userName { get; set; }
        public MessageModelType messagetype { get; set; }
        public int UsersId { get; set; }
        public  UsersModels users { get; set; }
        public ICollection<UsersModels> Userss { get; set; }
        public IEnumerable<SelectListItem> UserL { get; set; }
        public  IEnumerable<MessageModelType> messageTypes { get; set;}
    }
}