

ModelClientValidationRemoteRule Class
=====================================



.. contents:: 
   :local:



Summary
-------

:any:`Microsoft.AspNet.Mvc.ModelBinding.Validation.ModelClientValidationRule` containing information for HTML attribute generation in fields a 
:any:`Microsoft.AspNet.Mvc.RemoteAttribute` targets.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.Validation.ModelClientValidationRule`
* :dn:cls:`Microsoft.AspNet.Mvc.Internal.ModelClientValidationRemoteRule`








Syntax
------

.. code-block:: csharp

   public class ModelClientValidationRemoteRule : ModelClientValidationRule





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.ViewFeatures/Internal/ModelClientValidationRemoteRule.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Internal.ModelClientValidationRemoteRule

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Internal.ModelClientValidationRemoteRule
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Internal.ModelClientValidationRemoteRule.ModelClientValidationRemoteRule(System.String, System.String, System.String, System.String)
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Mvc.Internal.ModelClientValidationRemoteRule` class.
    
        
        
        
        :param errorMessage: Error message client should display when validation fails.
        
        :type errorMessage: System.String
        
        
        :param url: URL where client should send a validation request.
        
        :type url: System.String
        
        
        :param httpMethod: HTTP method ("GET" or "POST") client should use when sending a validation request.
        
        :type httpMethod: System.String
        
        
        :param additionalFields: Comma-separated names of fields the client should include in a validation request.
        
        :type additionalFields: System.String
    
        
        .. code-block:: csharp
    
           public ModelClientValidationRemoteRule(string errorMessage, string url, string httpMethod, string additionalFields)
    

