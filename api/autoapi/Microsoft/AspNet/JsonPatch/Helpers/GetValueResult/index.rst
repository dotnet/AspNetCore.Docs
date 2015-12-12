

GetValueResult Class
====================



.. contents:: 
   :local:



Summary
-------

Return value for the helper method used by Copy/Move.  Needed to ensure we can make a different
decision in the calling method when the value is null because it cannot be fetched (HasError = true)
versus when it actually is null (much like why RemovedPropertyTypeResult is used for returning
type in the Remove operation).





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.JsonPatch.Helpers.GetValueResult`








Syntax
------

.. code-block:: csharp

   public class GetValueResult





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/jsonpatch/src/Microsoft.AspNet.JsonPatch/Helpers/GetValueResult.cs>`_





.. dn:class:: Microsoft.AspNet.JsonPatch.Helpers.GetValueResult

Constructors
------------

.. dn:class:: Microsoft.AspNet.JsonPatch.Helpers.GetValueResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.JsonPatch.Helpers.GetValueResult.GetValueResult(System.Object, System.Boolean)
    
        
        
        
        :type propertyValue: System.Object
        
        
        :type hasError: System.Boolean
    
        
        .. code-block:: csharp
    
           public GetValueResult(object propertyValue, bool hasError)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.JsonPatch.Helpers.GetValueResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.JsonPatch.Helpers.GetValueResult.HasError
    
        
    
        HasError: true when an error occurred, the operation didn't complete succesfully
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool HasError { get; }
    
    .. dn:property:: Microsoft.AspNet.JsonPatch.Helpers.GetValueResult.PropertyValue
    
        
    
        The value of the property we're trying to get
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           public object PropertyValue { get; }
    

