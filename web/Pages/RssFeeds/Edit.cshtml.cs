using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NetLearnerWeb.Models;
using web.Data;

namespace NetLearnerWeb.Pages.RssFeeds
{
    public class EditModel : PageModel
    {
        private readonly web.Data.ApplicationDbContext _context;

        public EditModel(web.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(RssFeed).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RssFeedExists(RssFeed.Id))
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

        private bool RssFeedExists(int id)
        {
            return _context.RssFeed.Any(e => e.Id == id);
        }
    }
}
