

DefaultApplicationModelProvider Class
=====================================





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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Internal.DefaultApplicationModelProvider`








Syntax
------

.. code-block:: csharp

    public class DefaultApplicationModelProvider : IApplicationModelProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.DefaultApplicationModelProvider
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.DefaultApplicationModelProvider

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.DefaultApplicationModelProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Internal.DefaultApplicationModelProvider.DefaultApplicationModelProvider(Microsoft.Extensions.Options.IOptions<Microsoft.AspNetCore.Mvc.MvcOptions>)
    
        
    
        
        :type mvcOptionsAccessor: Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Options.IOptions`1>{Microsoft.AspNetCore.Mvc.MvcOptions<Microsoft.AspNetCore.Mvc.MvcOptions>}
    
        
        .. code-block:: csharp
    
            public DefaultApplicationModelProvider(IOptions<MvcOptions> mvcOptionsAccessor)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.DefaultApplicationModelProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.DefaultApplicationModelProvider.CreateActionModel(System.Reflection.TypeInfo, System.Reflection.MethodInfo)
    
        
    
        
        Creates the :any:`Microsoft.AspNetCore.Mvc.ApplicationModels.ActionModel` instance for the given action :any:`System.Reflection.MethodInfo`\.
    
        
    
        
        :param typeInfo: The controller :any:`System.Reflection.TypeInfo`\.
        
        :type typeInfo: System.Reflection.TypeInfo
    
        
        :param methodInfo: The action :any:`System.Reflection.MethodInfo`\.
        
        :type methodInfo: System.Reflection.MethodInfo
        :rtype: Microsoft.AspNetCore.Mvc.ApplicationModels.ActionModel
        :return: 
            An :any:`Microsoft.AspNetCore.Mvc.ApplicationModels.ActionModel` instance for the given action :any:`System.Reflection.MethodInfo` or
            <code>null</code> if the <em>methodInfo</em> does not represent an action.
    
        
        .. code-block:: csharp
    
            protected virtual ActionModel CreateActionModel(TypeInfo typeInfo, MethodInfo methodInfo)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.DefaultApplicationModelProvider.CreateControllerModel(System.Reflection.TypeInfo)
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.Mvc.ApplicationModels.ControllerModel` for the given :any:`System.Reflection.TypeInfo`\.
    
        
    
        
        :param typeInfo: The :any:`System.Reflection.TypeInfo`\.
        
        :type typeInfo: System.Reflection.TypeInfo
        :rtype: Microsoft.AspNetCore.Mvc.ApplicationModels.ControllerModel
        :return: A :any:`Microsoft.AspNetCore.Mvc.ApplicationModels.ControllerModel` for the given :any:`System.Reflection.TypeInfo`\.
    
        
        .. code-block:: csharp
    
            protected virtual ControllerModel CreateControllerModel(TypeInfo typeInfo)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.DefaultApplicationModelProvider.CreateParameterModel(System.Reflection.ParameterInfo)
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.Mvc.ApplicationModels.ParameterModel` for the given :any:`System.Reflection.ParameterInfo`\.
    
        
    
        
        :param parameterInfo: The :any:`System.Reflection.ParameterInfo`\.
        
        :type parameterInfo: System.Reflection.ParameterInfo
        :rtype: Microsoft.AspNetCore.Mvc.ApplicationModels.ParameterModel
        :return: A :any:`Microsoft.AspNetCore.Mvc.ApplicationModels.ParameterModel` for the given :any:`System.Reflection.ParameterInfo`\.
    
        
        .. code-block:: csharp
    
            protected virtual ParameterModel CreateParameterModel(ParameterInfo parameterInfo)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.DefaultApplicationModelProvider.CreatePropertyModel(System.Reflection.PropertyInfo)
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.Mvc.ApplicationModels.PropertyModel` for the given :any:`System.Reflection.PropertyInfo`\.
    
        
    
        
        :param propertyInfo: The :any:`System.Reflection.PropertyInfo`\.
        
        :type propertyInfo: System.Reflection.PropertyInfo
        :rtype: Microsoft.AspNetCore.Mvc.ApplicationModels.PropertyModel
        :return: A :any:`Microsoft.AspNetCore.Mvc.ApplicationModels.PropertyModel` for the given :any:`System.Reflection.PropertyInfo`\.
    
        
        .. code-block:: csharp
    
            protected virtual PropertyModel CreatePropertyModel(PropertyInfo propertyInfo)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.DefaultApplicationModelProvider.IsAction(System.Reflection.TypeInfo, System.Reflection.MethodInfo)
    
        
    
        
        Returns <code>true</code> if the <em>methodInfo</em> is an action. Otherwise <code>false</code>.
    
        
    
        
        :param typeInfo: The :any:`System.Reflection.TypeInfo`\.
        
        :type typeInfo: System.Reflection.TypeInfo
    
        
        :param methodInfo: The :any:`System.Reflection.MethodInfo`\.
        
        :type methodInfo: System.Reflection.MethodInfo
        :rtype: System.Boolean
        :return: <code>true</code> if the <em>methodInfo</em> is an action. Otherwise <code>false</code>.
    
        
        .. code-block:: csharp
    
            protected virtual bool IsAction(TypeInfo typeInfo, MethodInfo methodInfo)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.DefaultApplicationModelProvider.OnProvidersExecuted(Microsoft.AspNetCore.Mvc.ApplicationModels.ApplicationModelProviderContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ApplicationModels.ApplicationModelProviderContext
    
        
        .. code-block:: csharp
    
            public virtual void OnProvidersExecuted(ApplicationModelProviderContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.DefaultApplicationModelProvider.OnProvidersExecuting(Microsoft.AspNetCore.Mvc.ApplicationModels.ApplicationModelProviderContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ApplicationModels.ApplicationModelProviderContext
    
        
        .. code-block:: csharp
    
            public virtual void OnProvidersExecuting(ApplicationModelProviderContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.DefaultApplicationModelProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Internal.DefaultApplicationModelProvider.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int Order { get; }
    

