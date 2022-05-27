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
using whatsappWeb.Services;

namespace whatsappWeb.Controllers
{
    public class RankingsController : Controller
    {
        private readonly whatsappWebContext _context;
        private readonly IRankingsService _service;

        public RankingsController(IRankingsService service, whatsappWebContext context)
        {
            _service = service;
            _context = context;
        }

        // GET: Rankings
        public Task<IActionResult> Index()
        {
            return _service.Index(_context);
        }

        public Task<IActionResult> Search()
        {
            return _service.Search(_context);
        }

        [HttpPost]
        public Task<IActionResult> Search(string query)
        {
            return _service.Search(_context, query);
        }

        public Task<IActionResult> Search2(string query)
        {
            return _service.Search2(_context, query);
        }

        // GET: Rankings/Details/5
        public Task<IActionResult> Details(int? id)
        {
            return _service.Details(_context, id);
        }

        // GET: Rankings/Create
        public IActionResult Create()
        {
            return _service.Create(_context);
        }

        // POST: Rankings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public Task<IActionResult> Create(int Id, int score, string feedback, string author)
        {
            return _service.Create(_context, Id, score, feedback, author);
        }

        // GET: Rankings/Edit/5
        public Task<IActionResult> Edit(int? id)
        {
           return _service.Edit(_context, id);
        }

        // POST: Rankings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public Task<IActionResult> Edit(int id, [Bind("Id,score,feedback,author,date,time")] Ranking ranking)
        {
            return _service.Edit(_context, id, ranking);
        }

        // GET: Rankings/Delete/5
        public Task<IActionResult> Delete(int? id)
        {
            return _service.Delete(_context, id);
        }

        // POST: Rankings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public Task<IActionResult> DeleteConfirmed(int id)
        {
            return _service.DeleteConfirmed(_context, id);
        }
    }
}
