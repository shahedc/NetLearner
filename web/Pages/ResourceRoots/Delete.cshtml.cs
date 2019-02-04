using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NetLearnerWeb.Models;
using web.Data;

namespace NetLearnerWeb.Pages.ResourceRoots
{
    public class DeleteModel : PageModel
    {
        private readonly web.Data.ApplicationDbContext _context;

        public DeleteModel(web.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ResourceRoot ResourceRoot { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ResourceRoot = await _context.ResourceRoot.FirstOrDefaultAsync(m => m.Id == id);

            if (ResourceRoot == null)
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

            ResourceRoot = await _context.ResourceRoot.FindAsync(id);

            if (ResourceRoot != null)
            {
                _context.ResourceRoot.Remove(ResourceRoot);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
