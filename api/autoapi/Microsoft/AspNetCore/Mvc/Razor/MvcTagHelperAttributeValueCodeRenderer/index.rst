

MvcTagHelperAttributeValueCodeRenderer Class
============================================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Razor`
Assemblies
    * Microsoft.AspNetCore.Mvc.Razor.Host

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Razor.CodeGenerators.TagHelperAttributeValueCodeRenderer`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Razor.MvcTagHelperAttributeValueCodeRenderer`








Syntax
------

.. code-block:: csharp

    public class MvcTagHelperAttributeValueCodeRenderer : TagHelperAttributeValueCodeRenderer








.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.MvcTagHelperAttributeValueCodeRenderer
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.MvcTagHelperAttributeValueCodeRenderer

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.MvcTagHelperAttributeValueCodeRenderer
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Razor.MvcTagHelperAttributeValueCodeRenderer.MvcTagHelperAttributeValueCodeRenderer(Microsoft.AspNetCore.Mvc.Razor.GeneratedTagHelperAttributeContext)
    
        
    
        
        Instantiates a new instance of :any:`Microsoft.AspNetCore.Mvc.Razor.MvcTagHelperAttributeValueCodeRenderer`\.
    
        
    
        
        :param context: Contains code generation information for rendering attribute values.
        
        :type context: Microsoft.AspNetCore.Mvc.Razor.GeneratedTagHelperAttributeContext
    
        
        .. code-block:: csharp
    
            public MvcTagHelperAttributeValueCodeRenderer(GeneratedTagHelperAttributeContext context)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.MvcTagHelperAttributeValueCodeRenderer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.MvcTagHelperAttributeValueCodeRenderer.RenderAttributeValue(Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperAttributeDescriptor, Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter, Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorContext, System.Action<Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter>, System.Boolean)
    
        
    
        
        :type attributeDescriptor: Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperAttributeDescriptor
    
        
        :type writer: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter
    
        
        :type codeGeneratorContext: Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorContext
    
        
        :type renderAttributeValue: System.Action<System.Action`1>{Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter<Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter>}
    
        
        :type complexValue: System.Boolean
    
        
        .. code-block:: csharp
    
            public override void RenderAttributeValue(TagHelperAttributeDescriptor attributeDescriptor, CSharpCodeWriter writer, CodeGeneratorContext codeGeneratorContext, Action<CSharpCodeWriter> renderAttributeValue, bool complexValue)
    

