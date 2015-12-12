

IAntiforgeryAdditionalDataProvider Interface
============================================



.. contents:: 
   :local:



Summary
-------

Allows providing or validating additional custom data for antiforgery tokens.
For example, the developer could use this to supply a nonce when the token is
generated, then he could validate the nonce when the token is validated.











Syntax
------

.. code-block:: csharp

   public interface IAntiforgeryAdditionalDataProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/antiforgery/src/Microsoft.AspNet.Antiforgery/IAntiforgeryAdditionalDataProvider.cs>`_





.. dn:interface:: Microsoft.AspNet.Antiforgery.IAntiforgeryAdditionalDataProvider

Methods
-------

.. dn:interface:: Microsoft.AspNet.Antiforgery.IAntiforgeryAdditionalDataProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Antiforgery.IAntiforgeryAdditionalDataProvider.GetAdditionalData(Microsoft.AspNet.Http.HttpContext)
    
        
    
        Provides additional data to be stored for the antiforgery tokens generated
        during this request.
    
        
        
        
        :param context: Information about the current request.
        
        :type context: Microsoft.AspNet.Http.HttpContext
        :rtype: System.String
        :return: Supplemental data to embed within the antiforgery token.
    
        
        .. code-block:: csharp
    
           string GetAdditionalData(HttpContext context)
    
    .. dn:method:: Microsoft.AspNet.Antiforgery.IAntiforgeryAdditionalDataProvider.ValidateAdditionalData(Microsoft.AspNet.Http.HttpContext, System.String)
    
        
    
        Validates additional data that was embedded inside an incoming antiforgery
        token.
    
        
        
        
        :param context: Information about the current request.
        
        :type context: Microsoft.AspNet.Http.HttpContext
        
        
        :param additionalData: Supplemental data that was embedded within the token.
        
        :type additionalData: System.String
        :rtype: System.Boolean
        :return: True if the data is valid; false if the data is invalid.
    
        
        .. code-block:: csharp
    
           bool ValidateAdditionalData(HttpContext context, string additionalData)
    

