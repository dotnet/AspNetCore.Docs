//using Microsoft.AspNetCore.Http;
//using Microsoft.Extensions.Configuration;

//namespace WebAPI.Util
//{
//    public static class SetHost
//    {
//        public static string GetHost(IConfiguration Configuration, HttpContext context)
//        {
//            var Host = Configuration["host3"];
//            var theHost = context.Request.Host.Value;
//            if (Host.Contains(theHost))
//            {
//                Host = Configuration["host1"];
//            }
//            return Host;
//        }
//    }
//}
