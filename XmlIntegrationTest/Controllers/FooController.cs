using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace XmlIntegrationTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FooController : ControllerBase
    {
        private readonly ILogger<FooController> _logger;

        public FooController(ILogger<FooController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Post(Foo foo)
        {
            _logger.LogInformation($"{foo.Date} - {foo.Summary}");

            return NoContent();
        }
    }
}
