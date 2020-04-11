using Microsoft.AspNetCore.Mvc;
using System;
using TouchOnline.Api.ViewModels;
using TouchOnline.CqrsClient.Contracts;
using TouchOnline.CqrsClient.LessonText;

namespace TouchOnline.Api.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("api/[controller]/[action]")]
    public class LessonTextController : ControllerBase
    {
        private readonly IProcessor _processor;
        public LessonTextController(IProcessor processor)
        {
            _processor = processor;
        }

        [HttpPost]
        public IActionResult CreateLesson([FromBody]CreateLessonText createLessonText)
        {
            _processor.Send(createLessonText);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateLesson([FromBody]UpdateLessonText updateLessonText)
        {
            _processor.Send(updateLessonText);
            return Ok();
        }

        public IActionResult GetLessonTexts(GetLessonTexts getLessonTexts)
        {
            var result = _processor.Get(getLessonTexts);
            return Ok(result);
        }


        [HttpGet("{id}")]
        public IActionResult GetLessonTextById(Guid id)
        {
            var result = _processor.Get(new GetLessonTextById(id));

            return Ok(new EditLessonViewModel(result));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLessonText(Guid id)
        {
            _processor.Send(new DeleteLessonText(id));
            return Ok();
        }
    }
}
