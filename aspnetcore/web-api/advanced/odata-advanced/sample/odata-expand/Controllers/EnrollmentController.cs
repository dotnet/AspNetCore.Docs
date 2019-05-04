using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoUniversity.Models;
using ContosoUniversity.ODataValidators;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {

        #region snippet_MyEnableQuery

        [HttpGet, MyEnableQuery]
        public IQueryable<Enrollment> Get([FromServices]SchoolContext context) => context.Enrollment;

        #endregion

        #region snippet_EnableQuery

        [HttpGet, EnableQuery]
        public IQueryable<Enrollment> GetEnrollments([FromServices]SchoolContext context) => context.Enrollment;

        #endregion
    }
}
