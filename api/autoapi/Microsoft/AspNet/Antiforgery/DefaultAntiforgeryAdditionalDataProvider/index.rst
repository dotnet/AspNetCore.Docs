

DefaultAntiforgeryAdditionalDataProvider Class
==============================================



.. contents:: 
   :local:



Summary
-------

A default :any:`Microsoft.AspNet.Antiforgery.IAntiforgeryAdditionalDataProvider` implementation.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Antiforgery.DefaultAntiforgeryAdditionalDataProvider`








Syntax
------

.. code-block:: csharp

   public class DefaultAntiforgeryAdditionalDataProvider : IAntiforgeryAdditionalDataProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/antiforgery/src/Microsoft.AspNet.Antiforgery/DefaultAntiforgeryAdditionalDataProvider.cs>`_





.. dn:class:: Microsoft.AspNet.Antiforgery.DefaultAntiforgeryAdditionalDataProvider

Methods
-------

.. dn:class:: Microsoft.AspNet.Antiforgery.DefaultAntiforgeryAdditionalDataProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Antiforgery.DefaultAntiforgeryAdditionalDataProvider.GetAdditionalData(Microsoft.AspNet.Http.HttpContext)
    
        
        
        
        :type context: Microsoft.AspNet.Http.HttpContext
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public virtual string GetAdditionalData(HttpContext context)
    
    .. dn:method:: Microsoft.AspNet.Antiforgery.DefaultAntiforgeryAdditionalDataProvider.ValidateAdditionalData(Microsoft.AspNet.Http.HttpContext, System.String)
    
        
        
        
        :type context: Microsoft.AspNet.Http.HttpContext
        
        
        :type additionalData: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public virtual bool ValidateAdditionalData(HttpContext context, string additionalData)
    

