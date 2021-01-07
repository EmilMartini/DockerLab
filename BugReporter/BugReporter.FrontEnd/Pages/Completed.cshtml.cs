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
    public class CompletedModel : PageModel
    {
        public List<Bug> CompletedBugs { get; set; }
        public void OnGet()
        {
            UpdateCompletedBugs();
        }
        public IActionResult OnPost(int id)
        {
            //TODO api call skicka id för att byta status
            UpdateCompletedBugs();
            return Page();
        }
        private void UpdateCompletedBugs()
        {
            //TODO api call för att hämta lista av buggar
            CompletedBugs = new List<Bug>()
            {
                new Bug()
                {
                    Id = 1,
                    Description = "asdfadfdasfasf",
                },
                new Bug()
                {
                    Id = 2,
                    Description = "sdfgsfdgsd",
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
