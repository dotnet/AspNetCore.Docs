

RedirectToRouteResultExecutor Class
===================================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Internal.RedirectToRouteResultExecutor`








Syntax
------

.. code-block:: csharp

    public class RedirectToRouteResultExecutor








.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.RedirectToRouteResultExecutor
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.RedirectToRouteResultExecutor

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.RedirectToRouteResultExecutor
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Internal.RedirectToRouteResultExecutor.RedirectToRouteResultExecutor(Microsoft.Extensions.Logging.ILoggerFactory, Microsoft.AspNetCore.Mvc.Routing.IUrlHelperFactory)
    
        
    
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        :type urlHelperFactory: Microsoft.AspNetCore.Mvc.Routing.IUrlHelperFactory
    
        
        .. code-block:: csharp
    
            public RedirectToRouteResultExecutor(ILoggerFactory loggerFactory, IUrlHelperFactory urlHelperFactory)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.RedirectToRouteResultExecutor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.RedirectToRouteResultExecutor.Execute(Microsoft.AspNetCore.Mvc.ActionContext, Microsoft.AspNetCore.Mvc.RedirectToRouteResult)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ActionContext
    
        
        :type result: Microsoft.AspNetCore.Mvc.RedirectToRouteResult
    
        
        .. code-block:: csharp
    
            public void Execute(ActionContext context, RedirectToRouteResult result)
    

