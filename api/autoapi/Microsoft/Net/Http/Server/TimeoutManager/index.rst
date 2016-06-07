

TimeoutManager Class
====================






Exposes the Http.Sys timeout configurations.  These may also be configured in the registry.


Namespace
    :dn:ns:`Microsoft.Net.Http.Server`
Assemblies
    * Microsoft.Net.Http.Server

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Net.Http.Server.TimeoutManager`








Syntax
------

.. code-block:: csharp

    public sealed class TimeoutManager








.. dn:class:: Microsoft.Net.Http.Server.TimeoutManager
    :hidden:

.. dn:class:: Microsoft.Net.Http.Server.TimeoutManager

Properties
----------

.. dn:class:: Microsoft.Net.Http.Server.TimeoutManager
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Net.Http.Server.TimeoutManager.DrainEntityBody
    
        
    
        
        The time, in seconds, allowed for the HTTP Server API to drain the entity body on a Keep-Alive connection. 
        The default timer is 2 minutes.
        
        On a Keep-Alive connection, after the application has sent a response for a request and before the request 
        entity body has completely arrived, the HTTP Server API starts draining the remainder of the entity body to 
        reach another potentially pipelined request from the client. If the time to drain the remaining entity body 
        exceeds the allowed period the connection is timed out.
        
        Use TimeSpan.Zero to indicate that system defaults should be used.
    
        
        :rtype: System.TimeSpan
    
        
        .. code-block:: csharp
    
            public TimeSpan DrainEntityBody
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.Net.Http.Server.TimeoutManager.EntityBody
    
        
    
        
        The time, in seconds, allowed for the request entity body to arrive.  The default timer is 2 minutes.
        
        The HTTP Server API turns on this timer when the request has an entity body. The timer expiration is 
        initially set to the configured value. When the HTTP Server API receives additional data indications on the 
        request, it resets the timer to give the connection another interval.
        
        Use TimeSpan.Zero to indicate that system defaults should be used.
    
        
        :rtype: System.TimeSpan
    
        
        .. code-block:: csharp
    
            public TimeSpan EntityBody
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.Net.Http.Server.TimeoutManager.HeaderWait
    
        
    
        
        The time, in seconds, allowed for the HTTP Server API to parse the request header.  The default timer is 
        2 minutes.
         
        This timeout is only enforced after the first request on the connection is routed to the application.
        
        Use TimeSpan.Zero to indicate that system defaults should be used.
    
        
        :rtype: System.TimeSpan
    
        
        .. code-block:: csharp
    
            public TimeSpan HeaderWait
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.Net.Http.Server.TimeoutManager.IdleConnection
    
        
    
        
        The time, in seconds, allowed for an idle connection.  The default timer is 2 minutes.
        
        This timeout is only enforced after the first request on the connection is routed to the application.
        
        Use TimeSpan.Zero to indicate that system defaults should be used.
    
        
        :rtype: System.TimeSpan
    
        
        .. code-block:: csharp
    
            public TimeSpan IdleConnection
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.Net.Http.Server.TimeoutManager.MinSendBytesPerSecond
    
        
    
        
        The minimum send rate, in bytes-per-second, for the response. The default response send rate is 150 
        bytes-per-second.
        
        To disable this timer set it to UInt32.MaxValue
    
        
        :rtype: System.Int64
    
        
        .. code-block:: csharp
    
            public long MinSendBytesPerSecond
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.Net.Http.Server.TimeoutManager.RequestQueue
    
        
    
        
        The time, in seconds, allowed for the request to remain in the request queue before the application picks 
        it up.  The default timer is 2 minutes.
        
        Use TimeSpan.Zero to indicate that system defaults should be used.
    
        
        :rtype: System.TimeSpan
    
        
        .. code-block:: csharp
    
            public TimeSpan RequestQueue
            {
                get;
                set;
            }
    

