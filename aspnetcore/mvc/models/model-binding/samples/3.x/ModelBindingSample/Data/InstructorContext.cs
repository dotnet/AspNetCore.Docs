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

        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InstructorCourse>()
                .HasKey(ic => new { ic.InstructorId, ic.CourseId });
        }
    }
}
