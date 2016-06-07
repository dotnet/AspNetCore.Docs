

TagHelperAttributeValueCodeRenderer Class
=========================================






Renders code for tag helper property initialization.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Razor.CodeGenerators`
Assemblies
    * Microsoft.AspNetCore.Razor

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Razor.CodeGenerators.TagHelperAttributeValueCodeRenderer`








Syntax
------

.. code-block:: csharp

    public class TagHelperAttributeValueCodeRenderer








.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.TagHelperAttributeValueCodeRenderer
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.TagHelperAttributeValueCodeRenderer

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.TagHelperAttributeValueCodeRenderer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.TagHelperAttributeValueCodeRenderer.RenderAttributeValue(Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperAttributeDescriptor, Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter, Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorContext, System.Action<Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter>, System.Boolean)
    
        
    
        
        Called during Razor's code generation process to generate code that instantiates the value of the tag
        helper's property. Last value written should not be or end with a semicolon.
    
        
    
        
        :param attributeDescriptor: 
            The :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperAttributeDescriptor` to generate code for.
        
        :type attributeDescriptor: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperAttributeDescriptor
    
        
        :param writer: The :any:`Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter` that's used to write code.
        
        :type writer: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter
    
        
        :param context: A :any:`Microsoft.AspNetCore.Razor.Chunks.Generators.ChunkGeneratorContext` instance that contains
            information about the current code generation process.
        
        :type context: Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorContext
    
        
        :param renderAttributeValue: 
            :any:`System.Action` that renders the raw value of the HTML attribute.
        
        :type renderAttributeValue: System.Action<System.Action`1>{Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter<Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter>}
    
        
        :param complexValue: 
            Indicates whether or not the source attribute value contains more than simple text. <code>false</code> for plain
            C# expressions e.g. <code>"PropertyName"</code>. <code>true</code> if the attribute value contain at least one in-line
            Razor construct e.g. <code>"@(@readonly)"</code>.
        
        :type complexValue: System.Boolean
    
        
        .. code-block:: csharp
    
            public virtual void RenderAttributeValue(TagHelperAttributeDescriptor attributeDescriptor, CSharpCodeWriter writer, CodeGeneratorContext context, Action<CSharpCodeWriter> renderAttributeValue, bool complexValue)
    

