using Microsoft.AspNetCore.Mvc;
using TouchOnline.CqrsClient.Contracts;
using TouchOnline.CqrsClient.Migration;

namespace TouchOnline.Api.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("api/[controller]/[action]")]
    public class MigrationController : ControllerBase
    {
        private readonly IProcessor _processor;

        public MigrationController(IProcessor processor)
        {
            _processor = processor;
        }

        public IActionResult GetResults()
        {
            return Ok(_processor.Get(new GetResults()));
        }

        public IActionResult GetUsers()
        {
            return Ok(_processor.Get(new GetUsers()));
        }
        public IActionResult GetRecordeds()
        {
            return Ok(_processor.Get(new GetRecordeds()));
        }
        public IActionResult GetKeyboards()
        {
            return Ok(_processor.Get(new GetKeyboards()));
        }
        public IActionResult GetMyTexts()
        {
            return Ok(_processor.Get(new GetMyTexts()));
        }
        public IActionResult GetMessageSupports()
        {
            return Ok(_processor.Get(new GetMessageSupports()));
        }
        public IActionResult GetLessonTexts()
        {
            return Ok(_processor.Get(new GetLessonTexts()));
        }
    }
}
