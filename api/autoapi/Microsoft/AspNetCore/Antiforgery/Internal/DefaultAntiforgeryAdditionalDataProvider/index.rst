

DefaultAntiforgeryAdditionalDataProvider Class
==============================================






A default :any:`Microsoft.AspNetCore.Antiforgery.IAntiforgeryAdditionalDataProvider` implementation.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Antiforgery.Internal`
Assemblies
    * Microsoft.AspNetCore.Antiforgery

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Antiforgery.Internal.DefaultAntiforgeryAdditionalDataProvider`








Syntax
------

.. code-block:: csharp

    public class DefaultAntiforgeryAdditionalDataProvider : IAntiforgeryAdditionalDataProvider








.. dn:class:: Microsoft.AspNetCore.Antiforgery.Internal.DefaultAntiforgeryAdditionalDataProvider
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Antiforgery.Internal.DefaultAntiforgeryAdditionalDataProvider

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Antiforgery.Internal.DefaultAntiforgeryAdditionalDataProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Antiforgery.Internal.DefaultAntiforgeryAdditionalDataProvider.GetAdditionalData(Microsoft.AspNetCore.Http.HttpContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public virtual string GetAdditionalData(HttpContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Antiforgery.Internal.DefaultAntiforgeryAdditionalDataProvider.ValidateAdditionalData(Microsoft.AspNetCore.Http.HttpContext, System.String)
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
    
        
        :type additionalData: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public virtual bool ValidateAdditionalData(HttpContext context, string additionalData)
    

