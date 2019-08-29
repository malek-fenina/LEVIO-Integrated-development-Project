using IdentityServer.Models;
using ServiceSpecifiques;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace IdentityServer.Controllers
{
    public class ProjectController : Controller
    {
        ProjectService ps = null;
        ClientService cs = null;
        UserService us = null;
        CompetenceService comps = null;
        public ProjectController()
        {
            ps = new ProjectService();
            cs = new ClientService();
            comps = new CompetenceService();
            us = new UserService();
        }

        // GET: Project
        public ActionResult Index()
        {
            var project = ps.GetAll();

            List<Project> fVM = new List<Project>();
            foreach (var item in project)
            {

                fVM.Add(
                    new Project
                    {
                        idProject = item.idProject,
                        Nom = item.Nom,
                        Date_Debut = item.Date_Debut,
                        Date_Fin = item.Date_Fin,
                        NbrRessourceTotal = item.NbrRessourceTotal,
                        NbrRessourceLevio = item.NbrRessourceLevio,
                        Image = item.Image,
                        projectTypes = item.projectTypes,
                        IdClient = item.IdClient,
                        idCompetence = item.idCompetence,
                        LastName=item.Productor.LastName,
                        CompetenceName = item.Productor1.Label


                    });
            }
            return View(fVM);
        }
        [HttpPost]
        public ActionResult Index(string searchString)
        {
            var project = ps.GetAll();
            List<Project> fVM = new List<Project>();
            foreach (var item in project)
            {
                fVM.Add(new Project
                {
                    idProject = item.idProject,
                    Nom = item.Nom,
                    Date_Debut = item.Date_Debut,
                    Date_Fin = item.Date_Fin,
                    NbrRessourceTotal = item.NbrRessourceTotal,
                    NbrRessourceLevio = item.NbrRessourceLevio,
                    Image = item.Image,
                    projectTypes = item.projectTypes,
                    IdClient = item.IdClient,
                    idCompetence = item.idCompetence,
                    LastName = item.Productor.LastName,
                    CompetenceName=item.Productor1.Label
                   




                });
            }
            if (!String.IsNullOrEmpty(searchString))
            {


                fVM = fVM.Where(c => c.Nom == searchString).ToList();


                return View(fVM);

            }

            return View(fVM);
        }

        // GET: Project/Details/5
        public ActionResult Details(int? id, HttpPostedFileBase Image)
        {
            var project = ps.GetAll();
            List<Project> fVM = new List<Project>();
            foreach (var item in project)
            {
                fVM.Add(new Project
                {
                    idProject = item.idProject,
                    Nom = item.Nom,
                    Date_Debut = item.Date_Debut,
                    Date_Fin = item.Date_Fin,
                    NbrRessourceTotal = item.NbrRessourceTotal,
                    NbrRessourceLevio = item.NbrRessourceLevio,
                    Image = item.Image,
                    projectTypes = item.projectTypes,
                });
            }
            var rep = fVM.Where(r => r.idProject == id).FirstOrDefault();


            return View(rep);
        }

        // GET: Project/Create
        public ActionResult Create()
        {
            IdentityServer.Models.Project projectModel = new IdentityServer.Models.Project();
            // dropdowlist
            List<string> Projects = new List<string> { "New", "On_going", "Done" };
            ViewData["project"] = new SelectList(Projects);
            ///
            var prod = cs.GetAll();
            ViewData["Users"] = new SelectList(prod, "Id", "LastName");
            // ViewBag.Producteur = new SelectList(prod, "ProducteurId", "Nom");

            var x = us.GetMany(a=>a.UserRole.Equals("Client")).
               Select(w => new SelectListItem
               {
                   Text = w.LastName,
                   Value = w.Id.ToString()
               });
            projectModel.Clientss = x;

            var x1 = comps.GetAll().
             Select(w => new SelectListItem
             {
                 Text = w.Label,
                 Value = w.idCompetence.ToString()
             });
            projectModel.Competencess = x1;

            return View(projectModel);
        }

        // POST: Project/Create
        [HttpPost]
        public ActionResult Create(Project projectVM, HttpPostedFileBase Image)
        {
            Domain.Entity.Project p = new Domain.Entity.Project();
            p.Nom = projectVM.Nom;
            p.Date_Debut = projectVM.Date_Debut;
            p.Date_Fin = projectVM.Date_Fin;
            p.NbrRessourceTotal = projectVM.NbrRessourceTotal;
            p.NbrRessourceLevio = projectVM.NbrRessourceLevio;
            p.Image = Image.FileName;
            p.projectTypes = projectVM.projectTypes;
            p.IdClient = projectVM.IdClient;
            p.idCompetence = projectVM.idCompetence;
            ps.Add(p);
            ps.Commit();

            var path = Path.Combine(Server.MapPath("~/Content/Upload/"), Image.FileName);
            Image.SaveAs(path);
            return RedirectToAction("Index");
        }

        // GET: Project/Edit/5
        public ActionResult Edit(int id)
        {
            IdentityServer.Models.Project projectModel = new IdentityServer.Models.Project();
            // dropdowlist
            List<string> Projects = new List<string> { "New", "On_going", "Done" };
            ViewData["project"] = new SelectList(Projects);
            return View();
        }

        // POST: Project/Edit/5
        [HttpPost]
        public ActionResult Edit(Project p1, int id, HttpPostedFileBase Image)
        {


            try
            {
                Domain.Entity.Project project = ps.GetById(id);
                //project.idProject = p1.idProject;
                project.Nom = p1.Nom;
                project.Levels = p1.Levels;
                project.NbrRessourceLevio = p1.NbrRessourceLevio;
                project.NbrRessourceTotal = p1.NbrRessourceTotal;
                project.Image = Image.FileName;
                //project.Clients_Id = p1.Clients_Id;
                project.projectTypes = p1.projectTypes;

                ps.Update(project);
                ps.Commit();
                var path = Path.Combine(Server.MapPath("~/Content/Upload/"), Image.FileName);
                Image.SaveAs(path);
            }

            catch (DataException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Edit", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Create","EmailE");
        }

        // GET: Project/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Project/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection)
        {
            {
                try
                {
                    Domain.Entity.Project project = ps.GetById(id);
                    ps.Delete(project);
                    ps.Commit();
                }
                catch (DataException/* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    return RedirectToAction("Delete", new { id = id, saveChangesError = true });
                }
                return RedirectToAction("Index");


            }
        }

        public ActionResult Chart()
        {
            int nbr = ps.getNbrRessLevio();
            ViewBag.nbr = nbr;

            int nbr1 = ps.getNbrRessTotal();
            ViewBag.nbr1 = nbr1;

            return View();
        }

    }
}