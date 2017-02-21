var employees = modelBuilder.EntitySet<Employee>("Employees");
employees.EntityType.Ignore(emp => emp.Salary);