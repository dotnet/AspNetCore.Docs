

NullChangeToken Class
=====================






An empty change token that doesn't raise any change callbacks


Namespace
    :dn:ns:`Microsoft.Extensions.FileProviders`
Assemblies
    * Microsoft.Extensions.FileProviders.Abstractions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.FileProviders.NullChangeToken`








Syntax
------

.. code-block:: csharp

    public class NullChangeToken : IChangeToken








.. dn:class:: Microsoft.Extensions.FileProviders.NullChangeToken
    :hidden:

.. dn:class:: Microsoft.Extensions.FileProviders.NullChangeToken

Properties
----------

.. dn:class:: Microsoft.Extensions.FileProviders.NullChangeToken
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.FileProviders.NullChangeToken.ActiveChangeCallbacks
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool ActiveChangeCallbacks { get; }
    
    .. dn:property:: Microsoft.Extensions.FileProviders.NullChangeToken.HasChanged
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool HasChanged { get; }
    
    .. dn:property:: Microsoft.Extensions.FileProviders.NullChangeToken.Singleton
    
        
        :rtype: Microsoft.Extensions.FileProviders.NullChangeToken
    
        
        .. code-block:: csharp
    
            public static NullChangeToken Singleton { get; }
    

Methods
-------

.. dn:class:: Microsoft.Extensions.FileProviders.NullChangeToken
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.FileProviders.NullChangeToken.RegisterChangeCallback(System.Action<System.Object>, System.Object)
    
        
    
        
        :type callback: System.Action<System.Action`1>{System.Object<System.Object>}
    
        
        :type state: System.Object
        :rtype: System.IDisposable
    
        
        .. code-block:: csharp
    
            public IDisposable RegisterChangeCallback(Action<object> callback, object state)
    

