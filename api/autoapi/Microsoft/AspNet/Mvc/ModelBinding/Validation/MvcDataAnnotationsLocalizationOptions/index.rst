

MvcDataAnnotationsLocalizationOptions Class
===========================================



.. contents:: 
   :local:



Summary
-------

Provides programmatic configuration for DataAnnotations localization in the MVC framework.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.Validation.MvcDataAnnotationsLocalizationOptions`








Syntax
------

.. code-block:: csharp

   public class MvcDataAnnotationsLocalizationOptions





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.DataAnnotations/MvcDataAnnotationsLocalizationOptions.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.MvcDataAnnotationsLocalizationOptions

Fields
------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.Validation.MvcDataAnnotationsLocalizationOptions
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNet.Mvc.ModelBinding.Validation.MvcDataAnnotationsLocalizationOptions.DataAnnotationLocalizerProvider
    
        
    
        The delegate to invoke for creating :any:`Microsoft.Extensions.Localization.IStringLocalizer`\.
    
        
    
        
        .. code-block:: csharp
    
           public Func<Type, IStringLocalizerFactory, IStringLocalizer> DataAnnotationLocalizerProvider
    

