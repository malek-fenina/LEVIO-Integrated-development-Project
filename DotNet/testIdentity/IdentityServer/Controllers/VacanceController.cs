//using Domain.Entity;
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
    public class VacanceController : Controller
    {
        VacanceService vs = null;
        RessourceService rs = null;
        public VacanceController()
        {
            vs = new VacanceService();
            rs = new RessourceService();
        }
        // GET: Vacance
        public ActionResult Index()
        {
            var vacance = vs.GetAll();

            List<Vacance> fVM = new List<Vacance>();
            foreach (var item in vacance)
            {

                fVM.Add(
                    new Vacance
                    {
                        VacanceId = item.VacanceId,
                        typeholiday = item.typeholiday,
                        Date_Debut = item.Date_Debut,
                        Date_Fin = item.Date_Fin,
                        RessourceName = item.rr.Nom,

                    });
            }
            return View(fVM);
        }
        [HttpPost]
        public ActionResult Index(string searchString)
        {
            var vacance = vs.GetAll();
            List<Vacance> fVM = new List<Vacance>();
            foreach (var item in vacance)
            {
                fVM.Add(new Vacance
                {
                    VacanceId = item.VacanceId,
                    typeholiday = item.typeholiday,
                    Date_Debut = item.Date_Debut,
                    Date_Fin = item.Date_Fin,
                    RessourceName = item.rr.Nom,

                });
            }


            return View(fVM);
        }

        // GET: Vacance/Details/5
        public ActionResult Details(int id)

        {
            var vacance = vs.GetAll();
            List<Vacance> fVM = new List<Vacance>();
            foreach (var item in vacance)
            {
                fVM.Add(new Vacance
                {
                    VacanceId = item.VacanceId,

                    Date_Debut = item.Date_Debut,
                    Date_Fin = item.Date_Fin,
                    //idRessource=item.idRessource,
                    typeholiday = item.typeholiday,
                    RessourceName = item.rr.Nom,
                });
            }
            var rep = fVM.Where(r => r.VacanceId == id).FirstOrDefault();


            return View(rep);
        }
    

        // GET: Vacance/Create
        public ActionResult Create()
        {

            Vacance vacanceModel = new Vacance();
            ///
            List<string> Vacances = new List<string> { "DayOff", " OfficialVacation" };
            ViewData["vacance"] = new SelectList(Vacances);


            var x = rs.GetAll().
               Select(w => new SelectListItem
               {
                   Text = w.Nom,
                   Value = w.idRessource.ToString()
               });

            vacanceModel.Ressourcess = x;
            return View(vacanceModel);
        }

        // POST: Vacance/Create
        [HttpPost]
        public ActionResult Create(Vacance vacanceVM)
        {
            try
            {
                Domain.Entity.Vacance v = new Domain.Entity.Vacance();

                v.Date_Debut = vacanceVM.Date_Debut;
                v.Date_Fin = vacanceVM.Date_Fin;
                v.typeholiday = vacanceVM.typeholiday;
                v.idRessource = vacanceVM.idRessource;

                vs.Add(v);
                vs.Commit();


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Vacance/Edit/5
        public ActionResult Edit(int id)
        {
             Domain.Entity.Vacance v1 = vs.GetById(id);
            // dropdowlist
            List<Vacance> fVM = new List<Vacance>();

          

            List<string> Vacances = new List<string> { "DayOff", " OfficialVacation" };
            ViewData["vacance"] = new SelectList(Vacances);

            return View(v1);
        }

        // POST: Vacance/Edit/5
        [HttpPost]
        public ActionResult Edit(Vacance v1, int id)
       
        {

            try
            {
                Domain.Entity.Vacance vacance = vs.GetById(id);
                vacance.Date_Debut = v1.Date_Debut;
                vacance.Date_Fin = v1.Date_Fin;
                vacance.typeholiday = v1.typeholiday;

                //vacance.VacanceId = v1.VacanceId;
                vs.Update(vacance);
                vs.Commit();
                
            }
            catch (DataException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Edit", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("index");
        }

        // GET: Vacance/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Vacance/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection)
        {
            
                try
                {
                Domain.Entity.Vacance vacance = vs.GetById(id);
                    vs.Delete(vacance);
                    vs.Commit();
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
