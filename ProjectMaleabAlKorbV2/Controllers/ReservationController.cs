using ProjectMaleabAlKorbV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectMaleabAlKorbV2.Controllers
{
    [HandleError]
    public class ReservationController : Controller
    {
        MalaebAlKorbEntities db = new MalaebAlKorbEntities();
        // GET: Reservation
        public ActionResult Index()
        {
            if (Session["emails"] != null)
            {
         
                var items = db.StadiumByCities.ToList();
                if (items != null)
                {
                    ViewBag.data = items;
                }

                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            // return View();

        }

        //[HttpPost]
        //public ActionResult Index(Reservation reservation)
        //{
        //    var Exist = db.Reservations.Where(r => r.reservationDate == reservation.reservationDate && r.reservationTime == reservation.reservationTime).FirstOrDefault();
        //    if (Exist == null)
        //    {
        //        reservation.dateReservation = DateTime.Now;
        //        reservation.Email = "johari_Tijani12@gmail.com";
        //        //Session["emails"].ToString();
        //        db.Reservations.Add(reservation);
        //        db.SaveChanges();
        //    }
        //    else
        //    {
        //        ViewBag.ShowError = "Ok";
                
        //    }
           
        //    return View();
        //}

        public JsonResult resSaveData(Reservation res)
        {
            var result = "input Error";

            if (ModelState.IsValid)
            {
                result = "fail";
                var Exist = db.Reservations.Where(r => r.reservationDate == res.reservationDate && r.reservationTime == res.reservationTime).FirstOrDefault();
                if (Exist == null)
                {
                    res.dateReservation = DateTime.Now;
                    res.Email = Session["emails"].ToString();
                    res.FullName = Session["names"].ToString();
                    res.Phone = Session["phone"].ToString();
                    db.Reservations.Add(res);
                    db.SaveChanges();
                    result = "success";
                }

            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}