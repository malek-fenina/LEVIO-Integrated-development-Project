using IdentityServer.Models;
using ServiceSpecifiques;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;

namespace IdentityServer.Controllers
{
    public class RestfullController : Controller
    {
        ProjectService ps = null;
        ApplicationService apps=null;
        TestService ts= null;
        QuestionService qs = null;
        MessageService SM = null;
        public RestfullController()
        {
            ps = new ProjectService();
            apps = new ApplicationService();
            ts = new TestService();
            qs = new QuestionService();
            SM = new MessageService();

        }

        [WebMethod]
        [HttpPost]
        public ActionResult CreateQuestion(Project projectVM, HttpPostedFileBase Image)
        {

            Domain.Entity.Project p = new Domain.Entity.Project
            {
                Nom = projectVM.Nom,
                Date_Debut = projectVM.Date_Debut,
                Date_Fin = projectVM.Date_Fin,
                NbrRessourceTotal = projectVM.NbrRessourceTotal,
                NbrRessourceLevio = projectVM.NbrRessourceLevio,
                Image = null,
                projectTypes = projectVM.projectTypes,
                IdClient = projectVM.IdClient,
                idCompetence = projectVM.idCompetence,
                
            };
            ps.Add(p);
            ps.Commit();
            //var path = Path.Combine(Server.MapPath("~/Content/Upload/"), Image.FileName);
            //Image.SaveAs(path);
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
        }
        [WebMethod]
        [HttpPost]
        public ActionResult EditProject(Project p1, int id, HttpPostedFileBase Image)
        {


            
                Domain.Entity.Project project = ps.GetById(id);
                project.Nom = p1.Nom;
                project.Levels = p1.Levels;
                project.NbrRessourceLevio = p1.NbrRessourceLevio;
                project.NbrRessourceTotal = p1.NbrRessourceTotal;
                project.Image =null;
                project.projectTypes = p1.projectTypes;

                ps.Update(project);
                ps.Commit();
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
            }

        [WebMethod]
        [HttpPost]
        public ActionResult DeleteProject(int id, FormCollection collection)
        {
            
               
                    Domain.Entity.Project project = ps.GetById(id);
                    ps.Delete(project);
                    ps.Commit();
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
        }


        // Tache Malek :
            //Application
            [WebMethod]
            [HttpPost]
            public ActionResult SendApp(ApplicationsModel projectVM)
            {

                Domain.Entity.Application p = new Domain.Entity.Application
                {
                    Date = projectVM.Date,
                    Description = projectVM.Description,
                    IdUser=projectVM.IdUser //hetha zedtha bla test ken fama mochkol raho hna
                };
                apps.Add(p);
                apps.Commit();
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
            }
            [WebMethod]
            [HttpDelete]
            public ActionResult DeleteApp(int id, FormCollection collection)
            {


                Domain.Entity.Application application = apps.GetById(id);
                apps.Delete(application);
                apps.Commit();
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
            }
            [WebMethod]
            [HttpPost]
            public ActionResult EditAppDate(ApplicationsModel p1, int id, HttpPostedFileBase Image)
            {
                Domain.Entity.Application application = apps.GetById(id);
                application.Date = p1.Date;

                apps.Update(application);
                apps.Commit();
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
            }
            [WebMethod]
            [HttpPost]
            public ActionResult EditAppState(ApplicationsModel p1, int id, HttpPostedFileBase Image)
            {
                Domain.Entity.Application application = apps.GetById(id);
                application.State = p1.State;

                apps.Update(application);
                apps.Commit();
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
            }
        //Test
        [WebMethod]
        [HttpPost]
        public ActionResult CreateTest(TestModel projectVM)
        {

            Domain.Entity.Test p = new Domain.Entity.Test
            {
                Id = projectVM.Id,
                TypeTest = projectVM.TypeTest,
                Version = projectVM.Version,
            };
            ts.Add(p);
            ts.Commit();
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
        }
        [WebMethod]
        [HttpDelete]
        public ActionResult DeleteTest(int id, FormCollection collection)
        {


            Domain.Entity.Test test = ts.GetById(id);
            ts.Delete(test);
            ts.Commit();
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
        }
        [WebMethod]
        [HttpPost]
        public ActionResult EditTest(TestModel p1, int id, HttpPostedFileBase Image)
        {
            Domain.Entity.Test test = ts.GetById(id);
            test.Version = p1.Version;

            ts.Update(test);
            ts.Commit();
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
        }
        //Question
        [WebMethod]
        [HttpPost]
        public ActionResult CreateQuestionn(QuestionModel projectVM)
        {

            Domain.Entity.Question p = new Domain.Entity.Question
            {
                Id = projectVM.Id,
                Subject = projectVM.Subject,
                choice1 = projectVM.choice1,
                choice2 = projectVM.choice2,
                choice3 = projectVM.choice3,
                ValidChoise = projectVM.ValidChoise,
                TestId = projectVM.TestId,
            };
            qs.Add(p);
            qs.Commit();
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
        }
        [WebMethod]
        [HttpDelete]
        public ActionResult DeleteQuestion(int id, FormCollection collection)
        {


            Domain.Entity.Question question = qs.GetById(id);
            qs.Delete(question);
            qs.Commit();
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
        }
        [WebMethod]
        [HttpPost]
        public ActionResult EditQuestion(QuestionModel p1, int id, HttpPostedFileBase Image)
        {
            Domain.Entity.Question question = qs.GetById(id);
            question.Subject = p1.Subject;
            question.choice1 = p1.choice1;
            question.choice2 = p1.choice2;
            question.choice3 = p1.choice3;
            question.ValidChoise = p1.ValidChoise;

            qs.Update(question);
            qs.Commit();
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
        }

