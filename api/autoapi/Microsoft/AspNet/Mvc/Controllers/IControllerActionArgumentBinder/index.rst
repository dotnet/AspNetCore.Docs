

IControllerActionArgumentBinder Interface
=========================================



.. contents:: 
   :local:



Summary
-------

Provides a dictionary of action arguments.











Syntax
------

.. code-block:: csharp

   public interface IControllerActionArgumentBinder





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/Controllers/IControllerActionArgumentBinder.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.Controllers.IControllerActionArgumentBinder

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.Controllers.IControllerActionArgumentBinder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Controllers.IControllerActionArgumentBinder.BindActionArgumentsAsync(Microsoft.AspNet.Mvc.ActionContext, Microsoft.AspNet.Mvc.ActionBindingContext, System.Object)
    
        
    
        Returns a dictionary of representing the parameter-argument name-value pairs,
        which can be used to invoke the action. Also binds properties explicitly marked properties on the
        ``controller``.
    
        
        
        
        :param context: The action context assoicated with the current action.
        
        :type context: Microsoft.AspNet.Mvc.ActionContext
        
        
        :param bindingContext: The .
        
        :type bindingContext: Microsoft.AspNet.Mvc.ActionBindingContext
        
        
        :param controller: The controller object which contains the action.
        
        :type controller: System.Object
        :rtype: System.Threading.Tasks.Task{System.Collections.Generic.IDictionary{System.String,System.Object}}
    
        
        .. code-block:: csharp
    
           Task<IDictionary<string, object>> BindActionArgumentsAsync(ActionContext context, ActionBindingContext bindingContext, object controller)
    

