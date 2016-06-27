

CodeGenerator Class
===================





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








Syntax
------

.. code-block:: csharp

    public abstract class CodeGenerator








.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.CodeGenerator
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.CodeGenerator

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.CodeGenerator
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.CodeGenerators.CodeGenerator.CodeGenerator(Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorContext
    
        
        .. code-block:: csharp
    
            public CodeGenerator(CodeGeneratorContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.CodeGenerator
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.CodeGenerator.Context
    
        
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorContext
    
        
        .. code-block:: csharp
    
            protected CodeGeneratorContext Context { get; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.CodeGenerator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CodeGenerator.Generate()
    
        
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.CodeGeneratorResult
    
        
        .. code-block:: csharp
    
            public abstract CodeGeneratorResult Generate()
    

