

DefaultApplicationModelProvider Class
=====================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ApplicationModels.DefaultApplicationModelProvider`








Syntax
------

.. code-block:: csharp

   public class DefaultApplicationModelProvider : IApplicationModelProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/ApplicationModels/DefaultApplicationModelProvider.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ApplicationModels.DefaultApplicationModelProvider

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ApplicationModels.DefaultApplicationModelProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ApplicationModels.DefaultApplicationModelProvider.DefaultApplicationModelProvider(Microsoft.Extensions.OptionsModel.IOptions<Microsoft.AspNet.Mvc.MvcOptions>)
    
        
        
        
        :type mvcOptionsAccessor: Microsoft.Extensions.OptionsModel.IOptions{Microsoft.AspNet.Mvc.MvcOptions}
    
        
        .. code-block:: csharp
    
           public DefaultApplicationModelProvider(IOptions<MvcOptions> mvcOptionsAccessor)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ApplicationModels.DefaultApplicationModelProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ApplicationModels.DefaultApplicationModelProvider.BuildActionModels(System.Reflection.TypeInfo, System.Reflection.MethodInfo)
    
        
    
        Creates the :any:`Microsoft.AspNet.Mvc.ApplicationModels.ControllerModel` instances for the given action :any:`System.Reflection.MethodInfo`\.
    
        
        
        
        :param typeInfo: The controller .
        
        :type typeInfo: System.Reflection.TypeInfo
        
        
        :param methodInfo: The action .
        
        :type methodInfo: System.Reflection.MethodInfo
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.ApplicationModels.ActionModel}
        :return: A set of <see cref="T:Microsoft.AspNet.Mvc.ApplicationModels.ActionModel" /> instances for the given action <see cref="T:System.Reflection.MethodInfo" /> or
            <c>null</c> if the <paramref name="methodInfo" /> does not represent an action.
    
        
        .. code-block:: csharp
    
           protected virtual IEnumerable<ActionModel> BuildActionModels(TypeInfo typeInfo, MethodInfo methodInfo)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ApplicationModels.DefaultApplicationModelProvider.BuildControllerModels(System.Reflection.TypeInfo)
    
        
    
        Creates the :any:`Microsoft.AspNet.Mvc.ApplicationModels.ControllerModel` instances for the given controller :any:`System.Reflection.TypeInfo`\.
    
        
        
        
        :param typeInfo: The controller .
        
        :type typeInfo: System.Reflection.TypeInfo
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.ApplicationModels.ControllerModel}
        :return: A set of <see cref="T:Microsoft.AspNet.Mvc.ApplicationModels.ControllerModel" /> instances for the given controller <see cref="T:System.Reflection.TypeInfo" /> or
            <c>null</c> if the <paramref name="typeInfo" /> does not represent a controller.
    
        
        .. code-block:: csharp
    
           protected virtual IEnumerable<ControllerModel> BuildControllerModels(TypeInfo typeInfo)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ApplicationModels.DefaultApplicationModelProvider.CreateActionModel(System.Reflection.MethodInfo, System.Collections.Generic.IReadOnlyList<System.Object>)
    
        
    
        Creates an :any:`Microsoft.AspNet.Mvc.ApplicationModels.ActionModel` for the given :any:`System.Reflection.MethodInfo`\.
    
        
        
        
        :param methodInfo: The .
        
        :type methodInfo: System.Reflection.MethodInfo
        
        
        :param attributes: The set of attributes to use as metadata.
        
        :type attributes: System.Collections.Generic.IReadOnlyList{System.Object}
        :rtype: Microsoft.AspNet.Mvc.ApplicationModels.ActionModel
        :return: An <see cref="T:Microsoft.AspNet.Mvc.ApplicationModels.ActionModel" /> for the given <see cref="T:System.Reflection.MethodInfo" />.
    
        
        .. code-block:: csharp
    
           protected virtual ActionModel CreateActionModel(MethodInfo methodInfo, IReadOnlyList<object> attributes)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ApplicationModels.DefaultApplicationModelProvider.CreateControllerModel(System.Reflection.TypeInfo)
    
        
    
        Creates a :any:`Microsoft.AspNet.Mvc.ApplicationModels.ControllerModel` for the given :any:`System.Reflection.TypeInfo`\.
    
        
        
        
        :param typeInfo: The .
        
        :type typeInfo: System.Reflection.TypeInfo
        :rtype: Microsoft.AspNet.Mvc.ApplicationModels.ControllerModel
        :return: A <see cref="T:Microsoft.AspNet.Mvc.ApplicationModels.ControllerModel" /> for the given <see cref="T:System.Reflection.TypeInfo" />.
    
        
        .. code-block:: csharp
    
           protected virtual ControllerModel CreateControllerModel(TypeInfo typeInfo)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ApplicationModels.DefaultApplicationModelProvider.CreateParameterModel(System.Reflection.ParameterInfo)
    
        
    
        Creates a :any:`Microsoft.AspNet.Mvc.ApplicationModels.ParameterModel` for the given :any:`System.Reflection.ParameterInfo`\.
    
        
        
        
        :param parameterInfo: The .
        
        :type parameterInfo: System.Reflection.ParameterInfo
        :rtype: Microsoft.AspNet.Mvc.ApplicationModels.ParameterModel
        :return: A <see cref="T:Microsoft.AspNet.Mvc.ApplicationModels.ParameterModel" /> for the given <see cref="T:System.Reflection.ParameterInfo" />.
    
        
        .. code-block:: csharp
    
           protected virtual ParameterModel CreateParameterModel(ParameterInfo parameterInfo)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ApplicationModels.DefaultApplicationModelProvider.CreatePropertyModel(System.Reflection.PropertyInfo)
    
        
    
        Creates a :any:`Microsoft.AspNet.Mvc.ApplicationModels.PropertyModel` for the given :any:`System.Reflection.PropertyInfo`\.
    
        
        
        
        :param propertyInfo: The .
        
        :type propertyInfo: System.Reflection.PropertyInfo
        :rtype: Microsoft.AspNet.Mvc.ApplicationModels.PropertyModel
        :return: A <see cref="T:Microsoft.AspNet.Mvc.ApplicationModels.PropertyModel" /> for the given <see cref="T:System.Reflection.PropertyInfo" />.
    
        
        .. code-block:: csharp
    
           protected virtual PropertyModel CreatePropertyModel(PropertyInfo propertyInfo)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ApplicationModels.DefaultApplicationModelProvider.IsAction(System.Reflection.TypeInfo, System.Reflection.MethodInfo)
    
        
    
        Returns <c>true</c> if the ``methodInfo`` is an action. Otherwise <c>false</c>.
    
        
        
        
        :param typeInfo: The .
        
        :type typeInfo: System.Reflection.TypeInfo
        
        
        :param methodInfo: The .
        
        :type methodInfo: System.Reflection.MethodInfo
        :rtype: System.Boolean
        :return: <c>true</c> if the <paramref name="methodInfo" /> is an action. Otherwise <c>false</c>.
    
        
        .. code-block:: csharp
    
           protected virtual bool IsAction(TypeInfo typeInfo, MethodInfo methodInfo)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ApplicationModels.DefaultApplicationModelProvider.OnProvidersExecuted(Microsoft.AspNet.Mvc.ApplicationModels.ApplicationModelProviderContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.ApplicationModels.ApplicationModelProviderContext
    
        
        .. code-block:: csharp
    
           public virtual void OnProvidersExecuted(ApplicationModelProviderContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ApplicationModels.DefaultApplicationModelProvider.OnProvidersExecuting(Microsoft.AspNet.Mvc.ApplicationModels.ApplicationModelProviderContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.ApplicationModels.ApplicationModelProviderContext
    
        
        .. code-block:: csharp
    
           public virtual void OnProvidersExecuting(ApplicationModelProviderContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ApplicationModels.DefaultApplicationModelProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ApplicationModels.DefaultApplicationModelProvider.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int Order { get; }
    

