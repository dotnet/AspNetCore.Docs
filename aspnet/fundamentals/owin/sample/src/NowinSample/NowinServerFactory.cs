using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNet.Hosting.Server;
using Microsoft.AspNet.Owin;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNet.Http.Features;
using Nowin;

namespace NowinSample
{
    public class NowinServerFactory : IServerFactory
    {
        private Func<IFeatureCollection, Task> _callback;

        private Task HandleRequest(IDictionary<string, object> env)
        {
            return _callback(new FeatureCollection(new OwinFeatureCollection(env)));
        }

        public IFeatureCollection Initialize(IConfiguration configuration)
        {
            var builder = ServerBuilder.New()
                        .SetAddress(IPAddress.Any)
                        .SetPort(5000)
                        .SetOwinApp(HandleRequest);

            var serverFeatures = new FeatureCollection();
            serverFeatures.Set<INowinServerInformation>(new NowinServerInformation(builder));
            return serverFeatures;
        }

        public IDisposable Start(IFeatureCollection serverFeatures, 
                                 Func<IFeatureCollection, Task> application)
        {
            var information = serverFeatures.Get<INowinServerInformation>();
            _callback = application;
            INowinServer server = information.Builder.Build();
            server.Start();
            return server;
        }

        private class NowinServerInformation : INowinServerInformation
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