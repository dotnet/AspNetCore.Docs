

ObjectMethodExecutor Class
==========================





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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Internal.ObjectMethodExecutor`








Syntax
------

.. code-block:: csharp

    public class ObjectMethodExecutor








.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ObjectMethodExecutor
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ObjectMethodExecutor

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ObjectMethodExecutor
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Internal.ObjectMethodExecutor.MethodInfo
    
        
        :rtype: System.Reflection.MethodInfo
    
        
        .. code-block:: csharp
    
            public MethodInfo MethodInfo
            {
                get;
            }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ObjectMethodExecutor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.ObjectMethodExecutor.Create(System.Reflection.MethodInfo, System.Reflection.TypeInfo)
    
        
    
        
        :type methodInfo: System.Reflection.MethodInfo
    
        
        :type targetTypeInfo: System.Reflection.TypeInfo
        :rtype: Microsoft.AspNetCore.Mvc.Internal.ObjectMethodExecutor
    
        
        .. code-block:: csharp
    
            public static ObjectMethodExecutor Create(MethodInfo methodInfo, TypeInfo targetTypeInfo)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.ObjectMethodExecutor.Execute(System.Object, System.Object[])
    
        
    
        
        :type target: System.Object
    
        
        :type parameters: System.Object<System.Object>[]
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            public object Execute(object target, object[] parameters)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.ObjectMethodExecutor.ExecuteAsync(System.Object, System.Object[])
    
        
    
        
        :type target: System.Object
    
        
        :type parameters: System.Object<System.Object>[]
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public Task<object> ExecuteAsync(object target, object[] parameters)
    

