

StartupLoader Class
===================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Hosting.Startup`
Assemblies
    * Microsoft.AspNetCore.Hosting

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Hosting.Startup.StartupLoader`








Syntax
------

.. code-block:: csharp

    public class StartupLoader : IStartupLoader








.. dn:class:: Microsoft.AspNetCore.Hosting.Startup.StartupLoader
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Hosting.Startup.StartupLoader

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Hosting.Startup.StartupLoader
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Hosting.Startup.StartupLoader.StartupLoader(System.IServiceProvider, Microsoft.AspNetCore.Hosting.IHostingEnvironment)
    
        
    
        
        :type services: System.IServiceProvider
    
        
        :type hostingEnv: Microsoft.AspNetCore.Hosting.IHostingEnvironment
    
        
        .. code-block:: csharp
    
            public StartupLoader(IServiceProvider services, IHostingEnvironment hostingEnv)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Hosting.Startup.StartupLoader
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Hosting.Startup.StartupLoader.FindStartupType(System.String, System.Collections.Generic.IList<System.String>)
    
        
    
        
        :type startupAssemblyName: System.String
    
        
        :type diagnosticMessages: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.String<System.String>}
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
            public Type FindStartupType(string startupAssemblyName, IList<string> diagnosticMessages)
    
    .. dn:method:: Microsoft.AspNetCore.Hosting.Startup.StartupLoader.LoadMethods(System.Type, System.Collections.Generic.IList<System.String>)
    
        
    
        
        :type startupType: System.Type
    
        
        :type diagnosticMessages: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.String<System.String>}
        :rtype: Microsoft.AspNetCore.Hosting.Startup.StartupMethods
    
        
        .. code-block:: csharp
    
            public StartupMethods LoadMethods(Type startupType, IList<string> diagnosticMessages)
    

