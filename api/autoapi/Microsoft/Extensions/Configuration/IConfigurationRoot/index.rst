

IConfigurationRoot Interface
============================



.. contents:: 
   :local:



Summary
-------

Represents the root of an :any:`Microsoft.Extensions.Configuration.IConfiguration` hierarchy.











Syntax
------

.. code-block:: csharp

   public interface IConfigurationRoot : IConfiguration





GitHub
------

`View on GitHub <https://github.com/aspnet/configuration/blob/master/src/Microsoft.Extensions.Configuration.Abstractions/IConfigurationRoot.cs>`_





.. dn:interface:: Microsoft.Extensions.Configuration.IConfigurationRoot

Methods
-------

.. dn:interface:: Microsoft.Extensions.Configuration.IConfigurationRoot
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Configuration.IConfigurationRoot.Reload()
    
        
    
        Force the configuration values to be reloaded from the underlying :any:`Microsoft.Extensions.Configuration.IConfigurationProvider`\s.
    
        
    
        
        .. code-block:: csharp
    
           void Reload()
    

