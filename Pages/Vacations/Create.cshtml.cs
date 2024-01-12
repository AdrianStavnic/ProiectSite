using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProiectSite.Data;
using ProiectSite.Models;

namespace ProiectSite.Pages.Vacations
{
    public class CreateModel : PageModel
    {
        private readonly ProiectSite.Data.ProiectSiteContext _context;

        public CreateModel(ProiectSite.Data.ProiectSiteContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["CategoryID"] = new SelectList(_context.Set<Category>(), "Id","Name");
            return Page();
        }

        [BindProperty]
        public Vacation Vacation { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Vacation == null || Vacation == null)
            {
                return Page();
            }

            _context.Vacation.Add(Vacation);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
