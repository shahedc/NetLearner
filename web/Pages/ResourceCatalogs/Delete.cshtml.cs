using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NetLearnerWeb.Models;
using web.Data;

namespace NetLearnerWeb.Pages.ResourceCatalogs
{
    public class DeleteModel : PageModel
    {
        private readonly web.Data.ApplicationDbContext _context;

        public DeleteModel(web.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ResourceCatalog ResourceCatalog { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ResourceCatalog = await _context.ResourceCatalog.FirstOrDefaultAsync(m => m.Id == id);

            if (ResourceCatalog == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ResourceCatalog = await _context.ResourceCatalog.FindAsync(id);

            if (ResourceCatalog != null)
            {
                _context.ResourceCatalog.Remove(ResourceCatalog);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
