

ChunkTreeBuilder Class
======================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Razor.Chunks`
Assemblies
    * Microsoft.AspNetCore.Razor

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Razor.Chunks.ChunkTreeBuilder`








Syntax
------

.. code-block:: csharp

    public class ChunkTreeBuilder








.. dn:class:: Microsoft.AspNetCore.Razor.Chunks.ChunkTreeBuilder
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.Chunks.ChunkTreeBuilder

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.Chunks.ChunkTreeBuilder
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.Chunks.ChunkTreeBuilder.Current
    
        
        :rtype: Microsoft.AspNetCore.Razor.Chunks.ParentChunk
    
        
        .. code-block:: csharp
    
            public ParentChunk Current
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.Chunks.ChunkTreeBuilder.Root
    
        
        :rtype: Microsoft.AspNetCore.Razor.Chunks.ChunkTree
    
        
        .. code-block:: csharp
    
            public ChunkTree Root
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.Chunks.ChunkTreeBuilder
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.Chunks.ChunkTreeBuilder.ChunkTreeBuilder()
    
        
    
        
        .. code-block:: csharp
    
            public ChunkTreeBuilder()
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.Chunks.ChunkTreeBuilder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.Chunks.ChunkTreeBuilder.AddAddTagHelperChunk(System.String, Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SyntaxTreeNode)
    
        
    
        
        :type lookupText: System.String
    
        
        :type association: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SyntaxTreeNode
    
        
        .. code-block:: csharp
    
            public void AddAddTagHelperChunk(string lookupText, SyntaxTreeNode association)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Chunks.ChunkTreeBuilder.AddChunk(Microsoft.AspNetCore.Razor.Chunks.Chunk, Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SyntaxTreeNode, System.Boolean)
    
        
    
        
        :type chunk: Microsoft.AspNetCore.Razor.Chunks.Chunk
    
        
        :type association: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SyntaxTreeNode
    
        
        :type topLevel: System.Boolean
    
        
        .. code-block:: csharp
    
            public void AddChunk(Chunk chunk, SyntaxTreeNode association, bool topLevel = false)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Chunks.ChunkTreeBuilder.AddExpressionChunk(System.String, Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SyntaxTreeNode)
    
        
    
        
        :type expression: System.String
    
        
        :type association: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SyntaxTreeNode
    
        
        .. code-block:: csharp
    
            public void AddExpressionChunk(string expression, SyntaxTreeNode association)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Chunks.ChunkTreeBuilder.AddLiteralChunk(System.String, Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SyntaxTreeNode)
    
        
    
        
        :type literal: System.String
    
        
        :type association: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SyntaxTreeNode
    
        
        .. code-block:: csharp
    
            public void AddLiteralChunk(string literal, SyntaxTreeNode association)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Chunks.ChunkTreeBuilder.AddLiteralCodeAttributeChunk(System.String, Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SyntaxTreeNode)
    
        
    
        
        :type code: System.String
    
        
        :type association: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SyntaxTreeNode
    
        
        .. code-block:: csharp
    
            public void AddLiteralCodeAttributeChunk(string code, SyntaxTreeNode association)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Chunks.ChunkTreeBuilder.AddRemoveTagHelperChunk(System.String, Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SyntaxTreeNode)
    
        
    
        
        :type lookupText: System.String
    
        
        :type association: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SyntaxTreeNode
    
        
        .. code-block:: csharp
    
            public void AddRemoveTagHelperChunk(string lookupText, SyntaxTreeNode association)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Chunks.ChunkTreeBuilder.AddSetBaseTypeChunk(System.String, Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SyntaxTreeNode)
    
        
    
        
        :type typeName: System.String
    
        
        :type association: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SyntaxTreeNode
    
        
        .. code-block:: csharp
    
            public void AddSetBaseTypeChunk(string typeName, SyntaxTreeNode association)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Chunks.ChunkTreeBuilder.AddStatementChunk(System.String, Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SyntaxTreeNode)
    
        
    
        
        :type code: System.String
    
        
        :type association: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SyntaxTreeNode
    
        
        .. code-block:: csharp
    
            public void AddStatementChunk(string code, SyntaxTreeNode association)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Chunks.ChunkTreeBuilder.AddTagHelperPrefixDirectiveChunk(System.String, Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SyntaxTreeNode)
    
        
    
        
        :type prefix: System.String
    
        
        :type association: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SyntaxTreeNode
    
        
        .. code-block:: csharp
    
            public void AddTagHelperPrefixDirectiveChunk(string prefix, SyntaxTreeNode association)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Chunks.ChunkTreeBuilder.AddTypeMemberChunk(System.String, Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SyntaxTreeNode)
    
        
    
        
        :type code: System.String
    
        
        :type association: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SyntaxTreeNode
    
        
        .. code-block:: csharp
    
            public void AddTypeMemberChunk(string code, SyntaxTreeNode association)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Chunks.ChunkTreeBuilder.AddUsingChunk(System.String, Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SyntaxTreeNode)
    
        
    
        
        :type usingNamespace: System.String
    
        
        :type association: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SyntaxTreeNode
    
        
        .. code-block:: csharp
    
            public void AddUsingChunk(string usingNamespace, SyntaxTreeNode association)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Chunks.ChunkTreeBuilder.EndParentChunk()
    
        
    
        
        .. code-block:: csharp
    
            public void EndParentChunk()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Chunks.ChunkTreeBuilder.StartParentChunk<T>(Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SyntaxTreeNode)
    
        
    
        
        :type association: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SyntaxTreeNode
        :rtype: T
    
        
        .. code-block:: csharp
    
            public T StartParentChunk<T>(SyntaxTreeNode association)where T : ParentChunk, new ()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Chunks.ChunkTreeBuilder.StartParentChunk<T>(Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SyntaxTreeNode, System.Boolean)
    
        
    
        
        :type association: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SyntaxTreeNode
    
        
        :type topLevel: System.Boolean
        :rtype: T
    
        
        .. code-block:: csharp
    
            public T StartParentChunk<T>(SyntaxTreeNode association, bool topLevel)where T : ParentChunk, new ()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.Chunks.ChunkTreeBuilder.StartParentChunk<T>(T, Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SyntaxTreeNode, System.Boolean)
    
        
    
        
        :type parentChunk: T
    
        
        :type association: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SyntaxTreeNode
    
        
        :type topLevel: System.Boolean
        :rtype: T
    
        
        .. code-block:: csharp
    
            public T StartParentChunk<T>(T parentChunk, SyntaxTreeNode association, bool topLevel)where T : ParentChunk
    

