// <snippet_1>
using System.IO.Pipes;
using System.Security.AccessControl;
using System.Security.Principal;

var builder = WebApplication.CreateBuilder();

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenNamedPipe("defaultPipe");
    options.ListenNamedPipe("securedPipe");
});

builder.WebHost.UseNamedPipes(options =>
{
    options.CreateNamedPipeServerStream = (context) =>
    {
        var pipeName = context.NamedPipeEndPoint.PipeName;
        
        switch (pipeName)
        {
            case "defaultPipe":
                return NamedPipeTransportOptions.CreateDefaultNamedPipeServerStream(context);
            case "securedPipe":
                var allowSecurity = new PipeSecurity();
                allowSecurity.AddAccessRule(new PipeAccessRule("Users", PipeAccessRights.FullControl, AccessControlType.Allow));

                return NamedPipeServerStreamAcl.Create(pipeName, PipeDirection.InOut,
                    NamedPipeServerStream.MaxAllowedServerInstances, PipeTransmissionMode.Byte,
                    context.PipeOptions, inBufferSize: 0, outBufferSize: 0, allowSecurity);
            default:
                throw new InvalidOperationException($"Unexpected pipe name: {pipeName}");
        }
    };
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
// </snippet_1>
