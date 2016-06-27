

TagHelperAttributeNode Class
============================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Razor.Parser.TagHelpers`
Assemblies
    * Microsoft.AspNetCore.Razor

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperAttributeNode`








Syntax
------

.. code-block:: csharp

    public class TagHelperAttributeNode








.. dn:class:: Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperAttributeNode
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperAttributeNode

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperAttributeNode
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperAttributeNode.TagHelperAttributeNode(System.String, Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SyntaxTreeNode, Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle)
    
        
    
        
        :type name: System.String
    
        
        :type value: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SyntaxTreeNode
    
        
        :type valueStyle: Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle
    
        
        .. code-block:: csharp
    
            public TagHelperAttributeNode(string name, SyntaxTreeNode value, HtmlAttributeValueStyle valueStyle)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperAttributeNode
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperAttributeNode.Name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Name { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperAttributeNode.Value
    
        
        :rtype: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SyntaxTreeNode
    
        
        .. code-block:: csharp
    
            public SyntaxTreeNode Value { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Parser.TagHelpers.TagHelperAttributeNode.ValueStyle
    
        
        :rtype: Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle
    
        
        .. code-block:: csharp
    
            public HtmlAttributeValueStyle ValueStyle { get; }
    

