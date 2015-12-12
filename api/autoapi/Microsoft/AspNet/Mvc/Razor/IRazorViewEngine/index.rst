

IRazorViewEngine Interface
==========================



.. contents:: 
   :local:



Summary
-------

An :any:`Microsoft.AspNet.Mvc.ViewEngines.IViewEngine` used to render pages that use the Razor syntax.











Syntax
------

.. code-block:: csharp

   public interface IRazorViewEngine : IViewEngine





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Razor/IRazorViewEngine.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.Razor.IRazorViewEngine

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.Razor.IRazorViewEngine
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.IRazorViewEngine.FindPage(Microsoft.AspNet.Mvc.ActionContext, System.String)
    
        
    
        Finds a :any:`Microsoft.AspNet.Mvc.Razor.IRazorPage` using the same view discovery semantics used in 
        :dn:meth:`Microsoft.AspNet.Mvc.ViewEngines.IViewEngine.FindPartialView(Microsoft.AspNet.Mvc.ActionContext,System.String)`\.
    
        
        
        
        :param context: The .
        
        :type context: Microsoft.AspNet.Mvc.ActionContext
        
        
        :param page: The name or full path to the view.
        
        :type page: System.String
        :rtype: Microsoft.AspNet.Mvc.Razor.RazorPageResult
        :return: A result representing the result of locating the <see cref="T:Microsoft.AspNet.Mvc.Razor.IRazorPage" />.
    
        
        .. code-block:: csharp
    
           RazorPageResult FindPage(ActionContext context, string page)
    

