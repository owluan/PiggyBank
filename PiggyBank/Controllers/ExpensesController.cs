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
    public class ExpensesController : Controller
    {
        private readonly ExpenseService _expenseService;
        private readonly AccountService _accountService;
        IHttpContextAccessor HttpContextAccessor;

        public ExpensesController(ExpenseService ExpenseService, AccountService accountService, IHttpContextAccessor httpContextAccessor)
        {
            _expenseService = ExpenseService;
            _accountService = accountService;
            HttpContextAccessor = httpContextAccessor;
        }

        public async Task<IActionResult> Index()
        {
            var idUser = HttpContextAccessor.HttpContext.Session.GetString("LoggedInUserId");
            var list = await _expenseService.FindAllAsync(int.Parse(idUser));
            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            var idUser = HttpContextAccessor.HttpContext.Session.GetString("LoggedInUserId");
            var accounts = await _accountService.FindAllAsync(int.Parse(idUser));
            var viewModel = new ExpenseFormViewModel { Accounts = accounts};
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Expense Expense)
        {
            if (!ModelState.IsValid)
            {
                var idUser = HttpContextAccessor.HttpContext.Session.GetString("LoggedInUserId");
                var accounts = await _accountService.FindAllAsync(int.Parse(idUser));
                var viewModel = new ExpenseFormViewModel { Expense = Expense, Accounts = accounts };
                return View(viewModel);
            }
            await _expenseService.InsertAsync(Expense);
            await _accountService.AddCostAsync(Expense);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido"});
            }

            var obj = await _expenseService.FindByIdAsync(id.Value);
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
            await _accountService.RemoveCostAsync(id);
            await _expenseService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            var obj = await _expenseService.FindByIdAsync(id.Value);
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

            var obj = await _expenseService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }

            var idUser = HttpContextAccessor.HttpContext.Session.GetString("LoggedInUserId");
            List<Account> accounts = await _accountService.FindAllAsync(int.Parse(idUser));
            ExpenseFormViewModel viewModel = new ExpenseFormViewModel { Expense = obj, Accounts = accounts };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Expense Expense)
        {
            if (!ModelState.IsValid)
            {
                var idUser = HttpContextAccessor.HttpContext.Session.GetString("LoggedInUserId");
                var accounts = await _accountService.FindAllAsync(int.Parse(idUser));
                var viewModel = new ExpenseFormViewModel { Expense = Expense, Accounts = accounts };
                return View(viewModel);
            }

            if (id != Expense.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não compatível" });
            }

            try
            {
                await _expenseService.UpdateAsync(Expense);
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