using Microsoft.EntityFrameworkCore;
using WebApiSample.DataAccess.Models;

namespace WebApiSample.DataAccess
{
    public class PetContext : DbContext
    {
        public PetContext(DbContextOptions<PetContext> options)
            : base(options)
        {
        }

        public DbSet<Pet> Pets { get; set; }
    }
}
