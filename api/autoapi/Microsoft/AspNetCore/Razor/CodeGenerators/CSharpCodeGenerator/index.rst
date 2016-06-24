

CSharpCodeGenerator Class
=========================





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
* :dn:cls:`Microsoft.AspNetCore.Razor.CodeGenerators.CodeGenerator`
* :dn:cls:`Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeGenerator`








Syntax
------

.. code-block:: csharp

    public class CSharpCodeGenerator : CodeGenerator








.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeGenerator
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeGenerator

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeGenerator
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeGenerator.CSharpCodeGenerator(Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorContext
    
        
        .. code-block:: csharp
    
            public CSharpCodeGenerator(CodeGeneratorContext context)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeGenerator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeGenerator.BuildClassDeclaration(Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter)
    
        
    
        
        :type writer: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWritingScope
    
        
        .. code-block:: csharp
    
            protected virtual CSharpCodeWritingScope BuildClassDeclaration(CSharpCodeWriter writer)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeGenerator.BuildConstructor(Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter)
    
        
    
        
        :type writer: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter
    
        
        .. code-block:: csharp
    
            protected virtual void BuildConstructor(CSharpCodeWriter writer)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeGenerator.CreateCSharpCodeVisitor(Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter, Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorContext)
    
        
    
        
        :type writer: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter
    
        
        :type context: Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorContext
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpCodeVisitor
    
        
        .. code-block:: csharp
    
            protected virtual CSharpCodeVisitor CreateCSharpCodeVisitor(CSharpCodeWriter writer, CodeGeneratorContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeGenerator.CreateCSharpDesignTimeCodeVisitor(Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpCodeVisitor, Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter, Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorContext)
    
        
    
        
        :type csharpCodeVisitor: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpCodeVisitor
    
        
        :type writer: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter
    
        
        :type context: Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorContext
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.Visitors.CSharpDesignTimeCodeVisitor
    
        
        .. code-block:: csharp
    
            protected virtual CSharpDesignTimeCodeVisitor CreateCSharpDesignTimeCodeVisitor(CSharpCodeVisitor csharpCodeVisitor, CSharpCodeWriter writer, CodeGeneratorContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeGenerator.CreateCodeWriter()
    
        
    
        
        Protected for testing.
    
        
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter
        :return: A new instance of :any:`Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter`\.
    
        
        .. code-block:: csharp
    
            protected virtual CSharpCodeWriter CreateCodeWriter()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeGenerator.Generate()
    
        
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorResult
    
        
        .. code-block:: csharp
    
            public override CodeGeneratorResult Generate()
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeGenerator
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeGenerator.Host
    
        
        :rtype: Microsoft.AspNetCore.Razor.RazorEngineHost
    
        
        .. code-block:: csharp
    
            public RazorEngineHost Host { get; }
    

