using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LOGIC;
using Microsoft.AspNetCore.Mvc;
using MODEL;
using Microsoft.AspNetCore.Http;
using MODEL.AdvancedModels;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReserveringsApp.Controllers
{
    public class AdminController : Controller
    {
        ReservationsController reservationController = new ReservationsController();
        RestaurantController restaurantController = new RestaurantController();
        TableController tableController = new TableController();

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
                return View();
            }
        }

        [HttpPost]
        public IActionResult AdminPage(string restaurant)
        {
            return View();
        }

        public IActionResult AddTable()
        {
            RestaurantAndTableModel model = new RestaurantAndTableModel();
            model.restaurantModels = restaurantController.GetAll();
            return View(model);
        }

        [HttpPost]
        public IActionResult AddTable(RestaurantAndTableModel model)
        {
            tableController.AddTable(model.tableModel);

            RestaurantAndTableModel restaurantAndTableModel = new RestaurantAndTableModel();
            restaurantAndTableModel.restaurantModels = restaurantController.GetAll();


            return View(restaurantAndTableModel);
        }

        public IActionResult ReservationOverview()
        {
            

            
            List<AllReservationData> model = new List<AllReservationData>();
            try
            {

                model = reservationController.GetAllReservationData();
            }
            catch (Exception)
            {
                throw;
            }


            return View(model);
            

        }


    }
}
