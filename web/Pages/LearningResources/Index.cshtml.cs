using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NetLearnerWeb.Data;
using NetLearnerWeb.Models;

namespace NetLearnerWeb.Pages.LearningResources
{
    public class IndexModel : PageModel
    {
        private readonly NetLearnerWeb.Data.ApplicationDbContext _context;

        public IndexModel(NetLearnerWeb.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<LearningResource> LearningResource { get;set; }

        public async Task OnGetAsync()
        {
            LearningResource = await _context.LearningResource.ToListAsync();
        }
    }
}
