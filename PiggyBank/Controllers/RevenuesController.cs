using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PiggyBank.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PiggyBank.Models.ViewModels;
using PiggyBank.Models;
using PiggyBank.Services.Exceptions;
using System.Diagnostics;

namespace PiggyBank.Controllers
{
    public class RevenuesController : Controller
    {
        private readonly RevenueService _revenueService;
        private readonly AccountService _accountService;
        IHttpContextAccessor HttpContextAccessor;

        public RevenuesController(RevenueService revenueService, AccountService accountService, IHttpContextAccessor httpContextAccessor)
        {
            _revenueService = revenueService;
            _accountService = accountService;
            HttpContextAccessor = httpContextAccessor;
        }

        public async Task<IActionResult> Index()
        {
            var idUser = HttpContextAccessor.HttpContext.Session.GetString("LoggedInUserId");
            var list = await _revenueService.FindAllAsync(int.Parse(idUser));
            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            var idUser = HttpContextAccessor.HttpContext.Session.GetString("LoggedInUserId");
            var accounts = await _accountService.FindAllAsync(int.Parse(idUser));
            var viewModel = new RevenueFormViewModel { Accounts = accounts};
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Revenue revenue)
        {
            if (!ModelState.IsValid)
            {
                var idUser = HttpContextAccessor.HttpContext.Session.GetString("LoggedInUserId");
                var accounts = await _accountService.FindAllAsync(int.Parse(idUser));
                var viewModel = new RevenueFormViewModel { Revenue = revenue, Accounts = accounts };
                return View(viewModel);
            }
            await _revenueService.InsertAsync(revenue);
            await _accountService.AddRevenueAsync(revenue);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido"});
            }

            var obj = await _revenueService.FindByIdAsync(id.Value);
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
            await _accountService.RemoveRevenueAsync(id);
            await _revenueService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            var obj = await _revenueService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }

            return View(obj);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            var obj = await _revenueService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }

            var idUser = HttpContextAccessor.HttpContext.Session.GetString("LoggedInUserId");
            List<Account> accounts = await _accountService.FindAllAsync(int.Parse(idUser));
            RevenueFormViewModel viewModel = new RevenueFormViewModel { Revenue = obj, Accounts = accounts };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Revenue revenue)
        {
            if (!ModelState.IsValid)
            {
                var idUser = HttpContextAccessor.HttpContext.Session.GetString("LoggedInUserId");
                var accounts = await _accountService.FindAllAsync(int.Parse(idUser));
                var viewModel = new RevenueFormViewModel { Revenue = revenue, Accounts = accounts };
                return View(viewModel);
            }

            if (id != revenue.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não compatível" });
            }

            try
            {
                await _revenueService.UpdateAsync(revenue);
                return RedirectToAction(nameof(Index));
            }
            catch(NotFoundException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
            catch (DbConcurrencyException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
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
    }
}