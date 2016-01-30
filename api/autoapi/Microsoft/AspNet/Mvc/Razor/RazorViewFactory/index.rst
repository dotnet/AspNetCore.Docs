

RazorViewFactory Class
======================



.. contents:: 
   :local:



Summary
-------

Represents the default :any:`Microsoft.AspNet.Mvc.Razor.IRazorViewFactory` implementation that creates 
:any:`Microsoft.AspNet.Mvc.Razor.RazorView` instances with a given :any:`Microsoft.AspNet.Mvc.Razor.IRazorPage`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Razor.RazorViewFactory`








Syntax
------

.. code-block:: csharp

   public class RazorViewFactory : IRazorViewFactory





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Razor/RazorViewFactory.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Razor.RazorViewFactory

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.RazorViewFactory
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Razor.RazorViewFactory.RazorViewFactory(Microsoft.AspNet.Mvc.Razor.IRazorPageActivator, Microsoft.AspNet.Mvc.Razor.IViewStartProvider, Microsoft.Extensions.WebEncoders.IHtmlEncoder)
    
        
    
        Initializes a new instance of RazorViewFactory
    
        
        
        
        :param pageActivator: The  used to activate pages.
        
        :type pageActivator: Microsoft.AspNet.Mvc.Razor.IRazorPageActivator
        
        
        :param viewStartProvider: The  used for discovery of _ViewStart
            pages
        
        :type viewStartProvider: Microsoft.AspNet.Mvc.Razor.IViewStartProvider
        
        
        :type htmlEncoder: Microsoft.Extensions.WebEncoders.IHtmlEncoder
    
        
        .. code-block:: csharp
    
           public RazorViewFactory(IRazorPageActivator pageActivator, IViewStartProvider viewStartProvider, IHtmlEncoder htmlEncoder)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.RazorViewFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.RazorViewFactory.GetView(Microsoft.AspNet.Mvc.Razor.IRazorViewEngine, Microsoft.AspNet.Mvc.Razor.IRazorPage, System.Boolean)
    
        
        
        
        :type viewEngine: Microsoft.AspNet.Mvc.Razor.IRazorViewEngine
        
        
        :type page: Microsoft.AspNet.Mvc.Razor.IRazorPage
        
        
        :type isPartial: System.Boolean
        :rtype: Microsoft.AspNet.Mvc.ViewEngines.IView
    
        
        .. code-block:: csharp
    
           public IView GetView(IRazorViewEngine viewEngine, IRazorPage page, bool isPartial)
    

