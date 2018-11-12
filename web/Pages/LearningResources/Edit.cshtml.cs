using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NetLearnerWeb.Data;
using NetLearnerWeb.Models;

namespace NetLearnerWeb.Pages.LearningResources
{
    public class EditModel : PageModel
    {
        private readonly NetLearnerWeb.Data.ApplicationDbContext _context;

        public EditModel(NetLearnerWeb.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public LearningResource LearningResource { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LearningResource = await _context.LearningResource.FirstOrDefaultAsync(m => m.Id == id);

            if (LearningResource == null)
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

            _context.Attach(LearningResource).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LearningResourceExists(LearningResource.Id))
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

        private bool LearningResourceExists(int id)
        {
            return _context.LearningResource.Any(e => e.Id == id);
        }
    }
}
