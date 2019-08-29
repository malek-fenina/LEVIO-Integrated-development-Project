using Domain.Entity;
using Microsoft.AspNet.Identity;
using ServiceSpecifiques;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentityServer.Controllers
{
    //[Authorize(Roles = "Manager")]
    public class ApplicationController : Controller
    {

        ApplicationService appservice = null;

        public ApplicationController()
        {
            appservice = new ApplicationService();

        }

        // GET: Application
        public ActionResult Index()
        {
            var app = appservice.GetAll();
            List<string> State = new List<string> { "WaitForResponse", "interview", "testTech", "interviewTech", "testFr", "accepted"/*,applicationAccepted*/, "refused" };
            ViewData["State"] = new SelectList(State);
            List<Application> fVM = new List<Application>();
            foreach (var item in app)
            {
                if (item.IdUser == Int32.Parse(System.Web.HttpContext.Current.User.Identity.GetUserId()))
                    fVM.Add(
                    new Application
                    {
                        Id = item.Id,
                        Date = item.Date,
                        Description = item.Description,
                        State=item.State

            });
            }
            return View(fVM);
        }


        // GET: Application
        public ActionResult Index2()
        {
            var app = appservice.GetAll();

            List<Application> fVM = new List<Application>();
            foreach (var item in app)
            {
                    fVM.Add(
                    new Application
                    {
                        Id = item.Id,
                        Date = item.Date,
                        Description = item.Description,
                        State = item.State

                    });
            }
            return View(fVM);
        }

        [HttpPost]
        public ActionResult Index2(string search)
        {
            var skill = appservice.GetAll();
            List<Application> fVM = new List<Application>();

            foreach (var item in skill)
            {
                fVM.Add(new Application
                {
                    Id = item.Id,
                    Date = item.Date,
                    Description = item.Description,
                    State = item.State
                });
            }
            if (!String.IsNullOrEmpty(search))
            {


                fVM = fVM.Where(c => c.Description == search).ToList();


                return View(fVM);

            }

            return View(fVM);
        }

        // GET: Application/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Application/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Application/Create
        [HttpPost]
        public ActionResult Create(Application app)
        {
            Application p = new Application();

            try
            {
                // TODO: Add insert logic here
                p.Date = app.Date;
                p.Description = app.Description;
                p.IdUser= Int32.Parse(System.Web.HttpContext.Current.User.Identity.GetUserId());

                appservice.Add(p);
                appservice.Commit();

                return RedirectToAction("index", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: Application/Edit/5
        public ActionResult Edit(int id)
        {
            Application aps = appservice.GetById(id);

            return View(aps);
        }

        // POST: Application/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Application app)
        {
            Application x = appservice.GetById(id);
            x.State = app.State;


            appservice.Update(x);
            appservice.Commit();
            return RedirectToAction("Index");
        }


        // GET: Application/Edit/5
        public ActionResult Edit2(int id)
        {
            Application aps = appservice.GetById(id);
            return View(aps);
        }

        // POST: Application/Edit/5
        [HttpPost]
        public ActionResult Edit2(int id, Application app)
        {
            Application x = appservice.GetById(id);
            x.Date = app.Date;


            appservice.Update(x);
            appservice.Commit();
            return RedirectToAction("Index");
        }

        // GET: Application/Delete/5
        public ActionResult Delete(int id)
        {
            Application q = appservice.GetById(id);
            return View();
        }

        // POST: Application/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Application app = new Application();
                app = appservice.GetById(id);
                appservice.Delete(app);
                appservice.Commit();
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
