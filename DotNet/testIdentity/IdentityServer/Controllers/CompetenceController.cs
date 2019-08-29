using IdentityServer.Models;
using Rotativa.MVC;
using ServiceSpecifiques;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentityServer.Controllers
{
    public class CompetenceController : Controller
    {
        CompetenceService cs = null;
        RessourceService rs = null;
        public CompetenceController()
        {
            cs = new CompetenceService();
            rs = new RessourceService();
        }
        // GET: Competence
        public ActionResult Index()
        {
            var skill = cs.GetAll();


            List<Competence> fVM = new List<Competence>();

            foreach (var item in skill)
            {

                fVM.Add(
                    new Competence
                    {
                        idCompetence = item.idCompetence,
                        Label = item.Label,
                        Dificulty = item.Dificulty,
                        RessourceName = item.ress.Nom,


                    });
            }
            return View(fVM);
        }

        // GET: Competence
        public ActionResult Index2()
        {
            var skill = cs.GetAll();


            List<Competence> fVM = new List<Competence>();

            foreach (var item in skill)
            {

                fVM.Add(
                    new Competence
                    {
                        idCompetence = item.idCompetence,
                        Label = item.Label,
                        Dificulty = item.Dificulty,
                        RessourceName = item.ress.Nom,


                    });
            }
            return View(fVM);
        }

        public ActionResult PrintViewToPdf()
        {
            var report = new ActionAsPdf("Index2");
            return report;
        }
        [HttpPost]
        public ActionResult Index(string search)
        {
            var skill = cs.GetAll();
            List<Competence> fVM = new List<Competence>();

            foreach (var item in skill)
            {
                fVM.Add(new Competence
                {
                    idCompetence = item.idCompetence,
                    Label = item.Label,
                    Dificulty = item.Dificulty,
                    //idRessource=item.idRessource,
                    RessourceName = item.ress.Nom,
                });
            }
            if (!String.IsNullOrEmpty(search))
            {


                fVM = fVM.Where(c => c.Label == search).ToList();


                return View(fVM);

            }

            return View(fVM);
        }






        // GET: Competence/Details/5
        public ActionResult Details(int id)
        {
            {
                var skill = cs.GetAll();
                List<Competence> fVM = new List<Competence>();
                foreach (var item in skill)
                {
                    fVM.Add(new Competence
                    {
                        idCompetence = item.idCompetence,
                        Label = item.Label,
                        Dificulty = item.Dificulty,
                        //idRessource=item.idRessource,
                        RessourceName = item.ress.Nom,
                        
                    });
                }
                var rep = fVM.Where(r => r.idCompetence == id).FirstOrDefault();


                return View(rep);
            }

        }




        // GET: Competence/Create
        public ActionResult Create()
        {
            IdentityServer.Models.Competence competencetModel = new IdentityServer.Models.Competence();
           
            ///

       

            var x = rs.GetAll().
               Select(w => new SelectListItem
               {
                   Text = w.Nom,
                   Value = w.idRessource.ToString()
               });

            competencetModel.Ressourcess = x;
            return View(competencetModel);
        }

        // POST: Competence/Create
        [HttpPost]
        public ActionResult Create(Competence skills)
        {
            try
            {

               Domain.Entity.Competence c = new Domain.Entity.Competence();

                c.Label = skills.Label;
                c.Dificulty = skills.Dificulty;
                c.idRessource = skills.idRessource;
              


                cs.Add(c);
                cs.Commit();


                return RedirectToAction("Index");
            }

            catch
            {
                return View();
            }
        }

// GET: Competence/Edit/5
public ActionResult Edit(int id)
        {
            Competence CompetenceModel = new Competence();

            //Domain.Entity.Competence c1 = cs.GetById(id);
           return View();
        }

        // POST: Competence/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Competence c1 )
        {

            try
            {
                Domain.Entity.Competence skill = cs.GetById(id);
                skill.Label = c1.Label;
                skill.Dificulty = c1.Dificulty;
                


                cs.Update(skill);
                cs.Commit();

            }
            catch (DataException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Edit", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("index");
        }

        // GET: Competence/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Competence/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Domain.Entity.Competence skill = cs.GetById(id);
                cs.Delete(skill);
                cs.Commit();
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
