using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecycleCoin.UI.Context;
using RecycleCoin.UI.Models;

namespace RecycleCoin.UI.Controllers
{
    public class PapersController : BaseController
    {
        private readonly RecycleCoinDbContext _context;

        public PapersController(RecycleCoinDbContext context)
        {
            _context = context;
        }

        // GET: Papers
        public async Task<IActionResult> Index()
        {
              return View(await _context.Papers.ToListAsync());
        }

        // GET: Papers/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Papers == null)
            {
                return NotFound();
            }

            var paper = await _context.Papers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paper == null)
            {
                return NotFound();
            }

            return View(paper);
        }

        // GET: Papers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Papers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Object,CarbonValue,Id")] Paper paper)
        {
            if (ModelState.IsValid)
            {
                paper.Id = Guid.NewGuid();
                _context.Add(paper);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(paper);
        }

        // GET: Papers/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Papers == null)
            {
                return NotFound();
            }

            var paper = await _context.Papers.FindAsync(id);
            if (paper == null)
            {
                return NotFound();
            }
            return View(paper);
        }

        // POST: Papers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Object,CarbonValue,Id")] Paper paper)
        {
            if (id != paper.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paper);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaperExists(paper.Id))
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
            return View(paper);
        }

        // GET: Papers/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Papers == null)
            {
                return NotFound();
            }

            var paper = await _context.Papers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paper == null)
            {
                return NotFound();
            }

            return View(paper);
        }

        // POST: Papers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Papers == null)
            {
                return Problem("Entity set 'RecycleCoinDbContext.Papers'  is null.");
            }
            var paper = await _context.Papers.FindAsync(id);
            if (paper != null)
            {
                _context.Papers.Remove(paper);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaperExists(Guid id)
        {
          return _context.Papers.Any(e => e.Id == id);
        }
    }
}
