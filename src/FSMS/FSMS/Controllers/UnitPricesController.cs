using FSMS.Data;
using FSMS.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FSMS.Controllers
{
    public class UnitPricesController : Controller
    {
        private readonly AppDbContext _context;

        public UnitPricesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: UnitPrices
        public async Task<IActionResult> Index()
        {
            return View(await _context.UnitPrices.ToListAsync());
        }

        // GET: UnitPrices/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unitPrice = await _context.UnitPrices
                .FirstOrDefaultAsync(m => m.Id == id);
            if (unitPrice == null)
            {
                return NotFound();
            }

            return View(unitPrice);
        }

        // GET: UnitPrices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UnitPrices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Fuel,Price")] UnitPrice unitPrice)
        {
            if (ModelState.IsValid)
            {
                unitPrice.Id = Guid.NewGuid();
                _context.Add(unitPrice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(unitPrice);
        }

        // GET: UnitPrices/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unitPrice = await _context.UnitPrices.FindAsync(id);
            if (unitPrice == null)
            {
                return NotFound();
            }
            return View(unitPrice);
        }

        // POST: UnitPrices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Fuel,Price")] UnitPrice unitPrice)
        {
            if (id != unitPrice.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unitPrice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnitPriceExists(unitPrice.Id))
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
            return View(unitPrice);
        }

        // GET: UnitPrices/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unitPrice = await _context.UnitPrices
                .FirstOrDefaultAsync(m => m.Id == id);
            if (unitPrice == null)
            {
                return NotFound();
            }

            return View(unitPrice);
        }

        // POST: UnitPrices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var unitPrice = await _context.UnitPrices.FindAsync(id);
            if (unitPrice != null)
            {
                _context.UnitPrices.Remove(unitPrice);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UnitPriceExists(Guid id)
        {
            return _context.UnitPrices.Any(e => e.Id == id);
        }
    }
}
