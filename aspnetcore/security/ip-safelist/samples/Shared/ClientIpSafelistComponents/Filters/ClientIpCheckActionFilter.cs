using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Net;

namespace ClientIpSafelistComponents.Filters
{
    public class ClientIpCheckActionFilter : ActionFilterAttribute
    {
        private readonly string _safelist;

        public ILogger Logger { get; set; }

        public ClientIpCheckActionFilter(IConfiguration configuration)
        {
            _safelist = configuration["AdminSafeList"];
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var remoteIp = context.HttpContext.Connection.RemoteIpAddress;
            Logger.LogInformation(
                "Remote IpAddress: {RemoteIp}", remoteIp);

            string[] ip = _safelist.Split(';');

            var badIp = true;
            foreach (var address in ip)
            {
                if (remoteIp.IsIPv4MappedToIPv6)
                {
                    remoteIp = remoteIp.MapToIPv4();
                }
                var testIp = IPAddress.Parse(address);
                if (testIp.Equals(remoteIp))
                {
                    badIp = false;
                    break;
                }
            }

            if (badIp)
            {
                Logger.LogInformation(
                    "Forbidden Request from Remote IP address: {RemoteIp}", remoteIp);
                context.Result = new StatusCodeResult(401);
                return;
            }

            base.OnActionExecuting(context);
        }
    }
}
