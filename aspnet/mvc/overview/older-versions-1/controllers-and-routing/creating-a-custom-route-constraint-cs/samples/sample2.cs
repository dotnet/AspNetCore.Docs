using System.Web;
using System.Web.Routing;
namespace MvcApplication1.Constraints
{
    public class LocalhostConstraint : IRouteConstraint
    {
        public bool Match
            (
                HttpContextBase httpContext, 
                Route route, 
                string parameterName, 
                RouteValueDictionary values, 
                RouteDirection routeDirection
            )
        {
            return httpContext.Request.IsLocal;
        }
    }
}