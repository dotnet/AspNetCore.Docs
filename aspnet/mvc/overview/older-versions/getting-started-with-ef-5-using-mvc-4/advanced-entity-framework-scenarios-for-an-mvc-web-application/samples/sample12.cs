var duplicateDepartment = db.Departments
   .Include("Administrator")
   .Where(d => d.PersonID == department.PersonID)
   .AsNoTracking()
   .FirstOrDefault();