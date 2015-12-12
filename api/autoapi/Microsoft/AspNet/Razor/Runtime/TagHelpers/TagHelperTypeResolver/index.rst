

TagHelperTypeResolver Class
===========================



.. contents:: 
   :local:



Summary
-------

Class that locates valid :any:`Microsoft.AspNet.Razor.TagHelpers.ITagHelper`\s within an assembly.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperTypeResolver`








Syntax
------

.. code-block:: csharp

   public class TagHelperTypeResolver





GitHub
------

`View on GitHub <https://github.com/aspnet/razor/blob/master/src/Microsoft.AspNet.Razor.Runtime/Runtime/TagHelpers/TagHelperTypeResolver.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperTypeResolver

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperTypeResolver
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperTypeResolver.GetExportedTypes(System.Reflection.AssemblyName)
    
        
    
        Returns all exported types from the given ``assemblyName``
    
        
        
        
        :param assemblyName: The  to get s from.
        
        :type assemblyName: System.Reflection.AssemblyName
        :rtype: System.Collections.Generic.IEnumerable{System.Reflection.TypeInfo}
        :return: An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of types exported from the given <paramref name="assemblyName" />.
    
        
        .. code-block:: csharp
    
           protected virtual IEnumerable<TypeInfo> GetExportedTypes(AssemblyName assemblyName)
    
    .. dn:method:: Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperTypeResolver.GetTopLevelExportedTypes(System.Reflection.AssemblyName)
    
        
    
        Returns all non-nested exported types from the given ``assemblyName``
    
        
        
        
        :param assemblyName: The  to get s from.
        
        :type assemblyName: System.Reflection.AssemblyName
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Razor.Runtime.TagHelpers.ITypeInfo}
        :return: An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of types exported from the given <paramref name="assemblyName" />.
    
        
        .. code-block:: csharp
    
           protected virtual IEnumerable<ITypeInfo> GetTopLevelExportedTypes(AssemblyName assemblyName)
    
    .. dn:method:: Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperTypeResolver.Resolve(System.String, Microsoft.AspNet.Razor.SourceLocation, Microsoft.AspNet.Razor.ErrorSink)
    
        
    
        Locates valid :any:`Microsoft.AspNet.Razor.TagHelpers.ITagHelper` types from the :any:`System.Reflection.Assembly` named ``name``.
    
        
        
        
        :param name: The name of an  to search.
        
        :type name: System.String
        
        
        :param documentLocation: The  of the associated
            responsible for the current  call.
        
        :type documentLocation: Microsoft.AspNet.Razor.SourceLocation
        
        
        :param errorSink: The  used to record errors found when resolving
            types.
        
        :type errorSink: Microsoft.AspNet.Razor.ErrorSink
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Razor.Runtime.TagHelpers.ITypeInfo}
        :return: An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of valid <see cref="T:Microsoft.AspNet.Razor.TagHelpers.ITagHelper" /> types.
    
        
        .. code-block:: csharp
    
           public IEnumerable<ITypeInfo> Resolve(string name, SourceLocation documentLocation, ErrorSink errorSink)
    

