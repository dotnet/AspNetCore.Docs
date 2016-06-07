

AntiforgeryExtensions Class
===========================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ViewFeatures`
Assemblies
    * Microsoft.AspNetCore.Mvc.ViewFeatures

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ViewFeatures.AntiforgeryExtensions`








Syntax
------

.. code-block:: csharp

    public class AntiforgeryExtensions








.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.AntiforgeryExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.AntiforgeryExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.AntiforgeryExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.AntiforgeryExtensions.GetHtml(Microsoft.AspNetCore.Antiforgery.IAntiforgery, Microsoft.AspNetCore.Http.HttpContext)
    
        
    
        
        Generates an <input type="hidden"> element for an antiforgery token.
    
        
    
        
        :param antiforgery: The :any:`Microsoft.AspNetCore.Antiforgery.IAntiforgery` instance.
        
        :type antiforgery: Microsoft.AspNetCore.Antiforgery.IAntiforgery
    
        
        :param httpContext: The :any:`Microsoft.AspNetCore.Http.HttpContext` associated with the current request.
        
        :type httpContext: Microsoft.AspNetCore.Http.HttpContext
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: 
            A :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing an <input type="hidden"> element. This element should be put
            inside a <form>.
    
        
        .. code-block:: csharp
    
            public static IHtmlContent GetHtml(IAntiforgery antiforgery, HttpContext httpContext)
    

