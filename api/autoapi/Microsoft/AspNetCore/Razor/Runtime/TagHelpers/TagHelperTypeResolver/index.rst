

TagHelperTypeResolver Class
===========================






Class that locates valid :any:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper`\s within an assembly.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Razor.Runtime.TagHelpers`
Assemblies
    * Microsoft.AspNetCore.Razor.Runtime

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperTypeResolver`








Syntax
------

.. code-block:: csharp

    public class TagHelperTypeResolver : ITagHelperTypeResolver








.. dn:class:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperTypeResolver
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperTypeResolver

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperTypeResolver
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperTypeResolver.GetExportedTypes(System.Reflection.AssemblyName)
    
        
    
        
        Returns all exported types from the given <em>assemblyName</em>
    
        
    
        
        :param assemblyName: The :any:`System.Reflection.AssemblyName` to get :any:`System.Reflection.TypeInfo`\s from.
        
        :type assemblyName: System.Reflection.AssemblyName
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.Reflection.TypeInfo<System.Reflection.TypeInfo>}
        :return: 
            An :any:`System.Collections.Generic.IEnumerable\`1` of types exported from the given <em>assemblyName</em>.
    
        
        .. code-block:: csharp
    
            protected virtual IEnumerable<TypeInfo> GetExportedTypes(AssemblyName assemblyName)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperTypeResolver.IsTagHelper(System.Reflection.TypeInfo)
    
        
    
        
        Indicates if a :any:`System.Reflection.TypeInfo` should be treated as a tag helper.
    
        
    
        
        :param typeInfo: The :any:`System.Reflection.TypeInfo` to inspect.
        
        :type typeInfo: System.Reflection.TypeInfo
        :rtype: System.Boolean
        :return: <code>true</code> if <em>typeInfo</em> should be treated as a tag helper; 
            <code>false</code> otherwise
    
        
        .. code-block:: csharp
    
            protected virtual bool IsTagHelper(TypeInfo typeInfo)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperTypeResolver.Resolve(System.String, Microsoft.AspNetCore.Razor.SourceLocation, Microsoft.AspNetCore.Razor.ErrorSink)
    
        
    
        
        :type name: System.String
    
        
        :type documentLocation: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        :type errorSink: Microsoft.AspNetCore.Razor.ErrorSink
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.Type<System.Type>}
    
        
        .. code-block:: csharp
    
            public IEnumerable<Type> Resolve(string name, SourceLocation documentLocation, ErrorSink errorSink)
    

