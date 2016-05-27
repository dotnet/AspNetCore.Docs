

Enumerator Struct
=================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary`
Assemblies
    * Microsoft.AspNetCore.Mvc.Abstractions

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public struct Enumerator : IEnumerator<KeyValuePair<string, ModelStateEntry>>, IDisposable, IEnumerator








.. dn:structure:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.Enumerator
    :hidden:

.. dn:structure:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.Enumerator

Properties
----------

.. dn:structure:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.Enumerator
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.Enumerator.Current
    
        
        :rtype: System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair`2>{System.String<System.String>, Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry<Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry>}
    
        
        .. code-block:: csharp
    
            public KeyValuePair<string, ModelStateEntry> Current
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.Enumerator.System.Collections.IEnumerator.Current
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            object IEnumerator.Current
            {
                get;
            }
    

Constructors
------------

.. dn:structure:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.Enumerator
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.Enumerator.Enumerator(Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary, System.String)
    
        
    
        
        :type dictionary: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary
    
        
        :type prefix: System.String
    
        
        .. code-block:: csharp
    
            public Enumerator(ModelStateDictionary dictionary, string prefix)
    

Methods
-------

.. dn:structure:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.Enumerator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.Enumerator.Dispose()
    
        
    
        
        .. code-block:: csharp
    
            public void Dispose()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.Enumerator.MoveNext()
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool MoveNext()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.Enumerator.Reset()
    
        
    
        
        .. code-block:: csharp
    
            public void Reset()
    

