

ControllerFeature Class
=======================






The list of controllers types in an MVC application. The :any:`Microsoft.AspNetCore.Mvc.Controllers.ControllerFeature` can be populated
using the :any:`Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPartManager` that is available during startup at :dn:prop:`Microsoft.Extensions.DependencyInjection.IMvcBuilder.PartManager`
and :dn:prop:`Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder.PartManager` or at a later stage by requiring the :any:`Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPartManager`
as a dependency in a component.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Controllers.ControllerFeature`








Syntax
------

.. code-block:: csharp

    public class ControllerFeature








.. dn:class:: Microsoft.AspNetCore.Mvc.Controllers.ControllerFeature
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Controllers.ControllerFeature

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Controllers.ControllerFeature
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Controllers.ControllerFeature.Controllers
    
        
    
        
        Gets the list of controller types in an MVC application.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.Reflection.TypeInfo<System.Reflection.TypeInfo>}
    
        
        .. code-block:: csharp
    
            public IList<TypeInfo> Controllers { get; }
    

