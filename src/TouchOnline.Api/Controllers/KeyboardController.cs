using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TouchOnline.CqrsClient.Contracts;
using TouchOnline.CqrsClient.Keyboards;

namespace TouchOnline.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeyboardController : ControllerBase
    {
        private readonly IProcessor _processor;
        public KeyboardController(IProcessor processor)
        {
            _processor = processor;
        }

        [HttpGet]
        public IActionResult GetKeyboard()
        {
            var keyboard = _processor.Get(new GetKeyboard());
            return Ok(keyboard);
        }
    }
}