EntitySetConfiguration<Employee> employeesConfiguration = 
    builder.EntitySet<Employee>("Employees"); 
employeesConfiguration.HasSingletonBinding(c => c.Company, "Umbrella");