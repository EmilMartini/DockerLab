using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using RestSharp;
using System.Net;
using System.Net.Http;

namespace BugReporter.FrontEnd.Pages
{
    public class ReportModel : PageModel
    {
        public string Description { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }
        public IActionResult OnPost()
        {
            var description = Request.Form["description"].ToString();
            if (description != "")
            {
                var restClient = new RestClient("http://bugreporter.bugapi/api/Report");
                var request = new RestRequest("/Bug", Method.POST);
                request.RequestFormat = DataFormat.Json;
                request.AddJsonBody(description);
                request.AddHeader("Sec-Fetch-Dest", "document");
                var restResponse = restClient.Execute(request);
            }
            return Page();
        }
    }
}
