

JsonPatchDocument<TModel> Class
===============================





Namespace
    :dn:ns:`Microsoft.AspNetCore.JsonPatch`
Assemblies
    * Microsoft.AspNetCore.JsonPatch

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.JsonPatch.JsonPatchDocument\<TModel>`








Syntax
------

.. code-block:: csharp

    [JsonConverter(typeof (TypedJsonPatchDocumentConverter))]
    public class JsonPatchDocument<TModel> : IJsonPatchDocument where TModel : class








.. dn:class:: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument`1
    :hidden:

.. dn:class:: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<TModel>

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<TModel>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<TModel>.JsonPatchDocument()
    
        
    
        
        .. code-block:: csharp
    
            public JsonPatchDocument()
    
    .. dn:constructor:: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<TModel>.JsonPatchDocument(System.Collections.Generic.List<Microsoft.AspNetCore.JsonPatch.Operations.Operation<TModel>>, Newtonsoft.Json.Serialization.IContractResolver)
    
        
    
        
        :type operations: System.Collections.Generic.List<System.Collections.Generic.List`1>{Microsoft.AspNetCore.JsonPatch.Operations.Operation<Microsoft.AspNetCore.JsonPatch.Operations.Operation`1>{TModel}}
    
        
        :type contractResolver: Newtonsoft.Json.Serialization.IContractResolver
    
        
        .. code-block:: csharp
    
            public JsonPatchDocument(List<Operation<TModel>> operations, IContractResolver contractResolver)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<TModel>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<TModel>.Add<TProp>(System.Linq.Expressions.Expression<System.Func<TModel, System.Collections.Generic.IList<TProp>>>, TProp)
    
        
    
        
        At value at end of list
    
        
    
        
        :param path: target location
        
        :type path: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, System.Collections.Generic.IList<System.Collections.Generic.IList`1>{TProp}}}
    
        
        :param value: value
        
        :type value: TProp
        :rtype: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<Microsoft.AspNetCore.JsonPatch.JsonPatchDocument`1>{TModel}
    
        
        .. code-block:: csharp
    
            public JsonPatchDocument<TModel> Add<TProp>(Expression<Func<TModel, IList<TProp>>> path, TProp value)
    
    .. dn:method:: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<TModel>.Add<TProp>(System.Linq.Expressions.Expression<System.Func<TModel, System.Collections.Generic.IList<TProp>>>, TProp, System.Int32)
    
        
    
        
        Add value to list at given position
    
        
    
        
        :param path: target location
        
        :type path: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, System.Collections.Generic.IList<System.Collections.Generic.IList`1>{TProp}}}
    
        
        :param value: value
        
        :type value: TProp
    
        
        :param position: position
        
        :type position: System.Int32
        :rtype: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<Microsoft.AspNetCore.JsonPatch.JsonPatchDocument`1>{TModel}
    
        
        .. code-block:: csharp
    
            public JsonPatchDocument<TModel> Add<TProp>(Expression<Func<TModel, IList<TProp>>> path, TProp value, int position)
    
    .. dn:method:: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<TModel>.Add<TProp>(System.Linq.Expressions.Expression<System.Func<TModel, TProp>>, TProp)
    
        
    
        
        Add operation.  Will result in, for example,
        { "op": "add", "path": "/a/b/c", "value": [ "foo", "bar" ] }
    
        
    
        
        :param path: target location
        
        :type path: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, TProp}}
    
        
        :param value: value
        
        :type value: TProp
        :rtype: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<Microsoft.AspNetCore.JsonPatch.JsonPatchDocument`1>{TModel}
    
        
        .. code-block:: csharp
    
            public JsonPatchDocument<TModel> Add<TProp>(Expression<Func<TModel, TProp>> path, TProp value)
    
    .. dn:method:: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<TModel>.ApplyTo(TModel)
    
        
    
        
        Apply this JsonPatchDocument 
    
        
    
        
        :param objectToApplyTo: Object to apply the JsonPatchDocument to
        
        :type objectToApplyTo: TModel
    
        
        .. code-block:: csharp
    
            public void ApplyTo(TModel objectToApplyTo)
    
    .. dn:method:: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<TModel>.ApplyTo(TModel, Microsoft.AspNetCore.JsonPatch.Adapters.IObjectAdapter)
    
        
    
        
        Apply this JsonPatchDocument  
    
        
    
        
        :param objectToApplyTo: Object to apply the JsonPatchDocument to
        
        :type objectToApplyTo: TModel
    
        
        :param adapter: IObjectAdapter instance to use when applying
        
        :type adapter: Microsoft.AspNetCore.JsonPatch.Adapters.IObjectAdapter
    
        
        .. code-block:: csharp
    
            public void ApplyTo(TModel objectToApplyTo, IObjectAdapter adapter)
    
    .. dn:method:: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<TModel>.ApplyTo(TModel, System.Action<Microsoft.AspNetCore.JsonPatch.JsonPatchError>)
    
        
    
        
        Apply this JsonPatchDocument 
    
        
    
        
        :param objectToApplyTo: Object to apply the JsonPatchDocument to
        
        :type objectToApplyTo: TModel
    
        
        :param logErrorAction: Action to log errors
        
        :type logErrorAction: System.Action<System.Action`1>{Microsoft.AspNetCore.JsonPatch.JsonPatchError<Microsoft.AspNetCore.JsonPatch.JsonPatchError>}
    
        
        .. code-block:: csharp
    
            public void ApplyTo(TModel objectToApplyTo, Action<JsonPatchError> logErrorAction)
    
    .. dn:method:: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<TModel>.Copy<TProp>(System.Linq.Expressions.Expression<System.Func<TModel, System.Collections.Generic.IList<TProp>>>, System.Int32, System.Linq.Expressions.Expression<System.Func<TModel, System.Collections.Generic.IList<TProp>>>)
    
        
    
        
        Copy from a position in a list to the end of another list
    
        
    
        
        :param from: source location
        
        :type from: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, System.Collections.Generic.IList<System.Collections.Generic.IList`1>{TProp}}}
    
        
        :param positionFrom: position
        
        :type positionFrom: System.Int32
    
        
        :param path: target location
        
        :type path: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, System.Collections.Generic.IList<System.Collections.Generic.IList`1>{TProp}}}
        :rtype: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<Microsoft.AspNetCore.JsonPatch.JsonPatchDocument`1>{TModel}
    
        
        .. code-block:: csharp
    
            public JsonPatchDocument<TModel> Copy<TProp>(Expression<Func<TModel, IList<TProp>>> from, int positionFrom, Expression<Func<TModel, IList<TProp>>> path)
    
    .. dn:method:: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<TModel>.Copy<TProp>(System.Linq.Expressions.Expression<System.Func<TModel, System.Collections.Generic.IList<TProp>>>, System.Int32, System.Linq.Expressions.Expression<System.Func<TModel, System.Collections.Generic.IList<TProp>>>, System.Int32)
    
        
    
        
        Copy from a position in a list to a new location in a list
    
        
    
        
        :param from: source location
        
        :type from: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, System.Collections.Generic.IList<System.Collections.Generic.IList`1>{TProp}}}
    
        
        :param positionFrom: position (source)
        
        :type positionFrom: System.Int32
    
        
        :param path: target location
        
        :type path: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, System.Collections.Generic.IList<System.Collections.Generic.IList`1>{TProp}}}
    
        
        :param positionTo: position (target)
        
        :type positionTo: System.Int32
        :rtype: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<Microsoft.AspNetCore.JsonPatch.JsonPatchDocument`1>{TModel}
    
        
        .. code-block:: csharp
    
            public JsonPatchDocument<TModel> Copy<TProp>(Expression<Func<TModel, IList<TProp>>> from, int positionFrom, Expression<Func<TModel, IList<TProp>>> path, int positionTo)
    
    .. dn:method:: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<TModel>.Copy<TProp>(System.Linq.Expressions.Expression<System.Func<TModel, System.Collections.Generic.IList<TProp>>>, System.Int32, System.Linq.Expressions.Expression<System.Func<TModel, TProp>>)
    
        
    
        
        Copy from a position in a list to a new location
    
        
    
        
        :param from: source location
        
        :type from: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, System.Collections.Generic.IList<System.Collections.Generic.IList`1>{TProp}}}
    
        
        :param positionFrom: position
        
        :type positionFrom: System.Int32
    
        
        :param path: target location
        
        :type path: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, TProp}}
        :rtype: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<Microsoft.AspNetCore.JsonPatch.JsonPatchDocument`1>{TModel}
    
        
        .. code-block:: csharp
    
            public JsonPatchDocument<TModel> Copy<TProp>(Expression<Func<TModel, IList<TProp>>> from, int positionFrom, Expression<Func<TModel, TProp>> path)
    
    .. dn:method:: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<TModel>.Copy<TProp>(System.Linq.Expressions.Expression<System.Func<TModel, TProp>>, System.Linq.Expressions.Expression<System.Func<TModel, System.Collections.Generic.IList<TProp>>>)
    
        
    
        
        Copy to the end of a list
    
        
    
        
        :param from: source location
        
        :type from: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, TProp}}
    
        
        :param path: target location
        
        :type path: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, System.Collections.Generic.IList<System.Collections.Generic.IList`1>{TProp}}}
        :rtype: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<Microsoft.AspNetCore.JsonPatch.JsonPatchDocument`1>{TModel}
    
        
        .. code-block:: csharp
    
            public JsonPatchDocument<TModel> Copy<TProp>(Expression<Func<TModel, TProp>> from, Expression<Func<TModel, IList<TProp>>> path)
    
    .. dn:method:: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<TModel>.Copy<TProp>(System.Linq.Expressions.Expression<System.Func<TModel, TProp>>, System.Linq.Expressions.Expression<System.Func<TModel, System.Collections.Generic.IList<TProp>>>, System.Int32)
    
        
    
        
        Copy from a property to a location in a list
    
        
    
        
        :param from: source location
        
        :type from: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, TProp}}
    
        
        :param path: target location
        
        :type path: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, System.Collections.Generic.IList<System.Collections.Generic.IList`1>{TProp}}}
    
        
        :param positionTo: position
        
        :type positionTo: System.Int32
        :rtype: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<Microsoft.AspNetCore.JsonPatch.JsonPatchDocument`1>{TModel}
    
        
        .. code-block:: csharp
    
            public JsonPatchDocument<TModel> Copy<TProp>(Expression<Func<TModel, TProp>> from, Expression<Func<TModel, IList<TProp>>> path, int positionTo)
    
    .. dn:method:: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<TModel>.Copy<TProp>(System.Linq.Expressions.Expression<System.Func<TModel, TProp>>, System.Linq.Expressions.Expression<System.Func<TModel, TProp>>)
    
        
    
        
        Copy the value at specified location to the target location.  Willr esult in, for example:
        { "op": "copy", "from": "/a/b/c", "path": "/a/b/e" }
    
        
    
        
        :param from: source location
        
        :type from: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, TProp}}
    
        
        :param path: target location
        
        :type path: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, TProp}}
        :rtype: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<Microsoft.AspNetCore.JsonPatch.JsonPatchDocument`1>{TModel}
    
        
        .. code-block:: csharp
    
            public JsonPatchDocument<TModel> Copy<TProp>(Expression<Func<TModel, TProp>> from, Expression<Func<TModel, TProp>> path)
    
    .. dn:method:: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<TModel>.Microsoft.AspNetCore.JsonPatch.IJsonPatchDocument.GetOperations()
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.JsonPatch.Operations.Operation<Microsoft.AspNetCore.JsonPatch.Operations.Operation>}
    
        
        .. code-block:: csharp
    
            IList<Operation> IJsonPatchDocument.GetOperations()
    
    .. dn:method:: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<TModel>.Move<TProp>(System.Linq.Expressions.Expression<System.Func<TModel, System.Collections.Generic.IList<TProp>>>, System.Int32, System.Linq.Expressions.Expression<System.Func<TModel, System.Collections.Generic.IList<TProp>>>)
    
        
    
        
        Move from a position in a list to the end of another list
    
        
    
        
        :param from: source location
        
        :type from: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, System.Collections.Generic.IList<System.Collections.Generic.IList`1>{TProp}}}
    
        
        :param positionFrom: position
        
        :type positionFrom: System.Int32
    
        
        :param path: target location
        
        :type path: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, System.Collections.Generic.IList<System.Collections.Generic.IList`1>{TProp}}}
        :rtype: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<Microsoft.AspNetCore.JsonPatch.JsonPatchDocument`1>{TModel}
    
        
        .. code-block:: csharp
    
            public JsonPatchDocument<TModel> Move<TProp>(Expression<Func<TModel, IList<TProp>>> from, int positionFrom, Expression<Func<TModel, IList<TProp>>> path)
    
    .. dn:method:: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<TModel>.Move<TProp>(System.Linq.Expressions.Expression<System.Func<TModel, System.Collections.Generic.IList<TProp>>>, System.Int32, System.Linq.Expressions.Expression<System.Func<TModel, System.Collections.Generic.IList<TProp>>>, System.Int32)
    
        
    
        
        Move from a position in a list to another location in a list
    
        
    
        
        :param from: source location
        
        :type from: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, System.Collections.Generic.IList<System.Collections.Generic.IList`1>{TProp}}}
    
        
        :param positionFrom: position (source)
        
        :type positionFrom: System.Int32
    
        
        :param path: target location
        
        :type path: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, System.Collections.Generic.IList<System.Collections.Generic.IList`1>{TProp}}}
    
        
        :param positionTo: position (target)
        
        :type positionTo: System.Int32
        :rtype: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<Microsoft.AspNetCore.JsonPatch.JsonPatchDocument`1>{TModel}
    
        
        .. code-block:: csharp
    
            public JsonPatchDocument<TModel> Move<TProp>(Expression<Func<TModel, IList<TProp>>> from, int positionFrom, Expression<Func<TModel, IList<TProp>>> path, int positionTo)
    
    .. dn:method:: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<TModel>.Move<TProp>(System.Linq.Expressions.Expression<System.Func<TModel, System.Collections.Generic.IList<TProp>>>, System.Int32, System.Linq.Expressions.Expression<System.Func<TModel, TProp>>)
    
        
    
        
        Move from a position in a list to a new location
    
        
    
        
        :param from: source location
        
        :type from: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, System.Collections.Generic.IList<System.Collections.Generic.IList`1>{TProp}}}
    
        
        :param positionFrom: position
        
        :type positionFrom: System.Int32
    
        
        :param path: target location
        
        :type path: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, TProp}}
        :rtype: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<Microsoft.AspNetCore.JsonPatch.JsonPatchDocument`1>{TModel}
    
        
        .. code-block:: csharp
    
            public JsonPatchDocument<TModel> Move<TProp>(Expression<Func<TModel, IList<TProp>>> from, int positionFrom, Expression<Func<TModel, TProp>> path)
    
    .. dn:method:: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<TModel>.Move<TProp>(System.Linq.Expressions.Expression<System.Func<TModel, TProp>>, System.Linq.Expressions.Expression<System.Func<TModel, System.Collections.Generic.IList<TProp>>>)
    
        
    
        
        Move to the end of a list
    
        
    
        
        :param from: source location
        
        :type from: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, TProp}}
    
        
        :param path: target location
        
        :type path: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, System.Collections.Generic.IList<System.Collections.Generic.IList`1>{TProp}}}
        :rtype: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<Microsoft.AspNetCore.JsonPatch.JsonPatchDocument`1>{TModel}
    
        
        .. code-block:: csharp
    
            public JsonPatchDocument<TModel> Move<TProp>(Expression<Func<TModel, TProp>> from, Expression<Func<TModel, IList<TProp>>> path)
    
    .. dn:method:: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<TModel>.Move<TProp>(System.Linq.Expressions.Expression<System.Func<TModel, TProp>>, System.Linq.Expressions.Expression<System.Func<TModel, System.Collections.Generic.IList<TProp>>>, System.Int32)
    
        
    
        
        Move from a property to a location in a list
    
        
    
        
        :param from: source location
        
        :type from: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, TProp}}
    
        
        :param path: target location
        
        :type path: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, System.Collections.Generic.IList<System.Collections.Generic.IList`1>{TProp}}}
    
        
        :param positionTo: position
        
        :type positionTo: System.Int32
        :rtype: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<Microsoft.AspNetCore.JsonPatch.JsonPatchDocument`1>{TModel}
    
        
        .. code-block:: csharp
    
            public JsonPatchDocument<TModel> Move<TProp>(Expression<Func<TModel, TProp>> from, Expression<Func<TModel, IList<TProp>>> path, int positionTo)
    
    .. dn:method:: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<TModel>.Move<TProp>(System.Linq.Expressions.Expression<System.Func<TModel, TProp>>, System.Linq.Expressions.Expression<System.Func<TModel, TProp>>)
    
        
    
        
        Removes value at specified location and add it to the target location.  Will result in, for example:
        { "op": "move", "from": "/a/b/c", "path": "/a/b/d" }
    
        
    
        
        :param from: source location
        
        :type from: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, TProp}}
    
        
        :param path: target location
        
        :type path: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, TProp}}
        :rtype: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<Microsoft.AspNetCore.JsonPatch.JsonPatchDocument`1>{TModel}
    
        
        .. code-block:: csharp
    
            public JsonPatchDocument<TModel> Move<TProp>(Expression<Func<TModel, TProp>> from, Expression<Func<TModel, TProp>> path)
    
    .. dn:method:: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<TModel>.Remove<TProp>(System.Linq.Expressions.Expression<System.Func<TModel, System.Collections.Generic.IList<TProp>>>)
    
        
    
        
        Remove value from end of list
    
        
    
        
        :param path: target location
        
        :type path: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, System.Collections.Generic.IList<System.Collections.Generic.IList`1>{TProp}}}
        :rtype: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<Microsoft.AspNetCore.JsonPatch.JsonPatchDocument`1>{TModel}
    
        
        .. code-block:: csharp
    
            public JsonPatchDocument<TModel> Remove<TProp>(Expression<Func<TModel, IList<TProp>>> path)
    
    .. dn:method:: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<TModel>.Remove<TProp>(System.Linq.Expressions.Expression<System.Func<TModel, System.Collections.Generic.IList<TProp>>>, System.Int32)
    
        
    
        
        Remove value from list at given position
    
        
    
        
        :param path: target location
        
        :type path: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, System.Collections.Generic.IList<System.Collections.Generic.IList`1>{TProp}}}
    
        
        :param position: position
        
        :type position: System.Int32
        :rtype: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<Microsoft.AspNetCore.JsonPatch.JsonPatchDocument`1>{TModel}
    
        
        .. code-block:: csharp
    
            public JsonPatchDocument<TModel> Remove<TProp>(Expression<Func<TModel, IList<TProp>>> path, int position)
    
    .. dn:method:: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<TModel>.Remove<TProp>(System.Linq.Expressions.Expression<System.Func<TModel, TProp>>)
    
        
    
        
        Remove value at target location.  Will result in, for example,
        { "op": "remove", "path": "/a/b/c" }
    
        
    
        
        :param path: target location
        
        :type path: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, TProp}}
        :rtype: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<Microsoft.AspNetCore.JsonPatch.JsonPatchDocument`1>{TModel}
    
        
        .. code-block:: csharp
    
            public JsonPatchDocument<TModel> Remove<TProp>(Expression<Func<TModel, TProp>> path)
    
    .. dn:method:: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<TModel>.Replace<TProp>(System.Linq.Expressions.Expression<System.Func<TModel, System.Collections.Generic.IList<TProp>>>, TProp)
    
        
    
        
        Replace value at end of a list
    
        
    
        
        :param path: target location
        
        :type path: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, System.Collections.Generic.IList<System.Collections.Generic.IList`1>{TProp}}}
    
        
        :param value: value
        
        :type value: TProp
        :rtype: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<Microsoft.AspNetCore.JsonPatch.JsonPatchDocument`1>{TModel}
    
        
        .. code-block:: csharp
    
            public JsonPatchDocument<TModel> Replace<TProp>(Expression<Func<TModel, IList<TProp>>> path, TProp value)
    
    .. dn:method:: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<TModel>.Replace<TProp>(System.Linq.Expressions.Expression<System.Func<TModel, System.Collections.Generic.IList<TProp>>>, TProp, System.Int32)
    
        
    
        
        Replace value in a list at given position
    
        
    
        
        :param path: target location
        
        :type path: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, System.Collections.Generic.IList<System.Collections.Generic.IList`1>{TProp}}}
    
        
        :param value: value
        
        :type value: TProp
    
        
        :param position: position
        
        :type position: System.Int32
        :rtype: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<Microsoft.AspNetCore.JsonPatch.JsonPatchDocument`1>{TModel}
    
        
        .. code-block:: csharp
    
            public JsonPatchDocument<TModel> Replace<TProp>(Expression<Func<TModel, IList<TProp>>> path, TProp value, int position)
    
    .. dn:method:: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<TModel>.Replace<TProp>(System.Linq.Expressions.Expression<System.Func<TModel, TProp>>, TProp)
    
        
    
        
        Replace value.  Will result in, for example,
        { "op": "replace", "path": "/a/b/c", "value": 42 }
    
        
    
        
        :param path: target location
        
        :type path: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, TProp}}
    
        
        :param value: value
        
        :type value: TProp
        :rtype: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<Microsoft.AspNetCore.JsonPatch.JsonPatchDocument`1>{TModel}
    
        
        .. code-block:: csharp
    
            public JsonPatchDocument<TModel> Replace<TProp>(Expression<Func<TModel, TProp>> path, TProp value)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<TModel>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<TModel>.ContractResolver
    
        
        :rtype: Newtonsoft.Json.Serialization.IContractResolver
    
        
        .. code-block:: csharp
    
            [JsonIgnore]
            public IContractResolver ContractResolver { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<TModel>.Operations
    
        
        :rtype: System.Collections.Generic.List<System.Collections.Generic.List`1>{Microsoft.AspNetCore.JsonPatch.Operations.Operation<Microsoft.AspNetCore.JsonPatch.Operations.Operation`1>{TModel}}
    
        
        .. code-block:: csharp
    
            public List<Operation<TModel>> Operations { get; }
    

