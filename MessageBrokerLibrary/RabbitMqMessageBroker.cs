using System;
using EasyNetQ;
using Microsoft.Extensions.Options;

namespace MessageBrokerLibrary
{
    public class RabbitMqMessageBroker : IMessageBroker
    {
        public RabbitMqMessageBroker(IOptions<RabbitMqBrokerConfiguration> options )
        {
            var rabbitMqBrokerConfiguration = options.Value;
            RabbitMqPubSub = RabbitHutch.CreateBus(rabbitMqBrokerConfiguration.ConnectionString).PubSub;

           
           
           

        }

        public IPubSub RabbitMqPubSub { get; }
    }
}