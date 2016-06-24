

Enumerator Struct
=================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Http.FormCollection`
Assemblies
    * Microsoft.AspNetCore.Http

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public struct Enumerator : IEnumerator<KeyValuePair<string, StringValues>>, IDisposable, IEnumerator








.. dn:structure:: Microsoft.AspNetCore.Http.FormCollection.Enumerator
    :hidden:

.. dn:structure:: Microsoft.AspNetCore.Http.FormCollection.Enumerator

Properties
----------

.. dn:structure:: Microsoft.AspNetCore.Http.FormCollection.Enumerator
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Http.FormCollection.Enumerator.Current
    
        
        :rtype: System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair`2>{System.String<System.String>, Microsoft.Extensions.Primitives.StringValues<Microsoft.Extensions.Primitives.StringValues>}
    
        
        .. code-block:: csharp
    
            public KeyValuePair<string, StringValues> Current { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.FormCollection.Enumerator.System.Collections.IEnumerator.Current
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            object IEnumerator.Current { get; }
    

Methods
-------

.. dn:structure:: Microsoft.AspNetCore.Http.FormCollection.Enumerator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Http.FormCollection.Enumerator.Dispose()
    
        
    
        
        .. code-block:: csharp
    
            public void Dispose()
    
    .. dn:method:: Microsoft.AspNetCore.Http.FormCollection.Enumerator.MoveNext()
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool MoveNext()
    
    .. dn:method:: Microsoft.AspNetCore.Http.FormCollection.Enumerator.System.Collections.IEnumerator.Reset()
    
        
    
        
        .. code-block:: csharp
    
            void IEnumerator.Reset()
    

