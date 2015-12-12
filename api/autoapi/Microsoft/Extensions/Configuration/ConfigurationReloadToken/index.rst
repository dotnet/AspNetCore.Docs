

ConfigurationReloadToken Class
==============================



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





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/configuration/src/Microsoft.Extensions.Configuration/ConfigurationReloadToken.cs>`_





.. dn:class:: Microsoft.Extensions.Configuration.ConfigurationReloadToken

Methods
-------

.. dn:class:: Microsoft.Extensions.Configuration.ConfigurationReloadToken
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Configuration.ConfigurationReloadToken.OnReload()
    
        
    
        
        .. code-block:: csharp
    
           public void OnReload()
    
    .. dn:method:: Microsoft.Extensions.Configuration.ConfigurationReloadToken.RegisterChangeCallback(System.Action<System.Object>, System.Object)
    
        
        
        
        :type callback: System.Action{System.Object}
        
        
        :type state: System.Object
        :rtype: System.IDisposable
    
        
        .. code-block:: csharp
    
           public IDisposable RegisterChangeCallback(Action<object> callback, object state)
    

Properties
----------

.. dn:class:: Microsoft.Extensions.Configuration.ConfigurationReloadToken
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Configuration.ConfigurationReloadToken.ActiveChangeCallbacks
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool ActiveChangeCallbacks { get; }
    
    .. dn:property:: Microsoft.Extensions.Configuration.ConfigurationReloadToken.HasChanged
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool HasChanged { get; }
    

