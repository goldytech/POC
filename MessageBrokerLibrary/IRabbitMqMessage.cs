using System;

namespace MessageBrokerLibrary
{
    public interface IRabbitMqMessage
    {
        public string MessageId { get; }


    }
}