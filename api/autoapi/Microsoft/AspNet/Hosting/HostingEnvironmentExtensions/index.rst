

HostingEnvironmentExtensions Class
==================================



.. contents:: 
   :local:



Summary
-------

Extension methods for :any:`Microsoft.AspNet.Hosting.IHostingEnvironment`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Hosting.HostingEnvironmentExtensions`








Syntax
------

.. code-block:: csharp

   public class HostingEnvironmentExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/hosting/blob/master/src/Microsoft.AspNet.Hosting.Abstractions/HostingEnvironmentExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Hosting.HostingEnvironmentExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Hosting.HostingEnvironmentExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Hosting.HostingEnvironmentExtensions.IsDevelopment(Microsoft.AspNet.Hosting.IHostingEnvironment)
    
        
    
        Checks if the current hosting environment name is "Development".
    
        
        
        
        :param hostingEnvironment: An instance of .
        
        :type hostingEnvironment: Microsoft.AspNet.Hosting.IHostingEnvironment
        :rtype: System.Boolean
        :return: True if the environment name is "Development", otherwise false.
    
        
        .. code-block:: csharp
    
           public static bool IsDevelopment(IHostingEnvironment hostingEnvironment)
    
    .. dn:method:: Microsoft.AspNet.Hosting.HostingEnvironmentExtensions.IsEnvironment(Microsoft.AspNet.Hosting.IHostingEnvironment, System.String)
    
        
    
        Compares the current hosting environment name against the specified value.
    
        
        
        
        :param hostingEnvironment: An instance of .
        
        :type hostingEnvironment: Microsoft.AspNet.Hosting.IHostingEnvironment
        
        
        :param environmentName: Environment name to validate against.
        
        :type environmentName: System.String
        :rtype: System.Boolean
        :return: True if the specified name is the same as the current environment, otherwise false.
    
        
        .. code-block:: csharp
    
           public static bool IsEnvironment(IHostingEnvironment hostingEnvironment, string environmentName)
    
    .. dn:method:: Microsoft.AspNet.Hosting.HostingEnvironmentExtensions.IsProduction(Microsoft.AspNet.Hosting.IHostingEnvironment)
    
        
    
        Checks if the current hosting environment name is "Production".
    
        
        
        
        :param hostingEnvironment: An instance of .
        
        :type hostingEnvironment: Microsoft.AspNet.Hosting.IHostingEnvironment
        :rtype: System.Boolean
        :return: True if the environment name is "Production", otherwise false.
    
        
        .. code-block:: csharp
    
           public static bool IsProduction(IHostingEnvironment hostingEnvironment)
    
    .. dn:method:: Microsoft.AspNet.Hosting.HostingEnvironmentExtensions.IsStaging(Microsoft.AspNet.Hosting.IHostingEnvironment)
    
        
    
        Checks if the current hosting environment name is "Staging".
    
        
        
        
        :param hostingEnvironment: An instance of .
        
        :type hostingEnvironment: Microsoft.AspNet.Hosting.IHostingEnvironment
        :rtype: System.Boolean
        :return: True if the environment name is "Staging", otherwise false.
    
        
        .. code-block:: csharp
    
           public static bool IsStaging(IHostingEnvironment hostingEnvironment)
    
    .. dn:method:: Microsoft.AspNet.Hosting.HostingEnvironmentExtensions.MapPath(Microsoft.AspNet.Hosting.IHostingEnvironment, System.String)
    
        
    
        Determines the physical path corresponding to the given virtual path.
    
        
        
        
        :param hostingEnvironment: An instance of .
        
        :type hostingEnvironment: Microsoft.AspNet.Hosting.IHostingEnvironment
        
        
        :param virtualPath: Path relative to the application root.
        
        :type virtualPath: System.String
        :rtype: System.String
        :return: Physical path corresponding to the virtual path.
    
        
        .. code-block:: csharp
    
           public static string MapPath(IHostingEnvironment hostingEnvironment, string virtualPath)
    

