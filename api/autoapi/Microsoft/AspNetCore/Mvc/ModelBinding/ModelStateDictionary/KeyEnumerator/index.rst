

KeyEnumerator Struct
====================





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

    public struct KeyEnumerator : IEnumerator<string>, IDisposable, IEnumerator








.. dn:structure:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.KeyEnumerator
    :hidden:

.. dn:structure:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.KeyEnumerator

Constructors
------------

.. dn:structure:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.KeyEnumerator
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.KeyEnumerator.KeyEnumerator(Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary, System.String)
    
        
    
        
        :type dictionary: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary
    
        
        :type prefix: System.String
    
        
        .. code-block:: csharp
    
            public KeyEnumerator(ModelStateDictionary dictionary, string prefix)
    

Properties
----------

.. dn:structure:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.KeyEnumerator
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.KeyEnumerator.Current
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Current { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.KeyEnumerator.System.Collections.IEnumerator.Current
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            object IEnumerator.Current { get; }
    

Methods
-------

.. dn:structure:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.KeyEnumerator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.KeyEnumerator.Dispose()
    
        
    
        
        .. code-block:: csharp
    
            public void Dispose()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.KeyEnumerator.MoveNext()
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool MoveNext()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.KeyEnumerator.Reset()
    
        
    
        
        .. code-block:: csharp
    
            public void Reset()
    

