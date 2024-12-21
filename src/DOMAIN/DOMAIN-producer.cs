using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace service_template
{
    public class DOMAINProducer
    {
        private readonly ILogger _logger;

        public DOMAINProducer(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<DOMAINProducer>();
        }

        [Function("DOMAIN-producer")]
        public void Run([TimerTrigger("0 */5 * * * *")] TimerInfo myTimer)
        {
            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            
            if (myTimer.ScheduleStatus is not null)
            {
                _logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
            }
        }
    }
}
