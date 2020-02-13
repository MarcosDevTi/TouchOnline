using Microsoft.AspNetCore.Mvc;
using System;
using TouchOnline.CqrsClient.Contracts;
using TouchOnline.CqrsClient.Keyboards;

namespace TouchOnline.Api.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("api/[controller]/[action]")]
    public class KeyboardController : ControllerBase
    {
        private readonly IProcessor _processor;
        public KeyboardController(IProcessor processor)
        {
            _processor = processor;
        }

        [HttpGet]
        public IActionResult GetKeyboard(Guid? keyboardId)
        {
            var keyboard = _processor.Get(new GetKeyboard(keyboardId));
            return Ok(keyboard);
        }

        [HttpGet]
        public IActionResult GetKeyboardsDw()
        {
            var keyboards = _processor.Get(new GetKeyboardsDw());
            return Ok(keyboards);
        }
    }
}