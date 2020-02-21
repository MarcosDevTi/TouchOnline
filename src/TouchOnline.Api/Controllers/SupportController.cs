using Microsoft.AspNetCore.Mvc;
using TouchOnline.CqrsClient.Contracts;
using TouchOnline.CqrsClient.Support;

namespace TouchOnline.Api.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("api/[controller]/[action]")]
    public class SupportController: ControllerBase
    {
         private readonly IProcessor _processor;
        public SupportController(IProcessor processor)
        {
            _processor = processor;
        }
        public IActionResult SendMessage(SendMessage sendMessage)
        {
            _processor.Send(sendMessage);
            return Ok();
        }
    }
}