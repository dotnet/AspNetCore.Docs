

KestrelServerOptionsConnectionLoggingExtensions Class
=====================================================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Hosting`
Assemblies
    * Microsoft.AspNetCore.Server.Kestrel

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Hosting.KestrelServerOptionsConnectionLoggingExtensions`








Syntax
------

.. code-block:: csharp

    public class KestrelServerOptionsConnectionLoggingExtensions








.. dn:class:: Microsoft.AspNetCore.Hosting.KestrelServerOptionsConnectionLoggingExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Hosting.KestrelServerOptionsConnectionLoggingExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Hosting.KestrelServerOptionsConnectionLoggingExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Hosting.KestrelServerOptionsConnectionLoggingExtensions.UseConnectionLogging(Microsoft.AspNetCore.Server.Kestrel.KestrelServerOptions)
    
        
    
        
        Emits verbose logs for bytes read from and written to the connection.
    
        
    
        
        :type options: Microsoft.AspNetCore.Server.Kestrel.KestrelServerOptions
        :rtype: Microsoft.AspNetCore.Server.Kestrel.KestrelServerOptions
        :return: 
            The Microsoft.AspNetCore.Server.KestrelServerOptions.
    
        
        .. code-block:: csharp
    
            public static KestrelServerOptions UseConnectionLogging(KestrelServerOptions options)
    
    .. dn:method:: Microsoft.AspNetCore.Hosting.KestrelServerOptionsConnectionLoggingExtensions.UseConnectionLogging(Microsoft.AspNetCore.Server.Kestrel.KestrelServerOptions, System.String)
    
        
    
        
        Emits verbose logs for bytes read from and written to the connection.
    
        
    
        
        :type options: Microsoft.AspNetCore.Server.Kestrel.KestrelServerOptions
    
        
        :type loggerName: System.String
        :rtype: Microsoft.AspNetCore.Server.Kestrel.KestrelServerOptions
        :return: 
            The Microsoft.AspNetCore.Server.KestrelServerOptions.
    
        
        .. code-block:: csharp
    
            public static KestrelServerOptions UseConnectionLogging(KestrelServerOptions options, string loggerName)
    

