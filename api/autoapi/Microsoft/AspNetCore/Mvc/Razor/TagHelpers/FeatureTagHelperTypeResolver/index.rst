

FeatureTagHelperTypeResolver Class
==================================






Resolves tag helper types from the :dn:prop:`Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPartManager.ApplicationParts`
of the application.


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
* :dn:cls:`Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperTypeResolver`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Razor.TagHelpers.FeatureTagHelperTypeResolver`








Syntax
------

.. code-block:: csharp

    public class FeatureTagHelperTypeResolver : TagHelperTypeResolver, ITagHelperTypeResolver








.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.TagHelpers.FeatureTagHelperTypeResolver
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.TagHelpers.FeatureTagHelperTypeResolver

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.TagHelpers.FeatureTagHelperTypeResolver
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Razor.TagHelpers.FeatureTagHelperTypeResolver.FeatureTagHelperTypeResolver(Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPartManager)
    
        
    
        
        Initializes a new :any:`Microsoft.AspNetCore.Mvc.Razor.TagHelpers.FeatureTagHelperTypeResolver` instance.
    
        
    
        
        :param manager: The :any:`Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPartManager` of the application.
        
        :type manager: Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPartManager
    
        
        .. code-block:: csharp
    
            public FeatureTagHelperTypeResolver(ApplicationPartManager manager)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.TagHelpers.FeatureTagHelperTypeResolver
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.TagHelpers.FeatureTagHelperTypeResolver.GetExportedTypes(System.Reflection.AssemblyName)
    
        
    
        
        :type assemblyName: System.Reflection.AssemblyName
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.Reflection.TypeInfo<System.Reflection.TypeInfo>}
    
        
        .. code-block:: csharp
    
            protected override IEnumerable<TypeInfo> GetExportedTypes(AssemblyName assemblyName)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.TagHelpers.FeatureTagHelperTypeResolver.IsTagHelper(System.Reflection.TypeInfo)
    
        
    
        
        :type typeInfo: System.Reflection.TypeInfo
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            protected override sealed bool IsTagHelper(TypeInfo typeInfo)
    

