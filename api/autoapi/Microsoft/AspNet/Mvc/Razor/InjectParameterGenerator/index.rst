

InjectParameterGenerator Class
==============================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Chunks.Generators.SpanChunkGenerator`
* :dn:cls:`Microsoft.AspNet.Mvc.Razor.InjectParameterGenerator`








Syntax
------

.. code-block:: csharp

   public class InjectParameterGenerator : SpanChunkGenerator, ISpanChunkGenerator





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Razor.Host/InjectParameterGenerator.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Razor.InjectParameterGenerator

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.InjectParameterGenerator
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Razor.InjectParameterGenerator.InjectParameterGenerator(System.String, System.String)
    
        
        
        
        :type typeName: System.String
        
        
        :type propertyName: System.String
    
        
        .. code-block:: csharp
    
           public InjectParameterGenerator(string typeName, string propertyName)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.InjectParameterGenerator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.InjectParameterGenerator.Equals(System.Object)
    
        
        
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.InjectParameterGenerator.GenerateChunk(Microsoft.AspNet.Razor.Parser.SyntaxTree.Span, Microsoft.AspNet.Razor.Chunks.Generators.ChunkGeneratorContext)
    
        
        
        
        :type target: Microsoft.AspNet.Razor.Parser.SyntaxTree.Span
        
        
        :type context: Microsoft.AspNet.Razor.Chunks.Generators.ChunkGeneratorContext
    
        
        .. code-block:: csharp
    
           public override void GenerateChunk(Span target, ChunkGeneratorContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.InjectParameterGenerator.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public override int GetHashCode()
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.InjectParameterGenerator.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public override string ToString()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.InjectParameterGenerator
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.InjectParameterGenerator.PropertyName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string PropertyName { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.InjectParameterGenerator.TypeName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string TypeName { get; }
    

