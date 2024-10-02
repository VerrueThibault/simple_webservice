using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace MCT.Functions
{
    public class CalculatorPostTrigger
    {
        private readonly ILogger<CalculatorPostTrigger> _logger;

        public CalculatorPostTrigger(ILogger<CalculatorPostTrigger> logger)
        {
            _logger = logger;
        }

        [Function("CalculatorPostTrigger")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "calculator")] HttpRequest req)
        {   
            CalculationRequest request = await req.ReadFromJsonAsync<CalculationRequest>();
            int result = request.A + request.B;
            CalculationResult r = new CalculationResult();
            r.A = request.A;
            r.B = request.B;
            r.result = result;
            return new OkObjectResult(r);
        }
    }
}