        /*******************************Message**********************/
        [WebMethod]
        [HttpPost]
        public ActionResult CreateMessage(MessageModels msg)
        {
            MessageModelType messageS;
            Enum.TryParse("Satisfaction", out messageS);
            MessageModelType messageR;
            Enum.TryParse("Reclamation", out messageR);

            Domain.Entity.Message message = new Domain.Entity.Message();
            message.Date = msg.Date;
            message.Contenu = msg.Contenu;
            message.Received = false;
            message.UsersId = msg.UsersId;


            if (msg.messagetype == messageS)
            {
                message.messageTypes = Domain.Entity.MessageType.Satisfaction;
            }
            else if (msg.messagetype == messageR)
            { message.messageTypes = Domain.Entity.MessageType.Reclamation; }
            else
            {
                message.messageTypes = Domain.Entity.MessageType.Probleme_Technique;
            }
            MessageService ms = new MessageService();
            ms.Add(message);
            ms.Commit();
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
        }

        // user= US.Get(u=>u.Email.Equals(msg.userName));
        //user = US.Get(u => u.Email.Equals("admin@yahoo.com"));
        // user = US.GetById(1);
        //  message.users = user;
        // Console.Out.WriteLine(message.users);
        //System.Diagnostics.Debug.WriteLine(message.users);

        [WebMethod]
        [HttpPost]
        public ActionResult CreateMessageAdmin(MessageModels msg)
        {


            Domain.Entity.Message message = new Domain.Entity.Message();
            message.Date = msg.Date;
            message.Contenu = msg.Contenu;
            message.Received = false;

            message.messageTypes = Domain.Entity.MessageType.Reponse;




            // user= US.Get(u=>u.Email.Equals(msg.userName));
            //user = US.Get(u => u.Email.Equals("admin@yahoo.com"));
            // user = US.GetById(1);
            message.UsersId = msg.UsersId;
            //  message.users = user;
            // Console.Out.WriteLine(message.users);
            //System.Diagnostics.Debug.WriteLine(message.users);

            MessageService ms = new MessageService();

            ms.Add(message);
            ms.Commit();
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);


        }
        [WebMethod]
        [HttpPost]
        public ActionResult EditMessage(int id, FormCollection collection, MessageModels Msg)
        {


            MessageModelType messageS;
            Enum.TryParse("Satisfaction", out messageS);

            MessageModelType messageR;
            Enum.TryParse("Reclamation", out messageR);



            Domain.Entity.Message msg = SM.GetById(id);
            msg.Contenu = Msg.Contenu;
            msg.Date = Msg.Date;

            if (Msg.messagetype == messageS)
            {
                msg.messageTypes = Domain.Entity.MessageType.Satisfaction;
            }
            else if (Msg.messagetype == messageR)
            { msg.messageTypes = Domain.Entity.MessageType.Reclamation; }
            else
            {
                msg.messageTypes = Domain.Entity.MessageType.Probleme_Technique;
            }
            SM.Update(msg);
            SM.Commit();

            return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);

        }
        [WebMethod]
        [HttpPost]
        public ActionResult DeleteMessage(int id, FormCollection collection)
        {

            // TODO: Add delete logic here
            Domain.Entity.Message msg = SM.GetById(id);
            SM.Delete(msg);
            SM.Commit();
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);


        }


    }
}
