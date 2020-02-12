using Microsoft.AspNetCore.Mvc;
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
        public IActionResult GetTrackings()
        {
            var result = _processor.Get(new GetTrackings());
            return Ok(result);
        }
    }
}