using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectSite.Data;
using ProiectSite.Models;

namespace ProiectSite.Pages.Vacations
{
    public class IndexModel : PageModel
    {
        private readonly ProiectSite.Data.ProiectSiteContext _context;

        public IndexModel(ProiectSite.Data.ProiectSiteContext context)
        {
            _context = context;
        }

        public IList<Vacation> Vacation { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Vacation != null)
            {
                Vacation = await _context.Vacation
                    .Include(b => b.Category)
                    .ToListAsync();
            }
        }
    }
}
