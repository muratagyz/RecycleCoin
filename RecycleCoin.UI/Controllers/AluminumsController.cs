using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecycleCoin.UI.Context;
using RecycleCoin.UI.Models;

namespace RecycleCoin.UI.Controllers
{
    public class AluminumsController : BaseController
    {
        private readonly RecycleCoinDbContext _context;

        public AluminumsController(RecycleCoinDbContext context)
        {
            _context = context;
        }

        // GET: Aluminums
        public async Task<IActionResult> Index()
        {
              return View(await _context.Aluminums.ToListAsync());
        }

        // GET: Aluminums/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Aluminums == null)
            {
                return NotFound();
            }

            var aluminum = await _context.Aluminums
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aluminum == null)
            {
                return NotFound();
            }

            return View(aluminum);
        }

        // GET: Aluminums/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Aluminums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Object,CarbonValue,Id")] Aluminum aluminum)
        {
            if (ModelState.IsValid)
            {
                aluminum.Id = Guid.NewGuid();
                _context.Add(aluminum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aluminum);
        }

        // GET: Aluminums/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Aluminums == null)
            {
                return NotFound();
            }

            var aluminum = await _context.Aluminums.FindAsync(id);
            if (aluminum == null)
            {
                return NotFound();
            }
            return View(aluminum);
        }

        // POST: Aluminums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Object,CarbonValue,Id")] Aluminum aluminum)
        {
            if (id != aluminum.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aluminum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AluminumExists(aluminum.Id))
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
            return View(aluminum);
        }

        // GET: Aluminums/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Aluminums == null)
            {
                return NotFound();
            }

            var aluminum = await _context.Aluminums
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aluminum == null)
            {
                return NotFound();
            }

            return View(aluminum);
        }

        // POST: Aluminums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Aluminums == null)
            {
                return Problem("Entity set 'RecycleCoinDbContext.Aluminums'  is null.");
            }
            var aluminum = await _context.Aluminums.FindAsync(id);
            if (aluminum != null)
            {
                _context.Aluminums.Remove(aluminum);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AluminumExists(Guid id)
        {
          return _context.Aluminums.Any(e => e.Id == id);
        }
    }
}
