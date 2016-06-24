

ISession Interface
==================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Http`
Assemblies
    * Microsoft.AspNetCore.Http.Features

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface ISession








.. dn:interface:: Microsoft.AspNetCore.Http.ISession
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Http.ISession

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Http.ISession
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Http.ISession.Clear()
    
        
    
        
        Remove all entries from the current session, if any.
        The session cookie is not removed.
    
        
    
        
        .. code-block:: csharp
    
            void Clear()
    
    .. dn:method:: Microsoft.AspNetCore.Http.ISession.CommitAsync()
    
        
    
        
        Store the session in the data store. This may throw if the data store is unavailable.
    
        
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            Task CommitAsync()
    
    .. dn:method:: Microsoft.AspNetCore.Http.ISession.LoadAsync()
    
        
    
        
        Load the session from the data store. This may throw if the data store is unavailable.
    
        
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            Task LoadAsync()
    
    .. dn:method:: Microsoft.AspNetCore.Http.ISession.Remove(System.String)
    
        
    
        
        Remove the given key from the session if present.
    
        
    
        
        :type key: System.String
    
        
        .. code-block:: csharp
    
            void Remove(string key)
    
    .. dn:method:: Microsoft.AspNetCore.Http.ISession.Set(System.String, System.Byte[])
    
        
    
        
        Set the given key and value in the current session. This will throw if the session
        was not established prior to sending the response.
    
        
    
        
        :type key: System.String
    
        
        :type value: System.Byte<System.Byte>[]
    
        
        .. code-block:: csharp
    
            void Set(string key, byte[] value)
    
    .. dn:method:: Microsoft.AspNetCore.Http.ISession.TryGetValue(System.String, out System.Byte[])
    
        
    
        
        Retrieve the value of the given key, if present.
    
        
    
        
        :type key: System.String
    
        
        :type value: System.Byte<System.Byte>[]
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            bool TryGetValue(string key, out byte[] value)
    

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.Http.ISession
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Http.ISession.Id
    
        
    
        
        A unique identifier for the current session. This is not the same as the session cookie
        since the cookie lifetime may not be the same as the session entry lifetime in the data store.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            string Id { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.ISession.IsAvailable
    
        
    
        
        Indicate whether the current session has loaded.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            bool IsAvailable { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.ISession.Keys
    
        
    
        
        Enumerates all the keys, if any.
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            IEnumerable<string> Keys { get; }
    

