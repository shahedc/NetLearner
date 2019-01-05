using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NetLearnerWeb.Models;
using web.Data;

namespace NetLearnerWeb.Pages.LearningResources
{
    public class CreateModel : PageModel
    {
        private readonly web.Data.ApplicationDbContext _context;

        public CreateModel(web.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public LearningResource LearningResource { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.LearningResource.Add(LearningResource);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}