

PrefixEnumerator Struct
=======================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public struct PrefixEnumerator : IEnumerator<KeyValuePair<string, ModelStateEntry>>, IDisposable, IEnumerator





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Abstractions/ModelBinding/ModelStateDictionary.cs>`_





.. dn:structure:: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary.PrefixEnumerator

Constructors
------------

.. dn:structure:: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary.PrefixEnumerator
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary.PrefixEnumerator.PrefixEnumerator(Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary, System.String)
    
        
        
        
        :type dictionary: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary
        
        
        :type prefix: System.String
    
        
        .. code-block:: csharp
    
           public PrefixEnumerator(ModelStateDictionary dictionary, string prefix)
    

Methods
-------

.. dn:structure:: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary.PrefixEnumerator
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary.PrefixEnumerator.Dispose()
    
        
    
        
        .. code-block:: csharp
    
           public void Dispose()
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary.PrefixEnumerator.MoveNext()
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool MoveNext()
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary.PrefixEnumerator.Reset()
    
        
    
        
        .. code-block:: csharp
    
           public void Reset()
    

Properties
----------

.. dn:structure:: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary.PrefixEnumerator
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary.PrefixEnumerator.Current
    
        
        :rtype: System.Collections.Generic.KeyValuePair{System.String,Microsoft.AspNet.Mvc.ModelBinding.ModelStateEntry}
    
        
        .. code-block:: csharp
    
           public KeyValuePair<string, ModelStateEntry> Current { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary.PrefixEnumerator.System.Collections.IEnumerator.Current
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           object IEnumerator.Current { get; }
    

