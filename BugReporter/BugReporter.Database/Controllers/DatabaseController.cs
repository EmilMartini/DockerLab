using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

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
        public IActionResult SaveToFile([FromBody]string content)
        {
            if (String.IsNullOrEmpty(content))
                return NoContent();

            if (dbClient.SaveToFile(content))
            {
                return new OkObjectResult("Successfully saved file.");
            } else
            {
                return new BadRequestResult();
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
