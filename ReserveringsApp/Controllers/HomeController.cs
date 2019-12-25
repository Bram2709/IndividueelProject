using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReserveringsApp.Models;
using MODEL;
using DAL;

using MODEL.Reservation;

namespace ReserveringsApp.Controllers
{
    public class HomeController : Controller
    {
        UserDAL userDAL = new UserDAL();
        ReservationDAL reservering = new ReservationDAL();

        public IActionResult Index()
        {
            //ReserveringContext context = HttpContext.RequestServices.GetService(typeof(ReserveringsApp.Models.ReserveringContext)) as ReserveringContext;
           
            List<UserModel> user = userDAL.GetAll();
            ViewBag.user = user;
            return View();
        }

        public IActionResult AdminPage()
        {
            var reserveringen = reservering.GetAll();
            return View(reserveringen);
        }

        public IActionResult Inloggen()
        {

            return View();
        }

        
        public IActionResult Registreren()
        {

            return View();
        }

        [HttpPost]
        public RedirectToActionResult Registreren(UserModel uniqueUser)
        {
            

            userDAL.AddUser(uniqueUser);

            return RedirectToAction("Inloggen");
        }


        public IActionResult MedewerkerPage()
        {
            return View();
        }

        public IActionResult Reserveren()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Reserveren(ReservationModel reserveringModel)
        {
            
            reservering.AddReservation(reserveringModel);

            return View();

        }

        
    }
}
