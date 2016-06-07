

ConfigurationReloadToken Class
==============================





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
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool ActiveChangeCallbacks
            {
                get;
            }
    
    .. dn:property:: Microsoft.Extensions.Configuration.ConfigurationReloadToken.HasChanged
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool HasChanged
            {
                get;
            }
    

Methods
-------

.. dn:class:: Microsoft.Extensions.Configuration.ConfigurationReloadToken
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Configuration.ConfigurationReloadToken.OnReload()
    
        
    
        
        .. code-block:: csharp
    
            public void OnReload()
    
    .. dn:method:: Microsoft.Extensions.Configuration.ConfigurationReloadToken.RegisterChangeCallback(System.Action<System.Object>, System.Object)
    
        
    
        
        :type callback: System.Action<System.Action`1>{System.Object<System.Object>}
    
        
        :type state: System.Object
        :rtype: System.IDisposable
    
        
        .. code-block:: csharp
    
            public IDisposable RegisterChangeCallback(Action<object> callback, object state)
    

