

FileContentResultExecutor Class
===============================





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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Internal.FileResultExecutorBase`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Internal.FileContentResultExecutor`








Syntax
------

.. code-block:: csharp

    public class FileContentResultExecutor : FileResultExecutorBase








.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.FileContentResultExecutor
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.FileContentResultExecutor

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.FileContentResultExecutor
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Internal.FileContentResultExecutor.FileContentResultExecutor(Microsoft.Extensions.Logging.ILoggerFactory)
    
        
    
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        .. code-block:: csharp
    
            public FileContentResultExecutor(ILoggerFactory loggerFactory)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.FileContentResultExecutor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.FileContentResultExecutor.ExecuteAsync(Microsoft.AspNetCore.Mvc.ActionContext, Microsoft.AspNetCore.Mvc.FileContentResult)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ActionContext
    
        
        :type result: Microsoft.AspNetCore.Mvc.FileContentResult
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task ExecuteAsync(ActionContext context, FileContentResult result)
    

