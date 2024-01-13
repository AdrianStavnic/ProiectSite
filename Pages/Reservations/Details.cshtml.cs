using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectSite.Data;
using ProiectSite.Models;

namespace ProiectSite.Pages.Reservations
{
    public class DetailsModel : PageModel
    {
        private readonly ProiectSite.Data.ProiectSiteContext _context;

        public DetailsModel(ProiectSite.Data.ProiectSiteContext context)
        {
            _context = context;
        }

      public Reservation Reservation { get; set; } = default!; 
      public Vacation Vacation { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Reservation == null)
            {
                return NotFound();
            }

            Reservation = await _context.Reservation
                .Include(r => r.Vacation)
                .FirstOrDefaultAsync(m => m.ID == id);
            
            if (Reservation == null)
            {
                return NotFound();
            }
            else 
            {
                Reservation = Reservation;
            }

            Vacation = Reservation.Vacation;
            return Page();
        }
    }
}
