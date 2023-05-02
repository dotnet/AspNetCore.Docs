using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ValidationResultErrorMessage.Models;

namespace ValidationResultErrorMessage.Data
{
    public class ValidationResultErrorMessageContext : DbContext
    {
        public ValidationResultErrorMessageContext (DbContextOptions<ValidationResultErrorMessageContext> options)
            : base(options)
        {
        }

        public DbSet<ValidationResultErrorMessage.Models.Contact> Contact { get; set; } = default!;
    }
}
