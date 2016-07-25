

ConfigurationReloadToken Class
==============================






Implements :any:`Microsoft.Extensions.Primitives.IChangeToken`


Namespace
    :dn:ns:`Microsoft.Extensions.Configuration`
Assemblies
    * Microsoft.Extensions.Configuration

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Configuration.ConfigurationReloadToken`








Syntax
------

.. code-block:: csharp

    public class ConfigurationReloadToken : IChangeToken








.. dn:class:: Microsoft.Extensions.Configuration.ConfigurationReloadToken
    :hidden:

.. dn:class:: Microsoft.Extensions.Configuration.ConfigurationReloadToken

Properties
----------

.. dn:class:: Microsoft.Extensions.Configuration.ConfigurationReloadToken
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Configuration.ConfigurationReloadToken.ActiveChangeCallbacks
    
        
    
        
        Indicates if this token will proactively raise callbacks. Callbacks are still guaranteed to be invoked, eventually.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool ActiveChangeCallbacks { get; }
    
    .. dn:property:: Microsoft.Extensions.Configuration.ConfigurationReloadToken.HasChanged
    
        
    
        
        Gets a value that indicates if a change has occured.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool HasChanged { get; }
    

Methods
-------

.. dn:class:: Microsoft.Extensions.Configuration.ConfigurationReloadToken
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Configuration.ConfigurationReloadToken.OnReload()
    
        
    
        
        Used to trigger the change token when a reload occurs.
    
        
    
        
        .. code-block:: csharp
    
            public void OnReload()
    
    .. dn:method:: Microsoft.Extensions.Configuration.ConfigurationReloadToken.RegisterChangeCallback(System.Action<System.Object>, System.Object)
    
        
    
        
        Registers for a callback that will be invoked when the entry has changed. Microsoft.Extensions.Primitives.IChangeToken.HasChanged
        MUST be set before the callback is invoked.
    
        
    
        
        :param callback: The callback to invoke.
        
        :type callback: System.Action<System.Action`1>{System.Object<System.Object>}
    
        
        :param state: State to be passed into the callback.
        
        :type state: System.Object
        :rtype: System.IDisposable
    
        
        .. code-block:: csharp
    
            public IDisposable RegisterChangeCallback(Action<object> callback, object state)
    

