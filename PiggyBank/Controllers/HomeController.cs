using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PiggyBank.Models.ViewModels;

namespace PiggyBank.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View("Menu");
        }

        public IActionResult Help()
        {
            return View();
        }

        public IActionResult Menu()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
