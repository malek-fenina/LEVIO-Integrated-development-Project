using Data;
using IdentityServer.Models;
using ServiceSpecifiques;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentityServer.Controllers
{
    public class MandatController : Controller

    {
        MandatService ms = null;
        ProjectService clientService = new ProjectService();
        RessourceService rs = new RessourceService();
        public MandatController() {
            ms = new MandatService();

        }
        // GET: Mandat
        public ActionResult Index()
        {

            var listMandat = ms.GetAll();
            foreach (Domain.Entity.Mandat m in listMandat)
            {
                m.project = clientService.GetAll().Where(e => e.idProject == m.idProject).First();
                m.ressource = rs.GetAll().Where(e => e.Id == m.IdRessource).First();
            }
            return View(listMandat);
        }

        // GET: Mandat/Details/5
        public ActionResult Details(int id)
        {
            MAPContext mcd = new MAPContext();
            Domain.Entity.Mandat qs = mcd.Mandats.Find(id);

            return View(qs);
        }

        // GET: Mandat/Create
        public ActionResult Create()
        {
            Mandat mandat = new Mandat();
            var x = clientService.GetAll().Select(c => new SelectListItem
            {
                Text = c.idProject.ToString() + "",
                Value = c.idProject + ""
            });

            var y = rs.GetAll().Select(e => new SelectListItem
            {
                Text = e.Id.ToString(),
                Value = e.Id + ""
            });

            mandat.Projects = x;
            mandat.Ressources = y;

            return View(mandat);
        }

        // POST: Mandat/Create
        [HttpPost]
        public ActionResult Create(Mandat mandat)
        {
            try
            {
                // TODO: Add insert logic here


                Domain.Entity.Mandat m = new Domain.Entity.Mandat();
                m.date_debut = mandat.date_debut;
                m.date_fin = mandat.date_fin;
                m.idProject = mandat.idProject;
                m.IdRessource = mandat.IdRessource;
                m.NomMandat = mandat.NomMandat;
                //m.archive = mandat.archive;
                ms.Add(m);
                ms.Commit();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Mandat/Edit/5
        public ActionResult Edit(int id)
        {

            //  Domain.Entity.Mandat qs = ms.GetById(id);

            Domain.Entity.Mandat projectModel = new Domain.Entity.Mandat();
            // dropdowlist
            //List<string> Projects = new List<string> { "New", "On_going", "Done" };
            //ViewData["project"] = new SelectList(Projects);
            return View();

        }

        // POST: Mandat/Edit/5
        [HttpPost]
        public ActionResult Edit(Domain.Entity.Mandat mandat, int id, FormCollection collection)
        {
            MAPContext mcx = new MAPContext();

            // TODO: Add update logic here
            try {
                Domain.Entity.Mandat x = mcx.Mandats.Single(a => a.idMandat == id);
                // Domain.Entity.Mandat x = new Domain.Entity.Mandat();
                x.date_debut = mandat.date_debut;

                x.date_fin = mandat.date_fin;
                //x.idProject = mandat.idProject;
                //x.IdRessource = mandat.IdRessource;
                x.NomMandat = mandat.NomMandat;
                mcx.Mandats.Attach(x);


                mcx.SaveChanges();
                //ms.Update(x);
                //ms.Commit();
            }
            catch (DataException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Edit", new { id = id, saveChangesError = true });
            }
        
            return RedirectToAction("Create", "Email");
          }

        // GET: Mandat/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
            // return View(ms.GetAll().Where(e => e.id == id).First());
        }


        // POST: Mandat/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Delete(int id, FormCollection collection)
        {
            MAPContext mc = new MAPContext();
            {
                try
                {
                    Domain.Entity.Mandat mandat = mc.Mandats.Find(id);
                    mc.Mandats.Remove(mandat);
                    mc.SaveChanges();
                    //  ms.Delete(mandat);
                    // ms.Commit();
                }
                catch (DataException/* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    return RedirectToAction("Delete", new { id = id, saveChangesError = true });
                }
                return RedirectToAction("Index");


            }
        }
        //{
        //    try
        //    {
        //        Domain.Entity.Mandat m = new Domain.Entity.Mandat();
        //        m = ms.GetAll().Where(e => e.id == id).First();
        //        m.archive = true;
        //        ms.Delete(m);
        //        ms.Commit();

        //        return RedirectToAction("Index");
        //    }
        //    catch (DataException/* dex */)
        //    {
        //        //Log the error (uncomment dex variable name and add a line here to write a log.
        //        return RedirectToAction("Delete", new { id = id, saveChangesError = true });
        //    }
        //    return RedirectToAction("Index");
        //}
        public ActionResult Calculer(int id)
        {
            MAPContext mcc = new MAPContext();
            Domain.Entity.Mandat qs = mcc.Mandats.Find(id);
            //Domain.Entity.Mandat mandat = ms.GetById(id);
            List<Domain.Entity.Ressource> ressources = new List<Domain.Entity.Ressource>();

            ressources = rs.GetAll().ToList();
            String name = null;


            foreach (Domain.Entity.Ressource r in ressources)
            {
                if (r.idRessource == qs.IdRessource)
                {
                    name = r.FirstName;

                }
            }
            ViewBag.name = name;


            return View();
        }
        [HttpPost]
        public ActionResult Index(String search) {
            var mandat = ms.GetAll();
            List<Domain.Entity.Mandat> f = new List<Domain.Entity.Mandat>();
            foreach (var item in mandat)
            {
                f.Add(new Domain.Entity.Mandat
                {
                    IdRessource = item.IdRessource,
                    idMandat=item.idMandat,
                    idProject=item.idProject,
                    date_debut=item.date_debut,
                    date_fin = item.date_fin,
                    NomMandat =item.NomMandat

                });
            }
            if (!String.IsNullOrEmpty(search))
            {
                f = f.Where(c => c.NomMandat == search).ToList();


                return View(f);

            }

            return View(f);
        }
        public ActionResult Email(int id)
        {
            return RedirectToAction("Create", "Email");
           // return View();

        }

    }
    
}
