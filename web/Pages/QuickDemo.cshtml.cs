using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NetLearnerWeb.Pages
{
    public class QuickDemoModel : PageModel
    {
        public string Message { get; set; }

        public void OnGet()
        {
            Message = $"The time is now {DateTime.UtcNow}";
        }
    }
}