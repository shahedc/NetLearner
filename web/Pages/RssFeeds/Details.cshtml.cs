using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NetLearnerWeb.Models;
using web.Data;

namespace NetLearnerWeb.Pages.RssFeeds
{
    public class DetailsModel : PageModel
    {
        private readonly web.Data.ApplicationDbContext _context;

        public DetailsModel(web.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public RssFeed RssFeed { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RssFeed = await _context.RssFeed.FirstOrDefaultAsync(m => m.Id == id);

            if (RssFeed == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
