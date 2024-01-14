using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectSite.Data;
using ProiectSite.Models;

namespace ProiectSite.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly ProiectSite.Data.ProiectSiteContext _context;

        public IndexModel(ProiectSite.Data.ProiectSiteContext context)
        {
            _context = context;
        }

        public IList<User> User { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.User != null)
            {
                User = await _context.User.ToListAsync();
            }
        }
    }
}
