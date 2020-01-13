using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LOGIC;
using Microsoft.AspNetCore.Mvc;
using MODEL;
using Microsoft.AspNetCore.Http;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReserveringsApp.Controllers
{
    public class AdminController : Controller
    {
        ReservationsController reservationController = new ReservationsController();
        RestaurantController restaurantController = new RestaurantController();

        public IActionResult AdminPage()
        {
            int userLvl = 0;
            try
            {
                userLvl = (int)HttpContext.Session.GetInt32("UserLvl");
            }
            catch (Exception)
            {
                userLvl = 0;
               
            }





            if (userLvl == 0 && userLvl < 5)
            {
                return View("Views/Login/Inloggen.cshtml");
            }
            else
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
            
        }

        [HttpPost]
        public IActionResult AdminPage(string restaurant)
        {
            return View();
        }
    }
}
