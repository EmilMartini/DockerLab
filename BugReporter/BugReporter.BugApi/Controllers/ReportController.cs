using BugReporter.BugApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BugReporter.BugApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        Random rnd;
        HttpClient client;
        string baseUrl;

        public ReportController()
        {
            client = new HttpClient();
            rnd = new Random();
            baseUrl = "http://localhost:1337/api/Database";
        }

        [HttpPost]
        [Route("Bug")]
        public IActionResult CreateBug(string description)
        {
            var bug = new Bug()
            {
                Id = rnd.Next(0, int.MaxValue),
                Description = description
            };

            var response = client.GetAsync(baseUrl + "/File").Result;
            if (response.IsSuccessStatusCode)
            {
                var bugs = JsonConvert.DeserializeObject<List<Bug>>(response.Content.ReadAsStringAsync().Result);

                while(bugs.Where(i => i.Id == bug.Id).ToList().Count > 0)
                {
                    bug.Id = rnd.Next(0, int.MaxValue);
                }

                bugs.Add(bug);

                var httpContent = new HttpRequestMessage(HttpMethod.Post, baseUrl + "/File");
                httpContent.Headers.Add("content-type", "application/json");
                httpContent.Content = new StringContent(JsonConvert.SerializeObject(bugs), Encoding.UTF8, "application/json");

                response = client.SendAsync(httpContent).Result;

                if (response.IsSuccessStatusCode)
                {
                    return Ok();
                }
            }

            return BadRequest();
        }
    }

    //ta in string skapa en bug, skicka till DB

    // hämta lista på alla !DONE buggar och retunera den listan

    // hämta lista på alla DONE buggar och returnar den listan

    // ta in ID på bug och byta status på den buggen
}
