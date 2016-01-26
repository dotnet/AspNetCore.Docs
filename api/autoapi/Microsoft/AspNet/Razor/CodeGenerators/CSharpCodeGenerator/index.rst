

CSharpCodeGenerator Class
=========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.CodeGenerators.CodeGenerator`
* :dn:cls:`Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeGenerator`








Syntax
------

.. code-block:: csharp

   public class CSharpCodeGenerator : CodeGenerator





GitHub
------

`View on GitHub <https://github.com/aspnet/razor/blob/master/src/Microsoft.AspNet.Razor/CodeGenerators/CSharpCodeGenerator.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeGenerator

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeGenerator
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeGenerator.CSharpCodeGenerator(Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorContext)
    
        
        
        
        :type context: Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorContext
    
        
        .. code-block:: csharp
    
           public CSharpCodeGenerator(CodeGeneratorContext context)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeGenerator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeGenerator.BuildClassDeclaration(Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter)
    
        
        
        
        :type writer: Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter
        :rtype: Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWritingScope
    
        
        .. code-block:: csharp
    
           protected virtual CSharpCodeWritingScope BuildClassDeclaration(CSharpCodeWriter writer)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeGenerator.BuildConstructor(Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter)
    
        
        
        
        :type writer: Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter
    
        
        .. code-block:: csharp
    
           protected virtual void BuildConstructor(CSharpCodeWriter writer)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeGenerator.CreateCSharpCodeVisitor(Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter, Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorContext)
    
        
        
        
        :type writer: Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter
        
        
        :type context: Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorContext
        :rtype: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpCodeVisitor
    
        
        .. code-block:: csharp
    
           protected virtual CSharpCodeVisitor CreateCSharpCodeVisitor(CSharpCodeWriter writer, CodeGeneratorContext context)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeGenerator.CreateCSharpDesignTimeCodeVisitor(Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpCodeVisitor, Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter, Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorContext)
    
        
        
        
        :type csharpCodeVisitor: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpCodeVisitor
        
        
        :type writer: Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter
        
        
        :type context: Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorContext
        :rtype: Microsoft.AspNet.Razor.CodeGenerators.Visitors.CSharpDesignTimeCodeVisitor
    
        
        .. code-block:: csharp
    
           protected virtual CSharpDesignTimeCodeVisitor CreateCSharpDesignTimeCodeVisitor(CSharpCodeVisitor csharpCodeVisitor, CSharpCodeWriter writer, CodeGeneratorContext context)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeGenerator.CreateCodeWriter()
    
        
    
        Protected for testing.
    
        
        :rtype: Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter
        :return: A new instance of <see cref="T:Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter" />.
    
        
        .. code-block:: csharp
    
           protected virtual CSharpCodeWriter CreateCodeWriter()
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeGenerator.Generate()
    
        
        :rtype: Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorResult
    
        
        .. code-block:: csharp
    
           public override CodeGeneratorResult Generate()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeGenerator
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeGenerator.Host
    
        
        :rtype: Microsoft.AspNet.Razor.RazorEngineHost
    
        
        .. code-block:: csharp
    
           public RazorEngineHost Host { get; }
    

