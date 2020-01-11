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
            RestaurantAndEmptyReserveringModel model = new RestaurantAndEmptyReserveringModel();
            try
            {
                var restaurant = restaurantController.GetAllRestaurantNames();

                model = new RestaurantAndEmptyReserveringModel { Restaurants = restaurant.ToList() };
            }
            catch (Exception)
            {

                throw;
            }
            

            return View(model);
        }

        [HttpPost]
        public IActionResult Reserveren(RestaurantAndEmptyReserveringModel model)
        {
            RestaurantAndEmptyReserveringModel models = new RestaurantAndEmptyReserveringModel();
            
                if (reservationController.TryToAddReservation(model.Reserveringen, restaurantController.GetRestaurantModelByName(model.Reserveringen.restaurant)))//max aantal mensen van het restaurant < current aantal mensen + reserveringen.AmountOfPeaple
                {
                    ViewBag.Result = "Toveogen van reservering is gelukt";

                    if (true)
                    {

                    }
                }
                else
                {
                    ViewBag.Result = "Toevoegen van de reservering is mislukt";
                }

                var restaurant = restaurantController.GetAllRestaurantNames();

                models = new RestaurantAndEmptyReserveringModel { Restaurants = restaurant.ToList() };
          

            return View(models);

        }

    
    }
}
