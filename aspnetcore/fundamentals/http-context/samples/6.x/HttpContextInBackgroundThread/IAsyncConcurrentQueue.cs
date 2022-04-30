using System.Diagnostics.CodeAnalysis;

namespace HttpContextInBackgroundThread;

/// <summary>
/// A concurrent queue, where all instance methods are thread-safe.
/// </summary>
/// <typeparam name="T">The type of the items added to this queue.</typeparam>
[SuppressMessage("Naming", "CA1711: Identifiers should not have incorrect suffix", Justification = "This is a queue but does not implement System.Collections.Queue because this class handles concurrency.")]
public interface IAsyncConcurrentQueue<T>
{
    /// <summary>
    /// Queue an item.
    /// </summary>
    /// <param name="item">The item to queue.</param>
    void Enqueue(T item);

    /// <summary>
    /// Wait until there are items in the queue, then dequeue and returns the item.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token to abort execution.</param>
    /// <returns>Returns a queued item.</returns>
    /// <exception cref="System.OperationCanceledException">
    /// The <paramref name="cancellationToken" /> was canceled.
    /// </exception>
    Task<T?> DequeueAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Dequeue an item. Returns <see langword="true" /> when an item was successfully dequeued,
    /// otherwise returns <see langword="false" /> when there are no items in the queue.
    /// </summary>
    /// <param name="item">A queued item.</param>
    /// <returns>Returns <see langword="true" /> when an item was successfully dequeued.</returns>
    bool TryDequeue([MaybeNullWhen(true)] out T? item);
}
