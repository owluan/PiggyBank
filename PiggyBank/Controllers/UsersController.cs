using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PiggyBank.Models;
using PiggyBank.Services;
using Microsoft.AspNetCore.Http;

namespace PiggyBank.Controllers
{
    
    public class UsersController : Controller
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Login(int? id)
        {
            if (id != null)
            {
                if (id == 0)
                {
                    HttpContext.Session.SetString("LoggedInUserName", string.Empty);
                    HttpContext.Session.SetString("LoggedInUserEmail", string.Empty);
                    HttpContext.Session.SetString("LoggedInUserId", string.Empty);
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ValidarLogin(User user)
        {
            var obj = await _userService.ValidarLoginAsync(user);
            if (obj != null)
            {
                HttpContext.Session.SetString("LoggedInUserName", obj.Name);
                HttpContext.Session.SetString("LoggedInUserEmail", obj.Email);
                HttpContext.Session.SetString("LoggedInUserId", obj.Id.ToString());
                return RedirectToAction("Menu", "Home");
            }
            else
            {
                TempData["InvalidLoginMessage"] = "Invalid Login Data!";
                return RedirectToAction("Login");
            }
        }             

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("Id,Name,Email,Password")] User user)
        {
            await _userService.InsertAsync(user);
            return RedirectToAction(nameof(Success));
        }

        public IActionResult Success()
        {
            return View();
        }
        
    }
}
