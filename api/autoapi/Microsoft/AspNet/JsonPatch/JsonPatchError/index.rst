

JsonPatchError Class
====================



.. contents:: 
   :local:



Summary
-------

Captures error message and the related entity and the operation that caused it.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.JsonPatch.JsonPatchError`








Syntax
------

.. code-block:: csharp

   public class JsonPatchError





GitHub
------

`View on GitHub <https://github.com/aspnet/jsonpatch/blob/master/src/Microsoft.AspNet.JsonPatch/JsonPatchError.cs>`_





.. dn:class:: Microsoft.AspNet.JsonPatch.JsonPatchError

Constructors
------------

.. dn:class:: Microsoft.AspNet.JsonPatch.JsonPatchError
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.JsonPatch.JsonPatchError.JsonPatchError(System.Object, Microsoft.AspNet.JsonPatch.Operations.Operation, System.String)
    
        
    
        Initializes a new instance of :any:`Microsoft.AspNet.JsonPatch.JsonPatchError`\.
    
        
        
        
        :param affectedObject: The object that is affected by the error.
        
        :type affectedObject: System.Object
        
        
        :param operation: The  that caused the error.
        
        :type operation: Microsoft.AspNet.JsonPatch.Operations.Operation
        
        
        :param errorMessage: The error message.
        
        :type errorMessage: System.String
    
        
        .. code-block:: csharp
    
           public JsonPatchError(object affectedObject, Operation operation, string errorMessage)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.JsonPatch.JsonPatchError
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.JsonPatch.JsonPatchError.AffectedObject
    
        
    
        Gets the object that is affected by the error.
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           public object AffectedObject { get; }
    
    .. dn:property:: Microsoft.AspNet.JsonPatch.JsonPatchError.ErrorMessage
    
        
    
        Gets the error message.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ErrorMessage { get; }
    
    .. dn:property:: Microsoft.AspNet.JsonPatch.JsonPatchError.Operation
    
        
    
        Gets the :dn:prop:`Microsoft.AspNet.JsonPatch.JsonPatchError.Operation` that caused the error.
    
        
        :rtype: Microsoft.AspNet.JsonPatch.Operations.Operation
    
        
        .. code-block:: csharp
    
           public Operation Operation { get; }
    

