

ViewDataDictionary Class
========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary`








Syntax
------

.. code-block:: csharp

   public class ViewDataDictionary : IDictionary<string, object>, ICollection<KeyValuePair<string, object>>, IEnumerable<KeyValuePair<string, object>>, IEnumerable





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.ViewFeatures/ViewFeatures/ViewDataDictionary.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary.ViewDataDictionary(Microsoft.AspNet.Mvc.ModelBinding.IModelMetadataProvider, Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary)
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary` class.
    
        
        
        
        :param metadataProvider: instance used to calculate
            values.
        
        :type metadataProvider: Microsoft.AspNet.Mvc.ModelBinding.IModelMetadataProvider
        
        
        :param modelState: instance for this scope.
        
        :type modelState: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary
    
        
        .. code-block:: csharp
    
           public ViewDataDictionary(IModelMetadataProvider metadataProvider, ModelStateDictionary modelState)
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary.ViewDataDictionary(Microsoft.AspNet.Mvc.ModelBinding.IModelMetadataProvider, Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary, System.Type)
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary` class.
    
        
        
        
        :param metadataProvider: instance used to calculate
            values.
        
        :type metadataProvider: Microsoft.AspNet.Mvc.ModelBinding.IModelMetadataProvider
        
        
        :param modelState: instance for this scope.
        
        :type modelState: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary
        
        
        :param declaredModelType: of  values expected. Used to set
            when  is null.
        
        :type declaredModelType: System.Type
    
        
        .. code-block:: csharp
    
           protected ViewDataDictionary(IModelMetadataProvider metadataProvider, ModelStateDictionary modelState, Type declaredModelType)
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary.ViewDataDictionary(Microsoft.AspNet.Mvc.ModelBinding.IModelMetadataProvider, System.Type)
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary` class.
    
        
        
        
        :param metadataProvider: instance used to calculate
            values.
        
        :type metadataProvider: Microsoft.AspNet.Mvc.ModelBinding.IModelMetadataProvider
        
        
        :param declaredModelType: of  values expected. Used to set
            when  is null.
        
        :type declaredModelType: System.Type
    
        
        .. code-block:: csharp
    
           protected ViewDataDictionary(IModelMetadataProvider metadataProvider, Type declaredModelType)
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary.ViewDataDictionary(Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary)
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary` class based entirely on an existing
        instance.
    
        
        
        
        :param source: instance to copy initial values from.
        
        :type source: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary
    
        
        .. code-block:: csharp
    
           public ViewDataDictionary(ViewDataDictionary source)
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary.ViewDataDictionary(Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary, System.Object)
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary` class based in part on an existing
        instance. This constructor is careful to avoid exceptions :dn:meth:`Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary.SetModel(System.Object)` may throw when
        ``model`` is <c>null</c>.
    
        
        
        
        :param source: instance to copy initial values from.
        
        :type source: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary
        
        
        :param model: Value for the  property.
        
        :type model: System.Object
    
        
        .. code-block:: csharp
    
           public ViewDataDictionary(ViewDataDictionary source, object model)
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary.ViewDataDictionary(Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary, System.Object, System.Type)
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary` class based in part on an existing
        instance. This constructor is careful to avoid exceptions :dn:meth:`Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary.SetModel(System.Object)` may throw when
        ``model`` is <c>null</c>.
    
        
        
        
        :param source: instance to copy initial values from.
        
        :type source: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary
        
        
        :param model: Value for the  property.
        
        :type model: System.Object
        
        
        :param declaredModelType: of  values expected. Used to set
            when  is null.
        
        :type declaredModelType: System.Type
    
        
        .. code-block:: csharp
    
           protected ViewDataDictionary(ViewDataDictionary source, object model, Type declaredModelType)
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary.ViewDataDictionary(Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary, System.Type)
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary` class based in part on an existing
        instance.
    
        
        
        
        :param source: instance to copy initial values from.
        
        :type source: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary
        
        
        :param declaredModelType: of  values expected. Used to set
            when  is null.
        
        :type declaredModelType: System.Type
    
        
        .. code-block:: csharp
    
           protected ViewDataDictionary(ViewDataDictionary source, Type declaredModelType)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary.Add(System.Collections.Generic.KeyValuePair<System.String, System.Object>)
    
        
        
        
        :type item: System.Collections.Generic.KeyValuePair{System.String,System.Object}
    
        
        .. code-block:: csharp
    
           public void Add(KeyValuePair<string, object> item)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary.Add(System.String, System.Object)
    
        
        
        
        :type key: System.String
        
        
        :type value: System.Object
    
        
        .. code-block:: csharp
    
           public void Add(string key, object value)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary.Clear()
    
        
    
        
        .. code-block:: csharp
    
           public void Clear()
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary.Contains(System.Collections.Generic.KeyValuePair<System.String, System.Object>)
    
        
        
        
        :type item: System.Collections.Generic.KeyValuePair{System.String,System.Object}
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool Contains(KeyValuePair<string, object> item)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary.ContainsKey(System.String)
    
        
        
        
        :type key: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool ContainsKey(string key)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary.CopyTo(System.Collections.Generic.KeyValuePair<System.String, System.Object>[], System.Int32)
    
        
        
        
        :type array: System.Collections.Generic.KeyValuePair{System.String,System.Object}[]
        
        
        :type arrayIndex: System.Int32
    
        
        .. code-block:: csharp
    
           public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary.Eval(System.String)
    
        
    
        Gets value of named ``expression`` in this :any:`Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary`\.
    
        
        
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
        :rtype: System.Object
        :return: Value of named <paramref name="expression" /> in this <see cref="T:Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary" />.
    
        
        .. code-block:: csharp
    
           public object Eval(string expression)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary.Eval(System.String, System.String)
    
        
    
        Gets value of named ``expression`` in this :any:`Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary`\, formatted
        using given ``format``.
    
        
        
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
        
        
        :param format: The composite format  (see http://msdn.microsoft.com/en-us/library/txafckwd.aspx).
        
        :type format: System.String
        :rtype: System.String
        :return: Value of named <paramref name="expression" /> in this <see cref="T:Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary" />, formatted using
            given <paramref name="format" />.
    
        
        .. code-block:: csharp
    
           public string Eval(string expression, string format)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary.FormatValue(System.Object, System.String)
    
        
        
        
        :type value: System.Object
        
        
        :type format: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public static string FormatValue(object value, string format)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary.GetViewDataInfo(System.String)
    
        
    
        Gets :any:`Microsoft.AspNet.Mvc.ViewFeatures.ViewDataInfo` for named ``expression`` in this 
        :any:`Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary`\.
    
        
        
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
        :rtype: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataInfo
        :return: <see cref="T:Microsoft.AspNet.Mvc.ViewFeatures.ViewDataInfo" /> for named <paramref name="expression" /> in this
            <see cref="T:Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary" />.
    
        
        .. code-block:: csharp
    
           public ViewDataInfo GetViewDataInfo(string expression)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary.Remove(System.Collections.Generic.KeyValuePair<System.String, System.Object>)
    
        
        
        
        :type item: System.Collections.Generic.KeyValuePair{System.String,System.Object}
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool Remove(KeyValuePair<string, object> item)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary.Remove(System.String)
    
        
        
        
        :type key: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool Remove(string key)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary.SetModel(System.Object)
    
        
        
        
        :type value: System.Object
    
        
        .. code-block:: csharp
    
           protected virtual void SetModel(object value)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary.System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<System.String, System.Object>>.GetEnumerator()
    
        
        :rtype: System.Collections.Generic.IEnumerator{System.Collections.Generic.KeyValuePair{System.String,System.Object}}
    
        
        .. code-block:: csharp
    
           IEnumerator<KeyValuePair<string, object>> IEnumerable<KeyValuePair<string, object>>.GetEnumerator()
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary.System.Collections.IEnumerable.GetEnumerator()
    
        
        :rtype: System.Collections.IEnumerator
    
        
        .. code-block:: csharp
    
           IEnumerator IEnumerable.GetEnumerator()
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary.TryGetValue(System.String, out System.Object)
    
        
        
        
        :type key: System.String
        
        
        :type value: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool TryGetValue(string key, out object value)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary.Count
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int Count { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary.IsReadOnly
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsReadOnly { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary.Item[System.String]
    
        
        
        
        :type index: System.String
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           public object this[string index] { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary.Keys
    
        
        :rtype: System.Collections.Generic.ICollection{System.String}
    
        
        .. code-block:: csharp
    
           public ICollection<string> Keys { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary.Model
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           public object Model { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary.ModelExplorer
    
        
    
        Gets or sets the :dn:prop:`Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary.ModelExplorer` for the :dn:prop:`Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary.Model`\.
    
        
        :rtype: Microsoft.AspNet.Mvc.ViewFeatures.ModelExplorer
    
        
        .. code-block:: csharp
    
           public ModelExplorer ModelExplorer { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary.ModelMetadata
    
        
    
        :dn:prop:`Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary.ModelMetadata` for the current :dn:prop:`Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary.Model` value or the declared :any:`System.Type` if 
        :dn:prop:`Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary.Model` is <c>null</c>.
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata
    
        
        .. code-block:: csharp
    
           public ModelMetadata ModelMetadata { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary.ModelState
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary
    
        
        .. code-block:: csharp
    
           public ModelStateDictionary ModelState { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary.TemplateInfo
    
        
        :rtype: Microsoft.AspNet.Mvc.ViewFeatures.TemplateInfo
    
        
        .. code-block:: csharp
    
           public TemplateInfo TemplateInfo { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary.Values
    
        
        :rtype: System.Collections.Generic.ICollection{System.Object}
    
        
        .. code-block:: csharp
    
           public ICollection<object> Values { get; }
    

