using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BlazorServerDbContextExample.Data
{
    /// <summary>
    /// Factory to generate instances of <see cref="TContext"/>.
    /// </summary>
    /// <typeparam name="TContext">The <see cref="DbContext"/> type to provide.</typeparam>
    public class DbContextFactory<TContext> : IDbContextFactory<TContext> where TContext : DbContext
    {
        /// <summary>
        /// Service provider.
        /// </summary>
        private readonly IServiceProvider _provider;

        /// <summary>
        /// Inject the service provider.
        /// </summary>
        /// <param name="provider">The <see cref="IServiceProvider"/> instance.</param>
        public DbContextFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        /// <summary>
        /// Create a newly created context.
        /// </summary>
        /// <returns>A new instance of <see cref="TContext"/>.</returns>
        // rename to Create
        public TContext CreateDbContext()
        {
            if (_provider == null)
            {
                throw new InvalidOperationException($"You must configure an instance of IServiceProvider");
            }

            // satisfies any dependencies via the provider
            return ActivatorUtilities.CreateInstance<TContext>(_provider);
        }
    }
}
