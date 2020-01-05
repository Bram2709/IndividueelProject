using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReserveringsApp.Models;
using MODEL;
using DAL;
using MODEL.Restaurant;
using LOGIC;

using MODEL.Reservation;

namespace ReserveringsApp.Controllers
{
    public class HomeController : Controller
    {
        UserDAL userDAL = new UserDAL();
        ReservationDAL reservationDAL = new ReservationDAL();

        ReservationController reservationController = new ReservationController();
        RestaurantController restaurantController = new RestaurantController();

        public IActionResult Index()
        {
            //ReserveringContext context = HttpContext.RequestServices.GetService(typeof(ReserveringsApp.Models.ReserveringContext)) as ReserveringContext;
           
            List<UserModel> user = userDAL.GetAll();
            ViewBag.user = user;
            return View();
        }

        public IActionResult AdminPage()
        {
            var reserveringen = reservationController.GetAll();
            var restaurant = restaurantController.GetAll();

            var model = new RestaurantAndReserveringModel { Restaurants = restaurant.ToList(), Reserveringen = reserveringen.ToList() };

            return View(model);
        }

        [HttpPost]
        public IActionResult AdminPage(string restaurant)
        {
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
            

            userDAL.AddUser(uniqueUser);

            return RedirectToAction("Inloggen");
        }


        public IActionResult MedewerkerPage()
        {
            return View();
        }

        public IActionResult Reserveren()
        {
            var restaurant = restaurantController.GetAllRestaurantNames();

            var model = new RestaurantAndEmptyReserveringModel { Restaurants = restaurant.ToList()};

            return View(model);
        }

        [HttpPost]
        public IActionResult Reserveren(RestaurantAndEmptyReserveringModel restaurantAndEmptyReserveringModel)
        {
           //kijk of de personen nog in het resorant kunnen

            //kijk of er bij het gekozen restaurant nog tafels vrij zijn

            //FUNCTIE getAvaliblePlaces
            


            reservationDAL.AddReservation(restaurantAndEmptyReserveringModel.Reserveringen);

            return View();

        }

        
    }
}
