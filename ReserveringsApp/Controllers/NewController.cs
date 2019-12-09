using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReserveringsApp.Models;


namespace ReserveringsApp.Controllers
{
    public class NewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public string Welcome2()
        {
            return "Welcome";
        }
    }
}