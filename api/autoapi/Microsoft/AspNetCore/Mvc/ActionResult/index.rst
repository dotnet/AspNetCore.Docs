

ActionResult Class
==================






A default implementation of :any:`Microsoft.AspNetCore.Mvc.IActionResult`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ActionResult`








Syntax
------

.. code-block:: csharp

    public abstract class ActionResult : IActionResult








.. dn:class:: Microsoft.AspNetCore.Mvc.ActionResult
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ActionResult

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ActionResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ActionResult.ExecuteResult(Microsoft.AspNetCore.Mvc.ActionContext)
    
        
    
        
        Executes the result operation of the action method synchronously. This method is called by MVC to process
        the result of an action method.
    
        
    
        
        :param context: The context in which the result is executed. The context information includes
            information about the action that was executed and request information.
        
        :type context: Microsoft.AspNetCore.Mvc.ActionContext
    
        
        .. code-block:: csharp
    
            public virtual void ExecuteResult(ActionContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ActionResult.ExecuteResultAsync(Microsoft.AspNetCore.Mvc.ActionContext)
    
        
    
        
        Executes the result operation of the action method asynchronously. This method is called by MVC to process
        the result of an action method.
        The default implementation of this method calls the :dn:meth:`Microsoft.AspNetCore.Mvc.ActionResult.ExecuteResult(Microsoft.AspNetCore.Mvc.ActionContext)` method and
        returns a completed task.
    
        
    
        
        :param context: The context in which the result is executed. The context information includes
            information about the action that was executed and request information.
        
        :type context: Microsoft.AspNetCore.Mvc.ActionContext
        :rtype: System.Threading.Tasks.Task
        :return: A task that represents the asynchronous execute operation.
    
        
        .. code-block:: csharp
    
            public virtual Task ExecuteResultAsync(ActionContext context)
    

