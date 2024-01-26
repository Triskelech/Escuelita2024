using Microsoft.Extensions.DependencyInjection;
using Model.Entities;
using Service.Contracts;

namespace Service.Services
{
    public class ServiceActivator
    {
        private static IServiceProvider _serviceProvider;

        public static void Initialize(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public static IEntityService<Entity> EntityService => _serviceProvider.GetService<IEntityService<Entity>>();
    }
}
