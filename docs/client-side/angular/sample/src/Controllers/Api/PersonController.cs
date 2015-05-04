using AngularSample.Models;
using Microsoft.AspNet.Mvc;
using System.Collections.Generic;

namespace AngularSample.Controllers.Api
{
    public class PersonController : Controller
    {
        [Route("/api/people")]
        public JsonResult GetPersons()
        {
            var people = new List<Person>()
            {
                new Person { Id = 1, FirstName = "John", LastName = "Doe" },
                new Person { Id = 1, FirstName = "Mary", LastName = "Jane" },
                new Person { Id = 1, FirstName = "Bob", LastName = "Parker" }
            };

            return Json(people);
        }
    }
}
