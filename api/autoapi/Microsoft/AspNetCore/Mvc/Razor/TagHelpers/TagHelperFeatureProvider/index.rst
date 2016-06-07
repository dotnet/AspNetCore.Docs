

TagHelperFeatureProvider Class
==============================






Discovers tag helpers from a list of :any:`Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPart` instances.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Razor.TagHelpers.TagHelperFeatureProvider`








Syntax
------

.. code-block:: csharp

    public class TagHelperFeatureProvider : IApplicationFeatureProvider<TagHelperFeature>, IApplicationFeatureProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.TagHelpers.TagHelperFeatureProvider
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.TagHelpers.TagHelperFeatureProvider

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.TagHelpers.TagHelperFeatureProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.TagHelpers.TagHelperFeatureProvider.PopulateFeature(System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPart>, Microsoft.AspNetCore.Mvc.Razor.TagHelpers.TagHelperFeature)
    
        
    
        
        :type parts: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPart<Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPart>}
    
        
        :type feature: Microsoft.AspNetCore.Mvc.Razor.TagHelpers.TagHelperFeature
    
        
        .. code-block:: csharp
    
            public void PopulateFeature(IEnumerable<ApplicationPart> parts, TagHelperFeature feature)
    

