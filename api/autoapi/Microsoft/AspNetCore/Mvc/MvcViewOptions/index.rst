

MvcViewOptions Class
====================






Provides programmatic configuration for views in the MVC framework.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc`
Assemblies
    * Microsoft.AspNetCore.Mvc.ViewFeatures

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.MvcViewOptions`








Syntax
------

.. code-block:: csharp

    public class MvcViewOptions








.. dn:class:: Microsoft.AspNetCore.Mvc.MvcViewOptions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.MvcViewOptions

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.MvcViewOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.MvcViewOptions.ClientModelValidatorProviders
    
        
    
        
        Gets a list of :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IClientModelValidatorProvider` instances.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IClientModelValidatorProvider<Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IClientModelValidatorProvider>}
    
        
        .. code-block:: csharp
    
            public IList<IClientModelValidatorProvider> ClientModelValidatorProviders
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.MvcViewOptions.HtmlHelperOptions
    
        
    
        
        Gets or sets programmatic configuration for the HTML helpers and :any:`Microsoft.AspNetCore.Mvc.Rendering.ViewContext`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ViewFeatures.HtmlHelperOptions
    
        
        .. code-block:: csharp
    
            public HtmlHelperOptions HtmlHelperOptions
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.MvcViewOptions.ViewEngines
    
        
    
        
        Gets a list :any:`Microsoft.AspNetCore.Mvc.ViewEngines.IViewEngine`\s used by this application.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Mvc.ViewEngines.IViewEngine<Microsoft.AspNetCore.Mvc.ViewEngines.IViewEngine>}
    
        
        .. code-block:: csharp
    
            public IList<IViewEngine> ViewEngines
            {
                get;
            }
    

