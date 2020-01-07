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

            try
            {
                List<UserModel> user = userDAL.GetAll();
                ViewBag.user = user;

                UserController userController = new UserController();
                UserModel user2 = userController.GetUserByName("sadfasdfsadfasfsadfsad");

                ViewBag.user2 = user2.username;
            }
            catch (Exception e)
            {

                throw e;
            }
            

            return View();
        }


    
        
        




        
    }
}
