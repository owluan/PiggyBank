using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using PiggyBank.Models;
using PiggyBank.Models.ViewModels;
using PiggyBank.Services;
using PiggyBank.Services.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace PiggyBank.Controllers
{
    public class AccountsController : Controller
    {
        private readonly AccountService _accountService;
        private readonly UserService _userService;
        private readonly ExpenseService _expenseService;
        private readonly RevenueService _revenueService;
        IHttpContextAccessor HttpContextAccessor;

        public AccountsController(AccountService accountService, UserService userService, ExpenseService expenseService, RevenueService revenueService, IHttpContextAccessor httpContextAccessor)
        {
            _accountService = accountService;
            _userService = userService;
            _expenseService = expenseService;
            _revenueService = revenueService;
            HttpContextAccessor = httpContextAccessor;
        }

        public async Task<IActionResult> Index()
        {
            var idUser = HttpContextAccessor.HttpContext.Session.GetString("LoggedInUserId");
            var list = await _accountService.FindAllAsync(int.Parse(idUser));
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Account account)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(Create));
            }
            try
            {
                await _accountService.InsertAsync(account);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            var obj = await _accountService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _accountService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            var obj = await _accountService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Account account)
        {
            if (!ModelState.IsValid)
            {                
                return View(account);
            }

            if (id != account.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não compatível" });
            }

            try
            {
                await _accountService.UpdateAsync(account);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
            catch (DbConcurrencyException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
                        
        }

        public IActionResult Records()
        {
            return View();
        }

        public async Task<IActionResult> ExpenseSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
            var result = await _expenseService.FindByDateAsync(minDate, maxDate);
            return View(result);
        }

        public async Task<IActionResult> RevenueSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
            var result = await _revenueService.FindByDateAsync(minDate, maxDate);
            return View(result);
        }

        public async Task<IActionResult> Dashboard()
        {
            var idUser = HttpContextAccessor.HttpContext.Session.GetString("LoggedInUserId");
            var expenses = await _expenseService.DashAsync(int.Parse(idUser));
            var revenues = await _revenueService.DashAsync(int.Parse(idUser));
            ViewBag.Value1 = expenses;
            ViewBag.Value2 = revenues;
            ViewBag.Labels = "'Expenses','Revenues'";
            ViewBag.Cores = "'#696969','#4682B4'";
            return View();
        }
    }
}