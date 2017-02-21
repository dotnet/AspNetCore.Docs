using System;

namespace ContosoUniversity.BLL
{
    public class DuplicateAdministratorException : Exception
    {
        public DuplicateAdministratorException(string message)
            : base(message)
        {
        }
    }
}