

TagHelperRequiredAttributeDescriptor Class
==========================================






A metadata class describing a required tag helper attribute.


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
* :dn:cls:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperRequiredAttributeDescriptor`








Syntax
------

.. code-block:: csharp

    public class TagHelperRequiredAttributeDescriptor








.. dn:class:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperRequiredAttributeDescriptor
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperRequiredAttributeDescriptor

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperRequiredAttributeDescriptor
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperRequiredAttributeDescriptor.Name
    
        
    
        
        The HTML attribute name.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Name
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperRequiredAttributeDescriptor.NameComparison
    
        
    
        
        The comparison method to use for :dn:prop:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperRequiredAttributeDescriptor.Name` when determining if an HTML attribute name matches.
    
        
        :rtype: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperRequiredAttributeNameComparison
    
        
        .. code-block:: csharp
    
            public TagHelperRequiredAttributeNameComparison NameComparison
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperRequiredAttributeDescriptor.Value
    
        
    
        
        The HTML attribute value.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Value
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperRequiredAttributeDescriptor.ValueComparison
    
        
    
        
        The comparison method to use for :dn:prop:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperRequiredAttributeDescriptor.Value` when determining if an HTML attribute value matches.
    
        
        :rtype: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperRequiredAttributeValueComparison
    
        
        .. code-block:: csharp
    
            public TagHelperRequiredAttributeValueComparison ValueComparison
            {
                get;
                set;
            }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperRequiredAttributeDescriptor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperRequiredAttributeDescriptor.IsMatch(System.String, System.String)
    
        
    
        
        Determines if the current :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperRequiredAttributeDescriptor` matches the given
        <em>attributeName</em> and <em>attributeValue</em>.
    
        
    
        
        :param attributeName: An HTML attribute name.
        
        :type attributeName: System.String
    
        
        :param attributeValue: An HTML attribute value.
        
        :type attributeValue: System.String
        :rtype: System.Boolean
        :return: <code>true</code> if the current :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperRequiredAttributeDescriptor` matches
            <em>attributeName</em> and <em>attributeValue</em>; <code>false</code> otherwise.
    
        
        .. code-block:: csharp
    
            public bool IsMatch(string attributeName, string attributeValue)
    

