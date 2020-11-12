using EasyNetQ;
using MessageBrokerLibrary;

namespace EasyNetQApi.FinanceDomain
{
    [Queue("FinanceQueue", ExchangeName = "FinanceExchange")]
    public class FinanceMessage : IRabbitMqMessage
    {
        
        public FinanceMessage(double amount, string sellerId, string messageId)
        {
            Amount = amount;
            SellerId = sellerId;
            MessageId = messageId;
        }

        public double Amount { get;  }
        public string SellerId { get; }
        public string MessageId { get; }
    }



    public class FinanceMessage2 : IRabbitMqMessage
    {

        public FinanceMessage2(double amount, string sellerId, string messageId)
        {
            Amount = amount;
            SellerId = sellerId;
            MessageId = messageId;
        }

        public double Amount { get; }
        public string SellerId { get; }
        public string MessageId { get; }
    }


}