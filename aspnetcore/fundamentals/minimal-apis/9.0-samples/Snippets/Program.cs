using System.Net.Mime;
using System.Reflection;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Snippets;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        // <snippet_01>
        app.MapGet("/hello", () => "Hello World");
        // </snippet_01>
        // <snippet_02>
        app.MapGet("/hello", () => new { Message = "Hello World" });
        // </snippet_02>
        // <snippet_03>
        app.MapGet("/orders/{orderId}", IResult (int orderId)
            => orderId > 999 ? TypedResults.BadRequest() : TypedResults.Ok(new Order(orderId)))
            .Produces(400)
            .Produces<Order>();
        // </snippet_03>
        // <snippet_04>
        app.MapGet("/orders/{orderId}", Results<BadRequest, Ok<Order>> (int orderId)
            => orderId > 999 ? TypedResults.BadRequest() : TypedResults.Ok(new Order(orderId)));
        // </snippet_04>
        // <snippet_05>
        app.MapGet("/hello", () => Results.Json(new { Message = "Hello World" }));
        // </snippet_05>
        // <snippet_06>
        app.MapGet("/405", () => Results.StatusCode(405));
        // </snippet_06>
        // <snippet_07>
        app.MapGet("/500", () => Results.InternalServerError("Something went wrong!"));
        // </snippet_07>
        // <snippet_08>
        app.MapGet("/text", () => Results.Text("This is some text"));
        // </snippet_08>
        // <snippet_09>
        app.MapGet("/old-path", () => Results.Redirect("/new-path"));
        // </snippet_09>
        // <snippet_10>
        app.MapGet("/download", () => Results.File("myfile.text"));
        // </snippet_10>

        app.Run();
    }
    // <snippet_11>
    public static void PopulateMetadata(MethodInfo method, EndpointBuilder builder)
    {
        builder.Metadata.Add(new ProducesAttribute(MediaTypeNames.Text.Html));
    }
    // </snippet_11>
}

internal class Order
{
    public int ID { get; }

    public Order(int id)
    {
        ID = id;
    }
}
