using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace BlazorServerDbContextExample.Data
{
    /// <summary>
    /// Context for the contacts database.
    /// </summary>
    public class ContactContext : DbContext
    {
        /// <summary>
        /// Tracking lifetime of contexts.
        /// </summary>
        private readonly Guid _id;

        /// <summary>
        /// Magic string.
        /// </summary>
        public static readonly string RowVersion = nameof(RowVersion);

        /// <summary>
        /// Magic strings.
        /// </summary>
        public static readonly string ContactsDb = nameof(ContactsDb).ToLower();

        /// <summary>
        /// Inject options.
        /// </summary>
        /// <param name="options">The <see cref="DbContextOptions{ContactContext}"/>
        /// for the context
        /// </param>
        public ContactContext(DbContextOptions<ContactContext> options)
            : base(options)
        {
            _id = Guid.NewGuid();
            Debug.WriteLine($"{_id} context created.");
        }

        /// <summary>
        /// List of <see cref="Contact"/>.
        /// </summary>
        public DbSet<Contact> Contacts { get; set; }

        /// <summary>
        /// Define the model.
        /// </summary>
        /// <param name="modelBuilder">The <see cref="ModelBuilder"/>.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // this property isn't on the C# class
            // so we set it up as a "shadow" property and use it for concurrency
            modelBuilder.Entity<Contact>()
                .Property<byte[]>(RowVersion)
                .IsRowVersion();

            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// Dispose pattern.
        /// </summary>
        public override void Dispose()
        {
            Debug.WriteLine($"{_id} context disposed.");
            base.Dispose();
        }

        /// <summary>
        /// Dispose pattern.
        /// </summary>
        /// <returns>A <see cref="ValueTask"/></returns>
        public override ValueTask DisposeAsync()
        {
            Debug.WriteLine($"{_id} context disposed async.");
            return base.DisposeAsync();
        }
    }
}
