

TagHelperDescriptor Class
=========================






A metadata class describing a tag helper.


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
* :dn:cls:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor`








Syntax
------

.. code-block:: csharp

    public class TagHelperDescriptor








.. dn:class:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor.AllowedChildren
    
        
    
        
        Get the names of elements allowed as children.
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public IEnumerable<string> AllowedChildren { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor.AssemblyName
    
        
    
        
        The name of the assembly containing the tag helper class.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string AssemblyName { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor.Attributes
    
        
    
        
        The list of attributes the tag helper expects.
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperAttributeDescriptor<Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperAttributeDescriptor>}
    
        
        .. code-block:: csharp
    
            public IEnumerable<TagHelperAttributeDescriptor> Attributes { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor.DesignTimeDescriptor
    
        
    
        
        The :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDesignTimeDescriptor` that contains design time information about this
        tag helper.
    
        
        :rtype: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDesignTimeDescriptor
    
        
        .. code-block:: csharp
    
            public TagHelperDesignTimeDescriptor DesignTimeDescriptor { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor.FullTagName
    
        
    
        
        The full tag name that is required for the tag helper to target an HTML element.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string FullTagName { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor.Prefix
    
        
    
        
        Text used as a required prefix when matching HTML start and end tags in the Razor source to available
        tag helpers.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Prefix { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor.RequiredAttributes
    
        
    
        
        The list of required attribute names the tag helper expects to target an element.
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperRequiredAttributeDescriptor<Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperRequiredAttributeDescriptor>}
    
        
        .. code-block:: csharp
    
            public IEnumerable<TagHelperRequiredAttributeDescriptor> RequiredAttributes { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor.RequiredParent
    
        
    
        
        Get the name of the HTML element required as the immediate parent.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string RequiredParent { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor.TagName
    
        
    
        
        The tag name that the tag helper should target.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string TagName { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor.TagStructure
    
        
    
        
        The expected tag structure.
    
        
        :rtype: Microsoft.AspNetCore.Razor.TagHelpers.TagStructure
    
        
        .. code-block:: csharp
    
            public TagStructure TagStructure { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor.TypeName
    
        
    
        
        The full name of the tag helper class.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string TypeName { get; set; }
    

