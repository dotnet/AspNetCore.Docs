

IActionResult Interface
=======================






Defines a contract that represents the result of an action method.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc`
Assemblies
    * Microsoft.AspNetCore.Mvc.Abstractions

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IActionResult








.. dn:interface:: Microsoft.AspNetCore.Mvc.IActionResult
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.IActionResult

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.IActionResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.IActionResult.ExecuteResultAsync(Microsoft.AspNetCore.Mvc.ActionContext)
    
        
    
        
        Executes the result operation of the action method asynchronously. This method is called by MVC to process
        the result of an action method.
    
        
    
        
        :param context: The context in which the result is executed. The context information includes
            information about the action that was executed and request information.
        
        :type context: Microsoft.AspNetCore.Mvc.ActionContext
        :rtype: System.Threading.Tasks.Task
        :return: A task that represents the asynchronous execute operation.
    
        
        .. code-block:: csharp
    
            Task ExecuteResultAsync(ActionContext context)
    

