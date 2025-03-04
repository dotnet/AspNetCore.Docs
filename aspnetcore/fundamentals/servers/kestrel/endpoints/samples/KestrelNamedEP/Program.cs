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
        if (context.NamedPipeEndPoint.PipeName == "defaultPipe")
        {
            return NamedPipeTransportOptions.CreateDefaultNamedPipeServerStream(context);
        }
        
        var allowSecurity = new PipeSecurity();
        allowSecurity.AddAccessRule(new PipeAccessRule("Users", PipeAccessRights.FullControl, AccessControlType.Allow));

        return NamedPipeServerStreamAcl.Create(context.NamedPipeEndPoint.PipeName, PipeDirection.InOut,
            NamedPipeServerStream.MaxAllowedServerInstances, PipeTransmissionMode.Byte,
            context.PipeOptions, inBufferSize: 0, outBufferSize: 0, allowSecurity);
    };
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
// </snippet_1>
