

TagHelperFeature Class
======================






The list of tag helper types in an MVC application. The :any:`Microsoft.AspNetCore.Mvc.Razor.TagHelpers.TagHelperFeature` can be populated
using the :any:`Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPartManager` that is available during startup at :dn:prop:`Microsoft.Extensions.DependencyInjection.IMvcBuilder.PartManager`
and :dn:prop:`Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder.PartManager` or at a later stage by requiring the :any:`Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPartManager`
as a dependency in a component.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Razor.TagHelpers`
Assemblies
    * Microsoft.AspNetCore.Mvc.Razor

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Razor.TagHelpers.TagHelperFeature`








Syntax
------

.. code-block:: csharp

    public class TagHelperFeature








.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.TagHelpers.TagHelperFeature
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.TagHelpers.TagHelperFeature

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.TagHelpers.TagHelperFeature
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.TagHelpers.TagHelperFeature.TagHelpers
    
        
    
        
        Gets the list of tag helper types in an MVC application.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.Reflection.TypeInfo<System.Reflection.TypeInfo>}
    
        
        .. code-block:: csharp
    
            public IList<TypeInfo> TagHelpers
            {
                get;
            }
    

