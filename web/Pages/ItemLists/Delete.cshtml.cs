using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NetLearnerWeb.Models;
using web.Data;

namespace NetLearnerWeb.Pages.ItemLists
{
    public class DeleteModel : PageModel
    {
        private readonly web.Data.ApplicationDbContext _context;

        public DeleteModel(web.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ItemList ItemList { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ItemList = await _context.ItemList.FirstOrDefaultAsync(m => m.Id == id);

            if (ItemList == null)
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

            ItemList = await _context.ItemList.FindAsync(id);

            if (ItemList != null)
            {
                _context.ItemList.Remove(ItemList);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
