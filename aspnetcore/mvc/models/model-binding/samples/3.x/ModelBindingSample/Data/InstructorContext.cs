using Microsoft.EntityFrameworkCore;
using ModelBindingSample.Models;

namespace ModelBindingSample.Data
{
    public class InstructorContext : DbContext
    {
        public InstructorContext(DbContextOptions<InstructorContext> options)
            : base(options)
        {

        }

        public DbSet<Instructor> Instructors { get; set; }
    }
}
