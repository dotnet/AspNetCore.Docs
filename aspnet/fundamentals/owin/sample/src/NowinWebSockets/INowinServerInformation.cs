using Nowin;

namespace NowinWebSockets
{
    public interface INowinServerInformation
    {
        string Name { get; }
        ServerBuilder Builder { get; }
    }
}
