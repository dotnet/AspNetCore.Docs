

ViewExecutorDiagnosticSourceExtensions Class
============================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Diagnostics.ViewExecutorDiagnosticSourceExtensions`








Syntax
------

.. code-block:: csharp

   public class ViewExecutorDiagnosticSourceExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.ViewFeatures/DiagnosticSource/ViewExecutorDiagnosticSourceExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Diagnostics.ViewExecutorDiagnosticSourceExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Diagnostics.ViewExecutorDiagnosticSourceExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Diagnostics.ViewExecutorDiagnosticSourceExtensions.AfterView(System.Diagnostics.DiagnosticSource, Microsoft.AspNet.Mvc.ViewEngines.IView, Microsoft.AspNet.Mvc.Rendering.ViewContext)
    
        
        
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
        
        
        :type view: Microsoft.AspNet.Mvc.ViewEngines.IView
        
        
        :type viewContext: Microsoft.AspNet.Mvc.Rendering.ViewContext
    
        
        .. code-block:: csharp
    
           public static void AfterView(DiagnosticSource diagnosticSource, IView view, ViewContext viewContext)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Diagnostics.ViewExecutorDiagnosticSourceExtensions.BeforeView(System.Diagnostics.DiagnosticSource, Microsoft.AspNet.Mvc.ViewEngines.IView, Microsoft.AspNet.Mvc.Rendering.ViewContext)
    
        
        
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
        
        
        :type view: Microsoft.AspNet.Mvc.ViewEngines.IView
        
        
        :type viewContext: Microsoft.AspNet.Mvc.Rendering.ViewContext
    
        
        .. code-block:: csharp
    
           public static void BeforeView(DiagnosticSource diagnosticSource, IView view, ViewContext viewContext)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Diagnostics.ViewExecutorDiagnosticSourceExtensions.ViewFound(System.Diagnostics.DiagnosticSource, Microsoft.AspNet.Mvc.ActionContext, System.Boolean, Microsoft.AspNet.Mvc.PartialViewResult, System.String, Microsoft.AspNet.Mvc.ViewEngines.IView)
    
        
        
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
        
        
        :type actionContext: Microsoft.AspNet.Mvc.ActionContext
        
        
        :type isPartial: System.Boolean
        
        
        :type viewResult: Microsoft.AspNet.Mvc.PartialViewResult
        
        
        :type viewName: System.String
        
        
        :type view: Microsoft.AspNet.Mvc.ViewEngines.IView
    
        
        .. code-block:: csharp
    
           public static void ViewFound(DiagnosticSource diagnosticSource, ActionContext actionContext, bool isPartial, PartialViewResult viewResult, string viewName, IView view)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Diagnostics.ViewExecutorDiagnosticSourceExtensions.ViewNotFound(System.Diagnostics.DiagnosticSource, Microsoft.AspNet.Mvc.ActionContext, System.Boolean, Microsoft.AspNet.Mvc.PartialViewResult, System.String, System.Collections.Generic.IEnumerable<System.String>)
    
        
        
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
        
        
        :type actionContext: Microsoft.AspNet.Mvc.ActionContext
        
        
        :type isPartial: System.Boolean
        
        
        :type viewResult: Microsoft.AspNet.Mvc.PartialViewResult
        
        
        :type viewName: System.String
        
        
        :type searchedLocations: System.Collections.Generic.IEnumerable{System.String}
    
        
        .. code-block:: csharp
    
           public static void ViewNotFound(DiagnosticSource diagnosticSource, ActionContext actionContext, bool isPartial, PartialViewResult viewResult, string viewName, IEnumerable<string> searchedLocations)
    

