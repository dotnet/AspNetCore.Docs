using Nowin;

namespace NowinSample
{
    public interface INowinServerInformation
    {
        string Name { get; }
        ServerBuilder Builder { get; }
    }
}
