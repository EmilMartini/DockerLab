using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugReporter.Frontend.Pages
{
    public class ReportModel : PageModel
    {
        public string Description { get; set; }
        public void OnGet()
        {

        }
        public void OnPostCreate(string description)
        {
            // ta in description och posta till api
        }
    }
}
