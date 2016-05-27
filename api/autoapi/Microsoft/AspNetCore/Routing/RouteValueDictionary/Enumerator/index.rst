

Enumerator Struct
=================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Routing.RouteValueDictionary`
Assemblies
    * Microsoft.AspNetCore.Routing.Abstractions

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public struct Enumerator : IEnumerator<KeyValuePair<string, object>>, IDisposable, IEnumerator








.. dn:structure:: Microsoft.AspNetCore.Routing.RouteValueDictionary.Enumerator
    :hidden:

.. dn:structure:: Microsoft.AspNetCore.Routing.RouteValueDictionary.Enumerator

Properties
----------

.. dn:structure:: Microsoft.AspNetCore.Routing.RouteValueDictionary.Enumerator
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Routing.RouteValueDictionary.Enumerator.Current
    
        
        :rtype: System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair`2>{System.String<System.String>, System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public KeyValuePair<string, object> Current
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.RouteValueDictionary.Enumerator.System.Collections.IEnumerator.Current
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            object IEnumerator.Current
            {
                get;
            }
    

Constructors
------------

.. dn:structure:: Microsoft.AspNetCore.Routing.RouteValueDictionary.Enumerator
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Routing.RouteValueDictionary.Enumerator.Enumerator(Microsoft.AspNetCore.Routing.RouteValueDictionary)
    
        
    
        
        :type dictionary: Microsoft.AspNetCore.Routing.RouteValueDictionary
    
        
        .. code-block:: csharp
    
            public Enumerator(RouteValueDictionary dictionary)
    

Methods
-------

.. dn:structure:: Microsoft.AspNetCore.Routing.RouteValueDictionary.Enumerator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Routing.RouteValueDictionary.Enumerator.Dispose()
    
        
    
        
        .. code-block:: csharp
    
            public void Dispose()
    
    .. dn:method:: Microsoft.AspNetCore.Routing.RouteValueDictionary.Enumerator.MoveNext()
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool MoveNext()
    
    .. dn:method:: Microsoft.AspNetCore.Routing.RouteValueDictionary.Enumerator.Reset()
    
        
    
        
        .. code-block:: csharp
    
            public void Reset()
    

