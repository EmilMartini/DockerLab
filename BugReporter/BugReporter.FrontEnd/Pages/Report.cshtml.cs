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

namespace BugReporter.Frontend.Pages
{
    public class ReportModel : PageModel
    {
        public string Description { get; set; }
        public void OnGet()
        {

        }
        public void OnPost()
        {
            var description = Request.Form["description"].ToString();

            var restClient = new RestClient("http://localhost:1336/api/Report");
            var request = new RestRequest("/Bug", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(description);
            var restResponse = restClient.Execute(request);
        }
    }
}
