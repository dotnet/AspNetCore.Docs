return context.Departments.Include("Person").Include("Courses").
    OrderBy("it." + sortExpression).Where(d => d.Name.Contains(nameSearchString)).ToList();