

SyntaxTreeNode Class
====================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Parser.SyntaxTree.SyntaxTreeNode`








Syntax
------

.. code-block:: csharp

   public abstract class SyntaxTreeNode





GitHub
------

`View on GitHub <https://github.com/aspnet/razor/blob/master/src/Microsoft.AspNet.Razor/Parser/SyntaxTree/SyntaxTreeNode.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Parser.SyntaxTree.SyntaxTreeNode

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.Parser.SyntaxTree.SyntaxTreeNode
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.SyntaxTree.SyntaxTreeNode.Accept(Microsoft.AspNet.Razor.Parser.ParserVisitor)
    
        
    
        Accepts a parser visitor, calling the appropriate visit method and passing in this instance
    
        
        
        
        :param visitor: The visitor to accept
        
        :type visitor: Microsoft.AspNet.Razor.Parser.ParserVisitor
    
        
        .. code-block:: csharp
    
           public abstract void Accept(ParserVisitor visitor)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.SyntaxTree.SyntaxTreeNode.EquivalentTo(Microsoft.AspNet.Razor.Parser.SyntaxTree.SyntaxTreeNode)
    
        
    
        Determines if the specified node is equivalent to this node
    
        
        
        
        :param node: The node to compare this node with
        
        :type node: Microsoft.AspNet.Razor.Parser.SyntaxTree.SyntaxTreeNode
        :rtype: System.Boolean
        :return: true if the provided node has all the same content and metadata, though the specific quantity and type of
            symbols may be different.
    
        
        .. code-block:: csharp
    
           public abstract bool EquivalentTo(SyntaxTreeNode node)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.SyntaxTree.SyntaxTreeNode.GetEquivalenceHash()
    
        
    
        Determines a hash code for the :any:`Microsoft.AspNet.Razor.Parser.SyntaxTree.SyntaxTreeNode` using only information relevant in 
        :dn:meth:`Microsoft.AspNet.Razor.Parser.SyntaxTree.SyntaxTreeNode.EquivalentTo(Microsoft.AspNet.Razor.Parser.SyntaxTree.SyntaxTreeNode)` comparisons.
    
        
        :rtype: System.Int32
        :return: A hash code for the <see cref="T:Microsoft.AspNet.Razor.Parser.SyntaxTree.SyntaxTreeNode" /> using only information relevant in
            <see cref="M:Microsoft.AspNet.Razor.Parser.SyntaxTree.SyntaxTreeNode.EquivalentTo(Microsoft.AspNet.Razor.Parser.SyntaxTree.SyntaxTreeNode)" /> comparisons.
    
        
        .. code-block:: csharp
    
           public abstract int GetEquivalenceHash()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.Parser.SyntaxTree.SyntaxTreeNode
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.Parser.SyntaxTree.SyntaxTreeNode.IsBlock
    
        
    
        Returns true if this element is a block (to avoid casting)
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public abstract bool IsBlock { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Parser.SyntaxTree.SyntaxTreeNode.Length
    
        
    
        The length of all the content contained in this node
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public abstract int Length { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Parser.SyntaxTree.SyntaxTreeNode.Parent
    
        
        :rtype: Microsoft.AspNet.Razor.Parser.SyntaxTree.Block
    
        
        .. code-block:: csharp
    
           public Block Parent { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.Parser.SyntaxTree.SyntaxTreeNode.Start
    
        
    
        The start point of this node
    
        
        :rtype: Microsoft.AspNet.Razor.SourceLocation
    
        
        .. code-block:: csharp
    
           public abstract SourceLocation Start { get; }
    

