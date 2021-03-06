﻿using Microsoft.AspNetCore.Mvc;
using System;
using TouchOnline.CqrsClient.Contracts;
using TouchOnline.CqrsClient.Keyboard;
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
        public IActionResult InsertKeyboardLayout()
        {
            _processor.Send(new InsertKeyboards());
            return Ok();
        }

        [HttpGet]
        public IActionResult GetKeyboard(Guid keyboardId)
        {
            var keyboard = _processor.Get(new GetKeyboardById { Id = keyboardId });
            return Ok(keyboard);
        }

        [HttpGet]
        public IActionResult GetKeyboardWithLanguageCode(string languageCode)
        {
            var keyboard = _processor.Get(new GetKeyboardByLangCode { LanguageCode = languageCode });
            return Ok(keyboard);
        }

        [HttpGet]
        public IActionResult GetKeyboardsDw()
        {
            var keyboards = _processor.Get(new GetKeyboardsDw());
            return Ok(keyboards);
        }

        [HttpGet]
        public IActionResult GetKeyboardsManagement()
        {
            return Ok(_processor.Get(new GetKeyboardsManagement()));
        }

        [HttpPut]
        public IActionResult UpdateKeyboard([FromBody]KeyboardForUpdate keyboardForUpdate)
        {
            _processor.Send(keyboardForUpdate);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetKeyboardByIdForUpdate(Guid id)
        {
            return Ok(_processor.Get(new GetKeyboardForUpdate { Id = id }));
        }
    }
}