using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AppPartsSample.Model;

namespace AppPartsSample
{
    // An IApplicationFeatureProvider<ControllerFeature> will be used at startup time to
    // discover types that should be treated as controllers. ASP.NET Core does not regster
    // open generic type controllers.
    //
    // This component creates a new type (e.g. GenericController<Widget>) for each entity 
    // type that does not have a non-generic controller defined. This is determined based 
    // on the type name. Because SprocketController is defined, GenericController<Sprocket> 
    // is not added as it would create a conflict.
    #region snippet
    public class GenericControllerFeatureProvider : 
        IApplicationFeatureProvider<ControllerFeature>
    {
        public void PopulateFeature(IEnumerable<ApplicationPart> parts, ControllerFeature 
                                                                                  feature)
        {
            // This is designed to run after the default ControllerTypeProvider, 
            // so the list of 'real' controllers has already been populated.
            foreach (var entityType in EntityTypes.Types)
            {
                var typeName = entityType.Name + "Controller";
                if (!feature.Controllers.Any(t => t.Name == typeName))
                {
                    // There's no controller for this entity, so add the generic version.
                    var controllerType = typeof(GenericController<>)
                        .MakeGenericType(entityType.AsType()).GetTypeInfo();
                    feature.Controllers.Add(controllerType);
                }
            }
        }
    }
    #endregion
}
