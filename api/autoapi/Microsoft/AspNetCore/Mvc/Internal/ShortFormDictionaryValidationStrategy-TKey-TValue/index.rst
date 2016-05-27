

ShortFormDictionaryValidationStrategy<TKey, TValue> Class
=========================================================






An implementation of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IValidationStrategy` for a dictionary bound with 'short form' style keys.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Internal.ShortFormDictionaryValidationStrategy\<TKey, TValue>`








Syntax
------

.. code-block:: csharp

    public class ShortFormDictionaryValidationStrategy<TKey, TValue> : IValidationStrategy








.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ShortFormDictionaryValidationStrategy`2
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ShortFormDictionaryValidationStrategy<TKey, TValue>

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ShortFormDictionaryValidationStrategy<TKey, TValue>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Internal.ShortFormDictionaryValidationStrategy<TKey, TValue>.KeyMappings
    
        
    
        
        Gets the mapping from model prefix key to dictionary key.
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair`2>{System.String<System.String>, TKey}}
    
        
        .. code-block:: csharp
    
            public IEnumerable<KeyValuePair<string, TKey>> KeyMappings
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ShortFormDictionaryValidationStrategy<TKey, TValue>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Internal.ShortFormDictionaryValidationStrategy<TKey, TValue>.ShortFormDictionaryValidationStrategy(System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<System.String, TKey>>, Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.Internal.ShortFormDictionaryValidationStrategy\`2`\.
    
        
    
        
        :param keyMappings: The mapping from model prefix key to dictionary key.
        
        :type keyMappings: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair`2>{System.String<System.String>, TKey}}
    
        
        :param valueMetadata: 
            The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata` associated with <em>TValue</em>.
        
        :type valueMetadata: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata
    
        
        .. code-block:: csharp
    
            public ShortFormDictionaryValidationStrategy(IEnumerable<KeyValuePair<string, TKey>> keyMappings, ModelMetadata valueMetadata)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ShortFormDictionaryValidationStrategy<TKey, TValue>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.ShortFormDictionaryValidationStrategy<TKey, TValue>.GetChildren(Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata, System.String, System.Object)
    
        
    
        
        :type metadata: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata
    
        
        :type key: System.String
    
        
        :type model: System.Object
        :rtype: System.Collections.Generic.IEnumerator<System.Collections.Generic.IEnumerator`1>{Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidationEntry<Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidationEntry>}
    
        
        .. code-block:: csharp
    
            public IEnumerator<ValidationEntry> GetChildren(ModelMetadata metadata, string key, object model)
    

