

ModelStateDictionary Class
==========================



.. contents:: 
   :local:



Summary
-------

Represents the state of an attempt to bind values from an HTTP Request to an action method, which includes
validation information.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary`








Syntax
------

.. code-block:: csharp

   public class ModelStateDictionary : IDictionary<string, ModelStateEntry>, ICollection<KeyValuePair<string, ModelStateEntry>>, IEnumerable<KeyValuePair<string, ModelStateEntry>>, IEnumerable





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Abstractions/ModelBinding/ModelStateDictionary.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary.ModelStateDictionary()
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary` class.
    
        
    
        
        .. code-block:: csharp
    
           public ModelStateDictionary()
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary.ModelStateDictionary(Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary)
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary` class by using values that are copied
        from the specified ``dictionary``.
    
        
        
        
        :param dictionary: The  to copy values from.
        
        :type dictionary: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary
    
        
        .. code-block:: csharp
    
           public ModelStateDictionary(ModelStateDictionary dictionary)
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary.ModelStateDictionary(System.Int32)
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary` class.
    
        
        
        
        :type maxAllowedErrors: System.Int32
    
        
        .. code-block:: csharp
    
           public ModelStateDictionary(int maxAllowedErrors)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary.Add(System.Collections.Generic.KeyValuePair<System.String, Microsoft.AspNet.Mvc.ModelBinding.ModelStateEntry>)
    
        
        
        
        :type item: System.Collections.Generic.KeyValuePair{System.String,Microsoft.AspNet.Mvc.ModelBinding.ModelStateEntry}
    
        
        .. code-block:: csharp
    
           public void Add(KeyValuePair<string, ModelStateEntry> item)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary.Add(System.String, Microsoft.AspNet.Mvc.ModelBinding.ModelStateEntry)
    
        
        
        
        :type key: System.String
        
        
        :type value: Microsoft.AspNet.Mvc.ModelBinding.ModelStateEntry
    
        
        .. code-block:: csharp
    
           public void Add(string key, ModelStateEntry value)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary.AddModelError(System.String, System.Exception, Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata)
    
        
    
        Adds the specified ``exception`` to the :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelStateEntry.Errors` instance
        that is associated with the specified ``key``.
    
        
        
        
        :param key: The key of the  to add errors to.
        
        :type key: System.String
        
        
        :param exception: The  to add.
        
        :type exception: System.Exception
        
        
        :type metadata: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata
    
        
        .. code-block:: csharp
    
           public void AddModelError(string key, Exception exception, ModelMetadata metadata)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary.AddModelError(System.String, System.String)
    
        
    
        Adds the specified ``errorMessage`` to the :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelStateEntry.Errors` instance
        that is associated with the specified ``key``.
    
        
        
        
        :param key: The key of the  to add errors to.
        
        :type key: System.String
        
        
        :param errorMessage: The error message to add.
        
        :type errorMessage: System.String
    
        
        .. code-block:: csharp
    
           public void AddModelError(string key, string errorMessage)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary.Clear()
    
        
    
        
        .. code-block:: csharp
    
           public void Clear()
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary.ClearValidationState(System.String)
    
        
    
        Clears :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary` entries that match the key that is passed as parameter.
    
        
        
        
        :param key: The key of  to clear.
        
        :type key: System.String
    
        
        .. code-block:: csharp
    
           public void ClearValidationState(string key)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary.Contains(System.Collections.Generic.KeyValuePair<System.String, Microsoft.AspNet.Mvc.ModelBinding.ModelStateEntry>)
    
        
        
        
        :type item: System.Collections.Generic.KeyValuePair{System.String,Microsoft.AspNet.Mvc.ModelBinding.ModelStateEntry}
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool Contains(KeyValuePair<string, ModelStateEntry> item)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary.ContainsKey(System.String)
    
        
        
        
        :type key: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool ContainsKey(string key)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary.CopyTo(System.Collections.Generic.KeyValuePair<System.String, Microsoft.AspNet.Mvc.ModelBinding.ModelStateEntry>[], System.Int32)
    
        
        
        
        :type array: System.Collections.Generic.KeyValuePair{System.String,Microsoft.AspNet.Mvc.ModelBinding.ModelStateEntry}[]
        
        
        :type arrayIndex: System.Int32
    
        
        .. code-block:: csharp
    
           public void CopyTo(KeyValuePair<string, ModelStateEntry>[] array, int arrayIndex)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary.FindKeysWithPrefix(System.String)
    
        
        
        
        :type prefix: System.String
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary.PrefixEnumerable
    
        
        .. code-block:: csharp
    
           public ModelStateDictionary.PrefixEnumerable FindKeysWithPrefix(string prefix)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary.GetEnumerator()
    
        
        :rtype: System.Collections.Generic.IEnumerator{System.Collections.Generic.KeyValuePair{System.String,Microsoft.AspNet.Mvc.ModelBinding.ModelStateEntry}}
    
        
        .. code-block:: csharp
    
           public IEnumerator<KeyValuePair<string, ModelStateEntry>> GetEnumerator()
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary.GetFieldValidationState(System.String)
    
        
    
        Returns the aggregate :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelValidationState` for items starting with the
        specified ``key``.
    
        
        
        
        :param key: The key to look up model state errors for.
        
        :type key: System.String
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.ModelValidationState
        :return: Returns <see cref="F:Microsoft.AspNet.Mvc.ModelBinding.ModelValidationState.Unvalidated" /> if no entries are found for the specified
            key, <see cref="F:Microsoft.AspNet.Mvc.ModelBinding.ModelValidationState.Invalid" /> if at least one instance is found with one or more model
            state errors; <see cref="F:Microsoft.AspNet.Mvc.ModelBinding.ModelValidationState.Valid" /> otherwise.
    
        
        .. code-block:: csharp
    
           public ModelValidationState GetFieldValidationState(string key)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary.GetValidationState(System.String)
    
        
    
        Returns :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelValidationState` for the ``key``.
    
        
        
        
        :param key: The key to look up model state errors for.
        
        :type key: System.String
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.ModelValidationState
        :return: Returns <see cref="F:Microsoft.AspNet.Mvc.ModelBinding.ModelValidationState.Unvalidated" /> if no entry is found for the specified
            key, <see cref="F:Microsoft.AspNet.Mvc.ModelBinding.ModelValidationState.Invalid" /> if an instance is found with one or more model
            state errors; <see cref="F:Microsoft.AspNet.Mvc.ModelBinding.ModelValidationState.Valid" /> otherwise.
    
        
        .. code-block:: csharp
    
           public ModelValidationState GetValidationState(string key)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary.MarkFieldSkipped(System.String)
    
        
    
        Marks the :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelStateEntry.ValidationState` for the entry with the specified ``key``
        as :dn:field:`Microsoft.AspNet.Mvc.ModelBinding.ModelValidationState.Skipped`\.
    
        
        
        
        :param key: The key of the  to mark as skipped.
        
        :type key: System.String
    
        
        .. code-block:: csharp
    
           public void MarkFieldSkipped(string key)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary.MarkFieldValid(System.String)
    
        
    
        Marks the :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelStateEntry.ValidationState` for the entry with the specified
        ``key`` as :dn:field:`Microsoft.AspNet.Mvc.ModelBinding.ModelValidationState.Valid`\.
    
        
        
        
        :param key: The key of the  to mark as valid.
        
        :type key: System.String
    
        
        .. code-block:: csharp
    
           public void MarkFieldValid(string key)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary.Merge(Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary)
    
        
    
        Copies the values from the specified ``dictionary`` into this instance, overwriting
        existing values if keys are the same.
    
        
        
        
        :param dictionary: The  to copy values from.
        
        :type dictionary: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary
    
        
        .. code-block:: csharp
    
           public void Merge(ModelStateDictionary dictionary)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary.Remove(System.Collections.Generic.KeyValuePair<System.String, Microsoft.AspNet.Mvc.ModelBinding.ModelStateEntry>)
    
        
        
        
        :type item: System.Collections.Generic.KeyValuePair{System.String,Microsoft.AspNet.Mvc.ModelBinding.ModelStateEntry}
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool Remove(KeyValuePair<string, ModelStateEntry> item)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary.Remove(System.String)
    
        
        
        
        :type key: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool Remove(string key)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary.SetModelValue(System.String, Microsoft.AspNet.Mvc.ModelBinding.ValueProviderResult)
    
        
    
        Sets the value for the :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelStateEntry` with the specified ``key``.
    
        
        
        
        :param key: The key for the  entry
        
        :type key: System.String
        
        
        :param valueProviderResult: A  with data for the  entry.
        
        :type valueProviderResult: Microsoft.AspNet.Mvc.ModelBinding.ValueProviderResult
    
        
        .. code-block:: csharp
    
           public void SetModelValue(string key, ValueProviderResult valueProviderResult)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary.SetModelValue(System.String, System.Object, System.String)
    
        
    
        Sets the of :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelStateEntry.RawValue` and :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelStateEntry.AttemptedValue` for
        the :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelStateEntry` with the specified ``key``.
    
        
        
        
        :param key: The key for the  entry.
        
        :type key: System.String
        
        
        :type rawValue: System.Object
        
        
        :param attemptedValue: The values of  in a comma-separated .
        
        :type attemptedValue: System.String
    
        
        .. code-block:: csharp
    
           public void SetModelValue(string key, object rawValue, string attemptedValue)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary.StartsWithPrefix(System.String, System.String)
    
        
        
        
        :type prefix: System.String
        
        
        :type key: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public static bool StartsWithPrefix(string prefix, string key)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary.System.Collections.IEnumerable.GetEnumerator()
    
        
        :rtype: System.Collections.IEnumerator
    
        
        .. code-block:: csharp
    
           IEnumerator IEnumerable.GetEnumerator()
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary.TryAddModelError(System.String, System.Exception, Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata)
    
        
    
        Attempts to add the specified ``exception`` to the :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelStateEntry.Errors`
        instance that is associated with the specified ``key``. If the maximum number of allowed
        errors has already been recorded, records a :any:`Microsoft.AspNet.Mvc.ModelBinding.TooManyModelErrorsException` exception instead.
    
        
        
        
        :param key: The key of the  to add errors to.
        
        :type key: System.String
        
        
        :param exception: The  to add.
        
        :type exception: System.Exception
        
        
        :type metadata: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata
        :rtype: System.Boolean
        :return: <c>True</c> if the given error was added, <c>false</c> if the error was ignored.
            See <see cref="P:Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary.MaxAllowedErrors" />.
    
        
        .. code-block:: csharp
    
           public bool TryAddModelError(string key, Exception exception, ModelMetadata metadata)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary.TryAddModelError(System.String, System.String)
    
        
    
        Attempts to add the specified ``errorMessage`` to the :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelStateEntry.Errors`
        instance that is associated with the specified ``key``. If the maximum number of allowed
        errors has already been recorded, records a :any:`Microsoft.AspNet.Mvc.ModelBinding.TooManyModelErrorsException` exception instead.
    
        
        
        
        :param key: The key of the  to add errors to.
        
        :type key: System.String
        
        
        :param errorMessage: The error message to add.
        
        :type errorMessage: System.String
        :rtype: System.Boolean
        :return: <c>True</c> if the given error was added, <c>false</c> if the error was ignored.
            See <see cref="P:Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary.MaxAllowedErrors" />.
    
        
        .. code-block:: csharp
    
           public bool TryAddModelError(string key, string errorMessage)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary.TryGetValue(System.String, out Microsoft.AspNet.Mvc.ModelBinding.ModelStateEntry)
    
        
        
        
        :type key: System.String
        
        
        :type value: Microsoft.AspNet.Mvc.ModelBinding.ModelStateEntry
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool TryGetValue(string key, out ModelStateEntry value)
    

Fields
------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary.DefaultMaxAllowedErrors
    
        
    
        The default value for :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary.MaxAllowedErrors` of <c>200</c>.
    
        
    
        
        .. code-block:: csharp
    
           public static readonly int DefaultMaxAllowedErrors
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary.Count
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int Count { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary.ErrorCount
    
        
    
        Gets the number of errors added to this instance of :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary` via 
        :dn:meth:`Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary.AddModelError(System.String,System.Exception,Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata)` or :dn:meth:`Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary.TryAddModelError(System.String,System.Exception,Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata)`\.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int ErrorCount { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary.HasReachedMaxErrors
    
        
    
        Gets a value indicating whether or not the maximum number of errors have been
        recorded.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool HasReachedMaxErrors { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary.IsReadOnly
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsReadOnly { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary.IsValid
    
        
    
        Gets a value that indicates whether any model state values in this model state dictionary is invalid or not validated.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsValid { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary.Item[System.String]
    
        
        
        
        :type key: System.String
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.ModelStateEntry
    
        
        .. code-block:: csharp
    
           public ModelStateEntry this[string key] { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary.Keys
    
        
        :rtype: System.Collections.Generic.ICollection{System.String}
    
        
        .. code-block:: csharp
    
           public ICollection<string> Keys { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary.MaxAllowedErrors
    
        
    
        Gets or sets the maximum allowed model state errors in this instance of :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary`\.
        Defaults to <c>200</c>.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int MaxAllowedErrors { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary.ValidationState
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.ModelValidationState
    
        
        .. code-block:: csharp
    
           public ModelValidationState ValidationState { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary.Values
    
        
        :rtype: System.Collections.Generic.ICollection{Microsoft.AspNet.Mvc.ModelBinding.ModelStateEntry}
    
        
        .. code-block:: csharp
    
           public ICollection<ModelStateEntry> Values { get; }
    

