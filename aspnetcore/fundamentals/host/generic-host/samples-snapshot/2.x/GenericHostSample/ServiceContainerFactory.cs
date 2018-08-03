using System;
using Microsoft.Extensions.DependencyInjection;

namespace GenericHostSample
{
    internal class ServiceContainerFactory : IServiceProviderFactory<MyContainer>
    {
        public ServiceContainer CreateBuilder(IServiceCollection services)
        {
            return new ServiceContainer();
        }

        public IServiceProvider CreateServiceProvider(ServiceContainer containerBuilder)
        {
            throw new NotImplementedException();
        }
    }
}
