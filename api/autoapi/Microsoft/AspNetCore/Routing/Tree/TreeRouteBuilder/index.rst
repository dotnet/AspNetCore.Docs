

TreeRouteBuilder Class
======================





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
* :dn:cls:`Microsoft.AspNetCore.Routing.Tree.TreeRouteBuilder`








Syntax
------

.. code-block:: csharp

    public class TreeRouteBuilder








.. dn:class:: Microsoft.AspNetCore.Routing.Tree.TreeRouteBuilder
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Routing.Tree.TreeRouteBuilder

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Routing.Tree.TreeRouteBuilder
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Routing.Tree.TreeRouteBuilder.TreeRouteBuilder(Microsoft.AspNetCore.Routing.IRouter, Microsoft.Extensions.Logging.ILoggerFactory)
    
        
    
        
        :type target: Microsoft.AspNetCore.Routing.IRouter
    
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        .. code-block:: csharp
    
            public TreeRouteBuilder(IRouter target, ILoggerFactory loggerFactory)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Routing.Tree.TreeRouteBuilder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Routing.Tree.TreeRouteBuilder.Add(Microsoft.AspNetCore.Routing.Tree.TreeRouteLinkGenerationEntry)
    
        
    
        
        :type entry: Microsoft.AspNetCore.Routing.Tree.TreeRouteLinkGenerationEntry
    
        
        .. code-block:: csharp
    
            public void Add(TreeRouteLinkGenerationEntry entry)
    
    .. dn:method:: Microsoft.AspNetCore.Routing.Tree.TreeRouteBuilder.Add(Microsoft.AspNetCore.Routing.Tree.TreeRouteMatchingEntry)
    
        
    
        
        :type entry: Microsoft.AspNetCore.Routing.Tree.TreeRouteMatchingEntry
    
        
        .. code-block:: csharp
    
            public void Add(TreeRouteMatchingEntry entry)
    
    .. dn:method:: Microsoft.AspNetCore.Routing.Tree.TreeRouteBuilder.Build(System.Int32)
    
        
    
        
        :type version: System.Int32
        :rtype: Microsoft.AspNetCore.Routing.Tree.TreeRouter
    
        
        .. code-block:: csharp
    
            public TreeRouter Build(int version)
    
    .. dn:method:: Microsoft.AspNetCore.Routing.Tree.TreeRouteBuilder.Clear()
    
        
    
        
        .. code-block:: csharp
    
            public void Clear()
    

