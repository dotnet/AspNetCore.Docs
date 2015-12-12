

PrefixEnumerable Struct
=======================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public struct PrefixEnumerable : IEnumerable<KeyValuePair<string, ModelStateEntry>>, IEnumerable





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Abstractions/ModelBinding/ModelStateDictionary.cs>`_





.. dn:structure:: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary.PrefixEnumerable

Constructors
------------

.. dn:structure:: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary.PrefixEnumerable
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary.PrefixEnumerable.PrefixEnumerable(Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary, System.String)
    
        
        
        
        :type dictionary: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary
        
        
        :type prefix: System.String
    
        
        .. code-block:: csharp
    
           public PrefixEnumerable(ModelStateDictionary dictionary, string prefix)
    

Methods
-------

.. dn:structure:: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary.PrefixEnumerable
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary.PrefixEnumerable.GetEnumerator()
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary.PrefixEnumerator
    
        
        .. code-block:: csharp
    
           public ModelStateDictionary.PrefixEnumerator GetEnumerator()
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary.PrefixEnumerable.System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<System.String, Microsoft.AspNet.Mvc.ModelBinding.ModelStateEntry>>.GetEnumerator()
    
        
        :rtype: System.Collections.Generic.IEnumerator{System.Collections.Generic.KeyValuePair{System.String,Microsoft.AspNet.Mvc.ModelBinding.ModelStateEntry}}
    
        
        .. code-block:: csharp
    
           IEnumerator<KeyValuePair<string, ModelStateEntry>> IEnumerable<KeyValuePair<string, ModelStateEntry>>.GetEnumerator()
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary.PrefixEnumerable.System.Collections.IEnumerable.GetEnumerator()
    
        
        :rtype: System.Collections.IEnumerator
    
        
        .. code-block:: csharp
    
           IEnumerator IEnumerable.GetEnumerator()
    

