using AngularSample.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

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

            // force the Json serializer to keep the case of the model properties
            var serializerSettings = new JsonSerializerSettings();
            serializerSettings.ContractResolver = new DefaultContractResolver();

            return Json(people, serializerSettings);
        }
    }
}
