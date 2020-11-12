using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MessageBrokerLibrary
{
    public static class EasyNetQExtensions
    {
        public static IServiceCollection AddRabbitMqAsMessageBroker(this IServiceCollection services,
            IConfiguration config)
        {
            services.AddOptions();
            services.Configure<RabbitMqBrokerConfiguration>(configuration => configuration.ConnectionString = config.GetSection("RabbitMQ:Connection").Value );

         //   services.Configure<RabbitMqBrokerConfiguration>(configuration => configuration.ConnectionString);
            services.AddSingleton<IMessageBroker, RabbitMqMessageBroker>();
            return services;
        }
    }
}