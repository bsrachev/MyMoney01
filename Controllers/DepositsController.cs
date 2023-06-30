using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyMoney.Data;
using MyMoney.Data.Models;
using MyMoney.Data.Models.Enums;
using MyMoney.Models.Deposits;

namespace MyMoney.Controllers
{
    public class DepositsController : Controller
    {
        private readonly MyMoneyDbContext _context;

        public DepositsController(MyMoneyDbContext context)
        {
            _context = context;
        }

        // GET: Deposits
        public IActionResult Index([FromQuery] AllDepositsQueryModel querySearch, int? depositId)
        {
            var queryResult = this._context.Deposits.AsQueryable();

            if (querySearch.CurrencySearch != 0)
            {
                queryResult = queryResult.Where(c => c.Currency == querySearch.CurrencySearch);
            }

            querySearch.Deposits = queryResult.
                Select(d => new SingleDepositModel
                {
                    AnnualInterestRate = d.AnnualInterestRate,
                    MinimalAmount = d.MinimalAmount,
                    ClientType = d.ClientType,
                    CreditFacility = d.CreditFacility,
                    Currency = d.Currency,
                    Id = d.Id,
                    InterestPayment = d.InterestPayment,
                    IsInterestFixed = d.IsInterestFixed,
                    OverdraftFacility = d.OverdraftFacility,
                    Term = d.Term
                }); //.ToList();

            if (depositId != null)
            {
                querySearch.CalculatedAmount = CalculateAmountAtEndOfTerm(this._context.Deposits
                .FirstOrDefault(m => m.Id == depositId), 10000);
                querySearch.SelectedDepositId = depositId;
            }

            //var categories = this.products.AllCategories();

            //query.TotalProducts = queryResult.TotalProducts;
            //query.Products = queryResult.Products;
            //query.Categories = categories;

            return View(querySearch);
        }

        // GET: Deposits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Deposits == null)
            {
                return NotFound();
            }

            var deposit = await _context.Deposits
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deposit == null)
            {
                return NotFound();
            }

            return View(deposit);
        }

        private bool DepositExists(int id)
        {
          return (_context.Deposits?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public static decimal CalculateAmountAtEndOfTerm(Deposit deposit, decimal amount)
        {
            decimal interestRate = deposit.AnnualInterestRate / 100.00m;
            decimal finalAmount = amount;
            int period = deposit.Term;

            // Adjust the interest rate based on the client type
            if (deposit.ClientType == ClientType.VIP)
            {
                interestRate *= 1.1m; // Apply a 10% increase for VIP clients
            }

            // Adjust the interest rate based on the interest payment type
            if (deposit.InterestPayment == InterestPayment.Monthly)
            {
                interestRate /= 12; // Apply monthly compounding
                period *= 12;
            }
            else if (deposit.InterestPayment == InterestPayment.Quarterly)
            {
                interestRate /= 4; // Apply quarterly compounding
                period *= 3;
            }

            // Calculate the final amount at the end of the deposit term

            for (int i = 0; i < period / 12; i++)
            {
                decimal interest = finalAmount * interestRate;
                finalAmount += interest;

                // Apply overdraft facility if available
                if (deposit.OverdraftFacility && finalAmount < deposit.MinimalAmount)
                {
                    finalAmount = deposit.MinimalAmount; // Set the final amount to the minimal amount
                }

                // Apply credit facility if available
                if (deposit.CreditFacility && finalAmount > deposit.MinimalAmount)
                {
                    finalAmount -= deposit.MinimalAmount; // Deduct the minimal amount from the final amount
                }
            }

            return finalAmount;
        }
    }
}
