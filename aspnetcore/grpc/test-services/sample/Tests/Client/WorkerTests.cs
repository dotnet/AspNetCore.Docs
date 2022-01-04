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

using Client;
using Grpc.Core;
using Moq;
using Test;
using Tests.Client.Helpers;
using Xunit;

namespace Tests.Client
{
    public class WorkerTests
    {
        #region snippet_Test
        [Fact]
        public async Task Greeting_Success_RepositoryCalled()
        {
            // Arrange
            var mockRepository = new Mock<IGreetRepository>();

            var mockCall = CallHelpers.CreateAsyncUnaryCall(new HelloReply { Message = "Test" });
            var mockClient = new Mock<Tester.TesterClient>();
            mockClient
                .Setup(m => m.SayHelloUnaryAsync(
                    It.IsAny<HelloRequest>(), null, null, CancellationToken.None))
                .Returns(mockCall);

            var worker = new Worker(mockClient.Object, mockRepository.Object);

            // Act
            await worker.StartAsync(CancellationToken.None);

            // Assert
            mockRepository.Verify(v => v.SaveGreeting("Test"));
        }
        #endregion

        [Fact]
        public async Task Greeting_Error_ExceptionThrown()
        {
            // Arrange
            var mockRepository = new Mock<IGreetRepository>();
            var mockClient = new Mock<Tester.TesterClient>();
            mockClient
                .Setup(m => m.SayHelloUnaryAsync(It.IsAny<HelloRequest>(), null, null, CancellationToken.None))
                .Returns(CallHelpers.CreateAsyncUnaryCall<HelloReply>(StatusCode.InvalidArgument));

            var worker = new Worker(mockClient.Object, mockRepository.Object);

            // Act & Assert
            try
            {
                await worker.StartAsync(CancellationToken.None);
                Assert.True(false, "RpcException should have been thrown.");
            }
            catch (RpcException ex)
            {
                Assert.Equal(StatusCode.InvalidArgument, ex.StatusCode);
            }
        }
    }
}
