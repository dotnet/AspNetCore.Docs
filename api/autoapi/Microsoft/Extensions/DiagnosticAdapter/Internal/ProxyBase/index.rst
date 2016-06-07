

ProxyBase Class
===============





Namespace
    :dn:ns:`Microsoft.Extensions.DiagnosticAdapter.Internal`
Assemblies
    * Microsoft.Extensions.DiagnosticAdapter

----

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








.. dn:class:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyBase
    :hidden:

.. dn:class:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyBase

Properties
----------

.. dn:class:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyBase
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyBase.UnderlyingInstanceAsObject
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            public abstract object UnderlyingInstanceAsObject
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyBase
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyBase.ProxyBase(System.Type)
    
        
    
        
        :type wrappedType: System.Type
    
        
        .. code-block:: csharp
    
            protected ProxyBase(Type wrappedType)
    

Fields
------

.. dn:class:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyBase
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyBase.WrappedType
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
            public readonly Type WrappedType
    

Methods
-------

.. dn:class:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyBase
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyBase.Upwrap<T>()
    
        
        :rtype: T
    
        
        .. code-block:: csharp
    
            public T Upwrap<T>()
    

