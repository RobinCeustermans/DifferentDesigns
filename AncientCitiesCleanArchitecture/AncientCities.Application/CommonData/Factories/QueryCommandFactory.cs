using AncientCities.Application.CommonData.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AncientCities.Application.CommonData.Factories
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
