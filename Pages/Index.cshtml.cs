using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectSite.Data;
using ProiectSite.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProiectSite.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ProiectSiteContext _context;

        public IndexModel(ProiectSiteContext context)
        {
            _context = context;
        }

        public List<Vacation> Vacations { get; set; }

        public async Task<IActionResult> OnGetAsync(int? categoryId)
        {
            if (categoryId.HasValue)
            {
                Vacations = await _context.Vacation
                    .Where(v => v.CategoryID == categoryId)
                    .Include(v => v.Category)
                    .ToListAsync();
            }
            else
            {
                Vacations = await _context.Vacation
                    .Include(v => v.Category)
                    .ToListAsync();
            }

            return Page();
        }
    }
}