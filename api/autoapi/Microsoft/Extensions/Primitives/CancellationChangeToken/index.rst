

CancellationChangeToken Class
=============================






A :any:`Microsoft.Extensions.Primitives.IChangeToken` implementation using :any:`System.Threading.CancellationToken`\.


Namespace
    :dn:ns:`Microsoft.Extensions.Primitives`
Assemblies
    * Microsoft.Extensions.Primitives

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Primitives.CancellationChangeToken`








Syntax
------

.. code-block:: csharp

    public class CancellationChangeToken : IChangeToken








.. dn:class:: Microsoft.Extensions.Primitives.CancellationChangeToken
    :hidden:

.. dn:class:: Microsoft.Extensions.Primitives.CancellationChangeToken

Constructors
------------

.. dn:class:: Microsoft.Extensions.Primitives.CancellationChangeToken
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.Primitives.CancellationChangeToken.CancellationChangeToken(System.Threading.CancellationToken)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.Extensions.Primitives.CancellationChangeToken`\.
    
        
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken`\.
        
        :type cancellationToken: System.Threading.CancellationToken
    
        
        .. code-block:: csharp
    
            public CancellationChangeToken(CancellationToken cancellationToken)
    

Properties
----------

.. dn:class:: Microsoft.Extensions.Primitives.CancellationChangeToken
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Primitives.CancellationChangeToken.ActiveChangeCallbacks
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool ActiveChangeCallbacks { get; }
    
    .. dn:property:: Microsoft.Extensions.Primitives.CancellationChangeToken.HasChanged
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool HasChanged { get; }
    

Methods
-------

.. dn:class:: Microsoft.Extensions.Primitives.CancellationChangeToken
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Primitives.CancellationChangeToken.RegisterChangeCallback(System.Action<System.Object>, System.Object)
    
        
    
        
        :type callback: System.Action<System.Action`1>{System.Object<System.Object>}
    
        
        :type state: System.Object
        :rtype: System.IDisposable
    
        
        .. code-block:: csharp
    
            public IDisposable RegisterChangeCallback(Action<object> callback, object state)
    

