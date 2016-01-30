

CSharpTagHelperCodeRenderer Class
=================================



.. contents:: 
   :local:



Summary
-------

Renders tag helper rendering code.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.CodeGenerators.CSharpTagHelperCodeRenderer`








Syntax
------

.. code-block:: csharp

   public class CSharpTagHelperCodeRenderer





GitHub
------

`View on GitHub <https://github.com/aspnet/razor/blob/master/src/Microsoft.AspNet.Razor/CodeGenerators/CSharpTagHelperCodeRenderer.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.CSharpTagHelperCodeRenderer

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.CSharpTagHelperCodeRenderer
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.CodeGenerators.CSharpTagHelperCodeRenderer.CSharpTagHelperCodeRenderer(Microsoft.AspNet.Razor.CodeGenerators.Visitors.IChunkVisitor, Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter, Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorContext)
    
        
    
        Instantiates a new :any:`Microsoft.AspNet.Razor.CodeGenerators.CSharpTagHelperCodeRenderer`\.
    
        
        
        
        :param bodyVisitor: The  used to render chunks found in the body.
        
        :type bodyVisitor: Microsoft.AspNet.Razor.CodeGenerators.Visitors.IChunkVisitor
        
        
        :param writer: The  used to write code.
        
        :type writer: Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter
        
        
        :param context: A  instance that contains information about
            the current code generation process.
        
        :type context: Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorContext
    
        
        .. code-block:: csharp
    
           public CSharpTagHelperCodeRenderer(IChunkVisitor bodyVisitor, CSharpCodeWriter writer, CodeGeneratorContext context)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.CSharpTagHelperCodeRenderer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.CSharpTagHelperCodeRenderer.GenerateUniqueId()
    
        
    
        Generates a unique ID for an HTML element.
    
        
        :rtype: System.String
        :return: A globally unique ID.
    
        
        .. code-block:: csharp
    
           protected virtual string GenerateUniqueId()
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.CSharpTagHelperCodeRenderer.RenderTagHelper(Microsoft.AspNet.Razor.Chunks.TagHelperChunk)
    
        
    
        Renders the code for the given ``chunk``.
    
        
        
        
        :param chunk: A  to render.
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.TagHelperChunk
    
        
        .. code-block:: csharp
    
           public void RenderTagHelper(TagHelperChunk chunk)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.CSharpTagHelperCodeRenderer
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.CodeGenerators.CSharpTagHelperCodeRenderer.AttributeValueCodeRenderer
    
        
        :rtype: Microsoft.AspNet.Razor.CodeGenerators.TagHelperAttributeValueCodeRenderer
    
        
        .. code-block:: csharp
    
           public TagHelperAttributeValueCodeRenderer AttributeValueCodeRenderer { get; set; }
    

