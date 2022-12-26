using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecycleCoin.UI.Context;
using RecycleCoin.UI.Models;

namespace RecycleCoin.UI.Controllers
{
    public class IronsController : BaseController
    {
        private readonly RecycleCoinDbContext _context;

        public IronsController(RecycleCoinDbContext context)
        {
            _context = context;
        }

        // GET: Irons
        public async Task<IActionResult> Index()
        {
              return View(await _context.Irons.ToListAsync());
        }

        // GET: Irons/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Irons == null)
            {
                return NotFound();
            }

            var iron = await _context.Irons
                .FirstOrDefaultAsync(m => m.Id == id);
            if (iron == null)
            {
                return NotFound();
            }

            return View(iron);
        }

        // GET: Irons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Irons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Object,CarbonValue,Id")] Iron iron)
        {
            if (ModelState.IsValid)
            {
                iron.Id = Guid.NewGuid();
                _context.Add(iron);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(iron);
        }

        // GET: Irons/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Irons == null)
            {
                return NotFound();
            }

            var iron = await _context.Irons.FindAsync(id);
            if (iron == null)
            {
                return NotFound();
            }
            return View(iron);
        }

        // POST: Irons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Object,CarbonValue,Id")] Iron iron)
        {
            if (id != iron.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(iron);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IronExists(iron.Id))
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
            return View(iron);
        }

        // GET: Irons/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Irons == null)
            {
                return NotFound();
            }

            var iron = await _context.Irons
                .FirstOrDefaultAsync(m => m.Id == id);
            if (iron == null)
            {
                return NotFound();
            }

            return View(iron);
        }

        // POST: Irons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Irons == null)
            {
                return Problem("Entity set 'RecycleCoinDbContext.Irons'  is null.");
            }
            var iron = await _context.Irons.FindAsync(id);
            if (iron != null)
            {
                _context.Irons.Remove(iron);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IronExists(Guid id)
        {
          return _context.Irons.Any(e => e.Id == id);
        }
    }
}
