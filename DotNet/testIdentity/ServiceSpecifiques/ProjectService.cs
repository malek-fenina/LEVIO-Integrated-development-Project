using Data.Infrastructure;
using Domain.Entity;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSpecifiques
{
    public class ProjectService : Service<Project>
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);

        public ProjectService() : base(ut)

        {
        }

        public Users getResponsable()
        {
            List<Domain.Entity.Users> users = ut.getRepository<Users>().GetAll().ToList();
            foreach (Domain.Entity.Users u in users)
                if (u.UserRole.Equals("Responsable"))

                    return u;
            return null;
        }

        public int getNbrRessTotal()
        {
            return ut.getRepository<Project>().GetAll().Select(n => n.NbrRessourceTotal).Sum();
        }

        public int getNbrRessLevio()
        {
            return ut.getRepository<Project>().GetAll().Select(n => n.NbrRessourceLevio).Sum();
        }

    }
}