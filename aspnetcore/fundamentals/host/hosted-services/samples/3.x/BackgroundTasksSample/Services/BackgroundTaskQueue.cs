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

        Task<Func<CancellationToken, ValueTask>> DequeueAsync(
            CancellationToken cancellationToken);
    }

    public class BackgroundTaskQueue : IBackgroundTaskQueue
    {
        private readonly Channel<Func<CancellationToken, ValueTask>> _queue = Channel.CreateUnbounded<Func<CancellationToken, ValueTask>>();

        private readonly SemaphoreSlim _signal = new SemaphoreSlim(0);

        public async ValueTask QueueBackgroundWorkItemAsync(
            Func<CancellationToken, ValueTask> workItem)
        {
            if (workItem == null)
            {
                throw new ArgumentNullException(nameof(workItem));
            }

            await _queue.Writer.WriteAsync(workItem);
            
            _signal.Release();
        }

        public async Task<Func<CancellationToken, ValueTask>> DequeueAsync(
            CancellationToken cancellationToken)
        {
            await _signal.WaitAsync(cancellationToken);

            _queue.Reader.TryRead(out var workItem);

            return workItem;
        }
    }
    #endregion
}
