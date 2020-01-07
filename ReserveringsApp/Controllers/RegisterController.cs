using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MODEL;
using LOGIC;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReserveringsApp.Controllers
{
    public class RegisterController : Controller
    {
        UserController userController = new UserController();


        public IActionResult Registreren()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Registreren(UserModel uniqueUser)
        {
            userController.AddUser(uniqueUser);
            //als de user zijn account aanmaakt word hij automatisch ingelogd


            return View("Views/Login/Inloggen.cshtml");
        }
    }
}
