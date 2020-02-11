using Microsoft.AspNetCore.Mvc;
using TouchOnline.CqrsClient.Contracts;
using TouchOnline.CqrsClient.Tracking;
using TouchOnline.Domain.UserTracking;

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
    }
}