using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebAddress.Data
{
    public class WebAddressContext : DbContext
    {
        public WebAddressContext (DbContextOptions<WebAddressContext> options)
            : base(options)
        {
        }

        public DbSet<Address>? Address { get; set; }
    }
}
