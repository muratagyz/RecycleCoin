using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecycleCoin.UI.Context;
using RecycleCoin.UI.Models;

namespace RecycleCoin.UI.Controllers
{
    public class PinesController : BaseController
    {
        private readonly RecycleCoinDbContext _context;

        public PinesController(RecycleCoinDbContext context)
        {
            _context = context;
        }

        // GET: Pines
        public async Task<IActionResult> Index()
        {
              return View(await _context.Pines.ToListAsync());
        }

        // GET: Pines/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Pines == null)
            {
                return NotFound();
            }

            var pine = await _context.Pines
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pine == null)
            {
                return NotFound();
            }

            return View(pine);
        }

        // GET: Pines/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Object,CarbonValue,Id")] Pine pine)
        {
            if (ModelState.IsValid)
            {
                pine.Id = Guid.NewGuid();
                _context.Add(pine);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pine);
        }

        // GET: Pines/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Pines == null)
            {
                return NotFound();
            }

            var pine = await _context.Pines.FindAsync(id);
            if (pine == null)
            {
                return NotFound();
            }
            return View(pine);
        }

        // POST: Pines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Object,CarbonValue,Id")] Pine pine)
        {
            if (id != pine.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PineExists(pine.Id))
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
            return View(pine);
        }

        // GET: Pines/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Pines == null)
            {
                return NotFound();
            }

            var pine = await _context.Pines
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pine == null)
            {
                return NotFound();
            }

            return View(pine);
        }

        // POST: Pines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Pines == null)
            {
                return Problem("Entity set 'RecycleCoinDbContext.Pines'  is null.");
            }
            var pine = await _context.Pines.FindAsync(id);
            if (pine != null)
            {
                _context.Pines.Remove(pine);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PineExists(Guid id)
        {
          return _context.Pines.Any(e => e.Id == id);
        }
    }
}
