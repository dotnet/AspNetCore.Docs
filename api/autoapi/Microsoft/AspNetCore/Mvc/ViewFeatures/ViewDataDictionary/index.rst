

ViewDataDictionary Class
========================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ViewFeatures`
Assemblies
    * Microsoft.AspNetCore.Mvc.ViewFeatures

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary`








Syntax
------

.. code-block:: csharp

    public class ViewDataDictionary : IDictionary<string, object>, ICollection<KeyValuePair<string, object>>, IEnumerable<KeyValuePair<string, object>>, IEnumerable








.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary.Count
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Count
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary.IsReadOnly
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsReadOnly
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary.Item[System.String]
    
        
    
        
        :type index: System.String
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            public object this[string index]
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary.Keys
    
        
        :rtype: System.Collections.Generic.ICollection<System.Collections.Generic.ICollection`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public ICollection<string> Keys
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary.Model
    
        
    
        
        Gets or sets the current model.
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            public object Model
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary.ModelExplorer
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer` for the :dn:prop:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary.Model`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer
    
        
        .. code-block:: csharp
    
            public ModelExplorer ModelExplorer
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary.ModelMetadata
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata` for an expression, the :dn:prop:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary.Model` (if
        non-<code>null</code>), or the declared :any:`System.Type`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata
    
        
        .. code-block:: csharp
    
            public ModelMetadata ModelMetadata
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary.ModelState
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary
    
        
        .. code-block:: csharp
    
            public ModelStateDictionary ModelState
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary.TemplateInfo
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.TemplateInfo`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ViewFeatures.TemplateInfo
    
        
        .. code-block:: csharp
    
            public TemplateInfo TemplateInfo
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary.Values
    
        
        :rtype: System.Collections.Generic.ICollection<System.Collections.Generic.ICollection`1>{System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public ICollection<object> Values
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary.ViewDataDictionary(Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider, Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary)
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary` class.
    
        
    
        
        :param metadataProvider: 
            :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider` instance used to create :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer`
            instances.
        
        :type metadataProvider: Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider
    
        
        :param modelState: :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary` instance for this scope.
        
        :type modelState: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary
    
        
        .. code-block:: csharp
    
            public ViewDataDictionary(IModelMetadataProvider metadataProvider, ModelStateDictionary modelState)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary.ViewDataDictionary(Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider, Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary, System.Type)
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary` class.
    
        
    
        
        :param metadataProvider: 
            :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider` instance used to create :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer`
            instances.
        
        :type metadataProvider: Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider
    
        
        :param modelState: :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary` instance for this scope.
        
        :type modelState: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary
    
        
        :param declaredModelType: 
            :any:`System.Type` of :dn:prop:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary.Model` values expected. Used to set :dn:prop:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary.ModelMetadata`\.
        
        :type declaredModelType: System.Type
    
        
        .. code-block:: csharp
    
            protected ViewDataDictionary(IModelMetadataProvider metadataProvider, ModelStateDictionary modelState, Type declaredModelType)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary.ViewDataDictionary(Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider, System.Type)
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary` class.
    
        
    
        
        :param metadataProvider: 
            :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider` instance used to create :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer`
            instances.
        
        :type metadataProvider: Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider
    
        
        :param declaredModelType: 
            :any:`System.Type` of :dn:prop:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary.Model` values expected. Used to set :dn:prop:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary.ModelMetadata`\.
        
        :type declaredModelType: System.Type
    
        
        .. code-block:: csharp
    
            protected ViewDataDictionary(IModelMetadataProvider metadataProvider, Type declaredModelType)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary.ViewDataDictionary(Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary)
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary` class based entirely on an existing
        instance.
    
        
    
        
        :param source: :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary` instance to copy initial values from.
        
        :type source: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary
    
        
        .. code-block:: csharp
    
            public ViewDataDictionary(ViewDataDictionary source)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary.ViewDataDictionary(Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary, System.Object, System.Type)
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary` class based in part on an existing
        instance. This constructor is careful to avoid exceptions :dn:meth:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary.SetModel(System.Object)` may throw when
        <em>model</em> is <code>null</code>.
    
        
    
        
        :param source: :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary` instance to copy initial values from.
        
        :type source: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary
    
        
        :param model: Value for the :dn:prop:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary.Model` property.
        
        :type model: System.Object
    
        
        :param declaredModelType: 
            :any:`System.Type` of :dn:prop:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary.Model` values expected. Used to set :dn:prop:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary.ModelMetadata`\.
        
        :type declaredModelType: System.Type
    
        
        .. code-block:: csharp
    
            protected ViewDataDictionary(ViewDataDictionary source, object model, Type declaredModelType)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary.ViewDataDictionary(Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary, System.Type)
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary` class based in part on an existing
        instance.
    
        
    
        
        :param source: :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary` instance to copy initial values from.
        
        :type source: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary
    
        
        :param declaredModelType: 
            :any:`System.Type` of :dn:prop:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary.Model` values expected. Used to set :dn:prop:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary.ModelMetadata`\.
        
        :type declaredModelType: System.Type
    
        
        .. code-block:: csharp
    
            protected ViewDataDictionary(ViewDataDictionary source, Type declaredModelType)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary.Add(System.Collections.Generic.KeyValuePair<System.String, System.Object>)
    
        
    
        
        :type item: System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair`2>{System.String<System.String>, System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public void Add(KeyValuePair<string, object> item)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary.Add(System.String, System.Object)
    
        
    
        
        :type key: System.String
    
        
        :type value: System.Object
    
        
        .. code-block:: csharp
    
            public void Add(string key, object value)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary.Clear()
    
        
    
        
        .. code-block:: csharp
    
            public void Clear()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary.Contains(System.Collections.Generic.KeyValuePair<System.String, System.Object>)
    
        
    
        
        :type item: System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair`2>{System.String<System.String>, System.Object<System.Object>}
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Contains(KeyValuePair<string, object> item)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary.ContainsKey(System.String)
    
        
    
        
        :type key: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool ContainsKey(string key)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary.CopyTo(System.Collections.Generic.KeyValuePair<System.String, System.Object>[], System.Int32)
    
        
    
        
        :type array: System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair`2>{System.String<System.String>, System.Object<System.Object>}[]
    
        
        :type arrayIndex: System.Int32
    
        
        .. code-block:: csharp
    
            public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary.Eval(System.String)
    
        
    
        
        Gets value of named <em>expression</em> in this :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary`\.
    
        
    
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
        :rtype: System.Object
        :return: Value of named <em>expression</em> in this :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary`\.
    
        
        .. code-block:: csharp
    
            public object Eval(string expression)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary.Eval(System.String, System.String)
    
        
    
        
        Gets value of named <em>expression</em> in this :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary`\, formatted
        using given <em>format</em>.
    
        
    
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
    
        
        :param format: 
            The composite format :any:`System.String` (see http://msdn.microsoft.com/en-us/library/txafckwd.aspx).
        
        :type format: System.String
        :rtype: System.String
        :return: 
            Value of named <em>expression</em> in this :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary`\, formatted using
            given <em>format</em>.
    
        
        .. code-block:: csharp
    
            public string Eval(string expression, string format)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary.FormatValue(System.Object, System.String)
    
        
    
        
        Formats the given <em>value</em> using given <em>format</em>.
    
        
    
        
        :param value: The value to format.
        
        :type value: System.Object
    
        
        :param format: 
            The composite format :any:`System.String` (see http://msdn.microsoft.com/en-us/library/txafckwd.aspx).
        
        :type format: System.String
        :rtype: System.String
        :return: The formatted :any:`System.String`\.
    
        
        .. code-block:: csharp
    
            public static string FormatValue(object value, string format)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary.GetViewDataInfo(System.String)
    
        
    
        
        Gets :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataInfo` for named <em>expression</em> in this
        :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary`\.
    
        
    
        
        :param expression: Expression name, relative to the current model.
        
        :type expression: System.String
        :rtype: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataInfo
        :return: 
            :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataInfo` for named <em>expression</em> in this
            :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary`\.
    
        
        .. code-block:: csharp
    
            public ViewDataInfo GetViewDataInfo(string expression)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary.Remove(System.Collections.Generic.KeyValuePair<System.String, System.Object>)
    
        
    
        
        :type item: System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair`2>{System.String<System.String>, System.Object<System.Object>}
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Remove(KeyValuePair<string, object> item)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary.Remove(System.String)
    
        
    
        
        :type key: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Remove(string key)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary.SetModel(System.Object)
    
        
    
        
        Set :dn:prop:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary.ModelExplorer` to ensure :dn:prop:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary.Model` and :dn:prop:`Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExplorer.Model`
        reflect the new <em>value</em>.
    
        
    
        
        :param value: New :dn:prop:`Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary.Model` value.
        
        :type value: System.Object
    
        
        .. code-block:: csharp
    
            protected virtual void SetModel(object value)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary.System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<System.String, System.Object>>.GetEnumerator()
    
        
        :rtype: System.Collections.Generic.IEnumerator<System.Collections.Generic.IEnumerator`1>{System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair`2>{System.String<System.String>, System.Object<System.Object>}}
    
        
        .. code-block:: csharp
    
            IEnumerator<KeyValuePair<string, object>> IEnumerable<KeyValuePair<string, object>>.GetEnumerator()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary.System.Collections.IEnumerable.GetEnumerator()
    
        
        :rtype: System.Collections.IEnumerator
    
        
        .. code-block:: csharp
    
            IEnumerator IEnumerable.GetEnumerator()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary.TryGetValue(System.String, out System.Object)
    
        
    
        
        :type key: System.String
    
        
        :type value: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool TryGetValue(string key, out object value)
    

