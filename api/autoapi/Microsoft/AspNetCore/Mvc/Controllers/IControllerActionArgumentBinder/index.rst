

IControllerActionArgumentBinder Interface
=========================================






Provides a dictionary of action arguments.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Controllers`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IControllerActionArgumentBinder








.. dn:interface:: Microsoft.AspNetCore.Mvc.Controllers.IControllerActionArgumentBinder
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.Controllers.IControllerActionArgumentBinder

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.Controllers.IControllerActionArgumentBinder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Controllers.IControllerActionArgumentBinder.BindActionArgumentsAsync(Microsoft.AspNetCore.Mvc.ControllerContext, System.Object)
    
        
    
        
        Returns a dictionary of the parameter-argument name-value pairs,
        which can be used to invoke the action. Also binds properties explicitly marked properties on the 
        <em>controller</em>.
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Mvc.ControllerContext` associated with the current action.
        
        :type context: Microsoft.AspNetCore.Mvc.ControllerContext
    
        
        :param controller: The controller object which contains the action.
        
        :type controller: System.Object
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.Object<System.Object>}}
    
        
        .. code-block:: csharp
    
            Task<IDictionary<string, object>> BindActionArgumentsAsync(ControllerContext context, object controller)
    

