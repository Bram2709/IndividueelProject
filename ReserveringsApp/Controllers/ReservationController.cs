using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LOGIC;
using MODEL;
using MODEL.Reservation;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReserveringsApp.Controllers
{
    public class ReservationController : Controller
    {
        RestaurantController restaurantController = new RestaurantController();
        ReservationsController reservationController = new ReservationsController();

        public IActionResult Reserveren()
        {
            var restaurant = restaurantController.GetAllRestaurantNames();

            var model = new RestaurantAndEmptyReserveringModel { Restaurants = restaurant.ToList() };

            return View(model);
        }

        [HttpPost]
        public IActionResult Reserveren(RestaurantAndEmptyReserveringModel restaurantAndEmptyReserveringModel)
        {
            //kijk of de personen nog in het resorant kunnen

            //kijk of er bij het gekozen restaurant nog tafels vrij zijn

            //FUNCTIE getAvaliblePlaces

            //new comit

 

            reservationController.AddReservation(restaurantAndEmptyReserveringModel.Reserveringen);

            return View();

        }

    
    }
}
