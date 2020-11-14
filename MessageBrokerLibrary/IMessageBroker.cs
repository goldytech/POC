using EasyNetQ;

namespace MessageBrokerLibrary
{
    public interface IMessageBroker
    {
        public IPubSub RabbitMqPubSub { get;  }

        void ShutDownMessageBroker();
    }
}