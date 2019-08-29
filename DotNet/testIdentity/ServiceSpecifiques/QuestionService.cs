using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Infrastructure;
using Domain.Entity;
using ServicePattern;

namespace ServiceSpecifiques
{
    public class QuestionService : Service<Question>
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);

        public QuestionService():base(ut)
          
        {
        }


    }
}
