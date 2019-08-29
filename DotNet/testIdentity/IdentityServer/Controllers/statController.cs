using Domain.Entity;
using ServiceSpecifiques;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentityServer.Controllers
{
    public class statController : Controller
    {
        ServiceStat ss;
        ProjectService ps;
        public statController()
        {
            ss = new ServiceStat();
            ps = new ProjectService();
           
        }
        // GET: stat
        public ActionResult Index()
        {
            int nombreResource = ss.nbResource();
            ViewBag.nombreResource = nombreResource;
            int nbUsers = ss.nbUsers();
            ViewBag.nbUsers=nbUsers;
            int nbprojects = ss.nbProjects();
            ViewBag.nbprojects = nbprojects;
            int nbreq = ss.nbRequests();
            ViewBag.nbreq = nbreq;
           int resAV = ss.GetMany(a => a.ressourceStates == 0).ToList().Count();
            ViewBag.resAv = resAV;
            int clients = ss.nbclients();
            ViewBag.clients = clients;
            



            return View();
        }
        public ActionResult dash()
        {
            var clients = ss.AllClients();
            List<int> repartition = new List<int>();
            var clientsNames = clients.Select(x => x.Nom).Distinct();
            foreach(var item in clientsNames)
            {
                foreach(Domain.Entity.Client c in clients)
                repartition.Add(c.NbrRessource);
            }
            var rep = repartition;
            ViewBag.rep = repartition.ToList();
            ViewBag.clientsNames = clientsNames;








            
            return View();
        }
        public ActionResult dish()
        {
            /*dash*/
            var clients = ss.AllClients();
            List<int> repartition = new List<int>();
            var clientsNames = clients.Select(x => x.Nom).Distinct();
            foreach (var item in clientsNames)
            {
                foreach (Domain.Entity.Client c in clients)
                    repartition.Add(c.NbrRessource);
            }
            var rep = repartition;

            /*index2--pie*/
            int nombreResource = ss.nbResource();
            int nbUsers = ss.nbUsers();
            int nbprojects = ss.nbProjects();
            int nbreq = ss.nbRequests();
            int resAV = ss.GetMany(a => a.ressourceStates == 0).ToList().Count();
            int clientss = ss.nbclients();




            /*dish*/
            var projects = ps.GetAll();
            List<int> repartitonProjects = new List<int>();
            List<String> etatsproj = new List<string>();
            var projectsNames = projects.Select(x => x.Nom).Distinct();
            int nbprojectsDone = ss.Doneprojects();
            int nbprojectsNew = ss.newprojects();
            int nbprojectsGoing = ss.Goingprojects();
            repartitonProjects.Add(nbprojectsNew);
            repartitonProjects.Add(nbprojectsGoing);
            repartitonProjects.Add(nbprojectsDone);

            etatsproj.Add("new");


            etatsproj.Add("On_going");

            etatsproj.Add("Done");


            ViewBag.repartitonProjects = repartitonProjects;
            ViewBag.etatsproj = etatsproj;
            ViewBag.rep = repartition.ToList();
            ViewBag.clientsNames = clientsNames;
            ViewBag.resAv = resAV;
            ViewBag.clientss = clientss;
            ViewBag.nbUsers = nbUsers;
            ViewBag.nombreResource = nombreResource;
            ViewBag.nbprojects = nbprojects;





            return View();
        }

        public ActionResult Index2()
        {
            int nombreResource = ss.nbResource();
            ViewBag.nombreResource = nombreResource;
            int nbUsers = ss.nbUsers();
            ViewBag.nbUsers = nbUsers;
            int nbprojects = ss.nbProjects();
            ViewBag.nbprojects = nbprojects;
            int nbreq = ss.nbRequests();
            ViewBag.nbreq = nbreq;
            int resAV = ss.GetMany(a => a.ressourceStates == 0).ToList().Count();
            ViewBag.resAv = resAV;
            int clients = ss.nbclients();
            ViewBag.clients = clients;




            return View();
        }

    }
}