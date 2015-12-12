

CodeGenerator Class
===================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.CodeGenerators.CodeGenerator`








Syntax
------

.. code-block:: csharp

   public abstract class CodeGenerator





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/razor/src/Microsoft.AspNet.Razor/CodeGenerators/CodeGenerator.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.CodeGenerator

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.CodeGenerator
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.CodeGenerators.CodeGenerator.CodeGenerator(Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorContext)
    
        
        
        
        :type context: Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorContext
    
        
        .. code-block:: csharp
    
           public CodeGenerator(CodeGeneratorContext context)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.CodeGenerator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.CodeGenerator.Generate()
    
        
        :rtype: Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorResult
    
        
        .. code-block:: csharp
    
           public abstract CodeGeneratorResult Generate()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.CodeGenerator
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.CodeGenerators.CodeGenerator.Context
    
        
        :rtype: Microsoft.AspNet.Razor.CodeGenerators.CodeGeneratorContext
    
        
        .. code-block:: csharp
    
           protected CodeGeneratorContext Context { get; }
    

