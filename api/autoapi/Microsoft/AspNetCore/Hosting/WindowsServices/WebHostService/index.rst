

WebHostService Class
====================






    Provides an implementation of a Windows service that hosts ASP.NET Core.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Hosting.WindowsServices`
Assemblies
    * Microsoft.AspNetCore.Hosting.WindowsServices

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.MarshalByRefObject`
* :dn:cls:`System.ComponentModel.Component`
* :dn:cls:`System.ServiceProcess.ServiceBase`
* :dn:cls:`Microsoft.AspNetCore.Hosting.WindowsServices.WebHostService`








Syntax
------

.. code-block:: csharp

    public class WebHostService : ServiceBase, IComponent, IDisposable








.. dn:class:: Microsoft.AspNetCore.Hosting.WindowsServices.WebHostService
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Hosting.WindowsServices.WebHostService

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Hosting.WindowsServices.WebHostService
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Hosting.WindowsServices.WebHostService.WebHostService(Microsoft.AspNetCore.Hosting.IWebHost)
    
        
    
        
        Creates an instance of <code>WebHostService</code> which hosts the specified web application.
    
        
    
        
        :param host: The configured web host containing the web application to host in the Windows service.
        
        :type host: Microsoft.AspNetCore.Hosting.IWebHost
    
        
        .. code-block:: csharp
    
            public WebHostService(IWebHost host)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Hosting.WindowsServices.WebHostService
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Hosting.WindowsServices.WebHostService.OnStart(System.String[])
    
        
    
        
        :type args: System.String<System.String>[]
    
        
        .. code-block:: csharp
    
            protected override sealed void OnStart(string[] args)
    
    .. dn:method:: Microsoft.AspNetCore.Hosting.WindowsServices.WebHostService.OnStarted()
    
        
    
        
        Executes after ASP.NET Core starts.
    
        
    
        
        .. code-block:: csharp
    
            protected virtual void OnStarted()
    
    .. dn:method:: Microsoft.AspNetCore.Hosting.WindowsServices.WebHostService.OnStarting(System.String[])
    
        
    
        
        Executes before ASP.NET Core starts.
    
        
    
        
        :param args: The command line arguments passed to the service.
        
        :type args: System.String<System.String>[]
    
        
        .. code-block:: csharp
    
            protected virtual void OnStarting(string[] args)
    
    .. dn:method:: Microsoft.AspNetCore.Hosting.WindowsServices.WebHostService.OnStop()
    
        
    
        
        .. code-block:: csharp
    
            protected override sealed void OnStop()
    
    .. dn:method:: Microsoft.AspNetCore.Hosting.WindowsServices.WebHostService.OnStopped()
    
        
    
        
        Executes after ASP.NET Core shuts down.
    
        
    
        
        .. code-block:: csharp
    
            protected virtual void OnStopped()
    
    .. dn:method:: Microsoft.AspNetCore.Hosting.WindowsServices.WebHostService.OnStopping()
    
        
    
        
        Executes before ASP.NET Core shuts down.
    
        
    
        
        .. code-block:: csharp
    
            protected virtual void OnStopping()
    

