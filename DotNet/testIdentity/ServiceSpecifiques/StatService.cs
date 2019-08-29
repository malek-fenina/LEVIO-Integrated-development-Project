using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Infrastructure;

namespace ServiceSpecifiques
{
    public class ServiceStat : ServicePattern.Service<Ressource>
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);
        public ServiceStat() : base(ut)
        {

        }
        public int nbResource()
        {
            return ut.getRepository<Users>().GetMany(x => x.UserRole.Equals("Ressource")).Count();
        }
        public int nbUsers()
        {
            return ut.getRepository<Users>().GetMany().Count();
        }
        public int nbProjects()
        {
            return ut.getRepository<Project>().GetMany().Count();
        }
        public int nbRequests()
        {
            return ut.getRepository<Request>().GetMany().Count();
        }

        public int nbclients()
        {
            return ut.getRepository<Users>().GetMany(x => x.UserRole.Equals("Client")).Count();
        }

        public List<Client> AllClients()
        {
            return ut.getRepository<Client>().GetMany().ToList();
        }
        public int newprojects()
        {
            ProjectType pt;
            Enum.TryParse("NEW", out pt);
            return ut.getRepository<Project>().GetMany(x => x.projectTypes == pt).Count();
        }
        public int Goingprojects()
        {
            ProjectType pt;
            Enum.TryParse("On_going", out pt);
            return ut.getRepository<Project>().GetMany(x => x.projectTypes == pt).Count();
        }
        public int Doneprojects()
        {
            ProjectType pt;
            Enum.TryParse("Done", out pt);
            return ut.getRepository<Project>().GetMany(x => x.projectTypes == pt).Count();
        }

        public int avResources()
        {
            return ut.getRepository<Users>().GetMany(x => x.RessourceType.Equals("Available")).Count();
        }

        //public int ressourceLevioChez()
        //{

        // return ut.getRepository<Project>().;

        //}
    }
}
