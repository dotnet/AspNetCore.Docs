### Customize Kestrel named pipe endpoints

Kestrel's named pipe support has been improved with advanced customization options. The new `CreateNamedPipeServerStream` method on the named pipe options allows pipes to be customized per-endpoint.

An example of where this is useful is a Kestrel app that requires two pipe endpoints with different [access security](/windows/win32/ipc/named-pipe-security-and-access-rights). The `CreateNamedPipeServerStream` option can be used to create pipes with custom security settings, depending on the pipe name.


```csharp
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
        var pipeSecurity = CreatePipeSecurity(context.NamedPipeEndpoint.PipeName);

        return NamedPipeServerStreamAcl.Create(context.NamedPipeEndPoint.PipeName, PipeDirection.InOut,
            NamedPipeServerStream.MaxAllowedServerInstances, PipeTransmissionMode.Byte,
            context.PipeOptions, inBufferSize: 0, outBufferSize: 0, pipeSecurity);
    };
});
```
