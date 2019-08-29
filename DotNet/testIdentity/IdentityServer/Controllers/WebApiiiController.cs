using IdentityServer.Models;
using ServiceSpecifiques;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IdentityServer.Controllers
{
    [RoutePrefix("api")]
    public class WebApiiiController : ApiController
    {
        ApplicationService appservice = null;
        TestService ts = null;
        QuestionService qs = null;

        public WebApiiiController()
        {
            appservice = new ApplicationService();
            ts = new TestService();
            qs = new QuestionService();
        }

        [HttpGet]
        [Route("GetApplications")]
        public List<ApplicationsModel> GetApplications()
        {
            var applications = appservice.GetAll();

            List<ApplicationsModel> fVM = new List<ApplicationsModel>();
            foreach (var item in applications)
            {
                //if (item.IdUser == Int32.Parse(System.Web.HttpContext.Current.User.Identity.GetUserId()))
                    fVM.Add(
                    new ApplicationsModel
                    {
                        Id = item.Id,
                        IdUser = item.IdUser,
                        Date = item.Date,
                        Description = item.Description,
                        State = item.State,

                    });
            }
            return fVM;

        }

        [HttpGet]
        [Route("GetTests")]
        public List<TestModel> GetTests()
        {
            var tests = ts.GetAll();

            List<TestModel> fVM = new List<TestModel>();
            foreach (var item in tests)
            {
                fVM.Add(
                new TestModel
                {
                    Id = item.Id,
                    TypeTest = item.TypeTest,
                    Version = item.Version,
                });
            }
            return fVM;

        }
        [HttpGet]
        [Route("GetQuestions")]
        public List<QuestionModel> GetQuestions()
        {
            var questions = qs.GetAll();

            List<QuestionModel> fVM = new List<QuestionModel>();
            foreach (var item in questions)
            {

                fVM.Add(
                new QuestionModel
                {
                    Id = item.Id,
                    Subject = item.Subject,
                    choice1 = item.choice1,
                    choice2 = item.choice2,
                    choice3 = item.choice3,
                    ValidChoise = item.ValidChoise,
                    TestId = item.TestId,
                });
            }
            return fVM;

        }

        [HttpGet]
        [Route("GetQuestionsFr")]
        public List<QuestionModel> GetQuestionsFr()
        {
            var questions = qs.GetAll();

            List<QuestionModel> fVM = new List<QuestionModel>();
            foreach (var item in questions)
            {
                if (String.Equals(item.Test.TypeTest, "technical"))
                {
                    fVM.Add(
                new QuestionModel
                {
                    Id = item.Id,
                    Subject = item.Subject,
                    choice1 = item.choice1,
                    choice2 = item.choice2,
                    choice3 = item.choice3,
                    ValidChoise = item.ValidChoise,
                    TestId = item.TestId,
                });
                }
            }
            return fVM;
        }
        [HttpGet]
        [Route("GetQuestionsTech")]
        public List<QuestionModel> GetQuestionsTech()
        {
            var questions = qs.GetAll();

            List<QuestionModel> fVM = new List<QuestionModel>();
            foreach (var item in questions)
            {
                if (String.Equals(item.Test.TypeTest, "technical"))
                {
                    fVM.Add(
                new QuestionModel
                {
                    Id = item.Id,
                    Subject = item.Subject,
                    choice1 = item.choice1,
                    choice2 = item.choice2,
                    choice3 = item.choice3,
                    ValidChoise = item.ValidChoise,
                    TestId = item.TestId,
                });
                }
            }
            return fVM;

        }
    }
}
