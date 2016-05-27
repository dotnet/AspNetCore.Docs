

Enumerator Struct
=================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Http.Internal.RequestCookieCollection`
Assemblies
    * Microsoft.AspNetCore.Http

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public struct Enumerator : IEnumerator<KeyValuePair<string, string>>, IDisposable, IEnumerator








.. dn:structure:: Microsoft.AspNetCore.Http.Internal.RequestCookieCollection.Enumerator
    :hidden:

.. dn:structure:: Microsoft.AspNetCore.Http.Internal.RequestCookieCollection.Enumerator

Properties
----------

.. dn:structure:: Microsoft.AspNetCore.Http.Internal.RequestCookieCollection.Enumerator
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Http.Internal.RequestCookieCollection.Enumerator.Current
    
        
        :rtype: System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair`2>{System.String<System.String>, System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public KeyValuePair<string, string> Current
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Internal.RequestCookieCollection.Enumerator.System.Collections.IEnumerator.Current
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            object IEnumerator.Current
            {
                get;
            }
    

Methods
-------

.. dn:structure:: Microsoft.AspNetCore.Http.Internal.RequestCookieCollection.Enumerator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Http.Internal.RequestCookieCollection.Enumerator.Dispose()
    
        
    
        
        .. code-block:: csharp
    
            public void Dispose()
    
    .. dn:method:: Microsoft.AspNetCore.Http.Internal.RequestCookieCollection.Enumerator.MoveNext()
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool MoveNext()
    
    .. dn:method:: Microsoft.AspNetCore.Http.Internal.RequestCookieCollection.Enumerator.Reset()
    
        
    
        
        .. code-block:: csharp
    
            public void Reset()
    

