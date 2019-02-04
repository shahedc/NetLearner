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

namespace NetLearnerWeb.Pages.ResourceCatalogs
{
    public class EditModel : PageModel
    {
        private readonly web.Data.ApplicationDbContext _context;

        public EditModel(web.Data.ApplicationDbContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ResourceCatalog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResourceCatalogExists(ResourceCatalog.Id))
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

        private bool ResourceCatalogExists(int id)
        {
            return _context.ResourceCatalog.Any(e => e.Id == id);
        }
    }
}
