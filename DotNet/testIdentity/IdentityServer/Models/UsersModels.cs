using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IdentityServer.Models
{
    public class UsersModels : ApplicationUser
    {
        public String LastName { get; set; }
        public String FirstName { get; set; }
        [DataType(DataType.Password)]
        [Required]
        [MinLength(8)]
        public String Password { get; set; }

        public virtual ICollection<MessageModels> Messages { get; set; }


    }
}