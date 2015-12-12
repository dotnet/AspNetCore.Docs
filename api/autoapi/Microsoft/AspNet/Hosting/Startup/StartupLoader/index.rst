

StartupLoader Class
===================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Hosting.Startup.StartupLoader`








Syntax
------

.. code-block:: csharp

   public class StartupLoader : IStartupLoader





GitHub
------

`View on GitHub <https://github.com/aspnet/hosting/blob/master/src/Microsoft.AspNet.Hosting/Startup/StartupLoader.cs>`_





.. dn:class:: Microsoft.AspNet.Hosting.Startup.StartupLoader

Constructors
------------

.. dn:class:: Microsoft.AspNet.Hosting.Startup.StartupLoader
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Hosting.Startup.StartupLoader.StartupLoader(System.IServiceProvider, Microsoft.AspNet.Hosting.IHostingEnvironment)
    
        
        
        
        :type services: System.IServiceProvider
        
        
        :type hostingEnv: Microsoft.AspNet.Hosting.IHostingEnvironment
    
        
        .. code-block:: csharp
    
           public StartupLoader(IServiceProvider services, IHostingEnvironment hostingEnv)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Hosting.Startup.StartupLoader
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Hosting.Startup.StartupLoader.FindStartupType(System.String, System.Collections.Generic.IList<System.String>)
    
        
        
        
        :type startupAssemblyName: System.String
        
        
        :type diagnosticMessages: System.Collections.Generic.IList{System.String}
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
           public Type FindStartupType(string startupAssemblyName, IList<string> diagnosticMessages)
    
    .. dn:method:: Microsoft.AspNet.Hosting.Startup.StartupLoader.LoadMethods(System.Type, System.Collections.Generic.IList<System.String>)
    
        
        
        
        :type startupType: System.Type
        
        
        :type diagnosticMessages: System.Collections.Generic.IList{System.String}
        :rtype: Microsoft.AspNet.Hosting.Startup.StartupMethods
    
        
        .. code-block:: csharp
    
           public StartupMethods LoadMethods(Type startupType, IList<string> diagnosticMessages)
    

