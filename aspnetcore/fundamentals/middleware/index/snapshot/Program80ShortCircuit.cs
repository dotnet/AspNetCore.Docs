var app = WebApplication.Create();

app.UseHttpLogging();

// <mapget>
app.MapGet("/short-circuit", () => "Hello world!").ShortCircuit();
// </mapget>
// <mapshortcircuit>
app.MapShortCircuit(404, "robots.txt", "favicon.ico");
// </mapshortcircuit>

app.Run();
