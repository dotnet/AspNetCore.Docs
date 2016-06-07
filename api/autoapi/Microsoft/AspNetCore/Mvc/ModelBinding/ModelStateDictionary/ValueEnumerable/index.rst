

ValueEnumerable Struct
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

    public struct ValueEnumerable : IEnumerable<ModelStateEntry>, IEnumerable








.. dn:structure:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.ValueEnumerable
    :hidden:

.. dn:structure:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.ValueEnumerable

Constructors
------------

.. dn:structure:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.ValueEnumerable
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.ValueEnumerable.ValueEnumerable(Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary)
    
        
    
        
        :type dictionary: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary
    
        
        .. code-block:: csharp
    
            public ValueEnumerable(ModelStateDictionary dictionary)
    

Methods
-------

.. dn:structure:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.ValueEnumerable
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.ValueEnumerable.GetEnumerator()
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.ValueEnumerator
    
        
        .. code-block:: csharp
    
            public ModelStateDictionary.ValueEnumerator GetEnumerator()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.ValueEnumerable.System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry>.GetEnumerator()
    
        
        :rtype: System.Collections.Generic.IEnumerator<System.Collections.Generic.IEnumerator`1>{Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry<Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry>}
    
        
        .. code-block:: csharp
    
            IEnumerator<ModelStateEntry> IEnumerable<ModelStateEntry>.GetEnumerator()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.ValueEnumerable.System.Collections.IEnumerable.GetEnumerator()
    
        
        :rtype: System.Collections.IEnumerator
    
        
        .. code-block:: csharp
    
            IEnumerator IEnumerable.GetEnumerator()
    

