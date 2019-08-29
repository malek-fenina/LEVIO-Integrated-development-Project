using IdentityServer.Models;
using ServiceSpecifiques;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Xml.Linq;

namespace IdentityServer.Controllers
{
    [RoutePrefix("api/Project")]
    public class WebApiController : ApiController
    {
        ProjectService ps = null;
        UserService us = null;
        ServiceStat ss = null;

        public WebApiController()
        {
            ps = new ProjectService();
            us = new UserService();
        }
        [HttpGet]
        [Route("GetProjects")]
        public List<Project> GetProjects()
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
                        LastName = item.Productor.LastName,
                        CompetenceName = item.Productor1.Label

                    });
            }

            return fVM;
        }


        [HttpGet]
        [Route("GetUsers")]
        public List<Domain.Entity.Users> GetUsers()
        {
            var user = us.GetAll();

            List<Domain.Entity.Users> fVM = new List<Domain.Entity.Users>();
            foreach (var model in user)
            {

                fVM.Add(
                    new Domain.Entity.Users
                    {
                        Id = model.Id,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        UserName = model.Email,
                        Email = model.Email,
                        Password = model.Password,
                        UserRole = model.UserRole,
                        NbrRessource = model.NbrRessource,
                        NbrProjetActif = model.NbrProjetActif,
                        TypeClient = model.TypeClient,
                        Image = model.Image

                    });
            }

            return fVM;
        }

        [HttpGet]
        [Route("nbUsers")]
        public IHttpActionResult nbUsers()
        {
            //  int nombreResource = ss.nbResource();
            int nbUsers = ss.nbUsers();
            //int nbprojects = ss.nbProjects();
            //int nbreq = ss.nbRequests();
            //int resAV = ss.GetMany(a => a.ressourceStates == 0).ToList().Count();
            //int clients = ss.nbclients();


            //var lista = new List<int>();
            //lista.Add(nbUsers);
            //lista.Add(nbprojects);
            //lista.Add(nbreq);
            //lista.Add(clients);
            //lista.Add(resAV);
            //Dictionary<String, int> map = new Dictionary<string, int>();
            //map.Add("users",nbUsers);
            //map.Add("project", nbprojects);

            //map.Add("req", nbreq);
            //map.Add("client", clients);
            //map.Add("resav", resAV);

            //var abc = new List<Dictionary<string,int>>();
            //abc.Add(map);

            return Json(nbUsers);
        }

        [HttpGet]
        [Route("nbProjects")]
        public IHttpActionResult nbProjects()
        {

            int nbprojects = ss.nbProjects();
            return Json(nbprojects);
        }
        [HttpGet]
        [Route("nbRessources")]
        public IHttpActionResult nbRessources()
        {
            return Json(ss.nbResource());
        }
        [HttpGet]
        [Route("nbRequests")]
        public IHttpActionResult nbRequests()
        {
            return Json(ss.nbRequests());
        }
        [HttpGet]
        [Route("nbClients")]
        public IHttpActionResult nbClients()
        {
            return Json(ss.nbclients());
        }
        [HttpGet]
        [Route("nbAvRessources")]
        public IHttpActionResult nbRessourcesAv()
        {
            return Json(ss.avResources());
        }
        [HttpGet]
        [Route("DoneProjects")]
        public IHttpActionResult nbDoneProjects()
        {
            return Json(ss.Doneprojects());
        }

        [HttpGet]
        [Route("goingProjects")]
        public IHttpActionResult goingProjects()
        {
            return Json(ss.Goingprojects());
        }
        [HttpGet]
        [Route("NewProjects")]
        public IHttpActionResult nbNewProjects()
        {
            return Json(ss.newprojects());
        }
        [HttpGet]
        [Route("nbrlevio")]
        public IHttpActionResult nbRessourceLevio()
        {
            return Json(ps.getNbrRessLevio());
        }
        [HttpGet]
        [Route("nbrtotal")]
        public IHttpActionResult nbRessourceTotal()
        {

            return Json(ps.getNbrRessTotal());
        }
    }
}