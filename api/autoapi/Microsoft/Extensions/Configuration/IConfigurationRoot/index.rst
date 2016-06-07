

IConfigurationRoot Interface
============================






Represents the root of an :any:`Microsoft.Extensions.Configuration.IConfiguration` hierarchy.


Namespace
    :dn:ns:`Microsoft.Extensions.Configuration`
Assemblies
    * Microsoft.Extensions.Configuration.Abstractions

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IConfigurationRoot : IConfiguration








.. dn:interface:: Microsoft.Extensions.Configuration.IConfigurationRoot
    :hidden:

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
    

