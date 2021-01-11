using BugReporter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugReporter.FrontEnd.Pages
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
            ChangeBugStatusDoneToFalse(id);
            UpdateCompletedBugs();
            return Page();
        }
        private void UpdateCompletedBugs()
        {
            var restClient = new RestClient("http://bugreporter.bugapi:80/api/Report");
            var request = new RestRequest("/Bug", Method.GET);
            request.RequestFormat = DataFormat.Json;
            request.AddQueryParameter("done", "true");
            var restResponse = restClient.Execute(request);
            CompletedBugs = JsonConvert.DeserializeObject<List<Bug>>(restResponse.Content);
        }
        private void ChangeBugStatusDoneToFalse(int id)
        {
            var restClient = new RestClient("http://bugreporter.bugapi:80/api/Report");
            var request = new RestRequest("/Bug", Method.PUT);
            request.RequestFormat = DataFormat.Json;
            request.AddQueryParameter("id", id.ToString());
            request.AddQueryParameter("status", "false");
            var restResponse = restClient.Execute(request);
        }
    }
}
