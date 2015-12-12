

TagHelperDescriptorProvider Class
=================================



.. contents:: 
   :local:



Summary
-------

Enables retrieval of :any:`Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor`\'s.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptorProvider`








Syntax
------

.. code-block:: csharp

   public class TagHelperDescriptorProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/razor/src/Microsoft.AspNet.Razor/Compilation/TagHelpers/TagHelperDescriptorProvider.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptorProvider

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptorProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptorProvider.TagHelperDescriptorProvider(System.Collections.Generic.IEnumerable<Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor>)
    
        
    
        Instantiates a new instance of the :any:`Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptorProvider`\.
    
        
        
        
        :param descriptors: The descriptors that the  will pull from.
        
        :type descriptors: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor}
    
        
        .. code-block:: csharp
    
           public TagHelperDescriptorProvider(IEnumerable<TagHelperDescriptor> descriptors)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptorProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptorProvider.GetDescriptors(System.String, System.Collections.Generic.IEnumerable<System.String>, System.String)
    
        
    
        Gets all tag helpers that match the given ``tagName``.
    
        
        
        
        :param tagName: The name of the HTML tag to match. Providing a '*' tag name
            retrieves catch-all s (descriptors that target every tag).
        
        :type tagName: System.String
        
        
        :param attributeNames: Attributes the HTML element must contain to match.
        
        :type attributeNames: System.Collections.Generic.IEnumerable{System.String}
        
        
        :param parentTagName: The parent tag name of the given  tag.
        
        :type parentTagName: System.String
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor}
        :return: <see cref="T:Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor" />s that apply to the given <paramref name="tagName" />.
            Will return an empty <see cref="T:System.Linq.Enumerable" /> if no <see cref="T:Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor" />s are
            found.
    
        
        .. code-block:: csharp
    
           public IEnumerable<TagHelperDescriptor> GetDescriptors(string tagName, IEnumerable<string> attributeNames, string parentTagName)
    

Fields
------

.. dn:class:: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptorProvider
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptorProvider.ElementCatchAllTarget
    
        
    
        
        .. code-block:: csharp
    
           public const string ElementCatchAllTarget
    
    .. dn:field:: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptorProvider.RequiredAttributeWildcardSuffix
    
        
    
        
        .. code-block:: csharp
    
           public static readonly string RequiredAttributeWildcardSuffix
    

