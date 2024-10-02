using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace MCT.Functions
{
    public class CalculatorTrigger
    {
        private readonly ILogger<CalculatorTrigger> _logger;

        public CalculatorTrigger(ILogger<CalculatorTrigger> logger)
        {
            _logger = logger;
        }

        [Function("CalculatorTrigger")]
        public IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "calculator/{a:int}/{op}/{b:int}")] HttpRequest req,
            int a,
            int b,
            string op)
        {

            char oc =op[0];
            double result = 0;
            switch (oc)
            {
                case '+':
                    result = a + b;
                    break;
                case '-':
                    result = a - b;
                    break;
                case '*':
                    result = a * b;
                    break;
                case ':':
                    if (b != 0)
                    {
                        result = (double)a / b;
                    }
                    else
                    {
                        _logger.LogWarning("Attempted division by zero");
                        result = 0;
                    }
                    break;           
            }

            CalculationResult r = new CalculationResult();
            r.result = result;
            r.A = a;
            r.B = b;




            return new OkObjectResult(r);
        }
    }
}
