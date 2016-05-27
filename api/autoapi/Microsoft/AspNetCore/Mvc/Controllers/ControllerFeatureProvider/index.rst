

ControllerFeatureProvider Class
===============================






Discovers controllers from a list of :any:`Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPart` instances.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Controllers`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Controllers.ControllerFeatureProvider`








Syntax
------

.. code-block:: csharp

    public class ControllerFeatureProvider : IApplicationFeatureProvider<ControllerFeature>, IApplicationFeatureProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.Controllers.ControllerFeatureProvider
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Controllers.ControllerFeatureProvider

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Controllers.ControllerFeatureProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Controllers.ControllerFeatureProvider.IsController(System.Reflection.TypeInfo)
    
        
    
        
        Determines if a given <em>typeInfo</em> is a controller.
    
        
    
        
        :param typeInfo: The :any:`System.Reflection.TypeInfo` candidate.
        
        :type typeInfo: System.Reflection.TypeInfo
        :rtype: System.Boolean
        :return: <pre>
            <code>true</code>
            </pre> if the type is a controller; otherwise <pre><code>false</code></pre>.
    
        
        .. code-block:: csharp
    
            protected virtual bool IsController(TypeInfo typeInfo)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Controllers.ControllerFeatureProvider.PopulateFeature(System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPart>, Microsoft.AspNetCore.Mvc.Controllers.ControllerFeature)
    
        
    
        
        :type parts: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPart<Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPart>}
    
        
        :type feature: Microsoft.AspNetCore.Mvc.Controllers.ControllerFeature
    
        
        .. code-block:: csharp
    
            public void PopulateFeature(IEnumerable<ApplicationPart> parts, ControllerFeature feature)
    

