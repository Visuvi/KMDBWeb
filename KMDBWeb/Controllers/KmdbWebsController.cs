using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KMDBWeb.Data;
using KMDBWeb.Models;

namespace KMDBWeb.Controllers
{
    public class KmdbWebsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KmdbWebsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: KmdbWebs
        public async Task<IActionResult> Index()
        {
            return View(await _context.KmdbWeb.ToListAsync());
        }

        // GET: KmdbWebs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kmdbWeb = await _context.KmdbWeb
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kmdbWeb == null)
            {
                return NotFound();
            }

            return View(kmdbWeb);
        }

        // GET: KmdbWebs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KmdbWebs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,thumbNail,Title,Genre,UserRating")] KmdbWeb kmdbWeb)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kmdbWeb);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kmdbWeb);
        }

        // GET: KmdbWebs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kmdbWeb = await _context.KmdbWeb.FindAsync(id);
            if (kmdbWeb == null)
            {
                return NotFound();
            }
            return View(kmdbWeb);
        }

        // POST: KmdbWebs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,thumbNail,Title,Genre,UserRating")] KmdbWeb kmdbWeb)
        {
            if (id != kmdbWeb.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kmdbWeb);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KmdbWebExists(kmdbWeb.Id))
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
            return View(kmdbWeb);
        }

        // GET: KmdbWebs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kmdbWeb = await _context.KmdbWeb
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kmdbWeb == null)
            {
                return NotFound();
            }

            return View(kmdbWeb);
        }

        // POST: KmdbWebs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kmdbWeb = await _context.KmdbWeb.FindAsync(id);
            _context.KmdbWeb.Remove(kmdbWeb);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KmdbWebExists(int id)
        {
            return _context.KmdbWeb.Any(e => e.Id == id);
        }
    }
}
