using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch.SystemTextJson;

using App.Data;
using App.Models;

namespace App.Controllers;

[ApiController]
[Route("/api/customers")]
public class CustomerController : ControllerBase
{
    [HttpGet("{id}", Name = "GetCustomer")]
    public Customer Get(AppDb db, string id)
    {
        // Retrieve the customer by ID
        var customer = db.Customers.FirstOrDefault(c => c.Id == id);

        // Return 404 Not Found if customer doesn't exist
        if (customer == null)
        {
            Response.StatusCode = 404;
            return null;
        }

        return customer;
    }

    // <snippet_PatchAction>
    [HttpPatch("{id}", Name = "UpdateCustomer")]
    public IActionResult Update(AppDb db, string id, [FromBody] JsonPatchDocument<Customer> patchDoc)
    {
        // Retrieve the customer by ID
        var customer = db.Customers.FirstOrDefault(c => c.Id == id);

        // Return 404 Not Found if customer doesn't exist
        if (customer == null)
        {
            return NotFound();
        }

        patchDoc.ApplyTo(customer, jsonPatchError =>
            {
                var key = jsonPatchError.AffectedObject.GetType().Name;
                ModelState.AddModelError(key, jsonPatchError.ErrorMessage);
            }
        );

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return new ObjectResult(customer);
    }
    // </snippet_PatchAction>
}
