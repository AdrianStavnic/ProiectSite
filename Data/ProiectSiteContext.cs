using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProiectSite.Models;

namespace ProiectSite.Data
{
    public class ProiectSiteContext : DbContext
    {
        public ProiectSiteContext (DbContextOptions<ProiectSiteContext> options)
            : base(options)
        {
        }

        public DbSet<ProiectSite.Models.Vacation> Vacation { get; set; } = default!;

        public DbSet<ProiectSite.Models.Category>? Category { get; set; }

        public DbSet<ProiectSite.Models.Reservation>? Reservation { get; set; }
    
        public DbSet<ProiectSite.Models.User>? User { get; set; }
    }
}
