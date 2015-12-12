

ControllerActionExecutor Class
==============================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Controllers.ControllerActionExecutor`








Syntax
------

.. code-block:: csharp

   public class ControllerActionExecutor





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/Controllers/ControllerActionExecutor.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Controllers.ControllerActionExecutor

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Controllers.ControllerActionExecutor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Controllers.ControllerActionExecutor.ExecuteAsync(System.Reflection.MethodInfo, System.Object, System.Collections.Generic.IDictionary<System.String, System.Object>)
    
        
        
        
        :type actionMethodInfo: System.Reflection.MethodInfo
        
        
        :type instance: System.Object
        
        
        :type actionArguments: System.Collections.Generic.IDictionary{System.String,System.Object}
        :rtype: System.Threading.Tasks.Task{System.Object}
    
        
        .. code-block:: csharp
    
           public static Task<object> ExecuteAsync(MethodInfo actionMethodInfo, object instance, IDictionary<string, object> actionArguments)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controllers.ControllerActionExecutor.ExecuteAsync(System.Reflection.MethodInfo, System.Object, System.Object[])
    
        
        
        
        :type actionMethodInfo: System.Reflection.MethodInfo
        
        
        :type instance: System.Object
        
        
        :type orderedActionArguments: System.Object[]
        :rtype: System.Threading.Tasks.Task{System.Object}
    
        
        .. code-block:: csharp
    
           public static Task<object> ExecuteAsync(MethodInfo actionMethodInfo, object instance, object[] orderedActionArguments)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controllers.ControllerActionExecutor.PrepareArguments(System.Collections.Generic.IDictionary<System.String, System.Object>, System.Reflection.ParameterInfo[])
    
        
        
        
        :type actionParameters: System.Collections.Generic.IDictionary{System.String,System.Object}
        
        
        :type declaredParameterInfos: System.Reflection.ParameterInfo[]
        :rtype: System.Object[]
    
        
        .. code-block:: csharp
    
           public static object[] PrepareArguments(IDictionary<string, object> actionParameters, ParameterInfo[] declaredParameterInfos)
    

