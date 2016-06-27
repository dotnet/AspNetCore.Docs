

IChangeToken Interface
======================






Propagates notifications that a change has occured.


Namespace
    :dn:ns:`Microsoft.Extensions.Primitives`
Assemblies
    * Microsoft.Extensions.Primitives

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IChangeToken








.. dn:interface:: Microsoft.Extensions.Primitives.IChangeToken
    :hidden:

.. dn:interface:: Microsoft.Extensions.Primitives.IChangeToken

Properties
----------

.. dn:interface:: Microsoft.Extensions.Primitives.IChangeToken
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Primitives.IChangeToken.ActiveChangeCallbacks
    
        
    
        
        Indicates if this token will pro-actively raise callbacks. Callbacks are still guaranteed to fire, eventually.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            bool ActiveChangeCallbacks { get; }
    
    .. dn:property:: Microsoft.Extensions.Primitives.IChangeToken.HasChanged
    
        
    
        
        Gets a value that indicates if a change has occured.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            bool HasChanged { get; }
    

Methods
-------

.. dn:interface:: Microsoft.Extensions.Primitives.IChangeToken
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Primitives.IChangeToken.RegisterChangeCallback(System.Action<System.Object>, System.Object)
    
        
    
        
        Registers for a callback that will be invoked when the entry has changed. 
        :dn:prop:`Microsoft.Extensions.Primitives.IChangeToken.HasChanged` MUST be set before the callback is invoked.
    
        
    
        
        :param callback: The :any:`System.Action\`1` to invoke.
        
        :type callback: System.Action<System.Action`1>{System.Object<System.Object>}
    
        
        :param state: State to be passed into the callback.
        
        :type state: System.Object
        :rtype: System.IDisposable
        :return: An :any:`System.IDisposable` that is used to unregister the callback.
    
        
        .. code-block:: csharp
    
            IDisposable RegisterChangeCallback(Action<object> callback, object state)
    

