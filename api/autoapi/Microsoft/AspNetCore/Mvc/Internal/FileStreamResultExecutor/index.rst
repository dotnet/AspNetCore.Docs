

FileStreamResultExecutor Class
==============================





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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Internal.FileStreamResultExecutor`








Syntax
------

.. code-block:: csharp

    public class FileStreamResultExecutor : FileResultExecutorBase








.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.FileStreamResultExecutor
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.FileStreamResultExecutor

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.FileStreamResultExecutor
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Internal.FileStreamResultExecutor.FileStreamResultExecutor(Microsoft.Extensions.Logging.ILoggerFactory)
    
        
    
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        .. code-block:: csharp
    
            public FileStreamResultExecutor(ILoggerFactory loggerFactory)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.FileStreamResultExecutor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.FileStreamResultExecutor.ExecuteAsync(Microsoft.AspNetCore.Mvc.ActionContext, Microsoft.AspNetCore.Mvc.FileStreamResult)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ActionContext
    
        
        :type result: Microsoft.AspNetCore.Mvc.FileStreamResult
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task ExecuteAsync(ActionContext context, FileStreamResult result)
    

