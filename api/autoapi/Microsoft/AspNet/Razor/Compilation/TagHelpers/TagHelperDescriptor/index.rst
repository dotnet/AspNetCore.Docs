

TagHelperDescriptor Class
=========================



.. contents:: 
   :local:



Summary
-------

A metadata class describing a tag helper.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor`








Syntax
------

.. code-block:: csharp

   public class TagHelperDescriptor





GitHub
------

`View on GitHub <https://github.com/aspnet/razor/blob/master/src/Microsoft.AspNet.Razor/Compilation/TagHelpers/TagHelperDescriptor.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor.AllowedChildren
    
        
    
        Get the names of elements allowed as children.
    
        
        :rtype: System.Collections.Generic.IEnumerable{System.String}
    
        
        .. code-block:: csharp
    
           public IEnumerable<string> AllowedChildren { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor.AssemblyName
    
        
    
        The name of the assembly containing the tag helper class.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string AssemblyName { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor.Attributes
    
        
    
        The list of attributes the tag helper expects.
    
        
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperAttributeDescriptor}
    
        
        .. code-block:: csharp
    
           public IEnumerable<TagHelperAttributeDescriptor> Attributes { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor.DesignTimeDescriptor
    
        
    
        The :any:`Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDesignTimeDescriptor` that contains design time information about this
        tag helper.
    
        
        :rtype: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDesignTimeDescriptor
    
        
        .. code-block:: csharp
    
           public TagHelperDesignTimeDescriptor DesignTimeDescriptor { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor.FullTagName
    
        
    
        The full tag name that is required for the tag helper to target an HTML element.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string FullTagName { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor.Prefix
    
        
    
        Text used as a required prefix when matching HTML start and end tags in the Razor source to available
        tag helpers.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Prefix { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor.RequiredAttributes
    
        
    
        The list of required attribute names the tag helper expects to target an element.
    
        
        :rtype: System.Collections.Generic.IEnumerable{System.String}
    
        
        .. code-block:: csharp
    
           public IEnumerable<string> RequiredAttributes { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor.RequiredParent
    
        
    
        Get the name of the HTML element required as the immediate parent.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string RequiredParent { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor.TagName
    
        
    
        The tag name that the tag helper should target.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string TagName { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor.TagStructure
    
        
    
        The expected tag structure.
    
        
        :rtype: Microsoft.AspNet.Razor.TagHelpers.TagStructure
    
        
        .. code-block:: csharp
    
           public TagStructure TagStructure { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor.TypeName
    
        
    
        The full name of the tag helper class.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string TypeName { get; set; }
    

