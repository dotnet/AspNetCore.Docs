

AcceptLanguageHeaderRequestCultureProvider Class
================================================






Determines the culture information for a request via the value of the Accept-Language header.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Localization`
Assemblies
    * Microsoft.AspNetCore.Localization

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Localization.RequestCultureProvider`
* :dn:cls:`Microsoft.AspNetCore.Localization.AcceptLanguageHeaderRequestCultureProvider`








Syntax
------

.. code-block:: csharp

    public class AcceptLanguageHeaderRequestCultureProvider : RequestCultureProvider, IRequestCultureProvider








.. dn:class:: Microsoft.AspNetCore.Localization.AcceptLanguageHeaderRequestCultureProvider
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Localization.AcceptLanguageHeaderRequestCultureProvider

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Localization.AcceptLanguageHeaderRequestCultureProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Localization.AcceptLanguageHeaderRequestCultureProvider.MaximumAcceptLanguageHeaderValuesToTry
    
        
    
        
        The maximum number of values in the Accept-Language header to attempt to create a :any:`System.Globalization.CultureInfo`
        from for the current request.
        Defaults to <code>3</code>.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int MaximumAcceptLanguageHeaderValuesToTry
            {
                get;
                set;
            }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Localization.AcceptLanguageHeaderRequestCultureProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Localization.AcceptLanguageHeaderRequestCultureProvider.DetermineProviderCultureResult(Microsoft.AspNetCore.Http.HttpContext)
    
        
    
        
        :type httpContext: Microsoft.AspNetCore.Http.HttpContext
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Localization.ProviderCultureResult<Microsoft.AspNetCore.Localization.ProviderCultureResult>}
    
        
        .. code-block:: csharp
    
            public override Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
    

