using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContosoUniversity.DAL;

namespace ContosoUniversity.BLL
{
    public class SchoolBL : IDisposable
    {
        private ISchoolRepository schoolRepository;

        public SchoolBL()
        {
            this.schoolRepository = new SchoolRepository();
        }

        public SchoolBL(ISchoolRepository schoolRepository)
        {
            this.schoolRepository = schoolRepository;
        }

        public IEnumerable<Department> GetDepartments()
        {
            return schoolRepository.GetDepartments();
        }

        public void InsertDepartment(Department department)
        {
            try
            {
                schoolRepository.InsertDepartment(department);
            }
            catch (Exception ex)
            {
                //Include catch blocks for specific exceptions first,
                //and handle or log the error as appropriate in each.
                //Include a generic catch block like this one last.
                throw ex;
            }
        }

        public void DeleteDepartment(Department department)
        {
            try
            {
                schoolRepository.DeleteDepartment(department);
            }
            catch (Exception ex)
            {
                //Include catch blocks for specific exceptions first,
                //and handle or log the error as appropriate in each.
                //Include a generic catch block like this one last.
                throw ex;
            }
        }

        public void UpdateDepartment(Department department, Department origDepartment)
        {
            try
            {
                schoolRepository.UpdateDepartment(department, origDepartment);
            }
            catch (Exception ex)
            {
                //Include catch blocks for specific exceptions first,
                //and handle or log the error as appropriate in each.
                //Include a generic catch block like this one last.
                throw ex;
            }

        }

        public IEnumerable<InstructorName> GetInstructorNames()
        {
            return schoolRepository.GetInstructorNames();
        }

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    schoolRepository.Dispose();
                }
            }
            this.disposedValue = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}