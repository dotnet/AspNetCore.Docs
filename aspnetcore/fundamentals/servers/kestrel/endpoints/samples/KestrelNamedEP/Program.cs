// <snippet_1>
using System.IO.Pipes;
using System.Security.AccessControl;
using System.Security.Principal;
using Microsoft.AspNetCore.Server.Kestrel.Transport.NamedPipes;

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
                // A custom PipeSecurity can't be combined with
                // PipeOptions.CurrentUserOnly, so clear the flag for this
                // endpoint only. defaultPipe keeps its default protection.
                var pipeOptions = context.PipeOptions & ~PipeOptions.CurrentUserOnly;

                return NamedPipeServerStreamAcl.Create(pipeName, PipeDirection.InOut,
                    NamedPipeServerStream.MaxAllowedServerInstances, PipeTransmissionMode.Byte,
                    pipeOptions, inBufferSize: 0, outBufferSize: 0, CreateSecuredPipeSecurity());
            default:
                throw new InvalidOperationException($"Unexpected pipe name: {pipeName}");
        }
    };
});

static PipeSecurity CreateSecuredPipeSecurity()
{
    using var serverIdentity = WindowsIdentity.GetCurrent();
    var pipeSecurity = new PipeSecurity();

    // Only the account the server runs as creates pipe instances, so it's the
    // only principal that needs CreateNewInstance.
    pipeSecurity.AddAccessRule(new PipeAccessRule(
        serverIdentity.User!,
        PipeAccessRights.ReadWrite | PipeAccessRights.CreateNewInstance,
        AccessControlType.Allow));

    // Callers only need to read and write. Replace this SID with the narrowest
    // group that must reach the endpoint.
    pipeSecurity.AddAccessRule(new PipeAccessRule(
        new SecurityIdentifier(WellKnownSidType.BuiltinAdministratorsSid, null),
        PipeAccessRights.ReadWrite,
        AccessControlType.Allow));

    return pipeSecurity;
}

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
// </snippet_1>
