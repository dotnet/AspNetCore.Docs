using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

// This factory exposes a GetServices method that can be called
// by middleware to provide a list of the app's registered services.
namespace ServiceDescriptorsFactory
{
    /// <summary>
    /// Describes an individual service in the app.
    /// </summary>
    public class AppService
    {
        /// <summary>
        /// Full name of the service.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Lifetime of the service registration.
        /// </summary>
        public string Lifetime { get; set; }

        /// <summary>
        /// Implementation type of the service.
        /// </summary>
        public string ImplementationType { get; set; }
    }

    /// <summary>
    /// Service descriptor interface.
    /// </summary>
    public interface IServiceDescriptorsService
    {
        /// <summary>
        /// GetServices method returns an IEnumerable of app services.
        /// </summary>
        IEnumerable<AppService> GetServices();
    }

    /// <summary>
    /// A service to describe the app's services.
    /// </summary>
    public class ServiceDescriptorsService : IServiceDescriptorsService
    {
        private readonly IServiceCollection _serviceCollection;

        /// <summary>
        /// Construct the ServiceDescriptorsService.
        /// </summary>
        public ServiceDescriptorsService(IServiceCollection serviceCollection)
        {
            _serviceCollection = serviceCollection;
        }

        /// <summary>
        /// Return an IEnumerable of app services.
        /// </summary>
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
