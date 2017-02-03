using System;
using System.Collections.Generic;

namespace ContosoUniversity.DAL
{
    public interface ISchoolRepository : IDisposable
    {
        IEnumerable<Department> GetDepartments();
        void InsertDepartment(Department department);
        void DeleteDepartment(Department department);
        void UpdateDepartment(Department department, Department origDepartment);
        IEnumerable<InstructorName> GetInstructorNames();
    }
}