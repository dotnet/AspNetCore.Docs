

ProxyBase<T> Class
==================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyBase`
* :dn:cls:`Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyBase\<T>`








Syntax
------

.. code-block:: csharp

   public class ProxyBase<T> : ProxyBase, IProxy where T : class





GitHub
------

`View on GitHub <https://github.com/aspnet/eventnotification/blob/master/src/Microsoft.Extensions.DiagnosticAdapter/Internal/ProxyBaseOfT.cs>`_





.. dn:class:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyBase<T>

Constructors
------------

.. dn:class:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyBase<T>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyBase<T>.ProxyBase(T)
    
        
        
        
        :type instance: {T}
    
        
        .. code-block:: csharp
    
           public ProxyBase(T instance)
    

Fields
------

.. dn:class:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyBase<T>
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyBase<T>.Instance
    
        
    
        
        .. code-block:: csharp
    
           public readonly T Instance
    

Properties
----------

.. dn:class:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyBase<T>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyBase<T>.UnderlyingInstance
    
        
        :rtype: {T}
    
        
        .. code-block:: csharp
    
           public T UnderlyingInstance { get; }
    
    .. dn:property:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyBase<T>.UnderlyingInstanceAsObject
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           public override object UnderlyingInstanceAsObject { get; }
    

