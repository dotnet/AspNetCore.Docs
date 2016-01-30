

RazorViewEngineOptions Class
============================



.. contents:: 
   :local:



Summary
-------

Provides programmatic configuration for the :any:`Microsoft.AspNet.Mvc.Razor.RazorViewEngine`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Razor.RazorViewEngineOptions`








Syntax
------

.. code-block:: csharp

   public class RazorViewEngineOptions





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Razor/RazorViewEngineOptions.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Razor.RazorViewEngineOptions

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.RazorViewEngineOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.RazorViewEngineOptions.FileProvider
    
        
    
        Gets or sets the :any:`Microsoft.AspNet.FileProviders.IFileProvider` used by :any:`Microsoft.AspNet.Mvc.Razor.RazorViewEngine` to locate Razor files on
        disk.
    
        
        :rtype: Microsoft.AspNet.FileProviders.IFileProvider
    
        
        .. code-block:: csharp
    
           public IFileProvider FileProvider { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.RazorViewEngineOptions.ViewLocationExpanders
    
        
    
        Get a :any:`System.Collections.Generic.IList\`1` used by the :any:`Microsoft.AspNet.Mvc.Razor.RazorViewEngine`\.
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.AspNet.Mvc.Razor.IViewLocationExpander}
    
        
        .. code-block:: csharp
    
           public IList<IViewLocationExpander> ViewLocationExpanders { get; }
    

