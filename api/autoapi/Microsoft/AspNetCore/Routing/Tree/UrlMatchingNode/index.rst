

UrlMatchingNode Class
=====================






A node in a :any:`Microsoft.AspNetCore.Routing.Tree.UrlMatchingTree`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Routing.Tree`
Assemblies
    * Microsoft.AspNetCore.Routing

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Routing.Tree.UrlMatchingNode`








Syntax
------

.. code-block:: csharp

    [DebuggerDisplay("{DebuggerToString(),nq}")]
    public class UrlMatchingNode








.. dn:class:: Microsoft.AspNetCore.Routing.Tree.UrlMatchingNode
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Routing.Tree.UrlMatchingNode

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Routing.Tree.UrlMatchingNode
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Routing.Tree.UrlMatchingNode.UrlMatchingNode(System.Int32)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Routing.Tree.UrlMatchingNode`\.
    
        
    
        
        :param length: The length of the path to this node in the :any:`Microsoft.AspNetCore.Routing.Tree.UrlMatchingTree`\.
        
        :type length: System.Int32
    
        
        .. code-block:: csharp
    
            public UrlMatchingNode(int length)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Routing.Tree.UrlMatchingNode
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Routing.Tree.UrlMatchingNode.CatchAlls
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Routing.Tree.UrlMatchingNode` representing
        catch all parameter segments following this segment in the :any:`Microsoft.AspNetCore.Routing.Tree.TreeRouter`\.
    
        
        :rtype: Microsoft.AspNetCore.Routing.Tree.UrlMatchingNode
    
        
        .. code-block:: csharp
    
            public UrlMatchingNode CatchAlls { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.Tree.UrlMatchingNode.ConstrainedCatchAlls
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Routing.Tree.UrlMatchingNode` representing
        catch all parameter segments with constraints following this segment in the :any:`Microsoft.AspNetCore.Routing.Tree.TreeRouter`\.
    
        
        :rtype: Microsoft.AspNetCore.Routing.Tree.UrlMatchingNode
    
        
        .. code-block:: csharp
    
            public UrlMatchingNode ConstrainedCatchAlls { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.Tree.UrlMatchingNode.ConstrainedParameters
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Routing.Tree.UrlMatchingNode` representing
        parameter segments with constraints following this segment in the :any:`Microsoft.AspNetCore.Routing.Tree.TreeRouter`\.
    
        
        :rtype: Microsoft.AspNetCore.Routing.Tree.UrlMatchingNode
    
        
        .. code-block:: csharp
    
            public UrlMatchingNode ConstrainedParameters { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.Tree.UrlMatchingNode.Depth
    
        
    
        
        Gets the length of the path to this node in the :any:`Microsoft.AspNetCore.Routing.Tree.UrlMatchingTree`\.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Depth { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.Tree.UrlMatchingNode.IsCatchAll
    
        
    
        
        Gets or sets a value indicating whether this node represents a catch all segment.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsCatchAll { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.Tree.UrlMatchingNode.Literals
    
        
    
        
        Gets the literal segments following this segment.
    
        
        :rtype: System.Collections.Generic.Dictionary<System.Collections.Generic.Dictionary`2>{System.String<System.String>, Microsoft.AspNetCore.Routing.Tree.UrlMatchingNode<Microsoft.AspNetCore.Routing.Tree.UrlMatchingNode>}
    
        
        .. code-block:: csharp
    
            public Dictionary<string, UrlMatchingNode> Literals { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.Tree.UrlMatchingNode.Matches
    
        
    
        
        Gets the list of matching route entries associated with this node.
    
        
        :rtype: System.Collections.Generic.List<System.Collections.Generic.List`1>{Microsoft.AspNetCore.Routing.Tree.InboundMatch<Microsoft.AspNetCore.Routing.Tree.InboundMatch>}
    
        
        .. code-block:: csharp
    
            public List<InboundMatch> Matches { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.Tree.UrlMatchingNode.Parameters
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Routing.Tree.UrlMatchingNode` representing
        parameter segments following this segment in the :any:`Microsoft.AspNetCore.Routing.Tree.TreeRouter`\.
    
        
        :rtype: Microsoft.AspNetCore.Routing.Tree.UrlMatchingNode
    
        
        .. code-block:: csharp
    
            public UrlMatchingNode Parameters { get; set; }
    

