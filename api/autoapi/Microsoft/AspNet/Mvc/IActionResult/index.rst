

IActionResult Interface
=======================



.. contents:: 
   :local:



Summary
-------

Defines a contract that represents the result of an action method.











Syntax
------

.. code-block:: csharp

   public interface IActionResult





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Abstractions/IActionResult.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.IActionResult

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.IActionResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.IActionResult.ExecuteResultAsync(Microsoft.AspNet.Mvc.ActionContext)
    
        
    
        Executes the result operation of the action method asynchronously. This method is called by MVC to process
        the result of an action method.
    
        
        
        
        :param context: The context in which the result is executed. The context information includes
            information about the action that was executed and request information.
        
        :type context: Microsoft.AspNet.Mvc.ActionContext
        :rtype: System.Threading.Tasks.Task
        :return: A task that represents the asynchronous execute operation.
    
        
        .. code-block:: csharp
    
           Task ExecuteResultAsync(ActionContext context)
    

