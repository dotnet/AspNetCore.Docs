using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch.SystemTextJson;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using App.Data;
using App.Models;

internal static class CustomerApi {
    public static void MapCustomerApi(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/customers").WithTags("Customers");

        group.MapGet("/{id}", async Task<Results<Ok<Customer>, NotFound<ProblemDetails>>> (AppDb db, string id) =>
        {
            return await db.Customers.Include(c => c.Orders).FirstOrDefaultAsync(c => c.Id == id) is Customer customer
                ? TypedResults.Ok(customer)
                : TypedResults.NotFound<ProblemDetails>(new ());
        });

        group.MapPut("/{id}", async Task<Results<Ok<Customer>,Created<Customer>,ValidationProblem>> (AppDb db, string id, Customer body) =>
        {
            var customer = await db.Customers.Include(c => c.Orders).FirstOrDefaultAsync(c => c.Id == id);
            if (customer is null)
            {
                body.Id = id;
                db.Customers.Add(body);
                await db.SaveChangesAsync();
                return TypedResults.Created($"/customers/{id}", body);
            }

            customer.Name = body.Name;
            customer.Email = body.Email;
            customer.PhoneNumber = body.PhoneNumber;
            customer.Address = body.Address;

            await db.SaveChangesAsync();

            return TypedResults.Ok(customer);
        });

        // <snippet_PatchMethod>
        group.MapPatch("/{id}", async Task<Results<Ok<Customer>,ValidationProblem,NotFound<ProblemDetails>>> (AppDb db, string id,
            JsonPatchDocument<Customer> patchDoc) =>
        {
            var customer = await db.Customers.Include(c => c.Orders).FirstOrDefaultAsync(c => c.Id == id);
            if (customer is null)
            {
                return TypedResults.NotFound<ProblemDetails>(new ());
            }
            if (patchDoc != null)
            {
                Dictionary<string, string[]>? errors = null;
                patchDoc.ApplyTo(customer, jsonPatchError =>
                    {
                        errors ??= new ();
                        var key = jsonPatchError.AffectedObject.GetType().Name;
                        if (!errors.ContainsKey(key))
                        {
                            errors.Add(key, new string[] { });
                        }
                        errors[key] = errors[key].Append(jsonPatchError.ErrorMessage).ToArray();
                    });

                if (errors != null)
                {
                    return TypedResults.ValidationProblem(errors);
                }

                // Only save if there are no errors
                await db.SaveChangesAsync();
            }

            return TypedResults.Ok(customer);
        })
        .Accepts<JsonPatchDocument<Customer>>("application/json-patch+json");
        // </snippet_PatchMethod>
    }
}