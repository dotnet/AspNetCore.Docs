

RedirectResultExecutor Class
============================





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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Internal.RedirectResultExecutor`








Syntax
------

.. code-block:: csharp

    public class RedirectResultExecutor








.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.RedirectResultExecutor
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.RedirectResultExecutor

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.RedirectResultExecutor
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Internal.RedirectResultExecutor.RedirectResultExecutor(Microsoft.Extensions.Logging.ILoggerFactory, Microsoft.AspNetCore.Mvc.Routing.IUrlHelperFactory)
    
        
    
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        :type urlHelperFactory: Microsoft.AspNetCore.Mvc.Routing.IUrlHelperFactory
    
        
        .. code-block:: csharp
    
            public RedirectResultExecutor(ILoggerFactory loggerFactory, IUrlHelperFactory urlHelperFactory)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.RedirectResultExecutor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.RedirectResultExecutor.Execute(Microsoft.AspNetCore.Mvc.ActionContext, Microsoft.AspNetCore.Mvc.RedirectResult)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ActionContext
    
        
        :type result: Microsoft.AspNetCore.Mvc.RedirectResult
    
        
        .. code-block:: csharp
    
            public void Execute(ActionContext context, RedirectResult result)
    

