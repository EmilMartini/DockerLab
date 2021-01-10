using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace BugReporter.Database.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatabaseController : ControllerBase
    {
        private DatabaseClient dbClient;

        public DatabaseController()
        {
            dbClient = new DatabaseClient();
        }

        [HttpPost]
        [Route("File")]
        public IActionResult SaveToFile([FromBody]List<Bug> content)
        {
            var bugs = JsonConvert.SerializeObject(content);

            if (String.IsNullOrEmpty(bugs))
                return NoContent();

            if (dbClient.SaveToFile(bugs))
            {
                return new OkObjectResult("Successfully saved file.");
            } else
            {
                return new BadRequestObjectResult("Something went wrong");
            }
        }

        [HttpGet]
        [Route("File")]
        public IActionResult ReadFromFile()
        {
            return new OkObjectResult(dbClient.ReadFromFile());
        }
    }
}
