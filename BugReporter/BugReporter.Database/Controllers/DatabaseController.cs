using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BugReporter.Database.Controllers
{
    [Route("Database")]
    [ApiController]
    public class DatabaseController : ControllerBase
    {
        private DatabaseClient dbClient;

        public DatabaseController()
        {
            dbClient = new DatabaseClient();
        }

        [HttpPost]
        [Route("SaveToFile")]
        public IActionResult SaveToFile([FromBody]string content)
        {
            dbClient.SaveToFile(content);
            return new OkObjectResult("Successfully saved file.");
        }
    }
}
