

ProxyBase Class
===============



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyBase`








Syntax
------

.. code-block:: csharp

   public abstract class ProxyBase : IProxy





GitHub
------

`View on GitHub <https://github.com/aspnet/eventnotification/blob/master/src/Microsoft.Extensions.DiagnosticAdapter/Internal/ProxyBase.cs>`_





.. dn:class:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyBase

Constructors
------------

.. dn:class:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyBase
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyBase.ProxyBase(System.Type)
    
        
        
        
        :type wrappedType: System.Type
    
        
        .. code-block:: csharp
    
           protected ProxyBase(Type wrappedType)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyBase
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyBase.Upwrap<T>()
    
        
        :rtype: {T}
    
        
        .. code-block:: csharp
    
           public T Upwrap<T>()
    

Fields
------

.. dn:class:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyBase
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyBase.WrappedType
    
        
    
        
        .. code-block:: csharp
    
           public readonly Type WrappedType
    

Properties
----------

.. dn:class:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyBase
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyBase.UnderlyingInstanceAsObject
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           public abstract object UnderlyingInstanceAsObject { get; }
    

