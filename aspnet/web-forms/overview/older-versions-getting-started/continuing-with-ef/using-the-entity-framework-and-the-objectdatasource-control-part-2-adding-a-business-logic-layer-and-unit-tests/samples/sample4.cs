using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ContosoUniversity.DAL;
using ContosoUniversity.BLL;

namespace ContosoUniversity.Tests
{
    class MockSchoolRepository : ISchoolRepository, IDisposable
    {
        List<Department> departments = new List<Department>();
        List<InstructorName> instructors = new List<InstructorName>();

        public IEnumerable<Department> GetDepartments()
        {
            return departments;
        }

        public void InsertDepartment(Department department)
        {
            departments.Add(department);
        }

        public void DeleteDepartment(Department department)
        {
            departments.Remove(department);
        }

        public void UpdateDepartment(Department department, Department origDepartment)
        {
            departments.Remove(origDepartment);
            departments.Add(department);
        }

        public IEnumerable<InstructorName> GetInstructorNames()
        {
            return instructors;
        }

        public void Dispose()
        {
            
        }
    }
}