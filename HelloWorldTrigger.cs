using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace MCT.Functions
{
    public class HelloWorldTrigger
    {
        private readonly ILogger<HelloWorldTrigger> _logger;

        public HelloWorldTrigger(ILogger<HelloWorldTrigger> logger)
        {
            _logger = logger;
        }

        [Function("HelloWorldTrigger")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route ="helloworld")] HttpRequest req)
        {
            return new OkObjectResult("Hello World");
        }
    }
}
