using System;
using EasyNetQ;
using Microsoft.Extensions.Options;

namespace MessageBrokerLibrary
{
    public class RabbitMqMessageBroker : IMessageBroker
    {
        private readonly IBus _bus;

        public RabbitMqMessageBroker(IOptions<RabbitMqBrokerConfiguration> options)
        {
            var rabbitMqBrokerConfiguration = options.Value;
            _bus = RabbitHutch.CreateBus(rabbitMqBrokerConfiguration.ConnectionString);
            RabbitMqPubSub = _bus.PubSub;
        }

        public IPubSub RabbitMqPubSub { get; }

        public void ShutDownMessageBroker()
        {
            _bus.Dispose();
        }
    }
}