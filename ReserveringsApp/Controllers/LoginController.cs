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
        // GET: /<controller>/
        public IActionResult Inloggen()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Inloggen(string username,string password)
        {
            UserController userController = new UserController();
            if(userController.LoginCheck(username, password))
            {
                UserModel user = userController.GetUserByName(username);

                HttpContext.Session.SetString("UserID", user.userID.ToString());
                HttpContext.Session.SetString("Username", user.username.ToString());
            }
            return View();
        }
    }
}
