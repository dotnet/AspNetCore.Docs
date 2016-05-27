

IAntiforgeryAdditionalDataProvider Interface
============================================






Allows providing or validating additional custom data for antiforgery tokens.
For example, the developer could use this to supply a nonce when the token is
generated, then he could validate the nonce when the token is validated.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Antiforgery`
Assemblies
    * Microsoft.AspNetCore.Antiforgery

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IAntiforgeryAdditionalDataProvider








.. dn:interface:: Microsoft.AspNetCore.Antiforgery.IAntiforgeryAdditionalDataProvider
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Antiforgery.IAntiforgeryAdditionalDataProvider

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Antiforgery.IAntiforgeryAdditionalDataProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Antiforgery.IAntiforgeryAdditionalDataProvider.GetAdditionalData(Microsoft.AspNetCore.Http.HttpContext)
    
        
    
        
        Provides additional data to be stored for the antiforgery tokens generated
        during this request.
    
        
    
        
        :param context: Information about the current request.
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
        :rtype: System.String
        :return: Supplemental data to embed within the antiforgery token.
    
        
        .. code-block:: csharp
    
            string GetAdditionalData(HttpContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Antiforgery.IAntiforgeryAdditionalDataProvider.ValidateAdditionalData(Microsoft.AspNetCore.Http.HttpContext, System.String)
    
        
    
        
        Validates additional data that was embedded inside an incoming antiforgery
        token.
    
        
    
        
        :param context: Information about the current request.
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
    
        
        :param additionalData: Supplemental data that was embedded within the token.
        
        :type additionalData: System.String
        :rtype: System.Boolean
        :return: True if the data is valid; false if the data is invalid.
    
        
        .. code-block:: csharp
    
            bool ValidateAdditionalData(HttpContext context, string additionalData)
    

