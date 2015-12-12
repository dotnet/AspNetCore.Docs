

DistributedSessionStore Class
=============================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Session.DistributedSessionStore`








Syntax
------

.. code-block:: csharp

   public class DistributedSessionStore : ISessionStore





GitHub
------

`View on GitHub <https://github.com/aspnet/session/blob/master/src/Microsoft.AspNet.Session/DistributedSessionStore.cs>`_





.. dn:class:: Microsoft.AspNet.Session.DistributedSessionStore

Constructors
------------

.. dn:class:: Microsoft.AspNet.Session.DistributedSessionStore
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Session.DistributedSessionStore.DistributedSessionStore(Microsoft.Extensions.Caching.Distributed.IDistributedCache, Microsoft.Extensions.Logging.ILoggerFactory)
    
        
        
        
        :type cache: Microsoft.Extensions.Caching.Distributed.IDistributedCache
        
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        .. code-block:: csharp
    
           public DistributedSessionStore(IDistributedCache cache, ILoggerFactory loggerFactory)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Session.DistributedSessionStore
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Session.DistributedSessionStore.Connect()
    
        
    
        
        .. code-block:: csharp
    
           public void Connect()
    
    .. dn:method:: Microsoft.AspNet.Session.DistributedSessionStore.Create(System.String, System.TimeSpan, System.Func<System.Boolean>, System.Boolean)
    
        
        
        
        :type sessionId: System.String
        
        
        :type idleTimeout: System.TimeSpan
        
        
        :type tryEstablishSession: System.Func{System.Boolean}
        
        
        :type isNewSessionKey: System.Boolean
        :rtype: Microsoft.AspNet.Http.Features.ISession
    
        
        .. code-block:: csharp
    
           public ISession Create(string sessionId, TimeSpan idleTimeout, Func<bool> tryEstablishSession, bool isNewSessionKey)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Session.DistributedSessionStore
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Session.DistributedSessionStore.IsAvailable
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsAvailable { get; }
    

