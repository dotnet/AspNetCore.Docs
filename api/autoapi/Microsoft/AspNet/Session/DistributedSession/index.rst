

DistributedSession Class
========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Session.DistributedSession`








Syntax
------

.. code-block:: csharp

   public class DistributedSession : ISession





GitHub
------

`View on GitHub <https://github.com/aspnet/session/blob/master/src/Microsoft.AspNet.Session/DistributedSession.cs>`_





.. dn:class:: Microsoft.AspNet.Session.DistributedSession

Constructors
------------

.. dn:class:: Microsoft.AspNet.Session.DistributedSession
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Session.DistributedSession.DistributedSession(Microsoft.Extensions.Caching.Distributed.IDistributedCache, System.String, System.TimeSpan, System.Func<System.Boolean>, Microsoft.Extensions.Logging.ILoggerFactory, System.Boolean)
    
        
        
        
        :type cache: Microsoft.Extensions.Caching.Distributed.IDistributedCache
        
        
        :type sessionId: System.String
        
        
        :type idleTimeout: System.TimeSpan
        
        
        :type tryEstablishSession: System.Func{System.Boolean}
        
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
        
        
        :type isNewSessionKey: System.Boolean
    
        
        .. code-block:: csharp
    
           public DistributedSession(IDistributedCache cache, string sessionId, TimeSpan idleTimeout, Func<bool> tryEstablishSession, ILoggerFactory loggerFactory, bool isNewSessionKey)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Session.DistributedSession
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Session.DistributedSession.Clear()
    
        
    
        
        .. code-block:: csharp
    
           public void Clear()
    
    .. dn:method:: Microsoft.AspNet.Session.DistributedSession.CommitAsync()
    
        
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public Task CommitAsync()
    
    .. dn:method:: Microsoft.AspNet.Session.DistributedSession.LoadAsync()
    
        
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public Task LoadAsync()
    
    .. dn:method:: Microsoft.AspNet.Session.DistributedSession.Remove(System.String)
    
        
        
        
        :type key: System.String
    
        
        .. code-block:: csharp
    
           public void Remove(string key)
    
    .. dn:method:: Microsoft.AspNet.Session.DistributedSession.Set(System.String, System.Byte[])
    
        
        
        
        :type key: System.String
        
        
        :type value: System.Byte[]
    
        
        .. code-block:: csharp
    
           public void Set(string key, byte[] value)
    
    .. dn:method:: Microsoft.AspNet.Session.DistributedSession.TryGetValue(System.String, out System.Byte[])
    
        
        
        
        :type key: System.String
        
        
        :type value: System.Byte[]
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool TryGetValue(string key, out byte[] value)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Session.DistributedSession
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Session.DistributedSession.Keys
    
        
        :rtype: System.Collections.Generic.IEnumerable{System.String}
    
        
        .. code-block:: csharp
    
           public IEnumerable<string> Keys { get; }
    

