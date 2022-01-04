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
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Server;
using Test;
using Tests.Server.IntegrationTests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Tests.Server.IntegrationTests
{
    public class MockedGreeterServiceTests : IntegrationTestBase
    {
        #region snippet_SayHelloUnaryTest
        public MockedGreeterServiceTests(GrpcTestFixture<Startup> fixture,
            ITestOutputHelper outputHelper) : base(fixture, outputHelper)
        {
            var mockGreeter = new Mock<IGreeter>();
            mockGreeter.Setup(
                m => m.Greet(It.IsAny<string>())).Returns((string s) => $"Test {s}");

            Fixture.ConfigureWebHost(builder =>
            {
                builder.ConfigureServices(
                    services => services.AddSingleton(mockGreeter.Object));
            });
        }

        [Fact]
        public async Task SayHelloUnaryTest_MockGreeter()
        {
            // Arrange
            var client = new Tester.TesterClient(Channel);

            // Act
            var response = await client.SayHelloUnaryAsync(
                new HelloRequest { Name = "Joe" });

            // Assert
            Assert.Equal("Test Joe", response.Message);
        }
        #endregion
    }
}
