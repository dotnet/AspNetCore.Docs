
// <all>
var app = WebApplication.Create();

app.UseHttpLogging();

app.MapGet("/", () => "No short-circuiting!");
// <mapget>
app.MapGet("/short-circuit", () => "Short circuiting!").ShortCircuit();
// </mapget>
// <mapshortcircuit>
app.MapShortCircuit(404, "robots.txt", "favicon.ico");
// </mapshortcircuit>

app.Run();
// </all>
