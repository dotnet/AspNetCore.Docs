

DistributedSession Class
========================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Session`
Assemblies
    * Microsoft.AspNetCore.Session

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Session.DistributedSession`








Syntax
------

.. code-block:: csharp

    public class DistributedSession : ISession








.. dn:class:: Microsoft.AspNetCore.Session.DistributedSession
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Session.DistributedSession

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Session.DistributedSession
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Session.DistributedSession.DistributedSession(Microsoft.Extensions.Caching.Distributed.IDistributedCache, System.String, System.TimeSpan, System.Func<System.Boolean>, Microsoft.Extensions.Logging.ILoggerFactory, System.Boolean)
    
        
    
        
        :type cache: Microsoft.Extensions.Caching.Distributed.IDistributedCache
    
        
        :type sessionKey: System.String
    
        
        :type idleTimeout: System.TimeSpan
    
        
        :type tryEstablishSession: System.Func<System.Func`1>{System.Boolean<System.Boolean>}
    
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        :type isNewSessionKey: System.Boolean
    
        
        .. code-block:: csharp
    
            public DistributedSession(IDistributedCache cache, string sessionKey, TimeSpan idleTimeout, Func<bool> tryEstablishSession, ILoggerFactory loggerFactory, bool isNewSessionKey)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Session.DistributedSession
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Session.DistributedSession.Clear()
    
        
    
        
        .. code-block:: csharp
    
            public void Clear()
    
    .. dn:method:: Microsoft.AspNetCore.Session.DistributedSession.CommitAsync()
    
        
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task CommitAsync()
    
    .. dn:method:: Microsoft.AspNetCore.Session.DistributedSession.LoadAsync()
    
        
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task LoadAsync()
    
    .. dn:method:: Microsoft.AspNetCore.Session.DistributedSession.Remove(System.String)
    
        
    
        
        :type key: System.String
    
        
        .. code-block:: csharp
    
            public void Remove(string key)
    
    .. dn:method:: Microsoft.AspNetCore.Session.DistributedSession.Set(System.String, System.Byte[])
    
        
    
        
        :type key: System.String
    
        
        :type value: System.Byte<System.Byte>[]
    
        
        .. code-block:: csharp
    
            public void Set(string key, byte[] value)
    
    .. dn:method:: Microsoft.AspNetCore.Session.DistributedSession.TryGetValue(System.String, out System.Byte[])
    
        
    
        
        :type key: System.String
    
        
        :type value: System.Byte<System.Byte>[]
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool TryGetValue(string key, out byte[] value)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Session.DistributedSession
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Session.DistributedSession.Id
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Id { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Session.DistributedSession.IsAvailable
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsAvailable { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Session.DistributedSession.Keys
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public IEnumerable<string> Keys { get; }
    

