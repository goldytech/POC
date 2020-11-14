using System.Threading;
using System.Threading.Tasks;
using MessageBrokerLibrary;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RabbitMQMessages;

namespace RabbitMQMessageListeners
{
    public class FinanceInvoiceSubscriber2 : IHostedService
    {
        private readonly IMessageBroker _messageBroker;
        private readonly ILogger<FinanceInvoiceSubscriber2> _logger;

        public FinanceInvoiceSubscriber2(IMessageBroker messageBroker, ILogger<FinanceInvoiceSubscriber2> logger)
        {
            _messageBroker = messageBroker;
            _logger = logger;
        }
        public  Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogDebug("Listener service is starting");

           _messageBroker.RabbitMqPubSub.SubscribeAsync<Message>("invoices",
                OnMessageReceived, configuration => configuration.WithTopic("Finance.Invoice"),cancellationToken);

            _logger.LogInformation("Listener service is started");

           return Task.CompletedTask;
        }

       private Task OnMessageReceived(Message message, CancellationToken token)
       {
           return Task.Factory.StartNew(() =>
               {
                 
                       _logger.LogInformation(
                           $"Message received => {message.Text}");
                   
               }, token)
               .ContinueWith(task =>
               {
                   if (task.IsFaulted)
                   {
                       _logger.LogError("Error occurred while subscribing to event");
                   }
                   else
                   {
                       _logger.LogInformation("Message successfully handled");
                   }
               }, token);
       }


       public Task StopAsync(CancellationToken cancellationToken)
        {
            _messageBroker.ShutDownMessageBroker();

            _logger.LogInformation("Listener service is stopped");
            return Task.CompletedTask;
        }
    }
}