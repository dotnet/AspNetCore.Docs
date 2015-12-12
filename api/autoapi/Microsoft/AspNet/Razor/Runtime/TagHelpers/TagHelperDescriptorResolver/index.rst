

TagHelperDescriptorResolver Class
=================================



.. contents:: 
   :local:



Summary
-------

Used to resolve :any:`Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor`\s.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperDescriptorResolver`








Syntax
------

.. code-block:: csharp

   public class TagHelperDescriptorResolver : ITagHelperDescriptorResolver





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/razor/src/Microsoft.AspNet.Razor.Runtime/Runtime/TagHelpers/TagHelperDescriptorResolver.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperDescriptorResolver

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperDescriptorResolver
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperDescriptorResolver.TagHelperDescriptorResolver(Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperTypeResolver, System.Boolean)
    
        
    
        Instantiates a new instance of :any:`Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperDescriptorResolver` class with the
        specified ``typeResolver``.
    
        
        
        
        :param typeResolver: The .
        
        :type typeResolver: Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperTypeResolver
        
        
        :param designTime: Indicates whether resolved s should include
            design time specific information.
        
        :type designTime: System.Boolean
    
        
        .. code-block:: csharp
    
           public TagHelperDescriptorResolver(TagHelperTypeResolver typeResolver, bool designTime)
    
    .. dn:constructor:: Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperDescriptorResolver.TagHelperDescriptorResolver(System.Boolean)
    
        
    
        Instantiates a new instance of the :any:`Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperDescriptorResolver` class.
    
        
        
        
        :param designTime: Indicates whether resolved s should include
            design time specific information.
        
        :type designTime: System.Boolean
    
        
        .. code-block:: csharp
    
           public TagHelperDescriptorResolver(bool designTime)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperDescriptorResolver
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperDescriptorResolver.Resolve(Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptorResolutionContext)
    
        
        
        
        :type context: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptorResolutionContext
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor}
    
        
        .. code-block:: csharp
    
           public IEnumerable<TagHelperDescriptor> Resolve(TagHelperDescriptorResolutionContext context)
    
    .. dn:method:: Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperDescriptorResolver.ResolveDescriptorsInAssembly(System.String, Microsoft.AspNet.Razor.SourceLocation, Microsoft.AspNet.Razor.ErrorSink)
    
        
    
        Resolves all :any:`Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor`\s for :any:`Microsoft.AspNet.Razor.TagHelpers.ITagHelper`\s from the
        given ``assemblyName``.
    
        
        
        
        :param assemblyName: The name of the assembly to resolve s from.
        
        :type assemblyName: System.String
        
        
        :param documentLocation: The  of the directive.
        
        :type documentLocation: Microsoft.AspNet.Razor.SourceLocation
        
        
        :param errorSink: Used to record errors found when resolving s
            within the given .
        
        :type errorSink: Microsoft.AspNet.Razor.ErrorSink
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor}
        :return: <see cref="T:Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor" />s for <see cref="T:Microsoft.AspNet.Razor.TagHelpers.ITagHelper" />s from the given
            <paramref name="assemblyName" />.
    
        
        .. code-block:: csharp
    
           protected virtual IEnumerable<TagHelperDescriptor> ResolveDescriptorsInAssembly(string assemblyName, SourceLocation documentLocation, ErrorSink errorSink)
    

