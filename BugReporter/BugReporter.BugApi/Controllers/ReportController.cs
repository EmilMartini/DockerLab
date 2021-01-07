using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugReporter.BugApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
    }

    //ta in string skapa en bug, skicka till DB

    // hämta lista på alla !DONE buggar och retunera den listan

    // hämta lista på alla DONE buggar och returnar den listan

    // ta in ID på bug och byta status på den buggen
}
