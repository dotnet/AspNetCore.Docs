using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Net;

namespace ClientIpSafelistComponents.Filters
{
    #region snippet_ClassOnly
    public class ClientIpCheckPageFilter : IPageFilter
    {
        private readonly ILogger _logger;
        private readonly IPAddress[] _safelist;

        public ClientIpCheckPageFilter(
            string safelist,
            ILogger logger)
        {
            var ips = safelist.Split(';');
            _safelist = new IPAddress[ips.Length];
            for (var i = 0; i < ips.Length; i++)
            {
                _safelist[i] = IPAddress.Parse(ips[i]);
            }

            _logger = logger;
        }

        public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            var remoteIp = context.HttpContext.Connection.RemoteIpAddress;
            if (remoteIp.IsIPv4MappedToIPv6)
            {
                remoteIp = remoteIp.MapToIPv4();
            }
            _logger.LogDebug(
                "Remote IpAddress: {RemoteIp}", remoteIp);

            var badIp = true;
            foreach (var testIp in _safelist)
            {
                if (testIp.Equals(remoteIp))
                {
                    badIp = false;
                    break;
                }
            }

            if (badIp)
            {
                _logger.LogWarning(
                    "Forbidden Request from Remote IP address: {RemoteIp}", remoteIp);
                context.Result = new StatusCodeResult(StatusCodes.Status403Forbidden);
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
    #endregion snippet_ClassOnly
}
