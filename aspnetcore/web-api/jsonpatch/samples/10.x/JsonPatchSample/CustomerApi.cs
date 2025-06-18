using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch.SystemTextJson;
using Microsoft.EntityFrameworkCore;

using App.Data;
using App.Models;

internal static class CustomerApi {
    public static void MapCustomerApi(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/customers").WithTags("Customers");

        group.MapGet("/{id}", async Task<Results<Ok<Customer>, NotFound>> (AppDb db, string id) =>
        {
            return await db.Customers.Include(c => c.Orders).FirstOrDefaultAsync(c => c.Id == id) is Customer customer
                ? TypedResults.Ok(customer)
                : TypedResults.NotFound();
        });

        group.MapPatch("/{id}", async Task<Results<Ok<Customer>,NotFound,BadRequest, ValidationProblem>> (AppDb db, string id,
            JsonPatchDocument<Customer> patchDoc) =>
        {
            var customer = await db.Customers.Include(c => c.Orders).FirstOrDefaultAsync(c => c.Id == id);
            if (customer is null)
            {
                return TypedResults.NotFound();
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
                await db.SaveChangesAsync();
            }

            return TypedResults.Ok(customer);
        })
        .Accepts<JsonPatchDocument<Customer>>("application/json-patch+json");
    }
}