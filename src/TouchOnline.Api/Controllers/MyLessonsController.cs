using Microsoft.AspNetCore.Mvc;
using TouchOnline.CqrsClient.Contracts;

namespace TouchOnline.Api.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("api/[controller]/[action]")]
    public class MyLessonsController: ControllerBase
    {
        private readonly IProcessor _processor;
        public MyLessonsController(IProcessor processor)
        {
            _processor = processor;
        }

        [HttpPost]
        public IActionResult SaveMyTextLesson() 
        {
            return Ok();
        }
    }
}