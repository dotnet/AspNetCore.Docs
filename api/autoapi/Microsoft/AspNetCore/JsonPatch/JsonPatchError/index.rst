

JsonPatchError Class
====================






Captures error message and the related entity and the operation that caused it.


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
* :dn:cls:`Microsoft.AspNetCore.JsonPatch.JsonPatchError`








Syntax
------

.. code-block:: csharp

    public class JsonPatchError








.. dn:class:: Microsoft.AspNetCore.JsonPatch.JsonPatchError
    :hidden:

.. dn:class:: Microsoft.AspNetCore.JsonPatch.JsonPatchError

Properties
----------

.. dn:class:: Microsoft.AspNetCore.JsonPatch.JsonPatchError
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.JsonPatch.JsonPatchError.AffectedObject
    
        
    
        
        Gets the object that is affected by the error.
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            public object AffectedObject
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.JsonPatch.JsonPatchError.ErrorMessage
    
        
    
        
        Gets the error message.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ErrorMessage
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.JsonPatch.JsonPatchError.Operation
    
        
    
        
        Gets the :dn:prop:`Microsoft.AspNetCore.JsonPatch.JsonPatchError.Operation` that caused the error.
    
        
        :rtype: Microsoft.AspNetCore.JsonPatch.Operations.Operation
    
        
        .. code-block:: csharp
    
            public Operation Operation
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.JsonPatch.JsonPatchError
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.JsonPatch.JsonPatchError.JsonPatchError(System.Object, Microsoft.AspNetCore.JsonPatch.Operations.Operation, System.String)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.JsonPatch.JsonPatchError`\.
    
        
    
        
        :param affectedObject: The object that is affected by the error.
        
        :type affectedObject: System.Object
    
        
        :param operation: The :dn:prop:`Microsoft.AspNetCore.JsonPatch.JsonPatchError.Operation` that caused the error.
        
        :type operation: Microsoft.AspNetCore.JsonPatch.Operations.Operation
    
        
        :param errorMessage: The error message.
        
        :type errorMessage: System.String
    
        
        .. code-block:: csharp
    
            public JsonPatchError(object affectedObject, Operation operation, string errorMessage)
    

