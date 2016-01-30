

MvcViewOptions Class
====================



.. contents:: 
   :local:



Summary
-------

Provides programmatic configuration for views in the MVC framework.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.MvcViewOptions`








Syntax
------

.. code-block:: csharp

   public class MvcViewOptions





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.ViewFeatures/MvcViewOptions.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.MvcViewOptions

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.MvcViewOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.MvcViewOptions.ClientModelValidatorProviders
    
        
    
        Gets a list of :any:`Microsoft.AspNet.Mvc.ModelBinding.Validation.IClientModelValidatorProvider` instances.
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.AspNet.Mvc.ModelBinding.Validation.IClientModelValidatorProvider}
    
        
        .. code-block:: csharp
    
           public IList<IClientModelValidatorProvider> ClientModelValidatorProviders { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.MvcViewOptions.HtmlHelperOptions
    
        
    
        Gets or sets programmatic configuration for the HTML helpers and :any:`Microsoft.AspNet.Mvc.Rendering.ViewContext`\.
    
        
        :rtype: Microsoft.AspNet.Mvc.ViewFeatures.HtmlHelperOptions
    
        
        .. code-block:: csharp
    
           public HtmlHelperOptions HtmlHelperOptions { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.MvcViewOptions.ViewEngines
    
        
    
        Gets a list :any:`Microsoft.AspNet.Mvc.ViewEngines.IViewEngine`\s used by this application.
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.AspNet.Mvc.ViewEngines.IViewEngine}
    
        
        .. code-block:: csharp
    
           public IList<IViewEngine> ViewEngines { get; }
    

