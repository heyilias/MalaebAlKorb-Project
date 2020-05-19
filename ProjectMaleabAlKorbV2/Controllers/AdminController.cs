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
                    model.dateCreated = DateTime.Now;
                    db.Players.Add(model);
                    db.SaveChanges();
                    result = true; 
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //Delete Player
        public JsonResult DeletePlayer(int playerNo)
        {
            bool result = false;
            Player player = db.Players.SingleOrDefault(p => p.playerNo == playerNo );
            if (player != null)
            {
                db.SaveChanges();
                result = true;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Reservations()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
        
        public JsonResult GetContactList()
        {
            List<Contact> ContactList = db.Contacts.ToList<Contact>();

            return Json(ContactList, JsonRequestBehavior.AllowGet);
        }

        //ADD PLAYERS
        public JsonResult SaveDataInDatabaseContact(Contact model)
        {
            var result = false;
            if (ModelState.IsValid)
                try
                {
                    model.dateMessage = DateTime.Now;
                    db.Contacts.Add(model);
                    db.SaveChanges();
                    result = true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            return Json(result, JsonRequestBehavior.AllowGet);
        }


    }
}