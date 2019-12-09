using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReserveringsApp.Models;
using MODEL;
using DAL;

namespace ReserveringsApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //ReserveringContext context = HttpContext.RequestServices.GetService(typeof(ReserveringsApp.Models.ReserveringContext)) as ReserveringContext;
            UserDAL userDal = new UserDAL();
            UserModel user = userDal.GetAll();
            ViewBag.user = user;
            return View();
        }

        public IActionResult Reserveren()
        {
            return View();
        }

        public IActionResult Inloggen()
        {

            return View();
        }

        
        public IActionResult Registreren()
        {

            return View();
        }

        [HttpPost]
        public RedirectToActionResult Registreren(UserModel uniqueUser)
        {
            UserDAL userDAL = new UserDAL();

            userDAL.AddUser(uniqueUser);

            return RedirectToAction("Inloggen");
        }


        public IActionResult MedewerkerPage()
        {
            return View();
        }

        //public IActionResult About()
        //{
        //    ViewData["Message"] = "Your application description page.";

        //    return View();
        //}

        //public IActionResult Contact()
        //{
        //    ViewData["Message"] = "Your contact page.";

        //    return View();
        //}

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
