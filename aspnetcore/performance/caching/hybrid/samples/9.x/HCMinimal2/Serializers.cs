namespace HCMinimal;
using System.Buffers;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using global::Microsoft.Extensions.Caching.Hybrid;
using Google.Protobuf;
/// <summary>
/// HybridCache serialization implementation for a single Google.Protobuf message type.
/// </summary>
/// <typeparam name="T">The type of message to be handled</typeparam>.
public class GoogleProtobufSerializer<T> : IHybridCacheSerializer<T> where T : IMessage<T>
{
    // Serialization: via IMessage<T> instance methods.
    // Deserialization: via the parser API on the static .Parser property.
    private static readonly MessageParser<T> _parser = typeof(T)
        .GetProperty("Parser", BindingFlags.Public | BindingFlags.Static)?.GetValue(null)
            as MessageParser<T> ?? throw new InvalidOperationException(
                "Message parser not found; type may not be Google.Protobuf");

    T IHybridCacheSerializer<T>.Deserialize(ReadOnlySequence<byte> source)
        => _parser.ParseFrom(source);

    void IHybridCacheSerializer<T>.Serialize(T value, IBufferWriter<byte> target)
          => value.WriteTo(target);

    /// <summary>
    /// HybridCache serialization factory implementation for Google.Protobuf message types.
    /// </summary>
}
public class GoogleProtobufSerializerFactory : IHybridCacheSerializerFactory
{
    public bool TryCreateSerializer<T>([NotNullWhen(true)] out IHybridCacheSerializer<T>? serializer)
    {
        // All Google.Protobuf types implement IMessage<T> : IMessage; check for IMessage first,
        // since we can do that without needing to use MakeGenericType for that. Note that
        // IMessage<T> and GoogleProtobufSerializer<T> both have the T : IMessage<T> constraint,
        // which means we're going to need to use reflection here
        try
        {
            if (typeof(IMessage).IsAssignableFrom(typeof(T))
                && typeof(IMessage<>).MakeGenericType(typeof(T)).IsAssignableFrom(typeof(T)))
            {
                serializer = (IHybridCacheSerializer<T>)Activator.CreateInstance(
                    typeof(GoogleProtobufSerializer<>).MakeGenericType(typeof(T)))!;
                return true;
            }
        }
        catch (Exception ex)
        {
            // Unexpected; maybe manually implemented and missing .Parser property?
            // Log it and ignore the type.
            Debug.WriteLine(ex.Message);
        }
        // This does not appear to be a Google.Protobuf type.
        serializer = null;
        return false;
    }
}

