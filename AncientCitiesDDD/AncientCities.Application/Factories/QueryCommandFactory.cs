using AncientCities.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AncientCities.Application.Factories
{
    public class QueryCommandFactory : IQueryCommandFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public QueryCommandFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public T Create<T>() where T : class
        {
            return _serviceProvider.GetRequiredService<T>();
        }
    }
}
