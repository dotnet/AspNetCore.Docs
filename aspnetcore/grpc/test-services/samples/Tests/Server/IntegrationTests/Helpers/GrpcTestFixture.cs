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

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace Tests.Server.IntegrationTests.Helpers
{
    public delegate void LogMessage(LogLevel logLevel, string categoryName, EventId eventId, string message, Exception? exception);

    public class GrpcTestFixture<TStartup> : IDisposable where TStartup : class
    {
        private TestServer? _server;
        private IHost? _host;
        private HttpMessageHandler? _handler;
        private Action<IWebHostBuilder>? _configureWebHost;

        public event LogMessage? LoggedMessage;

        public GrpcTestFixture()
        {
            LoggerFactory = new LoggerFactory();
            LoggerFactory.AddProvider(new ForwardingLoggerProvider((logLevel, category, eventId, message, exception) =>
            {
                LoggedMessage?.Invoke(logLevel, category, eventId, message, exception);
            }));
        }

        public void ConfigureWebHost(Action<IWebHostBuilder> configure)
        {
            _configureWebHost = configure;
        }

        private void EnsureServer()
        {
            if (_host == null)
            {
                var builder = new HostBuilder()
                    .ConfigureServices(services =>
                    {
                        services.AddSingleton<ILoggerFactory>(LoggerFactory);
                    })
                    .ConfigureWebHostDefaults(webHost =>
                    {
                        webHost
                            .UseTestServer()
                            .UseStartup<TStartup>();

                        _configureWebHost?.Invoke(webHost);
                    });
                _host = builder.Start();
                _server = _host.GetTestServer();
                _handler = _server.CreateHandler();
            }
        }

        public LoggerFactory LoggerFactory { get; }

        public HttpMessageHandler Handler
        {
            get
            {
                EnsureServer();
                return _handler!;
            }
        }

        public void Dispose()
        {
            _handler?.Dispose();
            _host?.Dispose();
            _server?.Dispose();
        }

        public IDisposable GetTestContext(ITestOutputHelper outputHelper)
        {
            return new GrpcTestContext<TStartup>(this, outputHelper);
        }
    }
}
