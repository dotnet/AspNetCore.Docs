

JsonPatchException Class
========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Exception`
* :dn:cls:`Microsoft.AspNet.JsonPatch.Exceptions.JsonPatchException`








Syntax
------

.. code-block:: csharp

   public class JsonPatchException : Exception, ISerializable, _Exception





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/jsonpatch/src/Microsoft.AspNet.JsonPatch/Exceptions/JsonPatchException.cs>`_





.. dn:class:: Microsoft.AspNet.JsonPatch.Exceptions.JsonPatchException

Constructors
------------

.. dn:class:: Microsoft.AspNet.JsonPatch.Exceptions.JsonPatchException
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.JsonPatch.Exceptions.JsonPatchException.JsonPatchException()
    
        
    
        
        .. code-block:: csharp
    
           public JsonPatchException()
    
    .. dn:constructor:: Microsoft.AspNet.JsonPatch.Exceptions.JsonPatchException.JsonPatchException(Microsoft.AspNet.JsonPatch.JsonPatchError)
    
        
        
        
        :type jsonPatchError: Microsoft.AspNet.JsonPatch.JsonPatchError
    
        
        .. code-block:: csharp
    
           public JsonPatchException(JsonPatchError jsonPatchError)
    
    .. dn:constructor:: Microsoft.AspNet.JsonPatch.Exceptions.JsonPatchException.JsonPatchException(Microsoft.AspNet.JsonPatch.JsonPatchError, System.Exception)
    
        
        
        
        :type jsonPatchError: Microsoft.AspNet.JsonPatch.JsonPatchError
        
        
        :type innerException: System.Exception
    
        
        .. code-block:: csharp
    
           public JsonPatchException(JsonPatchError jsonPatchError, Exception innerException)
    
    .. dn:constructor:: Microsoft.AspNet.JsonPatch.Exceptions.JsonPatchException.JsonPatchException(System.String, System.Exception)
    
        
        
        
        :type message: System.String
        
        
        :type innerException: System.Exception
    
        
        .. code-block:: csharp
    
           public JsonPatchException(string message, Exception innerException)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.JsonPatch.Exceptions.JsonPatchException
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.JsonPatch.Exceptions.JsonPatchException.AffectedObject
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           public object AffectedObject { get; }
    
    .. dn:property:: Microsoft.AspNet.JsonPatch.Exceptions.JsonPatchException.FailedOperation
    
        
        :rtype: Microsoft.AspNet.JsonPatch.Operations.Operation
    
        
        .. code-block:: csharp
    
           public Operation FailedOperation { get; }
    

