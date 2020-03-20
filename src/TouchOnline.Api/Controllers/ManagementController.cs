using Microsoft.AspNetCore.Mvc;
using TouchOnline.CqrsClient.Contracts;
using TouchOnline.CqrsClient.Management;

namespace TouchOnline.Api.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("api/[controller]/[action]")]
    public class ManagementController : ControllerBase
    {
        private readonly IProcessor _processor;
        public ManagementController(IProcessor processor)
        {
            _processor = processor;
        }

        public IActionResult GetUsers()
        {
            return Ok(_processor.Get(new GetUsers()));
        }

        public IActionResult GetCounts()
        {
            return Ok(_processor.Get(new GetCounts()));
        }
    }
}