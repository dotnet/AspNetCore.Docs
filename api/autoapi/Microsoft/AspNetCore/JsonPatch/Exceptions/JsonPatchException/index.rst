

JsonPatchException Class
========================





Namespace
    :dn:ns:`Microsoft.AspNetCore.JsonPatch.Exceptions`
Assemblies
    * Microsoft.AspNetCore.JsonPatch

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Exception`
* :dn:cls:`Microsoft.AspNetCore.JsonPatch.Exceptions.JsonPatchException`








Syntax
------

.. code-block:: csharp

    public class JsonPatchException : Exception








.. dn:class:: Microsoft.AspNetCore.JsonPatch.Exceptions.JsonPatchException
    :hidden:

.. dn:class:: Microsoft.AspNetCore.JsonPatch.Exceptions.JsonPatchException

Properties
----------

.. dn:class:: Microsoft.AspNetCore.JsonPatch.Exceptions.JsonPatchException
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.JsonPatch.Exceptions.JsonPatchException.AffectedObject
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            public object AffectedObject
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.JsonPatch.Exceptions.JsonPatchException.FailedOperation
    
        
        :rtype: Microsoft.AspNetCore.JsonPatch.Operations.Operation
    
        
        .. code-block:: csharp
    
            public Operation FailedOperation
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.JsonPatch.Exceptions.JsonPatchException
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.JsonPatch.Exceptions.JsonPatchException.JsonPatchException()
    
        
    
        
        .. code-block:: csharp
    
            public JsonPatchException()
    
    .. dn:constructor:: Microsoft.AspNetCore.JsonPatch.Exceptions.JsonPatchException.JsonPatchException(Microsoft.AspNetCore.JsonPatch.JsonPatchError)
    
        
    
        
        :type jsonPatchError: Microsoft.AspNetCore.JsonPatch.JsonPatchError
    
        
        .. code-block:: csharp
    
            public JsonPatchException(JsonPatchError jsonPatchError)
    
    .. dn:constructor:: Microsoft.AspNetCore.JsonPatch.Exceptions.JsonPatchException.JsonPatchException(Microsoft.AspNetCore.JsonPatch.JsonPatchError, System.Exception)
    
        
    
        
        :type jsonPatchError: Microsoft.AspNetCore.JsonPatch.JsonPatchError
    
        
        :type innerException: System.Exception
    
        
        .. code-block:: csharp
    
            public JsonPatchException(JsonPatchError jsonPatchError, Exception innerException)
    
    .. dn:constructor:: Microsoft.AspNetCore.JsonPatch.Exceptions.JsonPatchException.JsonPatchException(System.String, System.Exception)
    
        
    
        
        :type message: System.String
    
        
        :type innerException: System.Exception
    
        
        .. code-block:: csharp
    
            public JsonPatchException(string message, Exception innerException)
    

