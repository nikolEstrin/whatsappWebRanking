using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using whatsappWeb.Data;
using whatsappWeb.Models;

namespace whatsappWeb.Services
{
    public class RankingsService : Controller, IRankingsService
    {
        public async Task<IActionResult> Index(whatsappWebContext _context)
        {
            return View(await _context.Ranking.ToListAsync());
        }
        public async Task<IActionResult> Search(whatsappWebContext _context)
        {
            return View(await _context.Ranking.ToListAsync());
        }
        public async Task<IActionResult> Search(whatsappWebContext _context, string query)
        {
            var q = _context.Ranking.Where(r => r.feedback.Contains(query) || r.author.Contains(query));

            return View(await q.ToListAsync());
        }
        public async Task<IActionResult> Search2(whatsappWebContext _context, string query)
        {
            var q = _context.Ranking.Where(r => r.feedback.Contains(query) || r.author.Contains(query));

            return PartialView(await q.ToListAsync());
        }
        public async Task<IActionResult> Details(whatsappWebContext _context, int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ranking = await _context.Ranking.FirstOrDefaultAsync(m => m.Id == id);
            if (ranking == null)
            {
                return NotFound();
            }

            return View(ranking);
        }
        public IActionResult Create(whatsappWebContext _context)
        {
            return View();
        }
        public async Task<IActionResult> Create(whatsappWebContext _context, int Id, int score, string feedback, string author)
        {
            if (ModelState.IsValid)
            {
                _context.Add(new Ranking() { Id = Id, score = score, feedback = feedback, author = author, date = DateTime.Now.ToString("MM/dd/yyyy"), time = DateTime.Now.ToString("HH:mm") });
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Search));
            }
            return View(new Ranking() { Id = Id, score = score, feedback = feedback, author = author, date = "H", time = "H" });
        }
        public async Task<IActionResult> Edit(whatsappWebContext _context, int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ranking = await _context.Ranking.FindAsync(id);
            if (ranking == null)
            {
                return NotFound();
            }
            return View(ranking);
        }
        public async Task<IActionResult> Edit(whatsappWebContext _context, int id, Ranking ranking)
        {
            if (id != ranking.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ranking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RankingExists(_context, ranking.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Search));
            }
            return View(ranking);
        }
        public async Task<IActionResult> Delete(whatsappWebContext _context, int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ranking = await _context.Ranking.FirstOrDefaultAsync(m => m.Id == id);
            if (ranking == null)
            {
                return NotFound();
            }

            return View(ranking);
        }
        public async Task<IActionResult> DeleteConfirmed(whatsappWebContext _context, int id)
        {
            var ranking = await _context.Ranking.FindAsync(id);
            _context.Ranking.Remove(ranking);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Search));
        }
        public bool RankingExists(whatsappWebContext _context, int id)
        {
            return _context.Ranking.Any(e => e.Id == id);
        }
    }
}
