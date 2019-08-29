using Domain.Entity;
using ServiceSpecifiques;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using IdentityServer.Models;
using Rotativa.MVC;

namespace IdentityServer.Controllers
{
    public class TestController : Controller
    {
        TestService testservice = null;
        QuestionService qsservice = null;

        public TestController()
        {
            testservice = new TestService();
            qsservice = new QuestionService();

        }
        // GET: Test
        public ActionResult Index()
        {
            var test = testservice.GetAll();

            List<Test> fVM = new List<Test>();
            foreach (var item in test)
            {

                fVM.Add(
                    new Test
                    {
                        Id = item.Id,
                        TypeTest = item.TypeTest,
                        Version = item.Version,

                    });
            }
            return View(fVM);
        }

        // GET: Test
        public ActionResult Index2()
        {
            var question = qsservice.GetAll();

            List<QuestionModel> fVM = new List<QuestionModel>();
            
            foreach (var item in question)
            {
                if (String.Equals(item.Test.TypeTest,"Francais")) { 
                fVM.Add(
                    new QuestionModel
                    {
                        Id = item.Id,
                        Subject = item.Subject,
                        choice1 = item.choice1,
                        choice2 = item.choice2,
                        choice3 = item.choice3,
                        ValidChoise = item.ValidChoise,
                        TypeTest = item.Test.TypeTest
                    });
                }
            }
            return View(fVM);
        }

        // GET: Test
        public ActionResult IndexPdfFr()
        {
            var question = qsservice.GetAll();

            List<QuestionModel> fVM = new List<QuestionModel>();

            foreach (var item in question)
            {
                if (String.Equals(item.Test.TypeTest, "Francais"))
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
                            TypeTest = item.Test.TypeTest
                        });
                }
            }
            return View(fVM);
        }

        public ActionResult PrintViewToPdf()
        {
            var report = new ActionAsPdf("IndexPdfFr");
            return report;
        }

        // GET: Test
        public ActionResult Index3()
        {
            var question = qsservice.GetAll();

            List<QuestionModel> fVM = new List<QuestionModel>();
            //List<QuestionModel> fM = new List<QuestionModel>();
            foreach (var item in question)
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
                            TypeTest = item.Test.TypeTest


                        });
                }

            }
            return View(fVM);
        }

        //// GET: Test
        public ActionResult IndexPdfTh()
        {
            var question = qsservice.GetAll();

            List<QuestionModel> fVM = new List<QuestionModel>();

            foreach (var item in question)
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
                            TypeTest = item.Test.TypeTest
                        });
                }
            }
            return View(fVM);
        }

        public ActionResult PrintViewToPdf2()
        {
            var report = new ActionAsPdf("IndexPdfTh");
            return report;
        }



        //// GET: Test/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: Test/Create
        public ActionResult Create()
        {
            List<string> typetest = new List<string> { "Francais", "technical"};
            ViewData["TypeTest"] = new SelectList(typetest);
            return View();
        }

        // POST: Test/Create
        [HttpPost]
        public ActionResult Create(Test test)
        {
            Test p = new Test();

            try
            {
                // TODO: Add insert logic here
                p.TypeTest = test.TypeTest;
                p.Version = test.Version;
                testservice.Add(p);
                testservice.Commit();

                return RedirectToAction("index", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: Test/Edit/5
        public ActionResult Edit(int id)
        {
            Test ts = testservice.GetById(id);
            return View(ts);
        }

        // POST: Test/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Test test)
        {
            Test x = testservice.GetById(id);
            //x.TypeTest = test.TypeTest;
            x.Version = test.Version;

            testservice.Update(x);
            testservice.Commit();
            return RedirectToAction("Index");
        }

        // GET: Test/Delete/5
        public ActionResult Delete(int id)
        {
            Test ts = testservice.GetById(id);
            return View(ts);
        }

        // POST: Test/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Test test = new Test();
                test = testservice.GetById(id);
                testservice.Delete(test);
                testservice.Commit();
            }
            catch (DataException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }

    }
}
