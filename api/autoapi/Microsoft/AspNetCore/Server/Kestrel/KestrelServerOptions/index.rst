

KestrelServerOptions Class
==========================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Server.Kestrel`
Assemblies
    * Microsoft.AspNetCore.Server.Kestrel

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.KestrelServerOptions`








Syntax
------

.. code-block:: csharp

    public class KestrelServerOptions








.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.KestrelServerOptions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.KestrelServerOptions

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.KestrelServerOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.KestrelServerOptions.ApplicationServices
    
        
        :rtype: System.IServiceProvider
    
        
        .. code-block:: csharp
    
            public IServiceProvider ApplicationServices
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.KestrelServerOptions.ConnectionFilter
    
        
        :rtype: Microsoft.AspNetCore.Server.Kestrel.Filter.IConnectionFilter
    
        
        .. code-block:: csharp
    
            public IConnectionFilter ConnectionFilter
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.KestrelServerOptions.MaxPooledHeaders
    
        
    
        
        Gets or sets value that instructs :any:`Microsoft.AspNetCore.Server.Kestrel.KestrelServer` whether it is safe to 
        pool the Request and Response headers
        for another request after the Response's OnCompleted callback has fired. 
        When this values is greater than zero, it is not safe to retain references to feature components after this event has fired.
        Value is zero by default.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int MaxPooledHeaders
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.KestrelServerOptions.MaxPooledStreams
    
        
    
        
        Gets or sets value that instructs :any:`Microsoft.AspNetCore.Server.Kestrel.KestrelServer` whether it is safe to 
        pool the Request and Response :any:`System.IO.Stream` objects
        for another request after the Response's OnCompleted callback has fired. 
        When this values is greater than zero, it is not safe to retain references to feature components after this event has fired.
        Value is zero by default.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int MaxPooledStreams
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.KestrelServerOptions.NoDelay
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool NoDelay
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.KestrelServerOptions.ShutdownTimeout
    
        
    
        
        The amount of time after the server begins shutting down before connections will be forcefully closed.
        By default, Kestrel will wait 5 seconds for any ongoing requests to complete before terminating
        the connection.
    
        
        :rtype: System.TimeSpan
    
        
        .. code-block:: csharp
    
            public TimeSpan ShutdownTimeout
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.KestrelServerOptions.ThreadCount
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int ThreadCount
            {
                get;
                set;
            }
    

