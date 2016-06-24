

ViewComponentFeature Class
==========================






The list of view component types in an MVC application.The :any:`Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentFeature` can be populated
using the :any:`Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPartManager` that is available during startup at :dn:prop:`Microsoft.Extensions.DependencyInjection.IMvcBuilder.PartManager`
and :dn:prop:`Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder.PartManager` or at a later stage by requiring the :any:`Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPartManager`
as a dependency in a component.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ViewComponents`
Assemblies
    * Microsoft.AspNetCore.Mvc.ViewFeatures

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentFeature`








Syntax
------

.. code-block:: csharp

    public class ViewComponentFeature








.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentFeature
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentFeature

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentFeature
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentFeature.ViewComponents
    
        
    
        
        Gets the list of view component types in an MVC application.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.Reflection.TypeInfo<System.Reflection.TypeInfo>}
    
        
        .. code-block:: csharp
    
            public IList<TypeInfo> ViewComponents { get; }
    

