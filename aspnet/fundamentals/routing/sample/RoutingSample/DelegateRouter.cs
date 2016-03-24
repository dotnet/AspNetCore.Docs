using System.Threading.Tasks;
using Microsoft.AspNet.Routing;

namespace RoutingSample
{
    public class DelegateRouter : IRouter
    {
        public delegate Task RoutedDelegate(RouteContext context);

        private readonly RoutedDelegate _appFunc;

        public DelegateRouter(RoutedDelegate appFunc)
        {
            _appFunc = appFunc;
        }

        public async Task RouteAsync(RouteContext context)
        {
            await _appFunc(context);
            context.IsHandled = true;
        }

        public VirtualPathData GetVirtualPath(VirtualPathContext context)
        {
            context.IsBound = true;
            return null;
        }
    }
}