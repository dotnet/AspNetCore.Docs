using System;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace BackgroundTasksSample.Services
{
    #region snippet1
    public interface IBackgroundTaskQueue
    {
        ValueTask QueueBackgroundWorkItemAsync(Func<CancellationToken, ValueTask> workItem);

        ValueTask<Func<CancellationToken, ValueTask>> DequeueAsync(
            CancellationToken cancellationToken);
    }

    public class BackgroundTaskQueue(int capacity) : IBackgroundTaskQueue
    {
        // Capacity should be set based on the expected application load and
        // number of concurrent threads accessing the queue.
        // BoundedChannelFullMode.Wait causes calls to WriteAsync() to return a task,
        // which only completes when space becomes available. In the event that many
        // publishers/calls start accumulating, using BoundedChannelFullMode.Wait can
        // lead to backpressure.
        private readonly Channel<Func<CancellationToken, ValueTask>> _queue =
            Channel.CreateBounded<Func<CancellationToken, ValueTask>>(new BoundedChannelOptions(capacity)
            {
                FullMode = BoundedChannelFullMode.Wait
            });

        public async ValueTask QueueBackgroundWorkItemAsync(
            Func<CancellationToken, ValueTask> workItem)
        {
            if (workItem == null)
            {
                throw new ArgumentNullException(nameof(workItem));
            }

            await _queue.Writer.WriteAsync(workItem);
        }

        public async ValueTask<Func<CancellationToken, ValueTask>> DequeueAsync(
            CancellationToken cancellationToken)
        {
            var workItem = await _queue.Reader.ReadAsync(cancellationToken);

            return workItem;
        }
    }
    #endregion
}
