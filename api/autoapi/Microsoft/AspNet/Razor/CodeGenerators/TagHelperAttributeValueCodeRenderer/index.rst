

TagHelperAttributeValueCodeRenderer Class
=========================================



.. contents:: 
   :local:



Summary
-------

Renders code for tag helper property initialization.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.CodeGenerators.TagHelperAttributeValueCodeRenderer`








Syntax
------

.. code-block:: csharp

   public class TagHelperAttributeValueCodeRenderer





GitHub
------

`View on GitHub <https://github.com/aspnet/razor/blob/master/src/Microsoft.AspNet.Razor/CodeGenerators/TagHelperAttributeValueCodeRenderer.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.TagHelperAttributeValueCodeRenderer

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.TagHelperAttributeValueCodeRenderer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.TagHelperAttributeValueCodeRenderer.RenderAttributeValue(Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperAttributeDescriptor, Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter, Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorContext, System.Action<Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter>, System.Boolean)
    
        
    
        Called during Razor's code generation process to generate code that instantiates the value of the tag
        helper's property. Last value written should not be or end with a semicolon.
    
        
        
        
        :param attributeDescriptor: The  to generate code for.
        
        :type attributeDescriptor: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperAttributeDescriptor
        
        
        :param writer: The  that's used to write code.
        
        :type writer: Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter
        
        
        :param context: A  instance that contains
            information about the current code generation process.
        
        :type context: Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorContext
        
        
        :param renderAttributeValue: that renders the raw value of the HTML attribute.
        
        :type renderAttributeValue: System.Action{Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter}
        
        
        :param complexValue: Indicates whether or not the source attribute value contains more than simple text. false for plain
            C# expressions e.g. "PropertyName". true if the attribute value contain at least one in-line
            Razor construct e.g. "@(@readonly)".
        
        :type complexValue: System.Boolean
    
        
        .. code-block:: csharp
    
           public virtual void RenderAttributeValue(TagHelperAttributeDescriptor attributeDescriptor, CSharpCodeWriter writer, CodeGeneratorContext context, Action<CSharpCodeWriter> renderAttributeValue, bool complexValue)
    

