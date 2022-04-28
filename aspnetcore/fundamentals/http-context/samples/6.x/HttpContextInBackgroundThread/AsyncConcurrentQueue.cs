using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;

namespace HttpContextInBackgroundThread;

/// <inheritdoc cref="IDisposable" />
/// <inheritdoc cref="IAsyncConcurrentQueue{T}" />
[SuppressMessage("Naming", "CA1711: Identifiers should not have incorrect suffix", Justification = "This is a queue but does not implement System.Collections.Queue because this class handles concurrency.")]
public sealed class AsyncConcurrentQueue<T> : IAsyncConcurrentQueue<T>, IDisposable
{
    private readonly ConcurrentQueue<T> _queue = new();
    private readonly SemaphoreSlim _signal = new(0);

    /// <inheritdoc />
    public void Enqueue(T item)
    {
        _queue.Enqueue(item);
        _signal.Release();
    }

    /// <inheritdoc />
    public async Task<T> DequeueAsync(CancellationToken cancellationToken)
    {
        await _signal.WaitAsync(cancellationToken);
        if (_queue.TryDequeue(out T? item))
        {
            return item;
        }

        throw new InvalidOperationException($"Unexpected failure of {nameof(AsyncConcurrentQueue<T>)}.{nameof(AsyncConcurrentQueue<T>.DequeueAsync)}.");
    }

    /// <inheritdoc />
    public bool TryDequeue([MaybeNullWhen(true)] out T? item)
    {
        if (_signal.Wait(0))
        {
            if (_queue.TryDequeue(out item))
            {
                return true;
            }

            throw new InvalidOperationException("Unexpected failure of {nameof(AsyncConcurrentQueue<T>)}.{nameof(AsyncConcurrentQueue<T>.TryDequeue)}.");
        }

        item = default;
        return false;
    }

    /// <inheritdoc />
    public void Dispose()
    {
        _signal.Dispose();
    }
}
