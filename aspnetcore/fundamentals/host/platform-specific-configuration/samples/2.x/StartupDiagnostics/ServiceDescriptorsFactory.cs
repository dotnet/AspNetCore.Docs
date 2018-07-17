using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

// This factory exposes a GetServices method that can be called
// by middleware to provide a list of the app's registered services.
namespace ServiceDescriptorsFactory
{
    public class AppService
    {
        public string FullName { get; set; }
        public string Lifetime { get; set; }
        public string ImplementationType { get; set; }
    }

    public interface IServiceDescriptorsService
    {
        IEnumerable<AppService> GetServices();
    }

    public class ServiceDescriptorsService : IServiceDescriptorsService
    {
        private readonly IServiceCollection _serviceCollection;
        
        public ServiceDescriptorsService(IServiceCollection serviceCollection)
        {
            _serviceCollection = serviceCollection;
        }

        public IEnumerable<AppService> GetServices()
        {
            foreach (var srv in _serviceCollection)
            {
                yield return(
                    new AppService()
                    { 
                        FullName = srv.ServiceType.FullName, 
                        Lifetime = srv.Lifetime.ToString(), 
                        ImplementationType = srv.ImplementationType?.FullName
                    });
            }
        }
    }
}
