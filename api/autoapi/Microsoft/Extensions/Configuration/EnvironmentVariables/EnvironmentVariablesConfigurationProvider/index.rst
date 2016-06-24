

EnvironmentVariablesConfigurationProvider Class
===============================================






An environment variable based :any:`Microsoft.Extensions.Configuration.ConfigurationProvider`\.


Namespace
    :dn:ns:`Microsoft.Extensions.Configuration.EnvironmentVariables`
Assemblies
    * Microsoft.Extensions.Configuration.EnvironmentVariables

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Configuration.ConfigurationProvider`
* :dn:cls:`Microsoft.Extensions.Configuration.EnvironmentVariables.EnvironmentVariablesConfigurationProvider`








Syntax
------

.. code-block:: csharp

    public class EnvironmentVariablesConfigurationProvider : ConfigurationProvider, IConfigurationProvider








.. dn:class:: Microsoft.Extensions.Configuration.EnvironmentVariables.EnvironmentVariablesConfigurationProvider
    :hidden:

.. dn:class:: Microsoft.Extensions.Configuration.EnvironmentVariables.EnvironmentVariablesConfigurationProvider

Constructors
------------

.. dn:class:: Microsoft.Extensions.Configuration.EnvironmentVariables.EnvironmentVariablesConfigurationProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.Configuration.EnvironmentVariables.EnvironmentVariablesConfigurationProvider.EnvironmentVariablesConfigurationProvider()
    
        
    
        
        Initializes a new instance.
    
        
    
        
        .. code-block:: csharp
    
            public EnvironmentVariablesConfigurationProvider()
    
    .. dn:constructor:: Microsoft.Extensions.Configuration.EnvironmentVariables.EnvironmentVariablesConfigurationProvider.EnvironmentVariablesConfigurationProvider(System.String)
    
        
    
        
        Initializes a new instance with the specified prefix.
    
        
    
        
        :param prefix: A prefix used to filter the environment variables.
        
        :type prefix: System.String
    
        
        .. code-block:: csharp
    
            public EnvironmentVariablesConfigurationProvider(string prefix)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.Configuration.EnvironmentVariables.EnvironmentVariablesConfigurationProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Configuration.EnvironmentVariables.EnvironmentVariablesConfigurationProvider.Load()
    
        
    
        
        Loads the environment variables.
    
        
    
        
        .. code-block:: csharp
    
            public override void Load()
    

