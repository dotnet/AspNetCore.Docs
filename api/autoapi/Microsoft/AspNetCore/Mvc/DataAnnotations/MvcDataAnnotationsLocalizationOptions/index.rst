

MvcDataAnnotationsLocalizationOptions Class
===========================================






Provides programmatic configuration for DataAnnotations localization in the MVC framework.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.DataAnnotations`
Assemblies
    * Microsoft.AspNetCore.Mvc.DataAnnotations

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.DataAnnotations.MvcDataAnnotationsLocalizationOptions`








Syntax
------

.. code-block:: csharp

    public class MvcDataAnnotationsLocalizationOptions








.. dn:class:: Microsoft.AspNetCore.Mvc.DataAnnotations.MvcDataAnnotationsLocalizationOptions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.DataAnnotations.MvcDataAnnotationsLocalizationOptions

Fields
------

.. dn:class:: Microsoft.AspNetCore.Mvc.DataAnnotations.MvcDataAnnotationsLocalizationOptions
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Mvc.DataAnnotations.MvcDataAnnotationsLocalizationOptions.DataAnnotationLocalizerProvider
    
        
    
        
        The delegate to invoke for creating :any:`Microsoft.Extensions.Localization.IStringLocalizer`\.
    
        
        :rtype: System.Func<System.Func`3>{System.Type<System.Type>, Microsoft.Extensions.Localization.IStringLocalizerFactory<Microsoft.Extensions.Localization.IStringLocalizerFactory>, Microsoft.Extensions.Localization.IStringLocalizer<Microsoft.Extensions.Localization.IStringLocalizer>}
    
        
        .. code-block:: csharp
    
            public Func<Type, IStringLocalizerFactory, IStringLocalizer> DataAnnotationLocalizerProvider
    

