

AcceptLanguageHeaderRequestCultureProvider Class
================================================



.. contents:: 
   :local:



Summary
-------

Determines the culture information for a request via the value of the Accept-Language header.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Localization.RequestCultureProvider`
* :dn:cls:`Microsoft.AspNet.Localization.AcceptLanguageHeaderRequestCultureProvider`








Syntax
------

.. code-block:: csharp

   public class AcceptLanguageHeaderRequestCultureProvider : RequestCultureProvider, IRequestCultureProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/localization/blob/master/src/Microsoft.AspNet.Localization/AcceptLanguageHeaderRequestCultureProvider.cs>`_





.. dn:class:: Microsoft.AspNet.Localization.AcceptLanguageHeaderRequestCultureProvider

Methods
-------

.. dn:class:: Microsoft.AspNet.Localization.AcceptLanguageHeaderRequestCultureProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Localization.AcceptLanguageHeaderRequestCultureProvider.DetermineProviderCultureResult(Microsoft.AspNet.Http.HttpContext)
    
        
        
        
        :type httpContext: Microsoft.AspNet.Http.HttpContext
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Localization.ProviderCultureResult}
    
        
        .. code-block:: csharp
    
           public override Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Localization.AcceptLanguageHeaderRequestCultureProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Localization.AcceptLanguageHeaderRequestCultureProvider.MaximumAcceptLanguageHeaderValuesToTry
    
        
    
        The maximum number of values in the Accept-Language header to attempt to create a :any:`System.Globalization.CultureInfo`
        from for the current request.
        Defaults to <c>3</c>.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int MaximumAcceptLanguageHeaderValuesToTry { get; set; }
    

