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
            ChangeBugStatusDoneToTrue(id);
            UpdateBugsToComplete();
            return Page();
        }
        private void UpdateBugsToComplete()
        {
            var restClient = new RestClient("http://bugreporter.bugapi:80/api/Report");
            var request = new RestRequest("/Bug", Method.GET);
            request.RequestFormat = DataFormat.Json;
            request.AddQueryParameter("done", "false");
            var restResponse = restClient.Execute(request);
            BugsToComplete = JsonConvert.DeserializeObject<List<Bug>>(restResponse.Content);
        }
        private void ChangeBugStatusDoneToTrue(int id)
        {
            var restClient = new RestClient("http://bugreporter.bugapi:80/api/Report");
            var request = new RestRequest("/Bug", Method.PUT);
            request.RequestFormat = DataFormat.Json;
            request.AddQueryParameter("id", id.ToString());
            request.AddQueryParameter("status", "true");
            var restResponse = restClient.Execute(request);
        }
    }
}
