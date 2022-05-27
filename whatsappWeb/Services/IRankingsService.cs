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

namespace whatsappWeb.Services
{
    public interface IRankingsService
    {
        Task<IActionResult> Index(whatsappWebContext _context);
        Task<IActionResult> Search(whatsappWebContext _context);
        Task<IActionResult> Search(whatsappWebContext _context, string query);
        Task<IActionResult> Search2(whatsappWebContext _context, string query);
        Task<IActionResult> Details(whatsappWebContext _context, int? id);
        IActionResult Create(whatsappWebContext _context);
        Task<IActionResult> Create(whatsappWebContext _context, int Id, int score, string feedback, string author);
        Task<IActionResult> Edit(whatsappWebContext _context, int? id);
        Task<IActionResult> Edit(whatsappWebContext _context, int id, Ranking ranking);
        Task<IActionResult> Delete(whatsappWebContext _context, int? id);
        Task<IActionResult> DeleteConfirmed(whatsappWebContext _context, int id);
        bool RankingExists(whatsappWebContext _context, int id);
    }
}
