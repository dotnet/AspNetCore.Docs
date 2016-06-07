

WebHostWindowsServiceExtensions Class
=====================================






    Extensions to :any:`Microsoft.AspNetCore.Hosting.IWebHost` for hosting inside a Windows service.


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
* :dn:cls:`Microsoft.AspNetCore.Hosting.WindowsServices.WebHostWindowsServiceExtensions`








Syntax
------

.. code-block:: csharp

    public class WebHostWindowsServiceExtensions








.. dn:class:: Microsoft.AspNetCore.Hosting.WindowsServices.WebHostWindowsServiceExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Hosting.WindowsServices.WebHostWindowsServiceExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Hosting.WindowsServices.WebHostWindowsServiceExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Hosting.WindowsServices.WebHostWindowsServiceExtensions.RunAsService(Microsoft.AspNetCore.Hosting.IWebHost)
    
        
    
        
            Runs the specified web application inside a Windows service and blocks until the service is stopped.
    
        
    
        
        :param host: An instance of the :any:`Microsoft.AspNetCore.Hosting.IWebHost` to host in the Windows service.
        
        :type host: Microsoft.AspNetCore.Hosting.IWebHost
    
        
        .. code-block:: csharp
    
            public static void RunAsService(IWebHost host)
    

