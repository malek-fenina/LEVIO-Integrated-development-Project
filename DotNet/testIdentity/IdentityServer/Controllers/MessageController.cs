
using Data;
using Domain.Entity;
using IdentityServer.Models;
using Microsoft.AspNet.Identity;
using ServiceSpecifiques;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentityServer.Controllers
{
   
    public class MessageController : Controller
    {


        /*  MessageService SM = null;
          public MessageController()
          {
              SM = new MessageService();
          }*/
        MessageService SM = new MessageService();

        // GET: Message
        public ActionResult Index()
        {
            MessageType messageS;
            Enum.TryParse("Satisfaction", out messageS);

            MessageType messageR;
            Enum.TryParse("Reclamation", out messageR);
            MessageType messageP;
            Enum.TryParse("Probleme_Technique", out messageP);

            var msg =  SM.GetAll();

            List<MessageModels> LM =new List<MessageModels>();

            if (Convert.ToInt32(User.Identity.GetUserId()) == 1) {

                return RedirectToAction("IndexAdmin");
            }
            else 
            {

                foreach (var item in msg)
                {
                    if (item.UsersId == Convert.ToInt32(User.Identity.GetUserId()))

                    {
                        if (item.messageTypes == messageS) { 

                            LM.Add(
                      new MessageModels
                      {

                          idMessage = item.idMessage,
                          Contenu = item.Contenu,
                          Received = item.Received,
                          Date = item.Date,

                        
                           messagetype = MessageModelType.Satisfaction
                        
                       
                    
                        // userName = item.users.UserName,
                       // messagetype = item.messageTypes,
                      //  users = SM.GetById(item.UsersId)
                      });
                        }else if(item.messageTypes == messageR)
                        {
                            LM.Add(
                      new MessageModels
                      {

                          idMessage = item.idMessage,
                          Contenu = item.Contenu,
                          Received = item.Received,
                          Date = item.Date,


                          messagetype = MessageModelType.Reclamation



                          // userName = item.users.UserName,
                          // messagetype = item.messageTypes,
                          //  users = SM.GetById(item.UsersId)
                      });
                        }
                        else if (item.messageTypes==messageP)
                        {
                            LM.Add(
                     new MessageModels
                     {

                         idMessage = item.idMessage,
                         Contenu = item.Contenu,
                         Received = item.Received,
                         Date = item.Date,


                         messagetype = MessageModelType.Probleme_Technique



                          // userName = item.users.UserName,
                          // messagetype = item.messageTypes,
                          //  users = SM.GetById(item.UsersId)
                      });
                        }
                        else
                        {
                            LM.Add(
                    new MessageModels
                    {

                        idMessage = item.idMessage,
                        Contenu = item.Contenu,
                        Received = item.Received,
                        Date = item.Date,


                        messagetype = MessageModelType.Reponse



                         // userName = item.users.UserName,
                         // messagetype = item.messageTypes,
                         //  users = SM.GetById(item.UsersId)
                     });
                        }
                    }
                }

                return View(LM);
            }
            
        }

        public ActionResult IndexAdmin()
        {
            MessageType messageS;
            Enum.TryParse("Satisfaction", out messageS);

            MessageType messageR;
            Enum.TryParse("Reclamation", out messageR);
            MessageType messageP;
            Enum.TryParse("Probleme_Technique", out messageP);
            var msg = SM.GetAll();

            List<MessageModels> LM = new List<MessageModels>();

           
            foreach (var item in msg)
                {

                if (item.messageTypes == messageS)
                {

                    LM.Add(
              new MessageModels
              {

                  idMessage = item.idMessage,
                  Contenu = item.Contenu,
                  Received = item.Received,
                  Date = item.Date,
                  UsersId=item.UsersId,

                  messagetype = MessageModelType.Satisfaction



                          // userName = item.users.UserName,
                          // messagetype = item.messageTypes,
                          //  users = SM.GetById(item.UsersId)
                      });
                }
                else if (item.messageTypes == messageR)
                {
                    LM.Add(
              new MessageModels
              {

                  idMessage = item.idMessage,
                  Contenu = item.Contenu,
                  Received = item.Received,
                  Date = item.Date,
                  UsersId = item.UsersId,

                  messagetype = MessageModelType.Reclamation



                          // userName = item.users.UserName,
                          // messagetype = item.messageTypes,
                          //  users = SM.GetById(item.UsersId)
                      });
                }
                else if (item.messageTypes == messageP)
                {
                    LM.Add(
             new MessageModels
             {

                 idMessage = item.idMessage,
                 Contenu = item.Contenu,
                 Received = item.Received,
                 Date = item.Date,
                 UsersId = item.UsersId,

                 messagetype = MessageModelType.Probleme_Technique



                         // userName = item.users.UserName,
                         // messagetype = item.messageTypes,
                         //  users = SM.GetById(item.UsersId)
                     });
                }
                else
                {
                    LM.Add(
            new MessageModels
            {

                idMessage = item.idMessage,
                Contenu = item.Contenu,
                Received = item.Received,
                Date = item.Date,
                UsersId = item.UsersId,

                messagetype = MessageModelType.Reponse



                        // userName = item.users.UserName,
                        // messagetype = item.messageTypes,
                        //  users = SM.GetById(item.UsersId)
                    });
                }
            }


            
            return View(LM);
        }




        // GET: Message/Details/5
        public ActionResult Details(int id)
        {
            MessageType messageS;
            Enum.TryParse("Satisfaction", out messageS);

            MessageType messageR;
            Enum.TryParse("Reclamation", out messageR);
            MessageType messageP;
            Enum.TryParse("Probleme_Technique", out messageP);



            Message msg = SM.GetById(id);
            MessageModels msgM = new MessageModels();
            msgM.Contenu = msg.Contenu;
            msgM.Date = msg.Date;

            if (msg.messageTypes == messageS)
            {
                msgM.messagetype = MessageModelType.Satisfaction;
            }
            else if (msg.messageTypes == messageR)
            { msgM.messagetype = MessageModelType.Reclamation; }
            else if(msg.messageTypes == messageP)
            {
                msgM.messagetype = MessageModelType.Probleme_Technique;
            }
            else  
            {
                msgM.messagetype = MessageModelType.Reponse;
            }


            // msgM.messagetype = msg.messageTypes;
            // msgM.Received = msg.Received;
            return View(msgM);
        }

        // GET: Message/Create
        public ActionResult Create()
        {
           /* UserService userS = new UserService();
            MessageModels MessageModels = new MessageModels();
              var  names = userS.GetAll();
              List<string> NU = new List<string>();
              foreach (var item in names)
              {

                  NU.Add(


                           item.Email


                      );
              }
              ViewData["names"] = new SelectList(NU);

            var x = userS.GetAll().Select(a => new SelectListItem
            {
                Text = a.UserName ,
                Value = a.Id.ToString()
            });
            MessageModels.UserL = x;*/


            List<MessageType> msgType = new List<MessageType> {MessageType.Reclamation,MessageType.Satisfaction,MessageType.Probleme_Technique };
            ViewData["type"] = new SelectList(msgType);
            return View();
        }

       // POST: Message/Create
       [HttpPost]
       public ActionResult Create(MessageModels msg)
         {
            MessageModelType messageS;
            Enum.TryParse("Satisfaction", out messageS);

            MessageModelType messageR;
            Enum.TryParse("Reclamation", out messageR);

            


            Message  message = new Message();
            message.Date = msg.Date;
            message.Contenu = msg.Contenu;
            message.Received = false;
            if (msg.messagetype==messageS)
            {
                message.messageTypes = MessageType.Satisfaction;
            }
            else if (msg.messagetype == messageR)
            { message.messageTypes = MessageType.Reclamation; }
            else
            {
                message.messageTypes = MessageType.Probleme_Technique;
            }
           
            // user= US.Get(u=>u.Email.Equals(msg.userName));
            //user = US.Get(u => u.Email.Equals("admin@yahoo.com"));
           // user = US.GetById(1);
            message.UsersId = Convert.ToInt32(User.Identity.GetUserId());
            //  message.users = user;
            // Console.Out.WriteLine(message.users);
            //System.Diagnostics.Debug.WriteLine(message.users);

            MessageService ms = new MessageService();

            ms.Add(message);
            ms.Commit();


            return RedirectToAction("Index");

         }


        // GET: Message/Create1
        public ActionResult Create1()
        {
             UserService userS = new UserService();
             MessageModels MessageModels = new MessageModels();
             
             var x = userS.GetAll().Select(a => new SelectListItem
             {
                 Text = a.UserName ,
                 Value = a.Id.ToString()
             });
             MessageModels.UserL = x;

          /*  List<string> msgType = new List<string> { "Satisfaction", "Reclamation", "Probleme_Technique" };
            ViewData["type"] = new SelectList(msgType);*/
            return View(MessageModels);
        }

        // POST: Message/Create1
        [HttpPost]
        public ActionResult Create1(MessageModels msg)
        {


            Message message = new Message();
            message.Date = msg.Date;
            message.Contenu = msg.Contenu;
            message.Received = false;
           
            message.messageTypes = MessageType.Reponse;
           
            


            // user= US.Get(u=>u.Email.Equals(msg.userName));
            //user = US.Get(u => u.Email.Equals("admin@yahoo.com"));
            // user = US.GetById(1);
            message.UsersId = msg.UsersId;
            //  message.users = user;
            // Console.Out.WriteLine(message.users);
            //System.Diagnostics.Debug.WriteLine(message.users);

            MessageService ms = new MessageService();

            ms.Add(message);
            ms.Commit();


            return RedirectToAction("IndexAdmin");

        }

        // GET: Film/Edit/5
        public ActionResult Edit(int id)
        {
            Message msg = SM.GetById(id);
            MessageModels msgM = new MessageModels();
            msgM.idMessage = msg.idMessage;
            msgM.Contenu = msg.Contenu;
            msgM.Date = msg.Date;
            //  msgM.messagetype = msg.messageTypes;

            //msgM.Received = msg.Received;

            List<MessageType> msgType = new List<MessageType> { MessageType.Reclamation, MessageType.Satisfaction, MessageType.Probleme_Technique };
            ViewData["type"] = new SelectList(msgType);
            return View(msgM);
        }

          // POST: Message/Edit/5
          [HttpPost]
            public ActionResult Edit(int id, FormCollection collection,MessageModels Msg)
            {
                try
                {

                MessageModelType messageS;
                Enum.TryParse("Satisfaction", out messageS);

                MessageModelType messageR;
                Enum.TryParse("Reclamation", out messageR);



                Message msg = SM.GetById(id);
                msg.Contenu = Msg.Contenu;
                msg.Date = Msg.Date;

                if (Msg.messagetype == messageS)
                {
                    msg.messageTypes = MessageType.Satisfaction;
                }
                else if (Msg.messagetype == messageR)
                { msg.messageTypes = MessageType.Reclamation; }
                else
                {
                    msg.messageTypes = MessageType.Probleme_Technique;
                }
                SM.Update(msg);
                SM.Commit();

              
                return RedirectToAction("Details", new { id = Msg.idMessage });
                }
                catch
                {
                    return View();
                }
            }

        // GET: Message/Delete/5
        public ActionResult Delete(int id)
        {
            Message msg = SM.GetById(id);
            MessageModels msgM = new MessageModels();
            msgM.Contenu = msg.Contenu;
            msgM.Date = msg.Date;
         
            msgM.Received = msg.Received;

            if (msgM == null)
                return View("NotFound");
            else
                return View(msgM);

            
        }

      // POST: Message/Delete/5
        [HttpPost]
          public ActionResult Delete(int id, FormCollection collection)
          {
              try
              {
                // TODO: Add delete logic here
                Message msg = SM.GetById(id);
                SM.Delete(msg);
                SM.Commit();

                  return RedirectToAction("Index");
              }
              catch
              {
                  return View();
              }
          }


        // GET: Message/Repondre/5
        public ActionResult Repondre(int id)
        {
            
            MessageModels msgM = new MessageModels();
            msgM.UsersId = id;
            //  msgM.messagetype = msg.messageTypes;

            //msgM.Received = msg.Received;

           
            return View(msgM);
        }

        // POST: Message/Repondre/5
        [HttpPost]
        public ActionResult Repondre(int id, FormCollection collection, MessageModels Msg)
        {
            try
            {

                

                Message msg =new Message();
                Message msgModif = new Message();
               // msgModif = SM.GetById(idM);
              //  msgModif.Received = true;
                msg.Contenu = Msg.Contenu;
                msg.Date = Msg.Date;
                msg.UsersId = id;
                msg.messageTypes = MessageType.Reponse;
                msg.Received = true;

              //  SM.Add(msgModif);
                SM.Add(msg);
                SM.Commit();


                return RedirectToAction("IndexAdmin");
            }
            catch
            {
                return View();
            }
        }

    }
}



