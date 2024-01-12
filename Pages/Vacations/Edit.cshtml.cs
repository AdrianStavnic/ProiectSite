using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProiectSite.Data;
using ProiectSite.Models;

namespace ProiectSite.Pages.Vacations
{
    public class EditModel : PageModel
    {
        private readonly ProiectSite.Data.ProiectSiteContext _context;

        public EditModel(ProiectSite.Data.ProiectSiteContext context)
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

            var vacation =  await _context.Vacation.FirstOrDefaultAsync(m => m.Id == id);
            if (vacation == null)
            {
                return NotFound();
            }
            Vacation = vacation;
            ViewData["CategoryID"] = new SelectList(_context.Set<Category>(), "Id", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Vacation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VacationExists(Vacation.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool VacationExists(int id)
        {
          return (_context.Vacation?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
