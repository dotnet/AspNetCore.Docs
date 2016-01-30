

MvcCSharpCodeGenerator Class
============================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.CodeGenerators.CodeGenerator`
* :dn:cls:`Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeGenerator`
* :dn:cls:`Microsoft.AspNet.Mvc.Razor.MvcCSharpCodeGenerator`








Syntax
------

.. code-block:: csharp

   public class MvcCSharpCodeGenerator : CSharpCodeGenerator





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Razor.Host/MvcCSharpCodeGenerator.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Razor.MvcCSharpCodeGenerator

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.MvcCSharpCodeGenerator
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Razor.MvcCSharpCodeGenerator.MvcCSharpCodeGenerator(Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorContext, System.String, System.String, Microsoft.AspNet.Mvc.Razor.GeneratedTagHelperAttributeContext)
    
        
        
        
        :type context: Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorContext
        
        
        :type defaultModel: System.String
        
        
        :type injectAttribute: System.String
        
        
        :type tagHelperAttributeContext: Microsoft.AspNet.Mvc.Razor.GeneratedTagHelperAttributeContext
    
        
        .. code-block:: csharp
    
           public MvcCSharpCodeGenerator(CodeGeneratorContext context, string defaultModel, string injectAttribute, GeneratedTagHelperAttributeContext tagHelperAttributeContext)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.MvcCSharpCodeGenerator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.MvcCSharpCodeGenerator.BuildClassDeclaration(Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter)
    
        
        
        
        :type writer: Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter
        :rtype: Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWritingScope
    
        
        .. code-block:: csharp
    
           protected override CSharpCodeWritingScope BuildClassDeclaration(CSharpCodeWriter writer)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.MvcCSharpCodeGenerator.BuildConstructor(Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter)
    
        
        
        
        :type writer: Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter
    
        
        .. code-block:: csharp
    
           protected override void BuildConstructor(CSharpCodeWriter writer)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.MvcCSharpCodeGenerator.CreateCSharpCodeVisitor(Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter, Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorContext)
    
        
        
        
        :type writer: Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter
        
        
        :type context: Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorContext
        :rtype: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpCodeVisitor
    
        
        .. code-block:: csharp
    
           protected override CSharpCodeVisitor CreateCSharpCodeVisitor(CSharpCodeWriter writer, CodeGeneratorContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.MvcCSharpCodeGenerator.CreateCSharpDesignTimeCodeVisitor(Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpCodeVisitor, Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter, Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorContext)
    
        
        
        
        :type csharpCodeVisitor: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpCodeVisitor
        
        
        :type writer: Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter
        
        
        :type context: Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorContext
        :rtype: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpDesignTimeCodeVisitor
    
        
        .. code-block:: csharp
    
           protected override CSharpDesignTimeCodeVisitor CreateCSharpDesignTimeCodeVisitor(CSharpCodeVisitor csharpCodeVisitor, CSharpCodeWriter writer, CodeGeneratorContext context)
    

