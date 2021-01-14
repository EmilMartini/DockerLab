using BugReporter.BugApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            baseUrl = "http://Bugreporter.database:80/api/Database";
        }

        [HttpPost]
        [Route("Bug")]
        [IgnoreAntiforgeryToken]
        public IActionResult CreateBug([FromBody] string description)
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
                if (bugs == null)
                {
                    bugs = new List<Bug>();
                }
                while (bugs.Where(i => i.Id == bug.Id).ToList().Count > 0)
                {
                    bug.Id = rnd.Next(0, int.MaxValue);
                }
                bugs.Add(bug);

                var restClient = new RestClient(baseUrl);
                var request = new RestRequest("/File", Method.POST);
                request.RequestFormat = DataFormat.Json;
                request.AddJsonBody(bugs);
                var restResponse = restClient.Execute(request);

                if (restResponse.StatusCode == HttpStatusCode.OK)
                {
                    return Ok();
                }
                else
                {
                    return new BadRequestObjectResult(restResponse.Content);
                }
            }
            else
            {
                return new BadRequestObjectResult(response);
            }
        }

        [HttpGet]
        [Route("Bug")]
        public IActionResult GetAllBugs([FromQuery] string done)
        {
            var response = client.GetAsync(baseUrl + "/File").Result;
            if (!response.IsSuccessStatusCode)
            {
                return BadRequest();
            }

            var bugs = JsonConvert.DeserializeObject<List<Bug>>(response.Content.ReadAsStringAsync().Result);
            if (bugs == null)
            {
                return NoContent();
            }
            else
            {
                bool isDone = bool.Parse(done);
                return Ok(bugs.Where(i => i.Done == isDone).ToList());
            }
        }
        
        [HttpPut]
        [IgnoreAntiforgeryToken]
        [Route("Bug")]
        public IActionResult SetBugStatus([FromQuery] string id, string status)
        {
            var bugId = int.Parse(id);
            var bugStatus = bool.Parse(status);
            var response = client.GetAsync(baseUrl + "/File").Result;
            if (!response.IsSuccessStatusCode)
            {
                return BadRequest();
            }

            var content = JsonConvert.DeserializeObject<List<Bug>>(response.Content.ReadAsStringAsync().Result);
            if (content == null)
            {
                return NoContent();
            }

            if (content.Where(i => i.Id == bugId).FirstOrDefault() == null)
            {
                return new BadRequestObjectResult("No bug with that ID.");
            }
            else
            {
                content.Where(i => i.Id == bugId).FirstOrDefault().Done = bugStatus;
            }

            var restClient = new RestClient(baseUrl);
            var request = new RestRequest("/File", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(content);
            var restResponse = restClient.Execute(request);

            if (restResponse.StatusCode == HttpStatusCode.OK)
            {
                return Ok();
            }
            else
            {
                return new BadRequestObjectResult(restResponse.Content);
            }
        }

        [HttpDelete]
        [IgnoreAntiforgeryToken]
        [Route("Bug")]
        public IActionResult DeleteTestCase()
        {
            var response = client.GetAsync(baseUrl + "/File").Result;
            if (!response.IsSuccessStatusCode)
            {
                return BadRequest();
            }

            var content = JsonConvert.DeserializeObject<List<Bug>>(response.Content.ReadAsStringAsync().Result);
            if (content == null)
            {
                return NoContent();
            }

            if (content.Where(i => i.Description == "This is a test log and it is going to be deleted 2545151984654651681635161355165132165416546513521651651").FirstOrDefault() == null)
            {
                return new NoContentResult();
            }
            else
            {
                content = content.Where(i => i.Description != "This is a test log and it is going to be deleted 2545151984654651681635161355165132165416546513521651651").ToList();
            }

            var restClient = new RestClient(baseUrl);
            var request = new RestRequest("/File", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(content);
            var restResponse = restClient.Execute(request);

            if (restResponse.StatusCode == HttpStatusCode.OK)
            {
                return Ok();
            }
            else
            {
                return new BadRequestObjectResult(restResponse.Content);
            }
        }
    }

}
