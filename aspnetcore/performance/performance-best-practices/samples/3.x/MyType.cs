/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace performance_best_practices
{
    #if BAD
    #region snippet1
    public class MyType
    {
        private readonly HttpContext _context;
        public MyType(IHttpContextAccessor accessor)
        {
            _context = accessor.HttpContext;
        }

        public void CheckAdmin()
        {
            if (!_context.User.IsInRole("admin"))
            {
                throw new UnauthorizedAccessException("The current user isn't an admin");
            }
        }
    }
    #endregion
    #else
    #region snippet2
    public class MyType
    {
        private readonly IHttpContextAccessor _accessor;
        public MyType(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public void CheckAdmin()
        {
            var context = _accessor.HttpContext;
            if (context != null && !context.User.IsInRole("admin"))
            {
                throw new UnauthorizedAccessException("The current user isn't an admin");
            }
        }
    }
    #endregion
    #endif
}
*/