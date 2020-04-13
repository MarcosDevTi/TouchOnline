using Microsoft.AspNetCore.Mvc;
using System;
using TouchOnline.CqrsClient.Contracts;
using TouchOnline.CqrsClient.Tracking;

namespace TouchOnline.Api.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("api/[controller]/[action]")]
    public class TrackingController : ControllerBase
    {
        private readonly IProcessor _processor;
        public TrackingController(IProcessor processor)
        {
            _processor = processor;
        }
        [HttpPost]
        public IActionResult SaveTracking([FromBody]SaveTracking saveTracking)
        {
            _processor.Send(saveTracking);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetTrackings([FromQuery]DateTime date)
        {
            var result = _processor.Get(new GetTrackings { InitialDate = date });
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetTrackingsToday()
        {
            var result = _processor.Get(new GetTrackings());
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetTrackingsLastMinute()
        {
            var result = _processor.Get(new GetTrackingsLastMinute());
            return Ok(result);
        }

        [HttpGet]
        public IActionResult getVisitors(DateTime date)
        {
            var result = _processor.Get(new GetTrackings());
            return Ok(result);
        }
    }
}