using IdentityServer.Models;
using ServiceSpecifiques;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;

namespace IdentityServer.Controllers
{
    public class RestfullCController : Controller
    {
        CompetenceService cs = null;
        public RestfullCController()
        {
            cs = new CompetenceService();

        }

        [WebMethod]
        [HttpPost]
        public ActionResult CreateCompetence(Competence skill)
        {

            Domain.Entity.Competence c = new Domain.Entity.Competence
            {
                
                
               
                idCompetence = skill.idCompetence,
               
                Label = skill.Label,
                Dificulty = skill.Dificulty,
                idRessource = skill.idRessource,

            };
            cs.Add(c);
            cs.Commit();
            //var path = Path.Combine(Server.MapPath("~/Content/Upload/"), Image.FileName);
            //Image.SaveAs(path);
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
        }
        [WebMethod]
        [HttpPost]
        public ActionResult EditCompetence(Competence c1, int id)
        {



            Domain.Entity.Competence skill = cs.GetById(id);
            skill.Label = c1.Label;
            skill.Dificulty = c1.Dificulty;
            

            cs.Update(skill);
            cs.Commit();
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
        }

        [WebMethod]
        [HttpDelete]
        public ActionResult DeleteCompetence(int id, FormCollection collection)
        {


            Domain.Entity.Competence skill = cs.GetById(id);
            cs.Delete(skill);
            cs.Commit();
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
        }

    }
}