

LocalRedirectResultExecutor Class
=================================





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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Internal.LocalRedirectResultExecutor`








Syntax
------

.. code-block:: csharp

    public class LocalRedirectResultExecutor








.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.LocalRedirectResultExecutor
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.LocalRedirectResultExecutor

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.LocalRedirectResultExecutor
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Internal.LocalRedirectResultExecutor.LocalRedirectResultExecutor(Microsoft.Extensions.Logging.ILoggerFactory, Microsoft.AspNetCore.Mvc.Routing.IUrlHelperFactory)
    
        
    
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        :type urlHelperFactory: Microsoft.AspNetCore.Mvc.Routing.IUrlHelperFactory
    
        
        .. code-block:: csharp
    
            public LocalRedirectResultExecutor(ILoggerFactory loggerFactory, IUrlHelperFactory urlHelperFactory)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.LocalRedirectResultExecutor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.LocalRedirectResultExecutor.Execute(Microsoft.AspNetCore.Mvc.ActionContext, Microsoft.AspNetCore.Mvc.LocalRedirectResult)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ActionContext
    
        
        :type result: Microsoft.AspNetCore.Mvc.LocalRedirectResult
    
        
        .. code-block:: csharp
    
            public void Execute(ActionContext context, LocalRedirectResult result)
    

