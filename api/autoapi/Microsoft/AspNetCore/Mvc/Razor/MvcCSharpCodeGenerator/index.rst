

MvcCSharpCodeGenerator Class
============================





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
* :dn:cls:`Microsoft.AspNetCore.Razor.CodeGenerators.CodeGenerator`
* :dn:cls:`Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeGenerator`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Razor.MvcCSharpCodeGenerator`








Syntax
------

.. code-block:: csharp

    public class MvcCSharpCodeGenerator : CSharpCodeGenerator








.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.MvcCSharpCodeGenerator
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.MvcCSharpCodeGenerator

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.MvcCSharpCodeGenerator
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Razor.MvcCSharpCodeGenerator.MvcCSharpCodeGenerator(Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorContext, System.String, System.String, Microsoft.AspNetCore.Mvc.Razor.GeneratedTagHelperAttributeContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorContext
    
        
        :type defaultModel: System.String
    
        
        :type injectAttribute: System.String
    
        
        :type tagHelperAttributeContext: Microsoft.AspNetCore.Mvc.Razor.GeneratedTagHelperAttributeContext
    
        
        .. code-block:: csharp
    
            public MvcCSharpCodeGenerator(CodeGeneratorContext context, string defaultModel, string injectAttribute, GeneratedTagHelperAttributeContext tagHelperAttributeContext)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.MvcCSharpCodeGenerator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.MvcCSharpCodeGenerator.BuildClassDeclaration(Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter)
    
        
    
        
        :type writer: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWritingScope
    
        
        .. code-block:: csharp
    
            protected override CSharpCodeWritingScope BuildClassDeclaration(CSharpCodeWriter writer)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.MvcCSharpCodeGenerator.BuildConstructor(Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter)
    
        
    
        
        :type writer: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter
    
        
        .. code-block:: csharp
    
            protected override void BuildConstructor(CSharpCodeWriter writer)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.MvcCSharpCodeGenerator.CreateCSharpCodeVisitor(Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter, Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorContext)
    
        
    
        
        :type writer: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter
    
        
        :type context: Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorContext
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpCodeVisitor
    
        
        .. code-block:: csharp
    
            protected override CSharpCodeVisitor CreateCSharpCodeVisitor(CSharpCodeWriter writer, CodeGeneratorContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.MvcCSharpCodeGenerator.CreateCSharpDesignTimeCodeVisitor(Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpCodeVisitor, Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter, Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorContext)
    
        
    
        
        :type csharpCodeVisitor: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpCodeVisitor
    
        
        :type writer: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter
    
        
        :type context: Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorContext
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpDesignTimeCodeVisitor
    
        
        .. code-block:: csharp
    
            protected override CSharpDesignTimeCodeVisitor CreateCSharpDesignTimeCodeVisitor(CSharpCodeVisitor csharpCodeVisitor, CSharpCodeWriter writer, CodeGeneratorContext context)
    

