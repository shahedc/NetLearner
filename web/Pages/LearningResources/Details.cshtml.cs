using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NetLearnerWeb.Models;
using web.Data;

namespace NetLearnerWeb.Pages.LearningResources
{
    public class DetailsModel : PageModel
    {
        private readonly web.Data.ApplicationDbContext _context;

        public DetailsModel(web.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
