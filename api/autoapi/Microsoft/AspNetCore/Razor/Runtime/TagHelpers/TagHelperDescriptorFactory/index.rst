

TagHelperDescriptorFactory Class
================================






Factory for :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor`\s from :any:`System.Type`\s.


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
* :dn:cls:`Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperDescriptorFactory`








Syntax
------

.. code-block:: csharp

    public class TagHelperDescriptorFactory : ITagHelperDescriptorFactory








.. dn:class:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperDescriptorFactory
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperDescriptorFactory

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperDescriptorFactory
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperDescriptorFactory.InvalidNonWhitespaceNameCharacters
    
        
        :rtype: System.Collections.Generic.ICollection<System.Collections.Generic.ICollection`1>{System.Char<System.Char>}
    
        
        .. code-block:: csharp
    
            public static ICollection<char> InvalidNonWhitespaceNameCharacters
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperDescriptorFactory
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperDescriptorFactory.TagHelperDescriptorFactory(System.Boolean)
    
        
    
        
        Instantiates a new :any:`Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperDescriptorFactory`\.
    
        
    
        
        :param designTime: 
            Indicates if :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor`\s should be created for design time.
        
        :type designTime: System.Boolean
    
        
        .. code-block:: csharp
    
            public TagHelperDescriptorFactory(bool designTime)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperDescriptorFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperDescriptorFactory.CreateDescriptors(System.String, System.Type, Microsoft.AspNetCore.Razor.ErrorSink)
    
        
    
        
        :type assemblyName: System.String
    
        
        :type type: System.Type
    
        
        :type errorSink: Microsoft.AspNetCore.Razor.ErrorSink
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor<Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor>}
    
        
        .. code-block:: csharp
    
            public virtual IEnumerable<TagHelperDescriptor> CreateDescriptors(string assemblyName, Type type, ErrorSink errorSink)
    

