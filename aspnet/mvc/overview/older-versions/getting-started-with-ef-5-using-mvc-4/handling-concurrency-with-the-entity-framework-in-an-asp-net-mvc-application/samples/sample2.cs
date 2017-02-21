modelBuilder.Entity<Department>()
    .Property(p => p.RowVersion).IsConcurrencyToken();