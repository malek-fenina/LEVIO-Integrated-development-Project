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
    public class ClientService : Service<Client>
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);

        public ClientService() : base(ut)

        { }
        public List<Users> getAllUsers()
        {
           return ut.getRepository<Users>().GetAll().ToList();
        }
    }
}
