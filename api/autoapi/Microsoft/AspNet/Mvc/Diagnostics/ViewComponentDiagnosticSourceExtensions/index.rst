

ViewComponentDiagnosticSourceExtensions Class
=============================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Diagnostics.ViewComponentDiagnosticSourceExtensions`








Syntax
------

.. code-block:: csharp

   public class ViewComponentDiagnosticSourceExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.ViewFeatures/DiagnosticSource/ViewComponentDiagnosticSourceExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Diagnostics.ViewComponentDiagnosticSourceExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Diagnostics.ViewComponentDiagnosticSourceExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Diagnostics.ViewComponentDiagnosticSourceExtensions.AfterViewComponent(System.Diagnostics.DiagnosticSource, Microsoft.AspNet.Mvc.ViewComponents.ViewComponentContext, Microsoft.AspNet.Mvc.IViewComponentResult, System.Object)
    
        
        
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
        
        
        :type context: Microsoft.AspNet.Mvc.ViewComponents.ViewComponentContext
        
        
        :type result: Microsoft.AspNet.Mvc.IViewComponentResult
        
        
        :type viewComponent: System.Object
    
        
        .. code-block:: csharp
    
           public static void AfterViewComponent(DiagnosticSource diagnosticSource, ViewComponentContext context, IViewComponentResult result, object viewComponent)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Diagnostics.ViewComponentDiagnosticSourceExtensions.BeforeViewComponent(System.Diagnostics.DiagnosticSource, Microsoft.AspNet.Mvc.ViewComponents.ViewComponentContext, System.Object)
    
        
        
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
        
        
        :type context: Microsoft.AspNet.Mvc.ViewComponents.ViewComponentContext
        
        
        :type viewComponent: System.Object
    
        
        .. code-block:: csharp
    
           public static void BeforeViewComponent(DiagnosticSource diagnosticSource, ViewComponentContext context, object viewComponent)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Diagnostics.ViewComponentDiagnosticSourceExtensions.ViewComponentAfterViewExecute(System.Diagnostics.DiagnosticSource, Microsoft.AspNet.Mvc.ViewComponents.ViewComponentContext, Microsoft.AspNet.Mvc.ViewEngines.IView)
    
        
        
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
        
        
        :type context: Microsoft.AspNet.Mvc.ViewComponents.ViewComponentContext
        
        
        :type view: Microsoft.AspNet.Mvc.ViewEngines.IView
    
        
        .. code-block:: csharp
    
           public static void ViewComponentAfterViewExecute(DiagnosticSource diagnosticSource, ViewComponentContext context, IView view)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Diagnostics.ViewComponentDiagnosticSourceExtensions.ViewComponentBeforeViewExecute(System.Diagnostics.DiagnosticSource, Microsoft.AspNet.Mvc.ViewComponents.ViewComponentContext, Microsoft.AspNet.Mvc.ViewEngines.IView)
    
        
        
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
        
        
        :type context: Microsoft.AspNet.Mvc.ViewComponents.ViewComponentContext
        
        
        :type view: Microsoft.AspNet.Mvc.ViewEngines.IView
    
        
        .. code-block:: csharp
    
           public static void ViewComponentBeforeViewExecute(DiagnosticSource diagnosticSource, ViewComponentContext context, IView view)
    

