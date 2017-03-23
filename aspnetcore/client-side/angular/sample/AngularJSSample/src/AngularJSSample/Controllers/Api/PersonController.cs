using AngularSample.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AngularSample.Controllers.Api
{
    public class PersonController : Controller
    {
        [Route("/api/people")]
        public JsonResult GetPeople()
        {
            var people = new List<Person>()
            {
                new Person { Id = 1, FirstName = "John", LastName = "Doe" },
                new Person { Id = 1, FirstName = "Mary", LastName = "Jane" },
                new Person { Id = 1, FirstName = "Bob", LastName = "Parker" }
            };

            // default behavior will convert fields in model to camelCase in Json object
            return Json(people);
        }
    }
}
