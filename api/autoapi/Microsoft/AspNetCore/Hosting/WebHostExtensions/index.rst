

WebHostExtensions Class
=======================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Hosting`
Assemblies
    * Microsoft.AspNetCore.Hosting

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Hosting.WebHostExtensions`








Syntax
------

.. code-block:: csharp

    public class WebHostExtensions








.. dn:class:: Microsoft.AspNetCore.Hosting.WebHostExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Hosting.WebHostExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Hosting.WebHostExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Hosting.WebHostExtensions.Run(Microsoft.AspNetCore.Hosting.IWebHost)
    
        
    
        
        Runs a web application and block the calling thread until host shutdown.
    
        
    
        
        :param host: The :any:`Microsoft.AspNetCore.Hosting.IWebHost` to run.
        
        :type host: Microsoft.AspNetCore.Hosting.IWebHost
    
        
        .. code-block:: csharp
    
            public static void Run(IWebHost host)
    
    .. dn:method:: Microsoft.AspNetCore.Hosting.WebHostExtensions.Run(Microsoft.AspNetCore.Hosting.IWebHost, System.Threading.CancellationToken)
    
        
    
        
        Runs a web application and block the calling thread until token is triggered or shutdown is triggered.
    
        
    
        
        :param host: The :any:`Microsoft.AspNetCore.Hosting.IWebHost` to run.
        
        :type host: Microsoft.AspNetCore.Hosting.IWebHost
    
        
        :param token: The token to trigger shutdown.
        
        :type token: System.Threading.CancellationToken
    
        
        .. code-block:: csharp
    
            public static void Run(IWebHost host, CancellationToken token)
    

