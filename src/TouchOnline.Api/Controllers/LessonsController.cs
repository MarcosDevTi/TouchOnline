using DigiteMais.Cqrs.Client.Presentation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TouchOnline.CqrsClient.Contracts;
using TouchOnline.CqrsClient.Presentation;

namespace DigiteMais.UI.Controllers
{
    [Route("api/[controller]")]
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

        [HttpGet]
        public IActionResult GetLessonPresentations([FromQuery]GetLessonsPresentationList getLesson)
        {
            var presentationList = _processor.Get(getLesson);
            var result = _processor.Get(new GetResults(getLesson.UserId));

            var resultList = new List<LessonPresentationItem>();
            foreach (var pres in presentationList)
            {
                var content = result.FirstOrDefault(x => x.IdLesson == pres.IdLesson);
                if (content != null)
                {
                    pres.AddResults(content.Precision, content.Ppm, content.Stars, content.Time);
                    resultList.Add(pres);
                }
                else
                {
                    resultList.Add(pres);
                }
            }
            return Ok(resultList);
        }

        [HttpGet("{idLesson}")]
        public IActionResult GetLessonPresentation(int idLesson)
        {
            return Ok(_processor.Get(new GetLessonPresentation { IdLesson = idLesson }));
        }

        [HttpPost("result")]
        public IActionResult SetResult([FromBody]SetResult result)
        {
            _processor.Send(result);
            return Ok();
        }

        [HttpGet("results")]
        public IActionResult GetResults(Guid userId)
        {
            var result = _processor.Get(new GetResults(userId));
            return Ok(result);
        }
    }
}