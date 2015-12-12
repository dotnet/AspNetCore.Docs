

ISession Interface
==================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface ISession





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/httpabstractions/src/Microsoft.AspNet.Http.Features/ISession.cs>`_





.. dn:interface:: Microsoft.AspNet.Http.Features.ISession

Methods
-------

.. dn:interface:: Microsoft.AspNet.Http.Features.ISession
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Http.Features.ISession.Clear()
    
        
    
        
        .. code-block:: csharp
    
           void Clear()
    
    .. dn:method:: Microsoft.AspNet.Http.Features.ISession.CommitAsync()
    
        
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           Task CommitAsync()
    
    .. dn:method:: Microsoft.AspNet.Http.Features.ISession.LoadAsync()
    
        
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           Task LoadAsync()
    
    .. dn:method:: Microsoft.AspNet.Http.Features.ISession.Remove(System.String)
    
        
        
        
        :type key: System.String
    
        
        .. code-block:: csharp
    
           void Remove(string key)
    
    .. dn:method:: Microsoft.AspNet.Http.Features.ISession.Set(System.String, System.Byte[])
    
        
        
        
        :type key: System.String
        
        
        :type value: System.Byte[]
    
        
        .. code-block:: csharp
    
           void Set(string key, byte[] value)
    
    .. dn:method:: Microsoft.AspNet.Http.Features.ISession.TryGetValue(System.String, out System.Byte[])
    
        
        
        
        :type key: System.String
        
        
        :type value: System.Byte[]
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           bool TryGetValue(string key, out byte[] value)
    

Properties
----------

.. dn:interface:: Microsoft.AspNet.Http.Features.ISession
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Http.Features.ISession.Keys
    
        
        :rtype: System.Collections.Generic.IEnumerable{System.String}
    
        
        .. code-block:: csharp
    
           IEnumerable<string> Keys { get; }
    

