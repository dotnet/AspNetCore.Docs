

InjectParameterGenerator Class
==============================





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
* :dn:cls:`Microsoft.AspNetCore.Razor.Chunks.Generators.SpanChunkGenerator`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Razor.InjectParameterGenerator`








Syntax
------

.. code-block:: csharp

    public class InjectParameterGenerator : SpanChunkGenerator, ISpanChunkGenerator








.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.InjectParameterGenerator
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.InjectParameterGenerator

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.InjectParameterGenerator
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.InjectParameterGenerator.PropertyName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string PropertyName
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.InjectParameterGenerator.TypeName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string TypeName
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.InjectParameterGenerator
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Razor.InjectParameterGenerator.InjectParameterGenerator(System.String, System.String)
    
        
    
        
        :type typeName: System.String
    
        
        :type propertyName: System.String
    
        
        .. code-block:: csharp
    
            public InjectParameterGenerator(string typeName, string propertyName)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.InjectParameterGenerator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.InjectParameterGenerator.Equals(System.Object)
    
        
    
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.InjectParameterGenerator.GenerateChunk(Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span, Microsoft.AspNetCore.Razor.Chunks.Generators.ChunkGeneratorContext)
    
        
    
        
        :type target: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.Span
    
        
        :type context: Microsoft.AspNetCore.Razor.Chunks.Generators.ChunkGeneratorContext
    
        
        .. code-block:: csharp
    
            public override void GenerateChunk(Span target, ChunkGeneratorContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.InjectParameterGenerator.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int GetHashCode()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Razor.InjectParameterGenerator.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string ToString()
    

