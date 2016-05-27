

UrlMatchingNode Class
=====================





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

    public class UrlMatchingNode








.. dn:class:: Microsoft.AspNetCore.Routing.Tree.UrlMatchingNode
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Routing.Tree.UrlMatchingNode

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Routing.Tree.UrlMatchingNode
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Routing.Tree.UrlMatchingNode.CatchAlls
    
        
        :rtype: Microsoft.AspNetCore.Routing.Tree.UrlMatchingNode
    
        
        .. code-block:: csharp
    
            public UrlMatchingNode CatchAlls
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.Tree.UrlMatchingNode.ConstrainedCatchAlls
    
        
        :rtype: Microsoft.AspNetCore.Routing.Tree.UrlMatchingNode
    
        
        .. code-block:: csharp
    
            public UrlMatchingNode ConstrainedCatchAlls
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.Tree.UrlMatchingNode.ConstrainedParameters
    
        
        :rtype: Microsoft.AspNetCore.Routing.Tree.UrlMatchingNode
    
        
        .. code-block:: csharp
    
            public UrlMatchingNode ConstrainedParameters
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.Tree.UrlMatchingNode.IsCatchAll
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsCatchAll
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.Tree.UrlMatchingNode.Length
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Length
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.Tree.UrlMatchingNode.Literals
    
        
        :rtype: System.Collections.Generic.Dictionary<System.Collections.Generic.Dictionary`2>{System.String<System.String>, Microsoft.AspNetCore.Routing.Tree.UrlMatchingNode<Microsoft.AspNetCore.Routing.Tree.UrlMatchingNode>}
    
        
        .. code-block:: csharp
    
            public Dictionary<string, UrlMatchingNode> Literals
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.Tree.UrlMatchingNode.Matches
    
        
        :rtype: System.Collections.Generic.List<System.Collections.Generic.List`1>{Microsoft.AspNetCore.Routing.Tree.TreeRouteMatchingEntry<Microsoft.AspNetCore.Routing.Tree.TreeRouteMatchingEntry>}
    
        
        .. code-block:: csharp
    
            public List<TreeRouteMatchingEntry> Matches
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.Tree.UrlMatchingNode.Parameters
    
        
        :rtype: Microsoft.AspNetCore.Routing.Tree.UrlMatchingNode
    
        
        .. code-block:: csharp
    
            public UrlMatchingNode Parameters
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Routing.Tree.UrlMatchingNode
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Routing.Tree.UrlMatchingNode.UrlMatchingNode(System.Int32)
    
        
    
        
        :type length: System.Int32
    
        
        .. code-block:: csharp
    
            public UrlMatchingNode(int length)
    

