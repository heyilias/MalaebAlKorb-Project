using ProjectMaleabAlKorbV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectMaleabAlKorbV2.Controllers
{
    public class HomeController : Controller
    {
        MalaebAlKorbEntities db = new MalaebAlKorbEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            
            return View();
        }

        public ActionResult Contact()
        {  

            return View();
        }

        public JsonResult SaveDataInDatabase(Contact model)
        {
            var result = false;
            try
            {
                if (model.messageNo > 0)
                {
                    Response.Write("<script>console.log('messageNo > 0')</script>");
                    Contact contact = db.Contacts.SingleOrDefault(x => x.messageNo == model.messageNo);
                    contact.name = model.name;
                    contact.emails = model.emails;
                    contact.allMessage = model.allMessage;
                    contact.dateMessage = DateTime.Now;
                    db.SaveChanges();
                    result = true;
                }
                else
                {
                    Response.Write("<script>console.log('else')</script>");
                    Contact contact = new Contact();
                    contact.name = model.name;
                    contact.emails = model.emails;
                    contact.allMessage = model.allMessage;
                    contact.dateMessage = DateTime.Now;
                    db.Contacts.Add(contact);
                    db.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex + "')</script>");
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}