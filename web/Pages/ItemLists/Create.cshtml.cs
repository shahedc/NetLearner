using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NetLearnerWeb.Models;
using web.Data;

namespace NetLearnerWeb.Pages.ItemLists
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
        public ItemList ItemList { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ItemList.Add(ItemList);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}