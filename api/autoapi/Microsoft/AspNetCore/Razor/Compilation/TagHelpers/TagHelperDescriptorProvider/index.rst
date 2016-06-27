

TagHelperDescriptorProvider Class
=================================






Enables retrieval of :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor`\'s.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers`
Assemblies
    * Microsoft.AspNetCore.Razor

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptorProvider`








Syntax
------

.. code-block:: csharp

    public class TagHelperDescriptorProvider








.. dn:class:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptorProvider
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptorProvider

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptorProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptorProvider.TagHelperDescriptorProvider(System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor>)
    
        
    
        
        Instantiates a new instance of the :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptorProvider`\.
    
        
    
        
        :param descriptors: The descriptors that the :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptorProvider` will pull from.
        
        :type descriptors: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor<Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor>}
    
        
        .. code-block:: csharp
    
            public TagHelperDescriptorProvider(IEnumerable<TagHelperDescriptor> descriptors)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptorProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptorProvider.GetDescriptors(System.String, System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<System.String, System.String>>, System.String)
    
        
    
        
        Gets all tag helpers that match the given <em>tagName</em>.
    
        
    
        
        :param tagName: The name of the HTML tag to match. Providing a '*' tag name
            retrieves catch-all :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor`\s (descriptors that target every tag).
        
        :type tagName: System.String
    
        
        :param attributes: Attributes the HTML element must contain to match.
        
        :type attributes: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair`2>{System.String<System.String>, System.String<System.String>}}
    
        
        :param parentTagName: The parent tag name of the given <em>tagName</em> tag.
        
        :type parentTagName: System.String
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor<Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor>}
        :return: :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor`\s that apply to the given <em>tagName</em>.
                Will return an empty :any:`System.Linq.Enumerable` if no :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor`\s are
                found.
    
        
        .. code-block:: csharp
    
            public IEnumerable<TagHelperDescriptor> GetDescriptors(string tagName, IEnumerable<KeyValuePair<string, string>> attributes, string parentTagName)
    

Fields
------

.. dn:class:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptorProvider
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptorProvider.ElementCatchAllTarget
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public const string ElementCatchAllTarget = "*"
    

