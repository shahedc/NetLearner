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
    public class IndexModel : PageModel
    {
        private readonly web.Data.ApplicationDbContext _context;

        public IndexModel(web.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<RssFeed> RssFeed { get;set; }

        public async Task OnGetAsync()
        {
            RssFeed = await _context.RssFeed.ToListAsync();
        }
    }
}
