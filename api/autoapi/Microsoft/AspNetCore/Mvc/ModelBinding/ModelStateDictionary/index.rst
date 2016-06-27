

ModelStateDictionary Class
==========================






Represents the state of an attempt to bind values from an HTTP Request to an action method, which includes
validation information.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ModelBinding`
Assemblies
    * Microsoft.AspNetCore.Mvc.Abstractions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary`








Syntax
------

.. code-block:: csharp

    public class ModelStateDictionary : IReadOnlyDictionary<string, ModelStateEntry>, IReadOnlyCollection<KeyValuePair<string, ModelStateEntry>>, IEnumerable<KeyValuePair<string, ModelStateEntry>>, IEnumerable








.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.ModelStateDictionary()
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary` class.
    
        
    
        
        .. code-block:: csharp
    
            public ModelStateDictionary()
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.ModelStateDictionary(Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary)
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary` class by using values that are copied
        from the specified <em>dictionary</em>.
    
        
    
        
        :param dictionary: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary` to copy values from.
        
        :type dictionary: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary
    
        
        .. code-block:: csharp
    
            public ModelStateDictionary(ModelStateDictionary dictionary)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.ModelStateDictionary(System.Int32)
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary` class.
    
        
    
        
        :type maxAllowedErrors: System.Int32
    
        
        .. code-block:: csharp
    
            public ModelStateDictionary(int maxAllowedErrors)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.AddModelError(System.String, System.Exception, Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata)
    
        
    
        
        Adds the specified <em>exception</em> to the :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry.Errors` instance
        that is associated with the specified <em>key</em>.
    
        
    
        
        :param key: The key of the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry` to add errors to.
        
        :type key: System.String
    
        
        :param exception: The :any:`System.Exception` to add.
        
        :type exception: System.Exception
    
        
        :param metadata: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata` associated with the model.
        
        :type metadata: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata
    
        
        .. code-block:: csharp
    
            public void AddModelError(string key, Exception exception, ModelMetadata metadata)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.AddModelError(System.String, System.String)
    
        
    
        
        Adds the specified <em>errorMessage</em> to the :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry.Errors` instance
        that is associated with the specified <em>key</em>.
    
        
    
        
        :param key: The key of the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry` to add errors to.
        
        :type key: System.String
    
        
        :param errorMessage: The error message to add.
        
        :type errorMessage: System.String
    
        
        .. code-block:: csharp
    
            public void AddModelError(string key, string errorMessage)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.Clear()
    
        
    
        
        Removes all keys and values from ths instance of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary`\.
    
        
    
        
        .. code-block:: csharp
    
            public void Clear()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.ClearValidationState(System.String)
    
        
    
        
        Clears :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary` entries that match the key that is passed as parameter.
    
        
    
        
        :param key: The key of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary` to clear.
        
        :type key: System.String
    
        
        .. code-block:: csharp
    
            public void ClearValidationState(string key)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.ContainsKey(System.String)
    
        
    
        
        :type key: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool ContainsKey(string key)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.FindKeysWithPrefix(System.String)
    
        
    
        
        :type prefix: System.String
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.PrefixEnumerable
    
        
        .. code-block:: csharp
    
            public ModelStateDictionary.PrefixEnumerable FindKeysWithPrefix(string prefix)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.GetEnumerator()
    
        
    
        
        Returns an enumerator that iterates through this instance of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.Enumerator
        :return: An :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.Enumerator`\.
    
        
        .. code-block:: csharp
    
            public ModelStateDictionary.Enumerator GetEnumerator()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.GetFieldValidationState(System.String)
    
        
    
        
        Returns the aggregate :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState` for items starting with the
        specified <em>key</em>.
    
        
    
        
        :param key: The key to look up model state errors for.
        
        :type key: System.String
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState
        :return: Returns :dn:field:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Unvalidated` if no entries are found for the specified
            key, :dn:field:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid` if at least one instance is found with one or more model
            state errors; :dn:field:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Valid` otherwise.
    
        
        .. code-block:: csharp
    
            public ModelValidationState GetFieldValidationState(string key)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.GetValidationState(System.String)
    
        
    
        
        Returns :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState` for the <em>key</em>.
    
        
    
        
        :param key: The key to look up model state errors for.
        
        :type key: System.String
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState
        :return: Returns :dn:field:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Unvalidated` if no entry is found for the specified
            key, :dn:field:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid` if an instance is found with one or more model
            state errors; :dn:field:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Valid` otherwise.
    
        
        .. code-block:: csharp
    
            public ModelValidationState GetValidationState(string key)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.MarkFieldSkipped(System.String)
    
        
    
        
        Marks the :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry.ValidationState` for the entry with the specified <em>key</em>
        as :dn:field:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Skipped`\.
    
        
    
        
        :param key: The key of the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry` to mark as skipped.
        
        :type key: System.String
    
        
        .. code-block:: csharp
    
            public void MarkFieldSkipped(string key)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.MarkFieldValid(System.String)
    
        
    
        
        Marks the :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry.ValidationState` for the entry with the specified
        <em>key</em> as :dn:field:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Valid`\.
    
        
    
        
        :param key: The key of the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry` to mark as valid.
        
        :type key: System.String
    
        
        .. code-block:: csharp
    
            public void MarkFieldValid(string key)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.Merge(Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary)
    
        
    
        
        Copies the values from the specified <em>dictionary</em> into this instance, overwriting
        existing values if keys are the same.
    
        
    
        
        :param dictionary: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary` to copy values from.
        
        :type dictionary: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary
    
        
        .. code-block:: csharp
    
            public void Merge(ModelStateDictionary dictionary)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.Remove(System.String)
    
        
    
        
        Removes the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry` with the specified <em>key</em>.
    
        
    
        
        :param key: The key.
        
        :type key: System.String
        :rtype: System.Boolean
        :return: <code>true</code> if the element is successfully removed; otherwise <code>false</code>. This method also
                returns <code>false</code> if key was not found.
    
        
        .. code-block:: csharp
    
            public bool Remove(string key)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.SetModelValue(System.String, Microsoft.AspNetCore.Mvc.ModelBinding.ValueProviderResult)
    
        
    
        
        Sets the value for the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry` with the specified <em>key</em>.
    
        
    
        
        :param key: The key for the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry` entry
        
        :type key: System.String
    
        
        :param valueProviderResult: 
            A :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ValueProviderResult` with data for the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry` entry.
        
        :type valueProviderResult: Microsoft.AspNetCore.Mvc.ModelBinding.ValueProviderResult
    
        
        .. code-block:: csharp
    
            public void SetModelValue(string key, ValueProviderResult valueProviderResult)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.SetModelValue(System.String, System.Object, System.String)
    
        
    
        
        Sets the of :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry.RawValue` and :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry.AttemptedValue` for
        the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry` with the specified <em>key</em>.
    
        
    
        
        :param key: The key for the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry` entry.
        
        :type key: System.String
    
        
        :param rawValue: The raw value for the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry` entry.
        
        :type rawValue: System.Object
    
        
        :param attemptedValue: 
            The values of <em>rawValue</em> in a comma-separated :any:`System.String`\.
        
        :type attemptedValue: System.String
    
        
        .. code-block:: csharp
    
            public void SetModelValue(string key, object rawValue, string attemptedValue)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.StartsWithPrefix(System.String, System.String)
    
        
    
        
        :type prefix: System.String
    
        
        :type key: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public static bool StartsWithPrefix(string prefix, string key)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<System.String, Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry>>.GetEnumerator()
    
        
        :rtype: System.Collections.Generic.IEnumerator<System.Collections.Generic.IEnumerator`1>{System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair`2>{System.String<System.String>, Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry<Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry>}}
    
        
        .. code-block:: csharp
    
            IEnumerator<KeyValuePair<string, ModelStateEntry>> IEnumerable<KeyValuePair<string, ModelStateEntry>>.GetEnumerator()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.System.Collections.IEnumerable.GetEnumerator()
    
        
        :rtype: System.Collections.IEnumerator
    
        
        .. code-block:: csharp
    
            IEnumerator IEnumerable.GetEnumerator()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.TryAddModelError(System.String, System.Exception, Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata)
    
        
    
        
        Attempts to add the specified <em>exception</em> to the :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry.Errors`
        instance that is associated with the specified <em>key</em>. If the maximum number of allowed
        errors has already been recorded, records a :any:`Microsoft.AspNetCore.Mvc.ModelBinding.TooManyModelErrorsException` exception instead.
    
        
    
        
        :param key: The key of the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry` to add errors to.
        
        :type key: System.String
    
        
        :param exception: The :any:`System.Exception` to add.
        
        :type exception: System.Exception
    
        
        :param metadata: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata` associated with the model.
        
        :type metadata: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata
        :rtype: System.Boolean
        :return: 
            <code>True</code> if the given error was added, <code>false</code> if the error was ignored.
            See :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.MaxAllowedErrors`\.
    
        
        .. code-block:: csharp
    
            public bool TryAddModelError(string key, Exception exception, ModelMetadata metadata)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.TryAddModelError(System.String, System.String)
    
        
    
        
        Attempts to add the specified <em>errorMessage</em> to the :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry.Errors`
        instance that is associated with the specified <em>key</em>. If the maximum number of allowed
        errors has already been recorded, records a :any:`Microsoft.AspNetCore.Mvc.ModelBinding.TooManyModelErrorsException` exception instead.
    
        
    
        
        :param key: The key of the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry` to add errors to.
        
        :type key: System.String
    
        
        :param errorMessage: The error message to add.
        
        :type errorMessage: System.String
        :rtype: System.Boolean
        :return: 
            <code>True</code> if the given error was added, <code>false</code> if the error was ignored.
            See :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.MaxAllowedErrors`\.
    
        
        .. code-block:: csharp
    
            public bool TryAddModelError(string key, string errorMessage)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.TryGetValue(System.String, out Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry)
    
        
    
        
        :type key: System.String
    
        
        :type value: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool TryGetValue(string key, out ModelStateEntry value)
    

Fields
------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.DefaultMaxAllowedErrors
    
        
    
        
        The default value for :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.MaxAllowedErrors` of <code>200</code>.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public static readonly int DefaultMaxAllowedErrors
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.Count
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Count { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.ErrorCount
    
        
    
        
        Gets the number of errors added to this instance of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary` via 
        :dn:meth:`AddModelError` or :dn:meth:`TryAddModelError`\.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int ErrorCount { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.HasReachedMaxErrors
    
        
    
        
        Gets a value indicating whether or not the maximum number of errors have been
        recorded.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool HasReachedMaxErrors { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.IsValid
    
        
    
        
        Gets a value that indicates whether any model state values in this model state dictionary is invalid or not validated.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsValid { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.Item[System.String]
    
        
    
        
        :type key: System.String
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry
    
        
        .. code-block:: csharp
    
            public ModelStateEntry this[string key] { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.Keys
    
        
    
        
        Gets the key sequence.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.KeyEnumerable
    
        
        .. code-block:: csharp
    
            public ModelStateDictionary.KeyEnumerable Keys { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.MaxAllowedErrors
    
        
    
        
        Gets or sets the maximum allowed model state errors in this instance of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary`\.
        Defaults to <code>200</code>.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int MaxAllowedErrors { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.Root
    
        
    
        
        Root entry for the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry
    
        
        .. code-block:: csharp
    
            public ModelStateEntry Root { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.System.Collections.Generic.IReadOnlyDictionary<System.String, Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry>.Keys
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            IEnumerable<string> IReadOnlyDictionary<string, ModelStateEntry>.Keys { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.System.Collections.Generic.IReadOnlyDictionary<System.String, Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry>.Values
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry<Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry>}
    
        
        .. code-block:: csharp
    
            IEnumerable<ModelStateEntry> IReadOnlyDictionary<string, ModelStateEntry>.Values { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.ValidationState
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState
    
        
        .. code-block:: csharp
    
            public ModelValidationState ValidationState { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.Values
    
        
    
        
        Gets the value sequence.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary.ValueEnumerable
    
        
        .. code-block:: csharp
    
            public ModelStateDictionary.ValueEnumerable Values { get; }
    

