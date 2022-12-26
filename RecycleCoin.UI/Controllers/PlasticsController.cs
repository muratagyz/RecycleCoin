using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecycleCoin.UI.Context;
using RecycleCoin.UI.Models;

namespace RecycleCoin.UI.Controllers
{
    public class PlasticsController : BaseController
    {
        private readonly RecycleCoinDbContext _context;

        public PlasticsController(RecycleCoinDbContext context)
        {
            _context = context;
        }

        // GET: Plastics
        public async Task<IActionResult> Index()
        {
              return View(await _context.Plastics.ToListAsync());
        }

        // GET: Plastics/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Plastics == null)
            {
                return NotFound();
            }

            var plastic = await _context.Plastics
                .FirstOrDefaultAsync(m => m.Id == id);
            if (plastic == null)
            {
                return NotFound();
            }

            return View(plastic);
        }

        // GET: Plastics/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Plastics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Object,CarbonValue,Id")] Plastic plastic)
        {
            if (ModelState.IsValid)
            {
                plastic.Id = Guid.NewGuid();
                _context.Add(plastic);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(plastic);
        }

        // GET: Plastics/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Plastics == null)
            {
                return NotFound();
            }

            var plastic = await _context.Plastics.FindAsync(id);
            if (plastic == null)
            {
                return NotFound();
            }
            return View(plastic);
        }

        // POST: Plastics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Object,CarbonValue,Id")] Plastic plastic)
        {
            if (id != plastic.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(plastic);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlasticExists(plastic.Id))
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
            return View(plastic);
        }

        // GET: Plastics/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Plastics == null)
            {
                return NotFound();
            }

            var plastic = await _context.Plastics
                .FirstOrDefaultAsync(m => m.Id == id);
            if (plastic == null)
            {
                return NotFound();
            }

            return View(plastic);
        }

        // POST: Plastics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Plastics == null)
            {
                return Problem("Entity set 'RecycleCoinDbContext.Plastics'  is null.");
            }
            var plastic = await _context.Plastics.FindAsync(id);
            if (plastic != null)
            {
                _context.Plastics.Remove(plastic);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlasticExists(Guid id)
        {
          return _context.Plastics.Any(e => e.Id == id);
        }
    }
}
