using Domain.Entity;
using IdentityServer.Models;
using ServiceSpecifiques;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentityServer.Controllers
{
    public class QuestionController : Controller
    {
        QuestionService questionservice = null;
        TestService testS = new TestService();

        public QuestionController()
        {
            questionservice = new QuestionService();

        }
        // GET: Question
        public ActionResult Index()
        {
            var question = questionservice.GetAll();

            List<QuestionModel> fVM = new List<QuestionModel>();
            foreach (var item in question)
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
                        TypeTest=item.Test.TypeTest


                    });
            }
            
            return View(fVM);
        }

        [HttpPost]
        public ActionResult Index(string search)
        {
            var skill = questionservice.GetAll();
            List<QuestionModel> fVM = new List<QuestionModel>();

            foreach (var item in skill)
            {
                fVM.Add(new QuestionModel
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
            if (!String.IsNullOrEmpty(search))
            {


                fVM = fVM.Where(c => c.Subject == search).ToList();


                return View(fVM);

            }

            return View(fVM);
        }

        // GET: Question/Details/5
        public ActionResult Details(int id)
        {
            Question qs = questionservice.GetById(id);

            return View(qs);
        }

        // GET: Question/Create
        public ActionResult Create()
        {
            var Qs = new QuestionModel();
            var x = testS.GetAll().Select(a => new SelectListItem {
                Text = a.TypeTest,
                Value = a.Id.ToString()


           });
            Qs.TestL = x;
            return View(Qs);
        }

        // POST: Question/Create
        [HttpPost]
        public ActionResult Create(Question quest)
        {
            Question p = new Question();

            try
            {
                // TODO: Add insert logic here
                p.Subject = quest.Subject;
                p.choice1 = quest.choice1;
                p.choice2 = quest.choice2;
                p.choice3 = quest.choice3;
                p.ValidChoise = quest.ValidChoise;
                p.TestId = quest.TestId;
                questionservice.Add(p);
                questionservice.Commit();

                //return RedirectToAction("../Home/Index");
                return RedirectToAction("index","Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: Question/Edit/5
        public ActionResult Edit(int id)
        {
            Question qs = questionservice.GetById(id);

            return View(qs);
        }

        // POST: Question/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Question question)
        {
            Question x = questionservice.GetById(id);
            x.Subject = question.Subject;
            x.choice1 = question.choice1;
            x.choice2 = question.choice2;
            x.choice3 = question.choice3;
            x.ValidChoise = question.ValidChoise;

            questionservice.Update(x);
            questionservice.Commit();
            return RedirectToAction("Index");
        }

        // GET: Question/Delete/5
        public ActionResult Delete(int id)
        {
            Question q =  questionservice.GetById(id);
            return View(q);
        }

        // POST: Question/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Question question = new Question();
                question = questionservice.GetById(id);
                questionservice.Delete(question);
                questionservice.Commit();
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
