using Microsoft.AspNetCore.Mvc;
using System;
using TouchOnline.CqrsClient.Contracts;
using TouchOnline.CqrsClient.MyText;

namespace TouchOnline.Api.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("api/[controller]/[action]")]
    public class MyTextController : ControllerBase
    {
        private readonly IProcessor _processor;
        public MyTextController(IProcessor processor)
        {
            _processor = processor;
        }

        [HttpPost]
        public IActionResult Save([FromBody]CreateMyText createMyText)
        {
            _processor.Send(createMyText);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetMyTests([FromQuery]Guid userId)
        {
            var result = _processor.Get(new GetMyTexts(userId));
            return Ok(result);
        }
    }
}