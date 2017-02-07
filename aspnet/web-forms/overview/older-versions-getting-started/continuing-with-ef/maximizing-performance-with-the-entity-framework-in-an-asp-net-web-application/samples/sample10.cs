using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Objects;

namespace ContosoUniversity.DAL
{
    public partial class SchoolEntities
    {
        private static readonly Func<SchoolEntities, IQueryable<InstructorName>> compiledInstructorNamesQuery =
            CompiledQuery.Compile((SchoolEntities context) => from i in context.InstructorNames orderby i.FullName select i);

        public IEnumerable<InstructorName> CompiledInstructorNamesQuery()
        {
            return compiledInstructorNamesQuery(this).ToList();
        }

        private static readonly Func<SchoolEntities, Int32, IQueryable<Department>> compiledDepartmentsByAdministratorQuery =
            CompiledQuery.Compile((SchoolEntities context, Int32 administrator) => from d in context.Departments.Include("Person") where d.Administrator == administrator select d);

        public IEnumerable<Department> CompiledDepartmentsByAdministratorQuery(Int32 administrator)
        {
            return compiledDepartmentsByAdministratorQuery(this, administrator).ToList();
        }
    }
}