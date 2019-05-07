//#define First
using ContosoUniversity.Models;
using ContosoUniversity.ODataValidators;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ContosoUniversity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
#if First
        #region snippet_EnableQuery
        [HttpGet, EnableQuery]
        public IQueryable<Enrollment> Get([FromServices]SchoolContext context) 
            => context.Enrollment;
        #endregion

#else

#region snippet_MyEnableQuery
        [HttpGet, MyEnableQuery]
        public IQueryable<Enrollment> Get([FromServices]SchoolContext context) 
                                                       => context.Enrollment;
#endregion
#endif
    }
}
