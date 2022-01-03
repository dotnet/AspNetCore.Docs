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

using Grpc.Net.Client;
using Microsoft.Extensions.Logging;
using Server;
using Tests.Server.IntegrationTests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Tests.Server.IntegrationTests
{
    public class IntegrationTestBase : IClassFixture<GrpcTestFixture<Startup>>, IDisposable
    {
        private GrpcChannel? _channel;
        private IDisposable? _testContext;

        protected GrpcTestFixture<Startup> Fixture { get; set; }

        protected ILoggerFactory LoggerFactory => Fixture.LoggerFactory;

        protected GrpcChannel Channel => _channel ??= CreateChannel();

        protected GrpcChannel CreateChannel()
        {
            return GrpcChannel.ForAddress("http://localhost", new GrpcChannelOptions
            {
                LoggerFactory = LoggerFactory,
                HttpHandler = Fixture.Handler
            });
        }

        public IntegrationTestBase(GrpcTestFixture<Startup> fixture, ITestOutputHelper outputHelper)
        {
            Fixture = fixture;
            _testContext = Fixture.GetTestContext(outputHelper);
        }

        public void Dispose()
        {
            _testContext?.Dispose();
            _channel = null;
        }
    }
}