using Microsoft.Data.Edm;
using System.Linq;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData.Routing;
using System.Web.Http.OData.Routing.Conventions;

namespace ODataRouting
{
    public class NavigationIndexRoutingConvention : EntitySetRoutingConvention
    {
        public override string SelectAction(ODataPath odataPath, HttpControllerContext context, 
            ILookup<string, HttpActionDescriptor> actionMap)
        {
            if (context.Request.Method == HttpMethod.Get && 
                odataPath.PathTemplate == "~/entityset/key/navigation/key")
            {
                NavigationPathSegment navigationSegment = odataPath.Segments[2] as NavigationPathSegment;
                IEdmNavigationProperty navigationProperty = navigationSegment.NavigationProperty.Partner;
                IEdmEntityType declaringType = navigationProperty.DeclaringType as IEdmEntityType;

                string actionName = "Get" + declaringType.Name;
                if (actionMap.Contains(actionName))
                {
                    // Add keys to route data, so they will bind to action parameters.
                    KeyValuePathSegment keyValueSegment = odataPath.Segments[1] as KeyValuePathSegment;
                    context.RouteData.Values[ODataRouteConstants.Key] = keyValueSegment.Value;

                    KeyValuePathSegment relatedKeySegment = odataPath.Segments[3] as KeyValuePathSegment;
                    context.RouteData.Values[ODataRouteConstants.RelatedKey] = relatedKeySegment.Value;

                    return actionName;
                }
            }
            // Not a match.
            return null;
        }
    }
}