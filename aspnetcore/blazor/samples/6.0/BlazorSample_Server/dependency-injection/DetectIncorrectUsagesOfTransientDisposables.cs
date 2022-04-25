using Microsoft.AspNetCore.Components.Server.Circuits;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Microsoft.Extensions.DependencyInjection
{
    using BlazorServerTransientDisposable;

    public static class WebHostBuilderTransientDisposableExtensions
    {
        public static WebApplicationBuilder DetectIncorrectUsageOfTransients(
            this WebApplicationBuilder builder)
        {
            builder.Host
                .UseServiceProviderFactory(
                    new DetectIncorrectUsageOfTransientDisposablesServiceFactory())
                .ConfigureServices(
                    s => s.TryAddEnumerable(ServiceDescriptor.Scoped<CircuitHandler,
                        ThrowOnTransientDisposableHandler>()));

            return builder;
        }
    }
}

namespace BlazorServerTransientDisposable
{
    internal class ThrowOnTransientDisposableHandler : CircuitHandler
    {
        public ThrowOnTransientDisposableHandler(
            ThrowOnTransientDisposable throwOnTransientDisposable)
        {
            throwOnTransientDisposable.ShouldThrow = true;
        }
    }

    public class DetectIncorrectUsageOfTransientDisposablesServiceFactory 
        : IServiceProviderFactory<IServiceCollection>
    {
        public IServiceCollection CreateBuilder(IServiceCollection services) => 
            services;

        public IServiceProvider CreateServiceProvider(
            IServiceCollection containerBuilder)
        {
            var collection = new ServiceCollection();

            foreach (var descriptor in containerBuilder)
            {
                if (descriptor.Lifetime == ServiceLifetime.Transient &&
                    descriptor.ImplementationType != null && 
                    typeof(IDisposable).IsAssignableFrom(
                        descriptor.ImplementationType))
                {
                    collection.Add(CreatePatchedDescriptor(descriptor));
                }
                else if (descriptor.Lifetime == ServiceLifetime.Transient &&
                         descriptor.ImplementationFactory != null)
                {
                    collection.Add(CreatePatchedFactoryDescriptor(descriptor));
                }
                else
                {
                    collection.Add(descriptor);
                }
            }

            collection.AddScoped<ThrowOnTransientDisposable>();

            return collection.BuildServiceProvider();
        }

        private ServiceDescriptor CreatePatchedFactoryDescriptor(
            ServiceDescriptor original)
        {
            var newDescriptor = new ServiceDescriptor(
                original.ServiceType,
                (sp) =>
                {
                    var originalFactory = original.ImplementationFactory;

                    if (originalFactory is null)
                    {
                        throw new InvalidOperationException(
                            "originalFactory is null.");
                    }

                    var originalResult = originalFactory(sp);

                    var throwOnTransientDisposable = 
                        sp.GetRequiredService<ThrowOnTransientDisposable>();
                    if (throwOnTransientDisposable.ShouldThrow && 
                        originalResult is IDisposable d)
                    {
                        throw new InvalidOperationException("Trying to resolve " +
                            $"transient disposable service {d.GetType().Name} in " +
                            "the wrong scope. Use an 'OwningComponentBase<T>' " +
                            "component base class for the service 'T' you are " +
                            "trying to resolve.");
                    }

                    return originalResult;
                },
                original.Lifetime);

            return newDescriptor;
        }

        private ServiceDescriptor CreatePatchedDescriptor(
            ServiceDescriptor original)
        {
            var newDescriptor = new ServiceDescriptor(
                original.ServiceType,
                (sp) => {
                    var throwOnTransientDisposable = 
                        sp.GetRequiredService<ThrowOnTransientDisposable>();
                    if (throwOnTransientDisposable.ShouldThrow)
                    {
                        throw new InvalidOperationException("Trying to resolve " +
                            "transient disposable service " +
                            $"{original.ImplementationType?.Name} in the wrong " +
                            "scope. Use an 'OwningComponentBase<T>' component " +
                            "base class for the service 'T' you are trying to " +
                            "resolve.");
                    }

                    if (original.ImplementationType is null)
                    {
                        throw new InvalidOperationException(
                            "ImplementationType is null.");
                    }

                    return ActivatorUtilities.CreateInstance(sp, 
                        original.ImplementationType);
                },
                ServiceLifetime.Transient);
    
            return newDescriptor;
        }
    }

    internal class ThrowOnTransientDisposable
    {
        public bool ShouldThrow { get; set; }
    }
}
