

IRazorViewFactory Interface
===========================



.. contents:: 
   :local:



Summary
-------

Defines methods to create :any:`Microsoft.AspNet.Mvc.Razor.RazorView` instances with a given :any:`Microsoft.AspNet.Mvc.Razor.IRazorPage`\.











Syntax
------

.. code-block:: csharp

   public interface IRazorViewFactory





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Razor/IRazorViewFactory.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.Razor.IRazorViewFactory

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.Razor.IRazorViewFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.IRazorViewFactory.GetView(Microsoft.AspNet.Mvc.Razor.IRazorViewEngine, Microsoft.AspNet.Mvc.Razor.IRazorPage, System.Boolean)
    
        
    
        Creates a :any:`Microsoft.AspNet.Mvc.Razor.RazorView` providing it with the :any:`Microsoft.AspNet.Mvc.Razor.IRazorPage` to execute.
    
        
        
        
        :param viewEngine: The  that was used to locate Layout pages
            that will be part of 's execution.
        
        :type viewEngine: Microsoft.AspNet.Mvc.Razor.IRazorViewEngine
        
        
        :param page: The  instance to execute.
        
        :type page: Microsoft.AspNet.Mvc.Razor.IRazorPage
        
        
        :param isPartial: Determines if the view is to be executed as a partial.
        
        :type isPartial: System.Boolean
        :rtype: Microsoft.AspNet.Mvc.ViewEngines.IView
        :return: A <see cref="T:Microsoft.AspNet.Mvc.ViewEngines.IView" /> instance that renders the contents of the <paramref name="page" />
    
        
        .. code-block:: csharp
    
           IView GetView(IRazorViewEngine viewEngine, IRazorPage page, bool isPartial)
    

