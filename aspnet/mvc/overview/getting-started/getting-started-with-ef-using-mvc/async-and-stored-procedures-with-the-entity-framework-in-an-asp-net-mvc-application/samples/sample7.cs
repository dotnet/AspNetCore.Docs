protected override void OnModelCreating(DbModelBuilder modelBuilder)
{
    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
    modelBuilder.Entity<Course>()
        .HasMany(c => c.Instructors).WithMany(i => i.Courses)
        .Map(t => t.MapLeftKey("CourseID")
            .MapRightKey("InstructorID")
            .ToTable("CourseInstructor"));
    modelBuilder.Entity<Department>().MapToStoredProcedures();
}