

ProxyTypeCacheResult Class
==========================





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
* :dn:cls:`Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyTypeCacheResult`








Syntax
------

.. code-block:: csharp

    public class ProxyTypeCacheResult








.. dn:class:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyTypeCacheResult
    :hidden:

.. dn:class:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyTypeCacheResult

Properties
----------

.. dn:class:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyTypeCacheResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyTypeCacheResult.Constructor
    
        
        :rtype: System.Reflection.ConstructorInfo
    
        
        .. code-block:: csharp
    
            public ConstructorInfo Constructor { get; }
    
    .. dn:property:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyTypeCacheResult.Error
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Error { get; }
    
    .. dn:property:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyTypeCacheResult.IsError
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsError { get; }
    
    .. dn:property:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyTypeCacheResult.Key
    
        
        :rtype: System.Tuple<System.Tuple`2>{System.Type<System.Type>, System.Type<System.Type>}
    
        
        .. code-block:: csharp
    
            public Tuple<Type, Type> Key { get; }
    
    .. dn:property:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyTypeCacheResult.Type
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
            public Type Type { get; }
    

Methods
-------

.. dn:class:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyTypeCacheResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyTypeCacheResult.FromError(System.Tuple<System.Type, System.Type>, System.String)
    
        
    
        
        :type key: System.Tuple<System.Tuple`2>{System.Type<System.Type>, System.Type<System.Type>}
    
        
        :type error: System.String
        :rtype: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyTypeCacheResult
    
        
        .. code-block:: csharp
    
            public static ProxyTypeCacheResult FromError(Tuple<Type, Type> key, string error)
    
    .. dn:method:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyTypeCacheResult.FromType(System.Tuple<System.Type, System.Type>, System.Type, System.Reflection.ConstructorInfo)
    
        
    
        
        :type key: System.Tuple<System.Tuple`2>{System.Type<System.Type>, System.Type<System.Type>}
    
        
        :type type: System.Type
    
        
        :type constructor: System.Reflection.ConstructorInfo
        :rtype: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyTypeCacheResult
    
        
        .. code-block:: csharp
    
            public static ProxyTypeCacheResult FromType(Tuple<Type, Type> key, Type type, ConstructorInfo constructor)
    

