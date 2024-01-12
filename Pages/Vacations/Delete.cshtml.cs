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
    public class DeleteModel : PageModel
    {
        private readonly ProiectSite.Data.ProiectSiteContext _context;

        public DeleteModel(ProiectSite.Data.ProiectSiteContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Vacation Vacation { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Vacation == null)
            {
                return NotFound();
            }

            var vacation = await _context.Vacation.FirstOrDefaultAsync(m => m.Id == id);

            if (vacation == null)
            {
                return NotFound();
            }
            else 
            {
                Vacation = vacation;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Vacation == null)
            {
                return NotFound();
            }
            var vacation = await _context.Vacation.FindAsync(id);

            if (vacation != null)
            {
                Vacation = vacation;
                _context.Vacation.Remove(Vacation);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
