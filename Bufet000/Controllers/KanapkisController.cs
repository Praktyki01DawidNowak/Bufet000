using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bufet000.Data;
using Bufet000.Models;

namespace Bufet000.Controllers
{
    public class KanapkisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KanapkisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Kanapkis
        public async Task<IActionResult> Index()
        {
              return _context.Kanapki != null ? 
                          View(await _context.Kanapki.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Kanapki'  is null.");
        }

        // GET: Kanapkis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Kanapki == null)
            {
                return NotFound();
            }

            var kanapki = await _context.Kanapki
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kanapki == null)
            {
                return NotFound();
            }

            return View(kanapki);
        }

        // GET: Kanapkis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kanapkis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdKategoria,Skladniki,CzyDostepne")] Kanapki kanapki)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kanapki);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kanapki);
        }

        // GET: Kanapkis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Kanapki == null)
            {
                return NotFound();
            }

            var kanapki = await _context.Kanapki.FindAsync(id);
            if (kanapki == null)
            {
                return NotFound();
            }
            return View(kanapki);
        }

        // POST: Kanapkis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdKategoria,Skladniki,CzyDostepne")] Kanapki kanapki)
        {
            if (id != kanapki.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kanapki);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KanapkiExists(kanapki.Id))
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
            return View(kanapki);
        }

        // GET: Kanapkis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Kanapki == null)
            {
                return NotFound();
            }

            var kanapki = await _context.Kanapki
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kanapki == null)
            {
                return NotFound();
            }

            return View(kanapki);
        }

        // POST: Kanapkis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Kanapki == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Kanapki'  is null.");
            }
            var kanapki = await _context.Kanapki.FindAsync(id);
            if (kanapki != null)
            {
                _context.Kanapki.Remove(kanapki);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KanapkiExists(int id)
        {
          return (_context.Kanapki?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
