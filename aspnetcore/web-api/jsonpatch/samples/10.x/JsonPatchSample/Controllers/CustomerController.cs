using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch.SystemTextJson;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

using App.Data;
using App.Models;

namespace App.Controllers;

[ApiController]
[Route("/api/customers")]
public class CustomerController : ControllerBase
{
    [HttpGet("{id}", Name = "GetCustomer")]
    public async Task<IActionResult> Get(AppDb db, string id)
    {
        // Retrieve the customer by ID
        var customer = await db.Customers.FirstOrDefaultAsync(c => c.Id == id);

        // Return 404 Not Found if customer doesn't exist
        if (customer == null)
        {
            return NotFound();
        }

        return Ok(customer);
    }

    [HttpPut("{id}", Name = "PutCustomer")]
    public async Task<IActionResult> Put(AppDb db, string id, [FromBody] Customer body)
    {
        var customer = await db.Customers.Include(c => c.Orders).FirstOrDefaultAsync(c => c.Id == id);
        if (customer is null)
        {
            body.Id = id;
            db.Customers.Add(body);
            await db.SaveChangesAsync();
            return CreatedAtRoute("GetCustomer", new { id }, body);
        }

        customer.Name = body.Name;
        customer.Email = body.Email;
        customer.PhoneNumber = body.PhoneNumber;
        customer.Address = body.Address;

        await db.SaveChangesAsync();

        return Ok(customer);
    }

    // <snippet_PatchAction>
    [HttpPatch("{id}", Name = "UpdateCustomer")]
    public async Task<IActionResult> Update(AppDb db, string id, [FromBody] JsonPatchDocument<Customer> patchDoc)
    {
        // Retrieve the customer by ID
        var customer = await db.Customers.FirstOrDefaultAsync(c => c.Id == id);

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
            // return BadRequest(ModelState);
            return ValidationProblem(ModelState);
        }

        // Only save if there are no errors
        await db.SaveChangesAsync();

        return new ObjectResult(customer);
    }
    // </snippet_PatchAction>
}
