

GetValueResult Class
====================






Return value for the helper method used by Copy/Move.  Needed to ensure we can make a different
decision in the calling method when the value is null because it cannot be fetched (HasError = true) 
versus when it actually is null (much like why RemovedPropertyTypeResult is used for returning 
type in the Remove operation).


Namespace
    :dn:ns:`Microsoft.AspNetCore.JsonPatch.Helpers`
Assemblies
    * Microsoft.AspNetCore.JsonPatch

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.JsonPatch.Helpers.GetValueResult`








Syntax
------

.. code-block:: csharp

    public class GetValueResult








.. dn:class:: Microsoft.AspNetCore.JsonPatch.Helpers.GetValueResult
    :hidden:

.. dn:class:: Microsoft.AspNetCore.JsonPatch.Helpers.GetValueResult

Properties
----------

.. dn:class:: Microsoft.AspNetCore.JsonPatch.Helpers.GetValueResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.JsonPatch.Helpers.GetValueResult.HasError
    
        
    
        
        HasError: true when an error occurred, the operation didn't complete succesfully
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool HasError
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.JsonPatch.Helpers.GetValueResult.PropertyValue
    
        
    
        
        The value of the property we're trying to get
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            public object PropertyValue
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.JsonPatch.Helpers.GetValueResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.JsonPatch.Helpers.GetValueResult.GetValueResult(System.Object, System.Boolean)
    
        
    
        
        :type propertyValue: System.Object
    
        
        :type hasError: System.Boolean
    
        
        .. code-block:: csharp
    
            public GetValueResult(object propertyValue, bool hasError)
    

