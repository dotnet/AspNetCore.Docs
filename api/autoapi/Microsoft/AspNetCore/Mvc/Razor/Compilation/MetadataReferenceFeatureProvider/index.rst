

MetadataReferenceFeatureProvider Class
======================================






An :any:`Microsoft.AspNetCore.Mvc.ApplicationParts.IApplicationFeatureProvider\`1` for :any:`Microsoft.AspNetCore.Mvc.Razor.Compilation.MetadataReferenceFeature` that 
uses :any:`Microsoft.Extensions.DependencyModel.DependencyContext` for registered :any:`Microsoft.AspNetCore.Mvc.ApplicationParts.AssemblyPart` instances to create 
:any:`Microsoft.CodeAnalysis.MetadataReference`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Razor.Compilation`
Assemblies
    * Microsoft.AspNetCore.Mvc.Razor

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Razor.Compilation.MetadataReferenceFeatureProvider`








Syntax
------

.. code-block:: csharp

    public class MetadataReferenceFeatureProvider : IApplicationFeatureProvider<MetadataReferenceFeature>, IApplicationFeatureProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Compilation.MetadataReferenceFeatureProvider
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Compilation.MetadataReferenceFeatureProvider

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Compilation.MetadataReferenceFeatureProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.Compilation.MetadataReferenceFeatureProvider.PopulateFeature(System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPart>, Microsoft.AspNetCore.Mvc.Razor.Compilation.MetadataReferenceFeature)
    
        
    
        
        :type parts: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPart<Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPart>}
    
        
        :type feature: Microsoft.AspNetCore.Mvc.Razor.Compilation.MetadataReferenceFeature
    
        
        .. code-block:: csharp
    
            public void PopulateFeature(IEnumerable<ApplicationPart> parts, MetadataReferenceFeature feature)
    

