

UrlMatchingTree Class
=====================






A tree part of a :any:`Microsoft.AspNetCore.Routing.Tree.TreeRouter`\.


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
* :dn:cls:`Microsoft.AspNetCore.Routing.Tree.UrlMatchingTree`








Syntax
------

.. code-block:: csharp

    public class UrlMatchingTree








.. dn:class:: Microsoft.AspNetCore.Routing.Tree.UrlMatchingTree
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Routing.Tree.UrlMatchingTree

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Routing.Tree.UrlMatchingTree
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Routing.Tree.UrlMatchingTree.UrlMatchingTree(System.Int32)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Routing.Tree.UrlMatchingTree`\.
    
        
    
        
        :param order: The order associated with routes in this :any:`Microsoft.AspNetCore.Routing.Tree.UrlMatchingTree`\.
        
        :type order: System.Int32
    
        
        .. code-block:: csharp
    
            public UrlMatchingTree(int order)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Routing.Tree.UrlMatchingTree
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Routing.Tree.UrlMatchingTree.Order
    
        
    
        
        Gets the order of the routes associated with this :any:`Microsoft.AspNetCore.Routing.Tree.UrlMatchingTree`\.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Order { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.Tree.UrlMatchingTree.Root
    
        
    
        
        Gets the root of the :any:`Microsoft.AspNetCore.Routing.Tree.UrlMatchingTree`\.
    
        
        :rtype: Microsoft.AspNetCore.Routing.Tree.UrlMatchingNode
    
        
        .. code-block:: csharp
    
            public UrlMatchingNode Root { get; }
    

