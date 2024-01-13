using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProiectSite.Data;
using ProiectSite.Models;

namespace ProiectSite.Pages.Reservations
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
        ViewData["VacationId"] = new SelectList(_context.Vacation, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Reservation Reservation { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          /*if (!ModelState.IsValid || _context.Reservation == null || Reservation == null)
            {
                return Page();
            }*/

            _context.Reservation.Add(Reservation);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
