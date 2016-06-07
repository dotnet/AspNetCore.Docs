

ValueEnumerator Struct
======================





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

    public struct ValueEnumerator : IEnumerator<ModelStateEntry>, IDisposable, IEnumerator








.. dn:structure:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.ValueEnumerator
    :hidden:

.. dn:structure:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.ValueEnumerator

Properties
----------

.. dn:structure:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.ValueEnumerator
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.ValueEnumerator.Current
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry
    
        
        .. code-block:: csharp
    
            public ModelStateEntry Current
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.ValueEnumerator.System.Collections.IEnumerator.Current
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            object IEnumerator.Current
            {
                get;
            }
    

Constructors
------------

.. dn:structure:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.ValueEnumerator
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.ValueEnumerator.ValueEnumerator(Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary, System.String)
    
        
    
        
        :type dictionary: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary
    
        
        :type prefix: System.String
    
        
        .. code-block:: csharp
    
            public ValueEnumerator(ModelStateDictionary dictionary, string prefix)
    

Methods
-------

.. dn:structure:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.ValueEnumerator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.ValueEnumerator.Dispose()
    
        
    
        
        .. code-block:: csharp
    
            public void Dispose()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.ValueEnumerator.MoveNext()
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool MoveNext()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.ValueEnumerator.Reset()
    
        
    
        
        .. code-block:: csharp
    
            public void Reset()
    

