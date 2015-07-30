using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.FeatureModel;
using Microsoft.AspNet.Hosting.Server;
using Microsoft.AspNet.Owin;
using Microsoft.Framework.Configuration;
using Nowin;

namespace NowinWebSockets
{
    public class NowinServerFactory : IServerFactory
    {
        private Func<IFeatureCollection, Task> _callback;

        private Task HandleRequest(IDictionary<string, object> env)
        {
            return _callback(new OwinFeatureCollection(env));
        }

        public IServerInformation Initialize(IConfiguration configuration)
        {
            // TODO: Parse config
            var builder = ServerBuilder.New()
                                       .SetAddress(IPAddress.Any)
                                       .SetPort(5000)
                                       .SetOwinApp(OwinWebSocketAcceptAdapter.AdaptWebSockets(HandleRequest));

            return new NowinServerInformation(builder);
        }

        public IDisposable Start(IServerInformation serverInformation, Func<IFeatureCollection, Task> application)
        {
            var information = (NowinServerInformation)serverInformation;
            _callback = application;
            INowinServer server = information.Builder.Build();
            server.Start();
            return server;
        }

        private class NowinServerInformation : IServerInformation
        {
            public NowinServerInformation(ServerBuilder builder)
            {
                Builder = builder;
            }

            public ServerBuilder Builder { get; private set; }

            public string Name
            {
                get
                {
                    return "Nowin";
                }
            }
        }
    }
}