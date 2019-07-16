using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Threading.Channels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SignalRChat.Hubs
{
    #region snippet1
    public class StreamHub : Hub
    {
        public ChannelReader<int> Counter(int count, int delay)
        {
            var channel = Channel.CreateUnbounded<int>();

            // We don't want to await WriteItemsAsync, otherwise we'd end up waiting 
            // for all the items to be written before returning the channel back to
            // the client.
            _ = WriteItemsAsync(channel.Writer, count, delay);

            return channel.Reader;
        }

        private async Task WriteItemsAsync(
            ChannelWriter<int> writer,
            int count,
            int delay)
        {
            try
            {
                for (var i = 0; i < count; i++)
                {
                    await writer.WriteAsync(i);
                    await Task.Delay(delay);
                }
            }
            catch (Exception ex)
            {
                writer.TryComplete(ex);
            }

            writer.TryComplete();
        }
    }
    #endregion
}