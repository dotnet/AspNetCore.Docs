

IControllerArgumentBinder Interface
===================================






Provides a dictionary of action arguments.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IControllerArgumentBinder








.. dn:interface:: Microsoft.AspNetCore.Mvc.Internal.IControllerArgumentBinder
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.Internal.IControllerArgumentBinder

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.Internal.IControllerArgumentBinder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.IControllerArgumentBinder.BindArgumentsAsync(Microsoft.AspNetCore.Mvc.ControllerContext, System.Object, System.Collections.Generic.IDictionary<System.String, System.Object>)
    
        
    
        
        Asyncronously binds a dictionary of the parameter-argument name-value pairs,
        which can be used to invoke the action. Also binds properties explicitly marked properties on the 
        <em>controller</em>.
    
        
    
        
        :param controllerContext: The :any:`Microsoft.AspNetCore.Mvc.ControllerContext` associated with the current action.
        
        :type controllerContext: Microsoft.AspNetCore.Mvc.ControllerContext
    
        
        :param controller: The controller object which contains the action.
        
        :type controller: System.Object
    
        
        :param arguments: The arguments dictionary.
        
        :type arguments: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.Object<System.Object>}
        :rtype: System.Threading.Tasks.Task
        :return: A :any:`System.Threading.Tasks.Task` which, when completed signals the completion of argument binding.
    
        
        .. code-block:: csharp
    
            Task BindArgumentsAsync(ControllerContext controllerContext, object controller, IDictionary<string, object> arguments)
    

