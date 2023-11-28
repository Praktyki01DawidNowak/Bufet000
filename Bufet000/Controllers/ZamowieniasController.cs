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
    public class ZamowieniasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ZamowieniasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Zamowienias
        public async Task<IActionResult> Index()
        {
              return _context.Zamowienia != null ? 
                          View(await _context.Zamowienia.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Zamowienia'  is null.");
        }

        // GET: Zamowienias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Zamowienia == null)
            {
                return NotFound();
            }

            var zamowienia = await _context.Zamowienia
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zamowienia == null)
            {
                return NotFound();
            }

            return View(zamowienia);
        }

        // GET: Zamowienias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zamowienias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Zamowienie,Data,Cena,IdKanapki,IdUzytkownik,IdStatus")] Zamowienia zamowienia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zamowienia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zamowienia);
        }

        // GET: Zamowienias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Zamowienia == null)
            {
                return NotFound();
            }

            var zamowienia = await _context.Zamowienia.FindAsync(id);
            if (zamowienia == null)
            {
                return NotFound();
            }
            return View(zamowienia);
        }

        // POST: Zamowienias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Zamowienie,Data,Cena,IdKanapki,IdUzytkownik,IdStatus")] Zamowienia zamowienia)
        {
            if (id != zamowienia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zamowienia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZamowieniaExists(zamowienia.Id))
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
            return View(zamowienia);
        }

        // GET: Zamowienias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Zamowienia == null)
            {
                return NotFound();
            }

            var zamowienia = await _context.Zamowienia
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zamowienia == null)
            {
                return NotFound();
            }

            return View(zamowienia);
        }

        // POST: Zamowienias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Zamowienia == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Zamowienia'  is null.");
            }
            var zamowienia = await _context.Zamowienia.FindAsync(id);
            if (zamowienia != null)
            {
                _context.Zamowienia.Remove(zamowienia);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZamowieniaExists(int id)
        {
          return (_context.Zamowienia?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
