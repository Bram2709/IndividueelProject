using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LOGIC;
using Microsoft.AspNetCore.Http;
using MODEL;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReserveringsApp.Controllers
{
    public class LoginController : Controller
    {
        User user = new User();
        UserController userController = new UserController();
        // GET: /<controller>/
        public IActionResult Inloggen()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Inloggen(string username,string password)
        {
            
            if(user.LoginCheck(username, password))
            {
                UserModel user = userController.GetUserByName(username);

                HttpContext.Session.SetInt32("UserID", user.userID);
                HttpContext.Session.SetString("Username", user.username.ToString());
                HttpContext.Session.SetInt32("UserLvl", user.lvl);
            }
            return View();
        }
    }
}


//SELECT `reservering`.`Naam`,`reservering`.`Datum`, `reservering`.`TelNr`, `reservering`.`AantalPersonen`, `reservering`.`Opmerkingen`,`table`.`RestaurantID` FROM `reservering` LEFT JOIN `table`  ON `reservering`.`ReserveringID` = `table`.`ReservationID`

//SELECT `reservering`.`Naam`,`reservering`.`Datum`, `reservering`.`TelNr`, `reservering`.`AantalPersonen`, `reservering`.`Opmerkingen`,`table`.`RestaurantID` FROM `reservering` INNER JOIN `table`  ON `reservering`.`ReserveringID` = `table`.`ReservationID`

//SELECT `reservering`.`Naam`,`reservering`.`Datum`, `reservering`.`TelNr`, `reservering`.`AantalPersonen`, `reservering`.`Opmerkingen`,`restaurant`.`Name`
//FROM `reservering` 
//INNER JOIN `table`  ON `reservering`.`ReserveringID` = `table`.`ReservationID`
//INNER JOIN `restaurant`  ON `restaurant`.`RestaurantID` = `table`.`RestaurantID`
