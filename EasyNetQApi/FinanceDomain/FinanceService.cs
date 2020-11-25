using System;
using System.Threading.Tasks;
using EasyNetQ;
using MessageBrokerLibrary;
using Microsoft.Extensions.Logging;
using RabbitMQMessages;

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
        public void GenerateDocument()
        {
            
            var guid = Guid.NewGuid().ToString();
            var msg = new Message { Text = guid };
            
            _messageBroker.RabbitMqPubSub.PublishAsync(msg,
                 configuration => configuration.WithTopic("Finance.Invoice")).ContinueWith(task =>
             {
                 if (task.IsFaulted)
                 {
                     if (task.Exception != null) _logger.LogError(task.Exception.InnerException?.Message);

                 }

                 _logger.LogInformation($"Message successfully published => {guid}");
             });
        }
    }
}