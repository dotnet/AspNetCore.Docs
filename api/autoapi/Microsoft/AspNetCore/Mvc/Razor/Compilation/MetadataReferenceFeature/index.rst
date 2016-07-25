

MetadataReferenceFeature Class
==============================






Specifies the list of :any:`Microsoft.CodeAnalysis.MetadataReference` used in Razor compilation.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Razor.Compilation.MetadataReferenceFeature`








Syntax
------

.. code-block:: csharp

    public class MetadataReferenceFeature








.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Compilation.MetadataReferenceFeature
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Compilation.MetadataReferenceFeature

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Compilation.MetadataReferenceFeature
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.Compilation.MetadataReferenceFeature.MetadataReferences
    
        
    
        
        Gets the :any:`Microsoft.CodeAnalysis.MetadataReference` instances.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.CodeAnalysis.MetadataReference<Microsoft.CodeAnalysis.MetadataReference>}
    
        
        .. code-block:: csharp
    
            public IList<MetadataReference> MetadataReferences { get; }
    

