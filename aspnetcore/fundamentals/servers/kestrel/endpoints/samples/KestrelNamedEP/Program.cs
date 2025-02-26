// <snippet_1>
using System.IO.Pipes;
using System.Security.AccessControl;
using System.Security.Principal;

var builder = WebApplication.CreateBuilder();

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenNamedPipe("pipe1");
    options.ListenNamedPipe("pipe2");
});

builder.WebHost.UseNamedPipes(options =>
{
    options.CreateNamedPipeServerStream = (context) =>
    {
        var pipeSecurity = CreatePipeSecurity(context.NamedPipeEndPoint.PipeName);

        return NamedPipeServerStreamAcl.Create(context.NamedPipeEndPoint.PipeName, PipeDirection.InOut,
            NamedPipeServerStream.MaxAllowedServerInstances, PipeTransmissionMode.Byte,
            context.PipeOptions, inBufferSize: 0, outBufferSize: 0, pipeSecurity);
    };
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();

static PipeSecurity CreatePipeSecurity(string pipeName)
{
    var pipeSecurity = new PipeSecurity();
    // configure PipeSecurity object.
    // </snippet_1>

    // This code to test preceding snippet compiles, it's not a working sample.

    return null;
    // Get the current process identity.
    var currentIdentity = WindowsIdentity.GetCurrent();
    var processUser = new SecurityIdentifier(WellKnownSidType.BuiltinUsersSid,
        currentIdentity.User.AccountDomainSid);

    // Allow only the current process read and write access to the pipe.
    pipeSecurity.AddAccessRule(new PipeAccessRule(processUser,
        PipeAccessRights.ReadWrite, AccessControlType.Allow));

    return pipeSecurity;
}
