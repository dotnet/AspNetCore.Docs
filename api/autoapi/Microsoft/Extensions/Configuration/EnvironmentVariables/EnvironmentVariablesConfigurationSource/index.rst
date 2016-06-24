

EnvironmentVariablesConfigurationSource Class
=============================================






Represents environment variables as an :any:`Microsoft.Extensions.Configuration.IConfigurationSource`\.


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
* :dn:cls:`Microsoft.Extensions.Configuration.EnvironmentVariables.EnvironmentVariablesConfigurationSource`








Syntax
------

.. code-block:: csharp

    public class EnvironmentVariablesConfigurationSource : IConfigurationSource








.. dn:class:: Microsoft.Extensions.Configuration.EnvironmentVariables.EnvironmentVariablesConfigurationSource
    :hidden:

.. dn:class:: Microsoft.Extensions.Configuration.EnvironmentVariables.EnvironmentVariablesConfigurationSource

Methods
-------

.. dn:class:: Microsoft.Extensions.Configuration.EnvironmentVariables.EnvironmentVariablesConfigurationSource
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Configuration.EnvironmentVariables.EnvironmentVariablesConfigurationSource.Build(Microsoft.Extensions.Configuration.IConfigurationBuilder)
    
        
    
        
        Builds the :any:`Microsoft.Extensions.Configuration.EnvironmentVariables.EnvironmentVariablesConfigurationProvider` for this source.
    
        
    
        
        :param builder: The :any:`Microsoft.Extensions.Configuration.IConfigurationBuilder`\.
        
        :type builder: Microsoft.Extensions.Configuration.IConfigurationBuilder
        :rtype: Microsoft.Extensions.Configuration.IConfigurationProvider
        :return: A :any:`Microsoft.Extensions.Configuration.EnvironmentVariables.EnvironmentVariablesConfigurationProvider`
    
        
        .. code-block:: csharp
    
            public IConfigurationProvider Build(IConfigurationBuilder builder)
    

Properties
----------

.. dn:class:: Microsoft.Extensions.Configuration.EnvironmentVariables.EnvironmentVariablesConfigurationSource
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Configuration.EnvironmentVariables.EnvironmentVariablesConfigurationSource.Prefix
    
        
    
        
        A prefix used to filter environment variables.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Prefix { get; set; }
    

