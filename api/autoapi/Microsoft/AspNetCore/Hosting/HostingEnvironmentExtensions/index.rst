

HostingEnvironmentExtensions Class
==================================






Extension methods for :any:`Microsoft.AspNetCore.Hosting.IHostingEnvironment`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Hosting`
Assemblies
    * Microsoft.AspNetCore.Hosting.Abstractions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Hosting.HostingEnvironmentExtensions`








Syntax
------

.. code-block:: csharp

    public class HostingEnvironmentExtensions








.. dn:class:: Microsoft.AspNetCore.Hosting.HostingEnvironmentExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Hosting.HostingEnvironmentExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Hosting.HostingEnvironmentExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Hosting.HostingEnvironmentExtensions.IsDevelopment(Microsoft.AspNetCore.Hosting.IHostingEnvironment)
    
        
    
        
        Checks if the current hosting environment name is "Development".
    
        
    
        
        :param hostingEnvironment: An instance of :any:`Microsoft.AspNetCore.Hosting.IHostingEnvironment`\.
        
        :type hostingEnvironment: Microsoft.AspNetCore.Hosting.IHostingEnvironment
        :rtype: System.Boolean
        :return: True if the environment name is "Development", otherwise false.
    
        
        .. code-block:: csharp
    
            public static bool IsDevelopment(this IHostingEnvironment hostingEnvironment)
    
    .. dn:method:: Microsoft.AspNetCore.Hosting.HostingEnvironmentExtensions.IsEnvironment(Microsoft.AspNetCore.Hosting.IHostingEnvironment, System.String)
    
        
    
        
        Compares the current hosting environment name against the specified value.
    
        
    
        
        :param hostingEnvironment: An instance of :any:`Microsoft.AspNetCore.Hosting.IHostingEnvironment`\.
        
        :type hostingEnvironment: Microsoft.AspNetCore.Hosting.IHostingEnvironment
    
        
        :param environmentName: Environment name to validate against.
        
        :type environmentName: System.String
        :rtype: System.Boolean
        :return: True if the specified name is the same as the current environment, otherwise false.
    
        
        .. code-block:: csharp
    
            public static bool IsEnvironment(this IHostingEnvironment hostingEnvironment, string environmentName)
    
    .. dn:method:: Microsoft.AspNetCore.Hosting.HostingEnvironmentExtensions.IsProduction(Microsoft.AspNetCore.Hosting.IHostingEnvironment)
    
        
    
        
        Checks if the current hosting environment name is "Production".
    
        
    
        
        :param hostingEnvironment: An instance of :any:`Microsoft.AspNetCore.Hosting.IHostingEnvironment`\.
        
        :type hostingEnvironment: Microsoft.AspNetCore.Hosting.IHostingEnvironment
        :rtype: System.Boolean
        :return: True if the environment name is "Production", otherwise false.
    
        
        .. code-block:: csharp
    
            public static bool IsProduction(this IHostingEnvironment hostingEnvironment)
    
    .. dn:method:: Microsoft.AspNetCore.Hosting.HostingEnvironmentExtensions.IsStaging(Microsoft.AspNetCore.Hosting.IHostingEnvironment)
    
        
    
        
        Checks if the current hosting environment name is "Staging".
    
        
    
        
        :param hostingEnvironment: An instance of :any:`Microsoft.AspNetCore.Hosting.IHostingEnvironment`\.
        
        :type hostingEnvironment: Microsoft.AspNetCore.Hosting.IHostingEnvironment
        :rtype: System.Boolean
        :return: True if the environment name is "Staging", otherwise false.
    
        
        .. code-block:: csharp
    
            public static bool IsStaging(this IHostingEnvironment hostingEnvironment)
    

