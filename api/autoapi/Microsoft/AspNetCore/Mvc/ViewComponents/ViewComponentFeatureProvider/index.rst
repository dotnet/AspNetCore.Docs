

ViewComponentFeatureProvider Class
==================================






Discovers view components from a list of :any:`Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPart` instances.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentFeatureProvider`








Syntax
------

.. code-block:: csharp

    public class ViewComponentFeatureProvider : IApplicationFeatureProvider<ViewComponentFeature>, IApplicationFeatureProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentFeatureProvider
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentFeatureProvider

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentFeatureProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentFeatureProvider.PopulateFeature(System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPart>, Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentFeature)
    
        
    
        
        :type parts: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPart<Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPart>}
    
        
        :type feature: Microsoft.AspNetCore.Mvc.ViewComponents.ViewComponentFeature
    
        
        .. code-block:: csharp
    
            public void PopulateFeature(IEnumerable<ApplicationPart> parts, ViewComponentFeature feature)
    

