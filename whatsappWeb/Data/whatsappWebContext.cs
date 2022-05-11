#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using whatsappWeb.Models;

namespace whatsappWeb.Data
{
    public class whatsappWebContext : DbContext
    {
        public whatsappWebContext (DbContextOptions<whatsappWebContext> options)
            : base(options)
        {
        }

        public DbSet<whatsappWeb.Models.Ranking> Ranking { get; set; }
    }
}
