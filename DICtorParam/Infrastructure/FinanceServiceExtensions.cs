using System;
using DICtorParam.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace DICtorParam.Infrastructure
{
    public static class FinanceServiceExtensions
    {
        public static IServiceCollection AddFinanceService(this IServiceCollection serviceCollection,
            Action<FinanceServiceOptions> config)
        {
            if (serviceCollection == null) throw new ArgumentNullException(nameof(serviceCollection));
            if (config == null) throw new ArgumentNullException(nameof(config));

            serviceCollection.Configure(config);
            return serviceCollection.AddTransient<IFinanceService, FinanceService>();
        }
    }
}