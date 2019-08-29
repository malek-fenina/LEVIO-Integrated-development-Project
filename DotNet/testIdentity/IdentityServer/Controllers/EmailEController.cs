using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace IdentityServer.Controllers
{
    public class EmailEController : Controller
    {
        // GET: EmailE
        public ActionResult Index()
        {
            return View();
        }

        // GET: EmailE/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmailE/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmailE/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string recieverEmail, string subject, string message)
        {
            var senderemail = new MailAddress("lasslasselyes@gmail.com", "Admin");
            var recieveremail = new MailAddress(recieverEmail, "Reciever");
            var password = "elyeselyes22";

            var sub = subject;
            var body = message;
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(senderemail.Address, password)
            };
            using (var mess = new MailMessage(senderemail, recieveremail)
            {
                Subject = subject,
                Body = body
            }
                )
            {
                smtp.Send(mess);
            }
            return RedirectToAction("Index","Project");
        }

        // GET: EmailE/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmailE/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EmailE/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmailE/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
