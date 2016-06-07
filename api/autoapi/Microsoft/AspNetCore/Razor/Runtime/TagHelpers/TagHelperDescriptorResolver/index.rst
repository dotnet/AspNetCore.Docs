

TagHelperDescriptorResolver Class
=================================






Used to resolve :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor`\s.


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
* :dn:cls:`Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperDescriptorResolver`








Syntax
------

.. code-block:: csharp

    public class TagHelperDescriptorResolver : ITagHelperDescriptorResolver








.. dn:class:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperDescriptorResolver
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperDescriptorResolver

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperDescriptorResolver
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperDescriptorResolver.TagHelperDescriptorResolver(Microsoft.AspNetCore.Razor.Runtime.TagHelpers.ITagHelperTypeResolver, Microsoft.AspNetCore.Razor.Runtime.TagHelpers.ITagHelperDescriptorFactory)
    
        
    
        
        Instantiates a new instance of :any:`Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperDescriptorResolver` class with the
        specified <em>typeResolver</em>.
    
        
    
        
        :param typeResolver: The :any:`Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperTypeResolver`\.
        
        :type typeResolver: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.ITagHelperTypeResolver
    
        
        :param descriptorFactory: The :any:`Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperDescriptorFactory`\.
        
        :type descriptorFactory: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.ITagHelperDescriptorFactory
    
        
        .. code-block:: csharp
    
            public TagHelperDescriptorResolver(ITagHelperTypeResolver typeResolver, ITagHelperDescriptorFactory descriptorFactory)
    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperDescriptorResolver.TagHelperDescriptorResolver(System.Boolean)
    
        
    
        
        Instantiates a new instance of the :any:`Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperDescriptorResolver` class.
    
        
    
        
        :param designTime: Indicates whether resolved :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor`\s should include
            design time specific information.
        
        :type designTime: System.Boolean
    
        
        .. code-block:: csharp
    
            public TagHelperDescriptorResolver(bool designTime)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperDescriptorResolver
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperDescriptorResolver.Resolve(Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptorResolutionContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptorResolutionContext
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor<Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor>}
    
        
        .. code-block:: csharp
    
            public IEnumerable<TagHelperDescriptor> Resolve(TagHelperDescriptorResolutionContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperDescriptorResolver.ResolveDescriptorsInAssembly(System.String, Microsoft.AspNetCore.Razor.SourceLocation, Microsoft.AspNetCore.Razor.ErrorSink)
    
        
    
        
        Resolves all :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor`\s for :any:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper`\s from the
        given <em>assemblyName</em>.
    
        
    
        
        :param assemblyName: 
            The name of the assembly to resolve :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor`\s from.
        
        :type assemblyName: System.String
    
        
        :param documentLocation: The :any:`Microsoft.AspNetCore.Razor.SourceLocation` of the directive.
        
        :type documentLocation: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        :param errorSink: Used to record errors found when resolving :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor`\s
            within the given <em>assemblyName</em>.
        
        :type errorSink: Microsoft.AspNetCore.Razor.ErrorSink
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor<Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor>}
        :return: :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor`\s for :any:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper`\s from the given
            <em>assemblyName</em>.
    
        
        .. code-block:: csharp
    
            protected virtual IEnumerable<TagHelperDescriptor> ResolveDescriptorsInAssembly(string assemblyName, SourceLocation documentLocation, ErrorSink errorSink)
    

