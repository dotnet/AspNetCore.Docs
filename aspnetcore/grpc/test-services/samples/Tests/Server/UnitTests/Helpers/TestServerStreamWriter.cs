#region Copyright notice and license

// Copyright 2019 The gRPC Authors
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#endregion

using System.Threading.Channels;
using Grpc.Core;

namespace Tests.Server.UnitTests.Helpers
{
    public class TestServerStreamWriter<T> : IServerStreamWriter<T> where T : class
    {
        private readonly ServerCallContext _serverCallContext;
        private readonly Channel<T> _channel;

        public WriteOptions? WriteOptions { get; set; }

        public TestServerStreamWriter(ServerCallContext serverCallContext)
        {
            _channel = Channel.CreateUnbounded<T>();

            _serverCallContext = serverCallContext;
        }

        public void Complete()
        {
            _channel.Writer.Complete();
        }

        public IAsyncEnumerable<T> ReadAllAsync()
        {
            return _channel.Reader.ReadAllAsync();
        }

        public async Task<T?> ReadNextAsync()
        {
            if (await _channel.Reader.WaitToReadAsync())
            {
                _channel.Reader.TryRead(out var message);
                return message;
            }
            else
            {
                return null;
            }
        }

        public Task WriteAsync(T message)
        {
            if (_serverCallContext.CancellationToken.IsCancellationRequested)
            {
                return Task.FromCanceled(_serverCallContext.CancellationToken);
            }

            if (!_channel.Writer.TryWrite(message))
            {
                throw new InvalidOperationException("Unable to write message.");
            }

            return Task.CompletedTask;
        }
    }
}
