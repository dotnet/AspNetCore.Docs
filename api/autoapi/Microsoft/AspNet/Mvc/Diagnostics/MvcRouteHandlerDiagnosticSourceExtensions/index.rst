

MvcRouteHandlerDiagnosticSourceExtensions Class
===============================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Diagnostics.MvcRouteHandlerDiagnosticSourceExtensions`








Syntax
------

.. code-block:: csharp

   public class MvcRouteHandlerDiagnosticSourceExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/DiagnosticSource/MvcRouteHandlerDiagnosticSourceExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Diagnostics.MvcRouteHandlerDiagnosticSourceExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Diagnostics.MvcRouteHandlerDiagnosticSourceExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Diagnostics.MvcRouteHandlerDiagnosticSourceExtensions.AfterAction(System.Diagnostics.DiagnosticSource, Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor, Microsoft.AspNet.Http.HttpContext, Microsoft.AspNet.Routing.RouteData)
    
        
        
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
        
        
        :type actionDescriptor: Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor
        
        
        :type httpContext: Microsoft.AspNet.Http.HttpContext
        
        
        :type routeData: Microsoft.AspNet.Routing.RouteData
    
        
        .. code-block:: csharp
    
           public static void AfterAction(DiagnosticSource diagnosticSource, ActionDescriptor actionDescriptor, HttpContext httpContext, RouteData routeData)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Diagnostics.MvcRouteHandlerDiagnosticSourceExtensions.BeforeAction(System.Diagnostics.DiagnosticSource, Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor, Microsoft.AspNet.Http.HttpContext, Microsoft.AspNet.Routing.RouteData)
    
        
        
        
        :type diagnosticSource: System.Diagnostics.DiagnosticSource
        
        
        :type actionDescriptor: Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor
        
        
        :type httpContext: Microsoft.AspNet.Http.HttpContext
        
        
        :type routeData: Microsoft.AspNet.Routing.RouteData
    
        
        .. code-block:: csharp
    
           public static void BeforeAction(DiagnosticSource diagnosticSource, ActionDescriptor actionDescriptor, HttpContext httpContext, RouteData routeData)
    

