

IConfigurationSource Interface
==============================






Represents a source of configuration key/values for an application.


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

    public interface IConfigurationSource








.. dn:interface:: Microsoft.Extensions.Configuration.IConfigurationSource
    :hidden:

.. dn:interface:: Microsoft.Extensions.Configuration.IConfigurationSource

Methods
-------

.. dn:interface:: Microsoft.Extensions.Configuration.IConfigurationSource
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Configuration.IConfigurationSource.Build(Microsoft.Extensions.Configuration.IConfigurationBuilder)
    
        
    
        
        Builds the :any:`Microsoft.Extensions.Configuration.IConfigurationProvider` for this source.
    
        
    
        
        :param builder: The :any:`Microsoft.Extensions.Configuration.IConfigurationBuilder`\.
        
        :type builder: Microsoft.Extensions.Configuration.IConfigurationBuilder
        :rtype: Microsoft.Extensions.Configuration.IConfigurationProvider
        :return: An :any:`Microsoft.Extensions.Configuration.IConfigurationProvider`
    
        
        .. code-block:: csharp
    
            IConfigurationProvider Build(IConfigurationBuilder builder)
    

