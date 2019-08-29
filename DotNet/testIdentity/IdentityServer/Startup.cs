using Data;
using Domain.Entity;
using IdentityServer.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using System;
using System.IO;

[assembly: OwinStartupAttribute(typeof(IdentityServer.Startup))]
namespace IdentityServer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            AddUsersAndRoles();
            createRoles();
        }
        private void AddUsersAndRoles()
        {

            MAPContext context = new MAPContext();
            var roleManager = new RoleManager<CustomRole, int>(new RoleStore<CustomRole, int, CustomUserRole>(context));
            var UserManager = new UserManager<Users, int>(new UserStore<Users, CustomRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim>(context));

           
            // In Startup iam creating first Admin Role and creating a default Admin User 
            var role = new CustomRole();
            if (!roleManager.RoleExists("Client"))
            {


                role.Name = "Client";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("Ressource"))
            {


                role.Name = "Ressource";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("Applicant"))
            {

                role.Name = "Applicant";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("Responsable"))
            {

                role.Name = "Responsable";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("SuperAdmin"))
            {

                role.Name = "SuperAdmin";
                roleManager.Create(role);
            }
            if (UserManager.FindByName("SuperAdmin") == null)
            {
                var user = new Users
                {
                    UserName = "admin@yahoo.com",

                    Email = "admin@yahoo.com",
                    Password = "Administration1234$"

                };
                var Password = "Administration1234$";
                var chkUser = UserManager.Create(user, Password);
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "SuperAdmin")
                    ;
                }

            }
        }
        private void createRoles()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            if (!roleManager.RoleExists("Client"))
            {


                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Client";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("Applicant"))
            {

                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Applicant";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("Ressource"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Ressource";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("SuperAdmin"))
            {

                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "SuperAdmin";
                roleManager.Create(role);
            }
          
            }
        }
    }

