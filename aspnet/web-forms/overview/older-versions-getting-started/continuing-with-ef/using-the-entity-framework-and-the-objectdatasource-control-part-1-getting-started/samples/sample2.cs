using System;
using System.Collections.Generic;
using System.Linq;
using ContosoUniversity.DAL;

namespace ContosoUniversity.DAL
{
    public class SchoolRepository : IDisposable
    {
        private SchoolEntities context = new SchoolEntities();

        public IEnumerable<Department> GetDepartments()
        {
            return context.Departments.Include("Person").ToList();
        }

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    context.Dispose();
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