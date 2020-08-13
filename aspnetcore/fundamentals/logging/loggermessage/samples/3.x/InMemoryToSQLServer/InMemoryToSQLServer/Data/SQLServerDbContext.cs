using InMemoryToSQLServer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InMemoryToSQLServer.Data
{
    public class SQLServerDbContext : DbContext
    {
        public SQLServerDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Log> Logs { get; set; }
    }
}
