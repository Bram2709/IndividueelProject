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
        public IActionResult Index()
        {
            //ReserveringContext context = HttpContext.RequestServices.GetService(typeof(ReserveringsApp.Models.ReserveringContext)) as ReserveringContext;
            UserDAL userDal = new UserDAL();
            List<UserModel> user = userDal.GetAll();
            ViewBag.user = user;
            return View();
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
            UserDAL userDAL = new UserDAL();

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
            ReservationDAL reservering = new ReservationDAL();
            reservering.AddReservation(reserveringModel);

            return View();

        }
    }
}
