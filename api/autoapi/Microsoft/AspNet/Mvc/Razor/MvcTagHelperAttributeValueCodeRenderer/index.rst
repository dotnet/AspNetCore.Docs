

MvcTagHelperAttributeValueCodeRenderer Class
============================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.CodeGenerators.TagHelperAttributeValueCodeRenderer`
* :dn:cls:`Microsoft.AspNet.Mvc.Razor.MvcTagHelperAttributeValueCodeRenderer`








Syntax
------

.. code-block:: csharp

   public class MvcTagHelperAttributeValueCodeRenderer : TagHelperAttributeValueCodeRenderer





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Razor.Host/MvcTagHelperAttributeValueCodeRenderer.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Razor.MvcTagHelperAttributeValueCodeRenderer

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.MvcTagHelperAttributeValueCodeRenderer
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Razor.MvcTagHelperAttributeValueCodeRenderer.MvcTagHelperAttributeValueCodeRenderer(Microsoft.AspNet.Mvc.Razor.GeneratedTagHelperAttributeContext)
    
        
    
        Instantiates a new instance of :any:`Microsoft.AspNet.Mvc.Razor.MvcTagHelperAttributeValueCodeRenderer`\.
    
        
        
        
        :param context: Contains code generation information for rendering attribute values.
        
        :type context: Microsoft.AspNet.Mvc.Razor.GeneratedTagHelperAttributeContext
    
        
        .. code-block:: csharp
    
           public MvcTagHelperAttributeValueCodeRenderer(GeneratedTagHelperAttributeContext context)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.MvcTagHelperAttributeValueCodeRenderer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.MvcTagHelperAttributeValueCodeRenderer.RenderAttributeValue(Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperAttributeDescriptor, Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter, Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorContext, System.Action<Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter>, System.Boolean)
    
        
        
        
        :type attributeDescriptor: Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperAttributeDescriptor
        
        
        :type writer: Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter
        
        
        :type codeGeneratorContext: Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorContext
        
        
        :type renderAttributeValue: System.Action{Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter}
        
        
        :type complexValue: System.Boolean
    
        
        .. code-block:: csharp
    
           public override void RenderAttributeValue(TagHelperAttributeDescriptor attributeDescriptor, CSharpCodeWriter writer, CodeGeneratorContext codeGeneratorContext, Action<CSharpCodeWriter> renderAttributeValue, bool complexValue)
    

