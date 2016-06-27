

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

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Internal.ObjectMethodExecutor.ActionParameters
    
        
        :rtype: System.Reflection.ParameterInfo<System.Reflection.ParameterInfo>[]
    
        
        .. code-block:: csharp
    
            public ParameterInfo[] ActionParameters { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Internal.ObjectMethodExecutor.IsMethodAsync
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsMethodAsync { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Internal.ObjectMethodExecutor.IsTypeAssignableFromIActionResult
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsTypeAssignableFromIActionResult { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Internal.ObjectMethodExecutor.MethodInfo
    
        
        :rtype: System.Reflection.MethodInfo
    
        
        .. code-block:: csharp
    
            public MethodInfo MethodInfo { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Internal.ObjectMethodExecutor.MethodReturnType
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
            public Type MethodReturnType { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Internal.ObjectMethodExecutor.TargetTypeInfo
    
        
        :rtype: System.Reflection.TypeInfo
    
        
        .. code-block:: csharp
    
            public TypeInfo TargetTypeInfo { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Internal.ObjectMethodExecutor.TaskGenericType
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
            public Type TaskGenericType { get; }
    

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
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.ObjectMethodExecutor.GetDefaultValueForParameter(System.Int32)
    
        
    
        
        :type index: System.Int32
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            public object GetDefaultValueForParameter(int index)
    

