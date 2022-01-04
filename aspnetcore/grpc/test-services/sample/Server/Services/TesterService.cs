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

using Grpc.Core;
using Test;

namespace Server
{
    #region snippet_TesterService
    public class TesterService : Tester.TesterBase
    {
        private readonly IGreeter _greeter;

        public TesterService(IGreeter greeter)
        {
            _greeter = greeter;
        }

        public override Task<HelloReply> SayHelloUnary(HelloRequest request,
            ServerCallContext context)
        {
            var message = _greeter.Greet(request.Name);
            return Task.FromResult(new HelloReply { Message = message });
        }

        public override async Task SayHelloServerStreaming(HelloRequest request,
            IServerStreamWriter<HelloReply> responseStream, ServerCallContext context)
        {
            var i = 0;
            while (!context.CancellationToken.IsCancellationRequested)
            {
                var message = _greeter.Greet($"{request.Name} {++i}");
                await responseStream.WriteAsync(new HelloReply { Message = message });

                await Task.Delay(1000);
            }
        }

        public override async Task<HelloReply> SayHelloClientStreaming(
            IAsyncStreamReader<HelloRequest> requestStream, ServerCallContext context)
        {
            var names = new List<string>();

            await foreach (var request in requestStream.ReadAllAsync())
            {
                names.Add(request.Name);
            }

            var message = _greeter.Greet(string.Join(", ", names));
            return new HelloReply { Message = message };
        }

        public override async Task SayHelloBidirectionalStreaming(
            IAsyncStreamReader<HelloRequest> requestStream,
            IServerStreamWriter<HelloReply> responseStream,
            ServerCallContext context)
        {
            await foreach (var request in requestStream.ReadAllAsync())
            {
                await responseStream.WriteAsync(
                    new HelloReply { Message = _greeter.Greet(request.Name) });
            }
        }
    }
    #endregion
}
