modelBuilder.Entity<Course>()
     .HasMany(c => c.Instructors).WithMany(i => i.Courses)
     .Map(t => t.MapLeftKey("CourseID")
         .MapRightKey("InstructorID")
         .ToTable("CourseInstructor"));