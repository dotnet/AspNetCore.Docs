

ControllerActionExecutor Class
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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Internal.ControllerActionExecutor`








Syntax
------

.. code-block:: csharp

    public class ControllerActionExecutor








.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ControllerActionExecutor
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ControllerActionExecutor

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ControllerActionExecutor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.ControllerActionExecutor.ExecuteAsync(Microsoft.AspNetCore.Mvc.Internal.ObjectMethodExecutor, System.Object, System.Collections.Generic.IDictionary<System.String, System.Object>)
    
        
    
        
        :type actionMethodExecutor: Microsoft.AspNetCore.Mvc.Internal.ObjectMethodExecutor
    
        
        :type instance: System.Object
    
        
        :type actionArguments: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.Object<System.Object>}
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public static Task<object> ExecuteAsync(ObjectMethodExecutor actionMethodExecutor, object instance, IDictionary<string, object> actionArguments)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.ControllerActionExecutor.ExecuteAsync(Microsoft.AspNetCore.Mvc.Internal.ObjectMethodExecutor, System.Object, System.Object[])
    
        
    
        
        :type actionMethodExecutor: Microsoft.AspNetCore.Mvc.Internal.ObjectMethodExecutor
    
        
        :type instance: System.Object
    
        
        :type orderedActionArguments: System.Object<System.Object>[]
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public static Task<object> ExecuteAsync(ObjectMethodExecutor actionMethodExecutor, object instance, object[] orderedActionArguments)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.ControllerActionExecutor.PrepareArguments(System.Collections.Generic.IDictionary<System.String, System.Object>, System.Reflection.ParameterInfo[])
    
        
    
        
        :type actionParameters: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.Object<System.Object>}
    
        
        :type declaredParameterInfos: System.Reflection.ParameterInfo<System.Reflection.ParameterInfo>[]
        :rtype: System.Object<System.Object>[]
    
        
        .. code-block:: csharp
    
            public static object[] PrepareArguments(IDictionary<string, object> actionParameters, ParameterInfo[] declaredParameterInfos)
    

