using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext (DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }

        public DbSet<ContosoUniversity.Models.Student> Students { get; set; }
        public DbSet<ContosoUniversity.Models.Enrollment> Enrollments { get; set; }
        public DbSet<ContosoUniversity.Models.Course> Courses { get; set; }
    }
}
