using System;
using System.Threading.Tasks;
using EasyNetQ;
using MessageBrokerLibrary;
using Microsoft.Extensions.Logging;

namespace EasyNetQApi.FinanceDomain
{
    public  class FinanceService : IFinanceService
    {
        private readonly IMessageBroker _messageBroker;
        private readonly ILogger<FinanceService> _logger;

        public FinanceService(IMessageBroker messageBroker, ILogger<FinanceService> logger)
        {
            _messageBroker = messageBroker;
            _logger = logger;
        }
        public async Task GenerateDocument()
        {
            _messageBroker.RabbitMqPubSub.Publish(new FinanceMessage(100, "ABC", Guid.NewGuid().ToString()), "Finance.Invoice");

            _logger.LogInformation("Message successfully published");

            // var t = await _messageBroker.RabbitMqPubSub.PublishAsync(new FinanceMessage(100,"ABC"), configuration => configuration.WithTopic())
            //await  _messageBroker.RabbitMqPubSub.PublishAsync(new FinanceMessage(100, "ABC"),
            //      configuration => configuration.WithTopic("FinTopic")).ContinueWith(task =>
            //  {
            //      if (task.IsFaulted)
            //      {
            //          if (task.Exception != null) _logger.LogError(task.Exception.InnerException?.Message);
            //          // throw new EasyNetQException("Unable to publish the message");
            //      }

            //      _logger.LogInformation("Message successfully published");
            //  });
        }
    }
}