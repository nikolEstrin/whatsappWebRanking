#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using whatsappWeb.Data;
using whatsappWeb.Models;

namespace whatsappWeb.Controllers
{
    public class AllRankingsController : Controller
    {
        private readonly whatsappWebContext _context;

        public AllRankingsController(whatsappWebContext context)
        {
            _context = context;
        }

        // GET: AllRankings
        public async Task<IActionResult> Index()
        {
            return View(await _context.AllRankings.ToListAsync());
        }

        // GET: AllRankings/Details/5
        public async Task<IActionResult> Details(float? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allRankings = await _context.AllRankings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (allRankings == null)
            {
                return NotFound();
            }

            return View(allRankings);
        }

        // GET: AllRankings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AllRankings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] AllRankings allRankings)
        {
            if (ModelState.IsValid)
            {
                _context.Add(allRankings);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(allRankings);
        }

        // GET: AllRankings/Edit/5
        public async Task<IActionResult> Edit(float? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allRankings = await _context.AllRankings.FindAsync(id);
            if (allRankings == null)
            {
                return NotFound();
            }
            return View(allRankings);
        }

        // POST: AllRankings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(float id, [Bind("Id")] AllRankings allRankings)
        {
            if (id != allRankings.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(allRankings);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AllRankingsExists(allRankings.Id))
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
            return View(allRankings);
        }

        // GET: AllRankings/Delete/5
        public async Task<IActionResult> Delete(float? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allRankings = await _context.AllRankings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (allRankings == null)
            {
                return NotFound();
            }

            return View(allRankings);
        }

        // POST: AllRankings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(float id)
        {
            var allRankings = await _context.AllRankings.FindAsync(id);
            _context.AllRankings.Remove(allRankings);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AllRankingsExists(float id)
        {
            return _context.AllRankings.Any(e => e.Id == id);
        }
    }
}
