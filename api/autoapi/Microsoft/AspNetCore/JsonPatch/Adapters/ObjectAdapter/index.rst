

ObjectAdapter Class
===================





Namespace
    :dn:ns:`Microsoft.AspNetCore.JsonPatch.Adapters`
Assemblies
    * Microsoft.AspNetCore.JsonPatch

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.JsonPatch.Adapters.ObjectAdapter`








Syntax
------

.. code-block:: csharp

    public class ObjectAdapter : IObjectAdapter








.. dn:class:: Microsoft.AspNetCore.JsonPatch.Adapters.ObjectAdapter
    :hidden:

.. dn:class:: Microsoft.AspNetCore.JsonPatch.Adapters.ObjectAdapter

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.JsonPatch.Adapters.ObjectAdapter
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.JsonPatch.Adapters.ObjectAdapter.ObjectAdapter(Newtonsoft.Json.Serialization.IContractResolver, System.Action<Microsoft.AspNetCore.JsonPatch.JsonPatchError>)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.JsonPatch.Adapters.ObjectAdapter`\.
    
        
    
        
        :param contractResolver: The :any:`Newtonsoft.Json.Serialization.IContractResolver`\.
        
        :type contractResolver: Newtonsoft.Json.Serialization.IContractResolver
    
        
        :param logErrorAction: The :any:`System.Action` for logging :any:`Microsoft.AspNetCore.JsonPatch.JsonPatchError`\.
        
        :type logErrorAction: System.Action<System.Action`1>{Microsoft.AspNetCore.JsonPatch.JsonPatchError<Microsoft.AspNetCore.JsonPatch.JsonPatchError>}
    
        
        .. code-block:: csharp
    
            public ObjectAdapter(IContractResolver contractResolver, Action<JsonPatchError> logErrorAction)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.JsonPatch.Adapters.ObjectAdapter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.JsonPatch.Adapters.ObjectAdapter.Add(Microsoft.AspNetCore.JsonPatch.Operations.Operation, System.Object)
    
        
    
        
        The "add" operation performs one of the following functions,
        depending upon what the target location references:
        
        o  If the target location specifies an array index, a new value is
           inserted into the array at the specified index.
        
        o  If the target location specifies an object member that does not
           already exist, a new member is added to the object.
        
        o  If the target location specifies an object member that does exist,
           that member's value is replaced.
        
        The operation object MUST contain a "value" member whose content
        specifies the value to be added.
        
        For example:
        
        { "op": "add", "path": "/a/b/c", "value": [ "foo", "bar" ] }
        
        When the operation is applied, the target location MUST reference one
        of:
        
        o  The root of the target document - whereupon the specified value
           becomes the entire content of the target document.
        
        o  A member to add to an existing object - whereupon the supplied
           value is added to that object at the indicated location.  If the
           member already exists, it is replaced by the specified value.
        
        o  An element to add to an existing array - whereupon the supplied
           value is added to the array at the indicated location.  Any
           elements at or above the specified index are shifted one position
           to the right.  The specified index MUST NOT be greater than the
           number of elements in the array.  If the "-" character is used to
           index the end of the array (see [RFC6901]), this has the effect of
           appending the value to the array.
        
        Because this operation is designed to add to existing objects and
        arrays, its target location will often not exist.  Although the
        pointer's error handling algorithm will thus be invoked, this
        specification defines the error handling behavior for "add" pointers
        to ignore that error and add the value as specified.
        
        However, the object itself or an array containing it does need to
        exist, and it remains an error for that not to be the case.  For
        example, an "add" with a target location of "/a/b" starting with this
        document:
        
        { "a": { "foo": 1 } }
        
        is not an error, because "a" exists, and "b" will be added to its
        value.  It is an error in this document:
        
        { "q": { "bar": 2 } }
        
        because "a" does not exist.
    
        
    
        
        :param operation: The add operation.
        
        :type operation: Microsoft.AspNetCore.JsonPatch.Operations.Operation
    
        
        :param objectToApplyTo: Object to apply the operation to.
        
        :type objectToApplyTo: System.Object
    
        
        .. code-block:: csharp
    
            public void Add(Operation operation, object objectToApplyTo)
    
    .. dn:method:: Microsoft.AspNetCore.JsonPatch.Adapters.ObjectAdapter.Copy(Microsoft.AspNetCore.JsonPatch.Operations.Operation, System.Object)
    
        
    
        
         The "copy" operation copies the value at a specified location to the
         target location.
        
         The operation object MUST contain a "from" member, which is a string
         containing a JSON Pointer value that references the location in the
         target document to copy the value from.
        
         The "from" location MUST exist for the operation to be successful.
        
         For example:
        
         { "op": "copy", "from": "/a/b/c", "path": "/a/b/e" }
        
         This operation is functionally identical to an "add" operation at the
         target location using the value specified in the "from" member.
        
         Note: even though it's the same functionally, we do not call add with
         the value specified in from for performance reasons (multiple checks of same requirements).
    
        
    
        
        :param operation: The copy operation.
        
        :type operation: Microsoft.AspNetCore.JsonPatch.Operations.Operation
    
        
        :param objectToApplyTo: Object to apply the operation to.
        
        :type objectToApplyTo: System.Object
    
        
        .. code-block:: csharp
    
            public void Copy(Operation operation, object objectToApplyTo)
    
    .. dn:method:: Microsoft.AspNetCore.JsonPatch.Adapters.ObjectAdapter.Move(Microsoft.AspNetCore.JsonPatch.Operations.Operation, System.Object)
    
        
    
        
        The "move" operation removes the value at a specified location and
        adds it to the target location.
        
        The operation object MUST contain a "from" member, which is a string
        containing a JSON Pointer value that references the location in the
        target document to move the value from.
        
        The "from" location MUST exist for the operation to be successful.
        
        For example:
        
        { "op": "move", "from": "/a/b/c", "path": "/a/b/d" }
        
        This operation is functionally identical to a "remove" operation on
        the "from" location, followed immediately by an "add" operation at
        the target location with the value that was just removed.
        
        The "from" location MUST NOT be a proper prefix of the "path"
        location; i.e., a location cannot be moved into one of its children.
    
        
    
        
        :param operation: The move operation.
        
        :type operation: Microsoft.AspNetCore.JsonPatch.Operations.Operation
    
        
        :param objectToApplyTo: Object to apply the operation to.
        
        :type objectToApplyTo: System.Object
    
        
        .. code-block:: csharp
    
            public void Move(Operation operation, object objectToApplyTo)
    
    .. dn:method:: Microsoft.AspNetCore.JsonPatch.Adapters.ObjectAdapter.Remove(Microsoft.AspNetCore.JsonPatch.Operations.Operation, System.Object)
    
        
    
        
        The "remove" operation removes the value at the target location.
        
        The target location MUST exist for the operation to be successful.
        
        For example:
        
        { "op": "remove", "path": "/a/b/c" }
        
        If removing an element from an array, any elements above the
        specified index are shifted one position to the left.
    
        
    
        
        :param operation: The remove operation.
        
        :type operation: Microsoft.AspNetCore.JsonPatch.Operations.Operation
    
        
        :param objectToApplyTo: Object to apply the operation to.
        
        :type objectToApplyTo: System.Object
    
        
        .. code-block:: csharp
    
            public void Remove(Operation operation, object objectToApplyTo)
    
    .. dn:method:: Microsoft.AspNetCore.JsonPatch.Adapters.ObjectAdapter.Replace(Microsoft.AspNetCore.JsonPatch.Operations.Operation, System.Object)
    
        
    
        
        The "replace" operation replaces the value at the target location
        with a new value.  The operation object MUST contain a "value" member
        whose content specifies the replacement value.
        
        The target location MUST exist for the operation to be successful.
        
        For example:
        
        { "op": "replace", "path": "/a/b/c", "value": 42 }
        
        This operation is functionally identical to a "remove" operation for
        a value, followed immediately by an "add" operation at the same
        location with the replacement value.
        
        Note: even though it's the same functionally, we do not call remove + add
        for performance reasons (multiple checks of same requirements).
    
        
    
        
        :param operation: The replace operation.
        
        :type operation: Microsoft.AspNetCore.JsonPatch.Operations.Operation
    
        
        :param objectToApplyTo: Object to apply the operation to.
        
        :type objectToApplyTo: System.Object
    
        
        .. code-block:: csharp
    
            public void Replace(Operation operation, object objectToApplyTo)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.JsonPatch.Adapters.ObjectAdapter
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.JsonPatch.Adapters.ObjectAdapter.ContractResolver
    
        
    
        
        Gets or sets the :any:`Newtonsoft.Json.Serialization.IContractResolver`\.
    
        
        :rtype: Newtonsoft.Json.Serialization.IContractResolver
    
        
        .. code-block:: csharp
    
            public IContractResolver ContractResolver { get; }
    
    .. dn:property:: Microsoft.AspNetCore.JsonPatch.Adapters.ObjectAdapter.LogErrorAction
    
        
    
        
        Action for logging :any:`Microsoft.AspNetCore.JsonPatch.JsonPatchError`\.
    
        
        :rtype: System.Action<System.Action`1>{Microsoft.AspNetCore.JsonPatch.JsonPatchError<Microsoft.AspNetCore.JsonPatch.JsonPatchError>}
    
        
        .. code-block:: csharp
    
            public Action<JsonPatchError> LogErrorAction { get; }
    

