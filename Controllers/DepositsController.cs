using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index([FromQuery] AllDepositsQueryModel querySearch, int? depositId, decimal desiredAmount)
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

            if (depositId != null && DepositExists(depositId.Value))
            {
                querySearch.CalculatedAmount = CalculateAmountAtEndOfTerm(this._context.Deposits
                .FirstOrDefault(m => m.Id == depositId), 1000);
                querySearch.SelectedDepositId = depositId;
            }

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

        private static decimal CalculateAmountAtEndOfTerm(Deposit deposit, decimal amount)
        {
            decimal interestRate = deposit.AnnualInterestRate / 100.00m;
            decimal finalAmount = amount;
            int period = deposit.Term;

            if (deposit.ClientType == ClientType.VIP)
            {
                interestRate *= 1.1m;
            }

            if (deposit.InterestPayment == InterestPayment.Monthly)
            {
                interestRate /= 12;
            }
            else if (deposit.InterestPayment == InterestPayment.Quarterly)
            {
                interestRate /= 4;
                period /= 4;
            }
            else if (deposit.InterestPayment == InterestPayment.Yearly)
            {
                period /= 12;
            }

            for (int i = 0; i < period; i++)
            {
                decimal interest = finalAmount * interestRate;
                finalAmount += interest;
            }

            return finalAmount;
        }
    }
}
