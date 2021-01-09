using BugReporter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugReporter.Frontend.Pages
{
    public class ViewModel : PageModel
    {
        public List<Bug> BugsToComplete { get; set; }
        public void OnGet()
        {
            UpdateBugsToComplete();
        }
        public IActionResult OnPost(int id)
        {
            //TODO api call skicka id för att byta status
            UpdateBugsToComplete();
            return Page();
        }
        private void UpdateBugsToComplete()
        {
            //TODO api call för att hämta lista av buggar
            BugsToComplete = new List<Bug>()
            {
                new Bug()
                {
                    Id = 1,
                    Description = "test 1",
                },
                new Bug()
                {
                    Id = 2,
                    Description = "test 2",
                },
                new Bug()
                {
                    Id = 3,
                    Description = "test 3",
                }
            };
        }
    }
}
