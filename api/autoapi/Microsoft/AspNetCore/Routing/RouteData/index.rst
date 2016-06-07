

RouteData Class
===============






Information about the current routing path.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Routing`
Assemblies
    * Microsoft.AspNetCore.Routing.Abstractions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Routing.RouteData`








Syntax
------

.. code-block:: csharp

    public class RouteData








.. dn:class:: Microsoft.AspNetCore.Routing.RouteData
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Routing.RouteData

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Routing.RouteData
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Routing.RouteData.DataTokens
    
        
    
        
        Gets the data tokens produced by routes on the current routing path.
    
        
        :rtype: Microsoft.AspNetCore.Routing.RouteValueDictionary
    
        
        .. code-block:: csharp
    
            public RouteValueDictionary DataTokens
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.RouteData.Routers
    
        
    
        
        Gets the list of :any:`Microsoft.AspNetCore.Routing.IRouter` instances on the current routing path.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Routing.IRouter<Microsoft.AspNetCore.Routing.IRouter>}
    
        
        .. code-block:: csharp
    
            public IList<IRouter> Routers
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.RouteData.Values
    
        
    
        
        Gets the set of values produced by routes on the current routing path.
    
        
        :rtype: Microsoft.AspNetCore.Routing.RouteValueDictionary
    
        
        .. code-block:: csharp
    
            public RouteValueDictionary Values
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Routing.RouteData
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Routing.RouteData.RouteData()
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Routing.RouteData` instance.
    
        
    
        
        .. code-block:: csharp
    
            public RouteData()
    
    .. dn:constructor:: Microsoft.AspNetCore.Routing.RouteData.RouteData(Microsoft.AspNetCore.Routing.RouteData)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Routing.RouteData` instance with values copied from <em>other</em>.
    
        
    
        
        :param other: The other :any:`Microsoft.AspNetCore.Routing.RouteData` instance to copy.
        
        :type other: Microsoft.AspNetCore.Routing.RouteData
    
        
        .. code-block:: csharp
    
            public RouteData(RouteData other)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Routing.RouteData
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Routing.RouteData.PushState(Microsoft.AspNetCore.Routing.IRouter, Microsoft.AspNetCore.Routing.RouteValueDictionary, Microsoft.AspNetCore.Routing.RouteValueDictionary)
    
        
    
        
        <p>
        Creates a snapshot of the current state of the :any:`Microsoft.AspNetCore.Routing.RouteData` before appending
        <em>router</em> to :dn:prop:`Microsoft.AspNetCore.Routing.RouteData.Routers`\, merging <em>values</em> into
        :dn:prop:`Microsoft.AspNetCore.Routing.RouteData.Values`\, and merging <em>dataTokens</em> into :dn:prop:`Microsoft.AspNetCore.Routing.RouteData.DataTokens`\.
        </p>
        <p>
        Call :dn:meth:`Microsoft.AspNetCore.Routing.RouteData.RouteDataSnapshot.Restore` to restore the state of this :any:`Microsoft.AspNetCore.Routing.RouteData`
        to the state at the time of calling
        :dn:meth:`Microsoft.AspNetCore.Routing.RouteData.PushState(Microsoft.AspNetCore.Routing.IRouter,Microsoft.AspNetCore.Routing.RouteValueDictionary,Microsoft.AspNetCore.Routing.RouteValueDictionary)`\.
        </p>
    
        
    
        
        :param router: 
            An :any:`Microsoft.AspNetCore.Routing.IRouter` to append to :dn:prop:`Microsoft.AspNetCore.Routing.RouteData.Routers`\. If <code>null</code>, then :dn:prop:`Microsoft.AspNetCore.Routing.RouteData.Routers`
            will not be changed.
        
        :type router: Microsoft.AspNetCore.Routing.IRouter
    
        
        :param values: 
            A :any:`Microsoft.AspNetCore.Routing.RouteValueDictionary` to merge into :dn:prop:`Microsoft.AspNetCore.Routing.RouteData.Values`\. If <code>null</code>, then
            :dn:prop:`Microsoft.AspNetCore.Routing.RouteData.Values` will not be changed.
        
        :type values: Microsoft.AspNetCore.Routing.RouteValueDictionary
    
        
        :param dataTokens: 
            A :any:`Microsoft.AspNetCore.Routing.RouteValueDictionary` to merge into :dn:prop:`Microsoft.AspNetCore.Routing.RouteData.DataTokens`\. If <code>null</code>, then
            :dn:prop:`Microsoft.AspNetCore.Routing.RouteData.DataTokens` will not be changed.
        
        :type dataTokens: Microsoft.AspNetCore.Routing.RouteValueDictionary
        :rtype: Microsoft.AspNetCore.Routing.RouteData.RouteDataSnapshot
        :return: A :any:`Microsoft.AspNetCore.Routing.RouteData.RouteDataSnapshot` that captures the current state.
    
        
        .. code-block:: csharp
    
            public RouteData.RouteDataSnapshot PushState(IRouter router, RouteValueDictionary values, RouteValueDictionary dataTokens)
    

