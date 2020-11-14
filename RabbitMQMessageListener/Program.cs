using System;
using MessageBrokerLibrary;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace RabbitMQMessageListeners
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    //services.PostConfigure<HostOptions>(options =>
                    //{
                    //    options.ShutdownTimeout = TimeSpan.FromSeconds(60);
                    //});
                    services.AddRabbitMqAsMessageBroker(hostContext.Configuration);
                    services.AddHostedService<FinanceInvoiceSubscriber2>();
                });
    }
}
