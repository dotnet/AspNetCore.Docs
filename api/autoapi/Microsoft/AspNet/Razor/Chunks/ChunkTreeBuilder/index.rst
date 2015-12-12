

ChunkTreeBuilder Class
======================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Chunks.ChunkTreeBuilder`








Syntax
------

.. code-block:: csharp

   public class ChunkTreeBuilder





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/razor/src/Microsoft.AspNet.Razor/Chunks/ChunkTreeBuilder.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Chunks.ChunkTreeBuilder

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.Chunks.ChunkTreeBuilder
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.Chunks.ChunkTreeBuilder.ChunkTreeBuilder()
    
        
    
        
        .. code-block:: csharp
    
           public ChunkTreeBuilder()
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.Chunks.ChunkTreeBuilder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.Chunks.ChunkTreeBuilder.AddAddTagHelperChunk(System.String, Microsoft.AspNet.Razor.Parser.SyntaxTree.SyntaxTreeNode)
    
        
        
        
        :type lookupText: System.String
        
        
        :type association: Microsoft.AspNet.Razor.Parser.SyntaxTree.SyntaxTreeNode
    
        
        .. code-block:: csharp
    
           public void AddAddTagHelperChunk(string lookupText, SyntaxTreeNode association)
    
    .. dn:method:: Microsoft.AspNet.Razor.Chunks.ChunkTreeBuilder.AddChunk(Microsoft.AspNet.Razor.Chunks.Chunk, Microsoft.AspNet.Razor.Parser.SyntaxTree.SyntaxTreeNode, System.Boolean)
    
        
        
        
        :type chunk: Microsoft.AspNet.Razor.Chunks.Chunk
        
        
        :type association: Microsoft.AspNet.Razor.Parser.SyntaxTree.SyntaxTreeNode
        
        
        :type topLevel: System.Boolean
    
        
        .. code-block:: csharp
    
           public void AddChunk(Chunk chunk, SyntaxTreeNode association, bool topLevel = false)
    
    .. dn:method:: Microsoft.AspNet.Razor.Chunks.ChunkTreeBuilder.AddExpressionChunk(System.String, Microsoft.AspNet.Razor.Parser.SyntaxTree.SyntaxTreeNode)
    
        
        
        
        :type expression: System.String
        
        
        :type association: Microsoft.AspNet.Razor.Parser.SyntaxTree.SyntaxTreeNode
    
        
        .. code-block:: csharp
    
           public void AddExpressionChunk(string expression, SyntaxTreeNode association)
    
    .. dn:method:: Microsoft.AspNet.Razor.Chunks.ChunkTreeBuilder.AddLiteralChunk(System.String, Microsoft.AspNet.Razor.Parser.SyntaxTree.SyntaxTreeNode)
    
        
        
        
        :type literal: System.String
        
        
        :type association: Microsoft.AspNet.Razor.Parser.SyntaxTree.SyntaxTreeNode
    
        
        .. code-block:: csharp
    
           public void AddLiteralChunk(string literal, SyntaxTreeNode association)
    
    .. dn:method:: Microsoft.AspNet.Razor.Chunks.ChunkTreeBuilder.AddLiteralCodeAttributeChunk(System.String, Microsoft.AspNet.Razor.Parser.SyntaxTree.SyntaxTreeNode)
    
        
        
        
        :type code: System.String
        
        
        :type association: Microsoft.AspNet.Razor.Parser.SyntaxTree.SyntaxTreeNode
    
        
        .. code-block:: csharp
    
           public void AddLiteralCodeAttributeChunk(string code, SyntaxTreeNode association)
    
    .. dn:method:: Microsoft.AspNet.Razor.Chunks.ChunkTreeBuilder.AddRemoveTagHelperChunk(System.String, Microsoft.AspNet.Razor.Parser.SyntaxTree.SyntaxTreeNode)
    
        
        
        
        :type lookupText: System.String
        
        
        :type association: Microsoft.AspNet.Razor.Parser.SyntaxTree.SyntaxTreeNode
    
        
        .. code-block:: csharp
    
           public void AddRemoveTagHelperChunk(string lookupText, SyntaxTreeNode association)
    
    .. dn:method:: Microsoft.AspNet.Razor.Chunks.ChunkTreeBuilder.AddSetBaseTypeChunk(System.String, Microsoft.AspNet.Razor.Parser.SyntaxTree.SyntaxTreeNode)
    
        
        
        
        :type typeName: System.String
        
        
        :type association: Microsoft.AspNet.Razor.Parser.SyntaxTree.SyntaxTreeNode
    
        
        .. code-block:: csharp
    
           public void AddSetBaseTypeChunk(string typeName, SyntaxTreeNode association)
    
    .. dn:method:: Microsoft.AspNet.Razor.Chunks.ChunkTreeBuilder.AddStatementChunk(System.String, Microsoft.AspNet.Razor.Parser.SyntaxTree.SyntaxTreeNode)
    
        
        
        
        :type code: System.String
        
        
        :type association: Microsoft.AspNet.Razor.Parser.SyntaxTree.SyntaxTreeNode
    
        
        .. code-block:: csharp
    
           public void AddStatementChunk(string code, SyntaxTreeNode association)
    
    .. dn:method:: Microsoft.AspNet.Razor.Chunks.ChunkTreeBuilder.AddTagHelperPrefixDirectiveChunk(System.String, Microsoft.AspNet.Razor.Parser.SyntaxTree.SyntaxTreeNode)
    
        
        
        
        :type prefix: System.String
        
        
        :type association: Microsoft.AspNet.Razor.Parser.SyntaxTree.SyntaxTreeNode
    
        
        .. code-block:: csharp
    
           public void AddTagHelperPrefixDirectiveChunk(string prefix, SyntaxTreeNode association)
    
    .. dn:method:: Microsoft.AspNet.Razor.Chunks.ChunkTreeBuilder.AddTypeMemberChunk(System.String, Microsoft.AspNet.Razor.Parser.SyntaxTree.SyntaxTreeNode)
    
        
        
        
        :type code: System.String
        
        
        :type association: Microsoft.AspNet.Razor.Parser.SyntaxTree.SyntaxTreeNode
    
        
        .. code-block:: csharp
    
           public void AddTypeMemberChunk(string code, SyntaxTreeNode association)
    
    .. dn:method:: Microsoft.AspNet.Razor.Chunks.ChunkTreeBuilder.AddUsingChunk(System.String, Microsoft.AspNet.Razor.Parser.SyntaxTree.SyntaxTreeNode)
    
        
        
        
        :type usingNamespace: System.String
        
        
        :type association: Microsoft.AspNet.Razor.Parser.SyntaxTree.SyntaxTreeNode
    
        
        .. code-block:: csharp
    
           public void AddUsingChunk(string usingNamespace, SyntaxTreeNode association)
    
    .. dn:method:: Microsoft.AspNet.Razor.Chunks.ChunkTreeBuilder.EndParentChunk()
    
        
    
        
        .. code-block:: csharp
    
           public void EndParentChunk()
    
    .. dn:method:: Microsoft.AspNet.Razor.Chunks.ChunkTreeBuilder.StartParentChunk<T>(Microsoft.AspNet.Razor.Parser.SyntaxTree.SyntaxTreeNode)
    
        
        
        
        :type association: Microsoft.AspNet.Razor.Parser.SyntaxTree.SyntaxTreeNode
        :rtype: {T}
    
        
        .. code-block:: csharp
    
           public T StartParentChunk<T>(SyntaxTreeNode association)where T : ParentChunk, new ()
    
    .. dn:method:: Microsoft.AspNet.Razor.Chunks.ChunkTreeBuilder.StartParentChunk<T>(Microsoft.AspNet.Razor.Parser.SyntaxTree.SyntaxTreeNode, System.Boolean)
    
        
        
        
        :type association: Microsoft.AspNet.Razor.Parser.SyntaxTree.SyntaxTreeNode
        
        
        :type topLevel: System.Boolean
        :rtype: {T}
    
        
        .. code-block:: csharp
    
           public T StartParentChunk<T>(SyntaxTreeNode association, bool topLevel)where T : ParentChunk, new ()
    
    .. dn:method:: Microsoft.AspNet.Razor.Chunks.ChunkTreeBuilder.StartParentChunk<T>(T, Microsoft.AspNet.Razor.Parser.SyntaxTree.SyntaxTreeNode, System.Boolean)
    
        
        
        
        :type parentChunk: {T}
        
        
        :type association: Microsoft.AspNet.Razor.Parser.SyntaxTree.SyntaxTreeNode
        
        
        :type topLevel: System.Boolean
        :rtype: {T}
    
        
        .. code-block:: csharp
    
           public T StartParentChunk<T>(T parentChunk, SyntaxTreeNode association, bool topLevel)where T : ParentChunk
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.Chunks.ChunkTreeBuilder
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.Chunks.ChunkTreeBuilder.ChunkTree
    
        
        :rtype: Microsoft.AspNet.Razor.Chunks.ChunkTree
    
        
        .. code-block:: csharp
    
           public ChunkTree ChunkTree { get; }
    

