using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyMoney.Areas.Admin.Controllers;
using MyMoney.Data;
using MyMoney.Data.Models;

namespace MyMoney.Areas.Admin.Controllers
{
    public class InsurrancesController : AdminController
    {
        private readonly MyMoneyDbContext _context;

        public InsurrancesController(MyMoneyDbContext context)
        {
            _context = context;
        }

        // GET: Insurrances
        public async Task<IActionResult> Index()
        {
              return _context.Insurrances != null ? 
                          View(await _context.Insurrances.ToListAsync()) :
                          Problem("Entity set 'MyMoneyDbContext.Insurrances'  is null.");
        }

        // GET: Insurrances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Insurrances == null)
            {
                return NotFound();
            }

            var insurrance = await _context.Insurrances
                .FirstOrDefaultAsync(m => m.Id == id);
            if (insurrance == null)
            {
                return NotFound();
            }

            return View(insurrance);
        }

        // GET: Insurrances/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Insurrances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,CoverageAmount,Item,Id,MinimalAmount,Currency,Term,AnnualInterestRate")] Insurrance insurrance)
        {
            if (ModelState.IsValid)
            {
                _context.Add(insurrance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(insurrance);
        }

        // GET: Insurrances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Insurrances == null)
            {
                return NotFound();
            }

            var insurrance = await _context.Insurrances.FindAsync(id);
            if (insurrance == null)
            {
                return NotFound();
            }
            return View(insurrance);
        }

        // POST: Insurrances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,CoverageAmount,Item,Id,MinimalAmount,Currency,Term,AnnualInterestRate")] Insurrance insurrance)
        {
            if (id != insurrance.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(insurrance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InsurranceExists(insurrance.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(insurrance);
        }

        // GET: Insurrances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Insurrances == null)
            {
                return NotFound();
            }

            var insurrance = await _context.Insurrances
                .FirstOrDefaultAsync(m => m.Id == id);
            if (insurrance == null)
            {
                return NotFound();
            }

            return View(insurrance);
        }

        // POST: Insurrances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Insurrances == null)
            {
                return Problem("Entity set 'MyMoneyDbContext.Insurrances'  is null.");
            }
            var insurrance = await _context.Insurrances.FindAsync(id);
            if (insurrance != null)
            {
                _context.Insurrances.Remove(insurrance);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InsurranceExists(int id)
        {
          return (_context.Insurrances?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
