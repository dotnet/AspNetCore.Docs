using System;
using Microsoft.Extensions.DependencyInjection;

namespace GenericHostSample
{
    internal class ServiceContainerFactory : 
        IServiceProviderFactory<ServiceContainer>
    {
        public ServiceContainer CreateBuilder(
            IServiceCollection services)
        {
            return new ServiceContainer();
        }

        public IServiceProvider CreateServiceProvider(
            ServiceContainer containerBuilder)
        {
            throw new NotImplementedException();
        }
    }
}
