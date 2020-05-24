using Newtonsoft.Json;
using ProjectMaleabAlKorbV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectMaleabAlKorbV2.Controllers
{
    public class AdminController : Controller
    {
        MalaebAlKorbEntities db = new MalaebAlKorbEntities();

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
         //Test Commit 
        public ActionResult Registers()
        {
            return View();
        }

        //Show all players in table registers
        public JsonResult GetPlyarsList()
        {
            List<Player> playerList = db.Players.ToList<Player>();

            return Json(playerList, JsonRequestBehavior.AllowGet);
        }

        //ADD PLAYERS
        public JsonResult SaveDataInDatabase(Player model)
        {
            var result = false;
            if (ModelState.IsValid)
                try
                {
                    if (model.playerNo > 0)
                    {
                        Player player = db.Players.Where(p =>p.playerNo == model.playerNo).FirstOrDefault();
                        player.names = model.names;
                        player.emails = model.emails;
                        player.passwords = model.passwords;
                        player.phone = model.phone;
                        db.SaveChanges();
                        result = true;
                    }
                    else
                    {
                        model.dateCreated = DateTime.Now;
                        db.Players.Add(model);
                        db.SaveChanges();
                        result = true;
                    }
                   
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            return Json(result, JsonRequestBehavior.AllowGet);
        }


        // Update Player
        public JsonResult GetPlayerById(int playerNo)
        {
            Player model = db.Players.Where(x => x.playerNo == playerNo).FirstOrDefault();
            string value = string.Empty;
            value = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }


        //Delete Player
        public JsonResult DeletePlayer(int playerNo)
        {
            bool result = false;
            Player player = db.Players.Where(p => p.playerNo == playerNo ).FirstOrDefault();
            if (player != null)
            {
                //player.dateCreated = DateTime.Now;
                db.Players.Remove(player);
                db.SaveChanges();
                result = true;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Reservations()
        {
            return View();
        }
        /***********************Contact**********************************/
        public ActionResult Contact()
        {
            return View();
        }
        
        public JsonResult GetContactList()
        {
            List<Contact> ContactList = db.Contacts.ToList<Contact>();

            return Json(ContactList, JsonRequestBehavior.AllowGet);
        }

        //ADD Contact
        public JsonResult SaveDataInDatabaseContact(Contact model)
        {
            var result = false;
            if (ModelState.IsValid)
                try
                {
                    if (model.messageNo > 0)
                    {
                        Contact player = db.Contacts.Where(p => p.messageNo == model.messageNo).FirstOrDefault();
                        player.name = model.name;
                        player.emails = model.emails;
                        player.allMessage = model.allMessage;
                        db.SaveChanges();
                        result = true;
                    }
                    else
                    {
                        model.dateMessage = DateTime.Now;
                        db.Contacts.Add(model);
                        db.SaveChanges();
                        result = true;
                    }
                    
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            return Json(result, JsonRequestBehavior.AllowGet);
        }


        // Update Contact
        public JsonResult GetContactById(int msgNo)
        {
            Contact model = db.Contacts.Where(x => x.messageNo == msgNo).FirstOrDefault();
            string value = string.Empty;
            value = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        // Delete contact
        public JsonResult DeleteeContact(int msgNo)
        {
            bool result = false;
            Contact cnt = db.Contacts.Where(c => c.messageNo == msgNo).FirstOrDefault();
            if (cnt != null)
            {
                
                db.Contacts.Remove(cnt);
                db.SaveChanges();
                result = true;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }


        /***********************Staduim****************************/
        public ActionResult Stadium()
        {
            return View();
        }
        //show the list
        public JsonResult GetStadiumList()
        {
            List<Stadium> stadiumList = db.Stadia.ToList<Stadium>();

            return Json(stadiumList, JsonRequestBehavior.AllowGet);
        }

        //ADD Contact
        public JsonResult SaveDataInStadiumTable(Stadium model)
        {
            var result = false;
            if (ModelState.IsValid)
                try
                {
                    if (model.stadiumNo > 0)
                    {
                        Stadium stadium = db.Stadia.Where(s => s.stadiumNo == model.stadiumNo).FirstOrDefault();
                        stadium.stadiumName = model.stadiumName;
                        stadium.stadiumCity = model.stadiumCity;
                        stadium.stadiumCapacity = model.stadiumCapacity;
                        db.SaveChanges();
                        result = true;
                    }
                    else
                    {
                        
                        db.Stadia.Add(model);
                        db.SaveChanges();
                        result = true;
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // Update Stadium
        public JsonResult GetStadiumById(int stdID)
        {
            Stadium model = db.Stadia.Where(s => s.stadiumNo == stdID).FirstOrDefault();
            string value = string.Empty;
            value = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        //Delete Stadium
        public JsonResult DeleteStadium(int stadiumNo)
        {
            bool result = false;
            Stadium stadium = db.Stadia.Where(s => s.stadiumNo == stadiumNo).FirstOrDefault();
            if (stadium != null)
            {
                
                db.Stadia.Remove(stadium);
                db.SaveChanges();
                result = true;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}