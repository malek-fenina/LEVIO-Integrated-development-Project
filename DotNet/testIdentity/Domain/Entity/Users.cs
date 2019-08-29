using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Domain.Entity
{
    public class Users : IdentityUser<int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {

        public String FirstName { get; set; }
        [DataType(DataType.Password)]
        [Required]
        [MinLength(8)]
        public String Password { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public string UserRole { get; set; }
        public int NbrRessource { get; set; }

        public int NbrProjetActif { get; set; }
        public String Image { get; set; }
        public String TypeClient { get; set; }
        public String LastName { get; set; }
        public string RessourceType { get; set; }

        public List<Project> Projects { get; set; }
        public String BusinessSectors { get; set; }

        public String Senioritys { get; set; }
        public String CV { get; set; }
        public String note { get; set; }


        public String ressourceTypes { get; set; }
        public String ressourceStates { get; set; }
        public String profil { get; set; }



        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Users, int> manager)
        {

            // Note the authenticationType must match the one defined in
            // CookieAuthenticationOptions.AuthenticationType 
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here 
            return userIdentity;
        }
    }
}
public class CustomUserLogin : IdentityUserLogin<int>
{
    public int Id { get; set; }

}
public class CustomUserRole : IdentityUserRole<int>
{
    public int Id { get; set; }
}
public class CustomUserClaim : IdentityUserClaim<int>
{

}
public class CustomRole : IdentityRole<int, CustomUserRole>
{
    public CustomRole() { }
    public CustomRole(string name) { Name = name; }
}