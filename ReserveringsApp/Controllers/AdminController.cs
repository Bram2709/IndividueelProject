using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LOGIC;
using Microsoft.AspNetCore.Mvc;
using MODEL;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReserveringsApp.Controllers
{
    public class AdminController : Controller
    {
        ReservationsController reservationController = new ReservationsController();
        RestaurantController restaurantController = new RestaurantController();

        public IActionResult AdminPage()
        {
            RestaurantAndReserveringModel model = new RestaurantAndReserveringModel();
            try
            {
                var reserveringen = reservationController.GetAll();
                var restaurant = restaurantController.GetAll();

                model = new RestaurantAndReserveringModel { Restaurants = restaurant.ToList(), Reserveringen = reserveringen.ToList() };
            }
            catch (Exception)
            {
                throw;
            }
            

            return View(model);
        }

        [HttpPost]
        public IActionResult AdminPage(string restaurant)
        {
            return View();
        }
    }
}
