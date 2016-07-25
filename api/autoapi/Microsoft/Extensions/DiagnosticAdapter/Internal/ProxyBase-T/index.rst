

ProxyBase<T> Class
==================





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
* :dn:cls:`Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyBase\<T>`








Syntax
------

.. code-block:: csharp

    public class ProxyBase<T> : ProxyBase, IProxy where T : class








.. dn:class:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyBase`1
    :hidden:

.. dn:class:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyBase<T>

Constructors
------------

.. dn:class:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyBase<T>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyBase<T>.ProxyBase(T)
    
        
    
        
        :type instance: T
    
        
        .. code-block:: csharp
    
            public ProxyBase(T instance)
    

Properties
----------

.. dn:class:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyBase<T>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyBase<T>.UnderlyingInstance
    
        
        :rtype: T
    
        
        .. code-block:: csharp
    
            public T UnderlyingInstance { get; }
    
    .. dn:property:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyBase<T>.UnderlyingInstanceAsObject
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            public override object UnderlyingInstanceAsObject { get; }
    

Fields
------

.. dn:class:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyBase<T>
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyBase<T>.Instance
    
        
        :rtype: T
    
        
        .. code-block:: csharp
    
            public readonly T Instance
    

