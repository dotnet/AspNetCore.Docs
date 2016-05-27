

PrefixEnumerable Struct
=======================





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

    public struct PrefixEnumerable : IEnumerable<KeyValuePair<string, ModelStateEntry>>, IEnumerable








.. dn:structure:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.PrefixEnumerable
    :hidden:

.. dn:structure:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.PrefixEnumerable

Constructors
------------

.. dn:structure:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.PrefixEnumerable
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.PrefixEnumerable.PrefixEnumerable(Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary, System.String)
    
        
    
        
        :type dictionary: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary
    
        
        :type prefix: System.String
    
        
        .. code-block:: csharp
    
            public PrefixEnumerable(ModelStateDictionary dictionary, string prefix)
    

Methods
-------

.. dn:structure:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.PrefixEnumerable
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.PrefixEnumerable.GetEnumerator()
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.Enumerator
    
        
        .. code-block:: csharp
    
            public ModelStateDictionary.Enumerator GetEnumerator()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.PrefixEnumerable.System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<System.String, Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry>>.GetEnumerator()
    
        
        :rtype: System.Collections.Generic.IEnumerator<System.Collections.Generic.IEnumerator`1>{System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair`2>{System.String<System.String>, Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry<Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry>}}
    
        
        .. code-block:: csharp
    
            IEnumerator<KeyValuePair<string, ModelStateEntry>> IEnumerable<KeyValuePair<string, ModelStateEntry>>.GetEnumerator()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.PrefixEnumerable.System.Collections.IEnumerable.GetEnumerator()
    
        
        :rtype: System.Collections.IEnumerator
    
        
        .. code-block:: csharp
    
            IEnumerator IEnumerable.GetEnumerator()
    

