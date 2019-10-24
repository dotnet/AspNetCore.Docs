using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Net;

namespace ClientIpAspNetCore
{
    public class ClientIpCheckPageFilter : IPageFilter
    {
        private readonly ILogger _logger;
        private readonly string _safelist;

        public ClientIpCheckPageFilter
            (ILoggerFactory loggerFactory, IConfiguration configuration)
        {
            _logger = loggerFactory.CreateLogger("ClientIdCheckPageFilter");
            _safelist = configuration["AdminSafeList"];
        }

        public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            var remoteIp = context.HttpContext.Connection.RemoteIpAddress;
            _logger.LogInformation(
                "Remote IpAddress: {RemoteIp}", remoteIp);

            string[] ip = _safelist.Split(';');

            var bytes = remoteIp.GetAddressBytes();
            var badIp = true;
            foreach (var address in ip)
            {
                var testIp = IPAddress.Parse(address);
                if (testIp.GetAddressBytes().SequenceEqual(bytes))
                {
                    badIp = false;
                    break;
                }
            }

            if (badIp)
            {
                _logger.LogInformation(
                    "Forbidden Request from Remote IP address: {RemoteIp}", remoteIp);
                context.Result = new StatusCodeResult(401);
                return;
            }
        }

        public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {
        }

        public void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {
        }
    }
}
