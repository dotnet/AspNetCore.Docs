

JsonPatchDocument Class
=======================





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
* :dn:cls:`Microsoft.AspNetCore.JsonPatch.JsonPatchDocument`








Syntax
------

.. code-block:: csharp

    [JsonConverter(typeof (JsonPatchDocumentConverter))]
    public class JsonPatchDocument : IJsonPatchDocument








.. dn:class:: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument
    :hidden:

.. dn:class:: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument

Properties
----------

.. dn:class:: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument.ContractResolver
    
        
        :rtype: Newtonsoft.Json.Serialization.IContractResolver
    
        
        .. code-block:: csharp
    
            [JsonIgnore]
            public IContractResolver ContractResolver
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument.Operations
    
        
        :rtype: System.Collections.Generic.List<System.Collections.Generic.List`1>{Microsoft.AspNetCore.JsonPatch.Operations.Operation<Microsoft.AspNetCore.JsonPatch.Operations.Operation>}
    
        
        .. code-block:: csharp
    
            public List<Operation> Operations
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument.JsonPatchDocument()
    
        
    
        
        .. code-block:: csharp
    
            public JsonPatchDocument()
    
    .. dn:constructor:: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument.JsonPatchDocument(System.Collections.Generic.List<Microsoft.AspNetCore.JsonPatch.Operations.Operation>, Newtonsoft.Json.Serialization.IContractResolver)
    
        
    
        
        :type operations: System.Collections.Generic.List<System.Collections.Generic.List`1>{Microsoft.AspNetCore.JsonPatch.Operations.Operation<Microsoft.AspNetCore.JsonPatch.Operations.Operation>}
    
        
        :type contractResolver: Newtonsoft.Json.Serialization.IContractResolver
    
        
        .. code-block:: csharp
    
            public JsonPatchDocument(List<Operation> operations, IContractResolver contractResolver)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument.Add(System.String, System.Object)
    
        
    
        
        Add operation.  Will result in, for example,
        { "op": "add", "path": "/a/b/c", "value": [ "foo", "bar" ] }
    
        
    
        
        :param path: target location
        
        :type path: System.String
    
        
        :param value: value
        
        :type value: System.Object
        :rtype: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument
    
        
        .. code-block:: csharp
    
            public JsonPatchDocument Add(string path, object value)
    
    .. dn:method:: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument.ApplyTo(System.Object)
    
        
    
        
        Apply this JsonPatchDocument 
    
        
    
        
        :param objectToApplyTo: Object to apply the JsonPatchDocument to
        
        :type objectToApplyTo: System.Object
    
        
        .. code-block:: csharp
    
            public void ApplyTo(object objectToApplyTo)
    
    .. dn:method:: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument.ApplyTo(System.Object, Microsoft.AspNetCore.JsonPatch.Adapters.IObjectAdapter)
    
        
    
        
        Apply this JsonPatchDocument  
    
        
    
        
        :param objectToApplyTo: Object to apply the JsonPatchDocument to
        
        :type objectToApplyTo: System.Object
    
        
        :param adapter: IObjectAdapter instance to use when applying
        
        :type adapter: Microsoft.AspNetCore.JsonPatch.Adapters.IObjectAdapter
    
        
        .. code-block:: csharp
    
            public void ApplyTo(object objectToApplyTo, IObjectAdapter adapter)
    
    .. dn:method:: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument.ApplyTo(System.Object, System.Action<Microsoft.AspNetCore.JsonPatch.JsonPatchError>)
    
        
    
        
        Apply this JsonPatchDocument 
    
        
    
        
        :param objectToApplyTo: Object to apply the JsonPatchDocument to
        
        :type objectToApplyTo: System.Object
    
        
        :param logErrorAction: Action to log errors
        
        :type logErrorAction: System.Action<System.Action`1>{Microsoft.AspNetCore.JsonPatch.JsonPatchError<Microsoft.AspNetCore.JsonPatch.JsonPatchError>}
    
        
        .. code-block:: csharp
    
            public void ApplyTo(object objectToApplyTo, Action<JsonPatchError> logErrorAction)
    
    .. dn:method:: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument.Copy(System.String, System.String)
    
        
    
        
        Copy the value at specified location to the target location.  Willr esult in, for example:
        { "op": "copy", "from": "/a/b/c", "path": "/a/b/e" }
    
        
    
        
        :param from: source location
        
        :type from: System.String
    
        
        :param path: target location
        
        :type path: System.String
        :rtype: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument
    
        
        .. code-block:: csharp
    
            public JsonPatchDocument Copy(string from, string path)
    
    .. dn:method:: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument.Microsoft.AspNetCore.JsonPatch.IJsonPatchDocument.GetOperations()
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.JsonPatch.Operations.Operation<Microsoft.AspNetCore.JsonPatch.Operations.Operation>}
    
        
        .. code-block:: csharp
    
            IList<Operation> IJsonPatchDocument.GetOperations()
    
    .. dn:method:: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument.Move(System.String, System.String)
    
        
    
        
        Removes value at specified location and add it to the target location.  Will result in, for example:
        { "op": "move", "from": "/a/b/c", "path": "/a/b/d" }
    
        
    
        
        :param from: source location
        
        :type from: System.String
    
        
        :param path: target location
        
        :type path: System.String
        :rtype: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument
    
        
        .. code-block:: csharp
    
            public JsonPatchDocument Move(string from, string path)
    
    .. dn:method:: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument.Remove(System.String)
    
        
    
        
        Remove value at target location.  Will result in, for example,
        { "op": "remove", "path": "/a/b/c" }
    
        
    
        
        :param path: target location
        
        :type path: System.String
        :rtype: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument
    
        
        .. code-block:: csharp
    
            public JsonPatchDocument Remove(string path)
    
    .. dn:method:: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument.Replace(System.String, System.Object)
    
        
    
        
        Replace value.  Will result in, for example,
        { "op": "replace", "path": "/a/b/c", "value": 42 }
    
        
    
        
        :param path: target location
        
        :type path: System.String
    
        
        :param value: value
        
        :type value: System.Object
        :rtype: Microsoft.AspNetCore.JsonPatch.JsonPatchDocument
    
        
        .. code-block:: csharp
    
            public JsonPatchDocument Replace(string path, object value)
    

