

ActionResult Class
==================



.. contents:: 
   :local:



Summary
-------

A default implementation of :any:`Microsoft.AspNet.Mvc.IActionResult`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ActionResult`








Syntax
------

.. code-block:: csharp

   public abstract class ActionResult : IActionResult





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/ActionResult.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ActionResult

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ActionResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ActionResult.ExecuteResult(Microsoft.AspNet.Mvc.ActionContext)
    
        
    
        Executes the result operation of the action method synchronously. This method is called by MVC to process
        the result of an action method.
    
        
        
        
        :param context: The context in which the result is executed. The context information includes
            information about the action that was executed and request information.
        
        :type context: Microsoft.AspNet.Mvc.ActionContext
    
        
        .. code-block:: csharp
    
           public virtual void ExecuteResult(ActionContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ActionResult.ExecuteResultAsync(Microsoft.AspNet.Mvc.ActionContext)
    
        
    
        Executes the result operation of the action method asynchronously. This method is called by MVC to process
        the result of an action method.
        The default implementation of this method calls the :dn:meth:`Microsoft.AspNet.Mvc.ActionResult.ExecuteResult(Microsoft.AspNet.Mvc.ActionContext)` method and
        returns a completed task.
    
        
        
        
        :param context: The context in which the result is executed. The context information includes
            information about the action that was executed and request information.
        
        :type context: Microsoft.AspNet.Mvc.ActionContext
        :rtype: System.Threading.Tasks.Task
        :return: A task that represents the asynchronous execute operation.
    
        
        .. code-block:: csharp
    
           public virtual Task ExecuteResultAsync(ActionContext context)
    

