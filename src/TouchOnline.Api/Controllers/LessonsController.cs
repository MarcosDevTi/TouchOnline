using DigiteMais.Cqrs.Client.Presentation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TouchOnline.CqrsClient.Contracts;
using TouchOnline.CqrsClient.Presentation;

namespace DigiteMais.UI.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("api/[controller]/[action]")]
    public class LessonsController : ControllerBase
    {
        private readonly IProcessor _processor;
        public LessonsController(IProcessor processor)
        {
            _processor = processor;
        }
        [HttpPost]
        public IActionResult Create([FromBody]SetResult lesson)
        {
            // _processor.Send(lesson);
            return Ok();
        }

        //[HttpGet]
        //public IActionResult GetLessonResults(Guid userId)
        //{
        //    var result = _processor.Get(new GetResults(userId));
        //    return Ok(result);
        //}

        [HttpGet]
        public IActionResult GetLessonPresentations([FromQuery]GetLessonsPresentationList getLessonsPresentation)
        {
            var presentationList = _processor.Get(getLessonsPresentation);
            return Ok(presentationList);
        }

        [HttpGet]
        public IActionResult GetLessonPresentation([FromQuery]GetLessonPresentation getLessonPresentation)
        {
            return Ok(_processor.Get(getLessonPresentation));
        }

        [HttpPost]
        public IActionResult SetResult([FromBody]SetResult result)
        {
            _processor.Send(result);
            return Ok();
        }

        [HttpPost]
        public IActionResult SetResults([FromBody]SetResults results)
        {
            _processor.Send(results);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetResults([FromQuery]Guid userId)
        {
            var result = _processor.Get(new GetResults(userId));
            return Ok(result);
        }
    }
}