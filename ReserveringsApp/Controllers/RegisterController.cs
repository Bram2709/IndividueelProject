using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MODEL;
using LOGIC;
using Microsoft.AspNetCore.Http;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReserveringsApp.Controllers
{
    public class RegisterController : Controller
    {
        UserController userController = new UserController();
        User user = new User();

        public IActionResult Registreren()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Registreren(UserModel uniqueUser)
        {
            try
            {
                if (userController.AddUser(uniqueUser))
                {
                    ViewBag.RegisterData = "Register Succesfull";
                }
                else
                {
                    ViewBag.RegisterData = "Register Failed";
                }
                

            }
            catch (Exception)
            {

                throw;
            }
            //als de user zijn account aanmaakt word hij automatisch ingelogd


            return View();
        }

        public IActionResult AccountDetails()
        {
            string userName = "";
            try
            {
                userName = HttpContext.Session.GetString("Username");
            }
            catch (Exception)
            {
                userName = "";

            }

            if (userName == ""|| userName == null)
            {
                return View("Views/Login/Inloggen.cshtml");
            }
            else
            {
                UserModel user = userController.GetUserByName(userName);

                UserModelAndEmptyUserModel userModelAndEmptyUserModel = new UserModelAndEmptyUserModel();
                userModelAndEmptyUserModel.UserModelFull = user;

                return View(userModelAndEmptyUserModel);
            } 
        }

        [HttpPost]
        public IActionResult AccountDetails(UserModelAndEmptyUserModel userModel)
        {
            try
            {
                UserModel userData = userController.GetUserByName(HttpContext.Session.GetString("Username"));

                userModel.UserModelEmpty.userID = userData.userID;

                if (userModel.UserModelEmpty.name == null)
                {
                    userModel.UserModelEmpty.name = userData.name;
                }
                if (userModel.UserModelEmpty.telNr == null)
                {
                    userModel.UserModelEmpty.telNr = userData.telNr;
                }
                if (userModel.UserModelEmpty.username == null)
                {
                    userModel.UserModelEmpty.username = userData.username;
                }
                if (userModel.UserModelEmpty.password == null)
                {
                    userModel.UserModelEmpty.password = userData.password;
                }

                user.EditUser(userModel.UserModelEmpty);


                UserModelAndEmptyUserModel userModelAndEmptyUserModel = new UserModelAndEmptyUserModel();
                userModelAndEmptyUserModel.UserModelFull = userData;
            }
            catch (Exception)
            {

                throw;
            }
           

            return Redirect("AccountDetails");
            
        }

        
    }
}
