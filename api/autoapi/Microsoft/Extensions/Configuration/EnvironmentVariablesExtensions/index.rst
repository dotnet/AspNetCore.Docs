

EnvironmentVariablesExtensions Class
====================================



.. contents:: 
   :local:



Summary
-------

Extension methods for registering :any:`Microsoft.Extensions.Configuration.EnvironmentVariables.EnvironmentVariablesConfigurationProvider` with :any:`Microsoft.Extensions.Configuration.IConfigurationBuilder`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Configuration.EnvironmentVariablesExtensions`








Syntax
------

.. code-block:: csharp

   public class EnvironmentVariablesExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/configuration/src/Microsoft.Extensions.Configuration.EnvironmentVariables/EnvironmentVariablesExtensions.cs>`_





.. dn:class:: Microsoft.Extensions.Configuration.EnvironmentVariablesExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.Configuration.EnvironmentVariablesExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Configuration.EnvironmentVariablesExtensions.AddEnvironmentVariables(Microsoft.Extensions.Configuration.IConfigurationBuilder)
    
        
    
        Adds an :any:`Microsoft.Extensions.Configuration.IConfigurationProvider` that reads configuration values from environment variables.
    
        
        
        
        :param configurationBuilder: The  to add to.
        
        :type configurationBuilder: Microsoft.Extensions.Configuration.IConfigurationBuilder
        :rtype: Microsoft.Extensions.Configuration.IConfigurationBuilder
        :return: The <see cref="T:Microsoft.Extensions.Configuration.IConfigurationBuilder" />.
    
        
        .. code-block:: csharp
    
           public static IConfigurationBuilder AddEnvironmentVariables(IConfigurationBuilder configurationBuilder)
    
    .. dn:method:: Microsoft.Extensions.Configuration.EnvironmentVariablesExtensions.AddEnvironmentVariables(Microsoft.Extensions.Configuration.IConfigurationBuilder, System.String)
    
        
    
        Adds an :any:`Microsoft.Extensions.Configuration.IConfigurationProvider` that reads configuration values from environment variables
        with a specified prefix.
    
        
        
        
        :param configurationBuilder: The  to add to.
        
        :type configurationBuilder: Microsoft.Extensions.Configuration.IConfigurationBuilder
        
        
        :param prefix: The prefix that environment variable names must start with.
        
        :type prefix: System.String
        :rtype: Microsoft.Extensions.Configuration.IConfigurationBuilder
        :return: The <see cref="T:Microsoft.Extensions.Configuration.IConfigurationBuilder" />.
    
        
        .. code-block:: csharp
    
           public static IConfigurationBuilder AddEnvironmentVariables(IConfigurationBuilder configurationBuilder, string prefix)
    

