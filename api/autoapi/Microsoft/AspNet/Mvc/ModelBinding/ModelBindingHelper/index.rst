

ModelBindingHelper Class
========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.ModelBindingHelper`








Syntax
------

.. code-block:: csharp

   public class ModelBindingHelper





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/ModelBinding/ModelBindingHelper.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingHelper

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingHelper
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingHelper.ClearValidationStateForModel(System.Type, Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary, Microsoft.AspNet.Mvc.ModelBinding.IModelMetadataProvider, System.String)
    
        
    
        Clears :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary` entries for :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelMetadata`\.
    
        
        
        
        :type modelType: System.Type
        
        
        :type modelstate: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary
        
        
        :type metadataProvider: Microsoft.AspNet.Mvc.ModelBinding.IModelMetadataProvider
        
        
        :param modelKey: The entry to clear.
        
        :type modelKey: System.String
    
        
        .. code-block:: csharp
    
           public static void ClearValidationStateForModel(Type modelType, ModelStateDictionary modelstate, IModelMetadataProvider metadataProvider, string modelKey)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingHelper.ConvertTo(System.Object, System.Type)
    
        
    
        Converts the provided ``value`` to a value of :any:`System.Type`\<param name="type" />
        using the :dn:prop:`System.Globalization.CultureInfo.InvariantCulture`\.
    
        
        
        
        :param value: The value to convert."/>
        
        :type value: System.Object
        
        
        :param type: The  for conversion.
        
        :type type: System.Type
        :rtype: System.Object
        :return: The converted value or <c>null</c> if the value could not be converted.
    
        
        .. code-block:: csharp
    
           public static object ConvertTo(object value, Type type)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingHelper.ConvertTo(System.Object, System.Type, System.Globalization.CultureInfo)
    
        
    
        Converts the provided ``value`` to a value of :any:`System.Type`\``type``.
    
        
        
        
        :param value: The value to convert."/>
        
        :type value: System.Object
        
        
        :param type: The  for conversion.
        
        :type type: System.Type
        
        
        :param culture: The  for conversion.
        
        :type culture: System.Globalization.CultureInfo
        :rtype: System.Object
        :return: The converted value or <c>null</c> if the value could not be converted.
    
        
        .. code-block:: csharp
    
           public static object ConvertTo(object value, Type type, CultureInfo culture)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingHelper.ConvertTo<T>(System.Object)
    
        
    
        Converts the provided ``value`` to a value of :any:`System.Type`\``T``
        using the :dn:prop:`System.Globalization.CultureInfo.InvariantCulture`\.
    
        
        
        
        :param value: The value to convert."/>
        
        :type value: System.Object
        :rtype: {T}
        :return: The converted value or the default value of <typeparamref name="T" /> if the value could not be converted.
    
        
        .. code-block:: csharp
    
           public static T ConvertTo<T>(object value)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingHelper.ConvertTo<T>(System.Object, System.Globalization.CultureInfo)
    
        
    
        Converts the provided ``value`` to a value of :any:`System.Type`\``T``.
    
        
        
        
        :param value: The value to convert."/>
        
        :type value: System.Object
        
        
        :param culture: The  for conversion.
        
        :type culture: System.Globalization.CultureInfo
        :rtype: {T}
        :return: The converted value or the default value of <typeparamref name="T" /> if the value could not be converted.
    
        
        .. code-block:: csharp
    
           public static T ConvertTo<T>(object value, CultureInfo culture)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingHelper.ConvertValuesToCollectionType<T>(System.Type, System.Collections.Generic.IList<T>)
    
        
        
        
        :type modelType: System.Type
        
        
        :type values: System.Collections.Generic.IList{{T}}
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           public static object ConvertValuesToCollectionType<T>(Type modelType, IList<T> values)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingHelper.GetIncludePredicateExpression<TModel>(System.String, System.Linq.Expressions.Expression<System.Func<TModel, System.Object>>[])
    
        
    
        Creates an expression for a predicate to limit the set of properties used in model binding.
    
        
        
        
        :param prefix: The model prefix.
        
        :type prefix: System.String
        
        
        :param expressions: Expressions identifying the properties to allow for binding.
        
        :type expressions: System.Linq.Expressions.Expression{System.Func{{TModel},System.Object}}[]
        :rtype: System.Linq.Expressions.Expression{System.Func{Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext,System.String,System.Boolean}}
        :return: An expression which can be used with <see cref="T:Microsoft.AspNet.Mvc.ModelBinding.IPropertyBindingPredicateProvider" />.
    
        
        .. code-block:: csharp
    
           public static Expression<Func<ModelBindingContext, string, bool>> GetIncludePredicateExpression<TModel>(string prefix, Expression<Func<TModel, object>>[] expressions)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingHelper.TryUpdateModelAsync(System.Object, System.Type, System.String, Microsoft.AspNet.Http.HttpContext, Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary, Microsoft.AspNet.Mvc.ModelBinding.IModelMetadataProvider, Microsoft.AspNet.Mvc.ModelBinding.IModelBinder, Microsoft.AspNet.Mvc.ModelBinding.IValueProvider, System.Collections.Generic.IList<Microsoft.AspNet.Mvc.Formatters.IInputFormatter>, Microsoft.AspNet.Mvc.ModelBinding.Validation.IObjectModelValidator, Microsoft.AspNet.Mvc.ModelBinding.Validation.IModelValidatorProvider)
    
        
    
        Updates the specified ``model`` instance using the specified ``modelBinder``
        and the specified ``valueProvider`` and executes validation using the specified
        ``validatorProvider``.
    
        
        
        
        :param model: The model instance to update and validate.
        
        :type model: System.Object
        
        
        :param modelType: The type of model instance to update and validate.
        
        :type modelType: System.Type
        
        
        :param prefix: The prefix to use when looking up values in the .
        
        :type prefix: System.String
        
        
        :param httpContext: The  for the current executing request.
        
        :type httpContext: Microsoft.AspNet.Http.HttpContext
        
        
        :param modelState: The  used for maintaining state and
            results of model-binding validation.
        
        :type modelState: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary
        
        
        :param metadataProvider: The provider used for reading metadata for the model type.
        
        :type metadataProvider: Microsoft.AspNet.Mvc.ModelBinding.IModelMetadataProvider
        
        
        :param modelBinder: The  used for binding.
        
        :type modelBinder: Microsoft.AspNet.Mvc.ModelBinding.IModelBinder
        
        
        :param valueProvider: The  used for looking up values.
        
        :type valueProvider: Microsoft.AspNet.Mvc.ModelBinding.IValueProvider
        
        
        :param inputFormatters: The set of  instances for deserializing the body.
        
        :type inputFormatters: System.Collections.Generic.IList{Microsoft.AspNet.Mvc.Formatters.IInputFormatter}
        
        
        :param objectModelValidator: The  used for validating the
            bound values.
        
        :type objectModelValidator: Microsoft.AspNet.Mvc.ModelBinding.Validation.IObjectModelValidator
        
        
        :param validatorProvider: The  used for executing validation
            on the model instance.
        
        :type validatorProvider: Microsoft.AspNet.Mvc.ModelBinding.Validation.IModelValidatorProvider
        :rtype: System.Threading.Tasks.Task{System.Boolean}
        :return: A <see cref="T:System.Threading.Tasks.Task" /> that on completion returns <c>true</c> if the update is successful
    
        
        .. code-block:: csharp
    
           public static Task<bool> TryUpdateModelAsync(object model, Type modelType, string prefix, HttpContext httpContext, ModelStateDictionary modelState, IModelMetadataProvider metadataProvider, IModelBinder modelBinder, IValueProvider valueProvider, IList<IInputFormatter> inputFormatters, IObjectModelValidator objectModelValidator, IModelValidatorProvider validatorProvider)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingHelper.TryUpdateModelAsync(System.Object, System.Type, System.String, Microsoft.AspNet.Http.HttpContext, Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary, Microsoft.AspNet.Mvc.ModelBinding.IModelMetadataProvider, Microsoft.AspNet.Mvc.ModelBinding.IModelBinder, Microsoft.AspNet.Mvc.ModelBinding.IValueProvider, System.Collections.Generic.IList<Microsoft.AspNet.Mvc.Formatters.IInputFormatter>, Microsoft.AspNet.Mvc.ModelBinding.Validation.IObjectModelValidator, Microsoft.AspNet.Mvc.ModelBinding.Validation.IModelValidatorProvider, System.Func<Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext, System.String, System.Boolean>)
    
        
    
        Updates the specified ``model`` instance using the specified ``modelBinder``
        and the specified ``valueProvider`` and executes validation using the specified
        ``validatorProvider``.
    
        
        
        
        :param model: The model instance to update and validate.
        
        :type model: System.Object
        
        
        :param modelType: The type of model instance to update and validate.
        
        :type modelType: System.Type
        
        
        :param prefix: The prefix to use when looking up values in the .
        
        :type prefix: System.String
        
        
        :param httpContext: The  for the current executing request.
        
        :type httpContext: Microsoft.AspNet.Http.HttpContext
        
        
        :param modelState: The  used for maintaining state and
            results of model-binding validation.
        
        :type modelState: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary
        
        
        :param metadataProvider: The provider used for reading metadata for the model type.
        
        :type metadataProvider: Microsoft.AspNet.Mvc.ModelBinding.IModelMetadataProvider
        
        
        :param modelBinder: The  used for binding.
        
        :type modelBinder: Microsoft.AspNet.Mvc.ModelBinding.IModelBinder
        
        
        :param valueProvider: The  used for looking up values.
        
        :type valueProvider: Microsoft.AspNet.Mvc.ModelBinding.IValueProvider
        
        
        :param inputFormatters: The set of  instances for deserializing the body.
        
        :type inputFormatters: System.Collections.Generic.IList{Microsoft.AspNet.Mvc.Formatters.IInputFormatter}
        
        
        :param objectModelValidator: The  used for validating the
            bound values.
        
        :type objectModelValidator: Microsoft.AspNet.Mvc.ModelBinding.Validation.IObjectModelValidator
        
        
        :param validatorProvider: The  used for executing validation
            on the model instance.
        
        :type validatorProvider: Microsoft.AspNet.Mvc.ModelBinding.Validation.IModelValidatorProvider
        
        
        :param predicate: A predicate which can be used to
            filter properties(for inclusion/exclusion) at runtime.
        
        :type predicate: System.Func{Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext,System.String,System.Boolean}
        :rtype: System.Threading.Tasks.Task{System.Boolean}
        :return: A <see cref="T:System.Threading.Tasks.Task" /> that on completion returns <c>true</c> if the update is successful
    
        
        .. code-block:: csharp
    
           public static Task<bool> TryUpdateModelAsync(object model, Type modelType, string prefix, HttpContext httpContext, ModelStateDictionary modelState, IModelMetadataProvider metadataProvider, IModelBinder modelBinder, IValueProvider valueProvider, IList<IInputFormatter> inputFormatters, IObjectModelValidator objectModelValidator, IModelValidatorProvider validatorProvider, Func<ModelBindingContext, string, bool> predicate)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingHelper.TryUpdateModelAsync<TModel>(TModel, System.String, Microsoft.AspNet.Http.HttpContext, Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary, Microsoft.AspNet.Mvc.ModelBinding.IModelMetadataProvider, Microsoft.AspNet.Mvc.ModelBinding.IModelBinder, Microsoft.AspNet.Mvc.ModelBinding.IValueProvider, System.Collections.Generic.IList<Microsoft.AspNet.Mvc.Formatters.IInputFormatter>, Microsoft.AspNet.Mvc.ModelBinding.Validation.IObjectModelValidator, Microsoft.AspNet.Mvc.ModelBinding.Validation.IModelValidatorProvider)
    
        
    
        Updates the specified ``model`` instance using the specified ``modelBinder``
        and the specified ``valueProvider`` and executes validation using the specified
        ``validatorProvider``.
    
        
        
        
        :param model: The model instance to update and validate.
        
        :type model: {TModel}
        
        
        :param prefix: The prefix to use when looking up values in the .
        
        :type prefix: System.String
        
        
        :param httpContext: The  for the current executing request.
        
        :type httpContext: Microsoft.AspNet.Http.HttpContext
        
        
        :param modelState: The  used for maintaining state and
            results of model-binding validation.
        
        :type modelState: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary
        
        
        :param metadataProvider: The provider used for reading metadata for the model type.
        
        :type metadataProvider: Microsoft.AspNet.Mvc.ModelBinding.IModelMetadataProvider
        
        
        :param modelBinder: The  used for binding.
        
        :type modelBinder: Microsoft.AspNet.Mvc.ModelBinding.IModelBinder
        
        
        :param valueProvider: The  used for looking up values.
        
        :type valueProvider: Microsoft.AspNet.Mvc.ModelBinding.IValueProvider
        
        
        :param inputFormatters: The set of  instances for deserializing the body.
        
        :type inputFormatters: System.Collections.Generic.IList{Microsoft.AspNet.Mvc.Formatters.IInputFormatter}
        
        
        :param objectModelValidator: The  used for validating the
            bound values.
        
        :type objectModelValidator: Microsoft.AspNet.Mvc.ModelBinding.Validation.IObjectModelValidator
        
        
        :param validatorProvider: The  used for executing validation
            on the model instance.
        
        :type validatorProvider: Microsoft.AspNet.Mvc.ModelBinding.Validation.IModelValidatorProvider
        :rtype: System.Threading.Tasks.Task{System.Boolean}
        :return: A <see cref="T:System.Threading.Tasks.Task" /> that on completion returns <c>true</c> if the update is successful
    
        
        .. code-block:: csharp
    
           public static Task<bool> TryUpdateModelAsync<TModel>(TModel model, string prefix, HttpContext httpContext, ModelStateDictionary modelState, IModelMetadataProvider metadataProvider, IModelBinder modelBinder, IValueProvider valueProvider, IList<IInputFormatter> inputFormatters, IObjectModelValidator objectModelValidator, IModelValidatorProvider validatorProvider)where TModel : class
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingHelper.TryUpdateModelAsync<TModel>(TModel, System.String, Microsoft.AspNet.Http.HttpContext, Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary, Microsoft.AspNet.Mvc.ModelBinding.IModelMetadataProvider, Microsoft.AspNet.Mvc.ModelBinding.IModelBinder, Microsoft.AspNet.Mvc.ModelBinding.IValueProvider, System.Collections.Generic.IList<Microsoft.AspNet.Mvc.Formatters.IInputFormatter>, Microsoft.AspNet.Mvc.ModelBinding.Validation.IObjectModelValidator, Microsoft.AspNet.Mvc.ModelBinding.Validation.IModelValidatorProvider, System.Func<Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext, System.String, System.Boolean>)
    
        
    
        Updates the specified ``model`` instance using the specified ``modelBinder``
        and the specified ``valueProvider`` and executes validation using the specified
        ``validatorProvider``.
    
        
        
        
        :param model: The model instance to update and validate.
        
        :type model: {TModel}
        
        
        :param prefix: The prefix to use when looking up values in the .
        
        :type prefix: System.String
        
        
        :param httpContext: The  for the current executing request.
        
        :type httpContext: Microsoft.AspNet.Http.HttpContext
        
        
        :param modelState: The  used for maintaining state and
            results of model-binding validation.
        
        :type modelState: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary
        
        
        :param metadataProvider: The provider used for reading metadata for the model type.
        
        :type metadataProvider: Microsoft.AspNet.Mvc.ModelBinding.IModelMetadataProvider
        
        
        :param modelBinder: The  used for binding.
        
        :type modelBinder: Microsoft.AspNet.Mvc.ModelBinding.IModelBinder
        
        
        :param valueProvider: The  used for looking up values.
        
        :type valueProvider: Microsoft.AspNet.Mvc.ModelBinding.IValueProvider
        
        
        :param inputFormatters: The set of  instances for deserializing the body.
        
        :type inputFormatters: System.Collections.Generic.IList{Microsoft.AspNet.Mvc.Formatters.IInputFormatter}
        
        
        :param objectModelValidator: The  used for validating the
            bound values.
        
        :type objectModelValidator: Microsoft.AspNet.Mvc.ModelBinding.Validation.IObjectModelValidator
        
        
        :param validatorProvider: The  used for executing validation
            on the model instance.
        
        :type validatorProvider: Microsoft.AspNet.Mvc.ModelBinding.Validation.IModelValidatorProvider
        
        
        :param predicate: A predicate which can be used to
            filter properties(for inclusion/exclusion) at runtime.
        
        :type predicate: System.Func{Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext,System.String,System.Boolean}
        :rtype: System.Threading.Tasks.Task{System.Boolean}
        :return: A <see cref="T:System.Threading.Tasks.Task" /> that on completion returns <c>true</c> if the update is successful
    
        
        .. code-block:: csharp
    
           public static Task<bool> TryUpdateModelAsync<TModel>(TModel model, string prefix, HttpContext httpContext, ModelStateDictionary modelState, IModelMetadataProvider metadataProvider, IModelBinder modelBinder, IValueProvider valueProvider, IList<IInputFormatter> inputFormatters, IObjectModelValidator objectModelValidator, IModelValidatorProvider validatorProvider, Func<ModelBindingContext, string, bool> predicate)where TModel : class
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingHelper.TryUpdateModelAsync<TModel>(TModel, System.String, Microsoft.AspNet.Http.HttpContext, Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary, Microsoft.AspNet.Mvc.ModelBinding.IModelMetadataProvider, Microsoft.AspNet.Mvc.ModelBinding.IModelBinder, Microsoft.AspNet.Mvc.ModelBinding.IValueProvider, System.Collections.Generic.IList<Microsoft.AspNet.Mvc.Formatters.IInputFormatter>, Microsoft.AspNet.Mvc.ModelBinding.Validation.IObjectModelValidator, Microsoft.AspNet.Mvc.ModelBinding.Validation.IModelValidatorProvider, System.Linq.Expressions.Expression<System.Func<TModel, System.Object>>[])
    
        
    
        Updates the specified ``model`` instance using the specified ``modelBinder``
        and the specified ``valueProvider`` and executes validation using the specified
        ``validatorProvider``.
    
        
        
        
        :param model: The model instance to update and validate.
        
        :type model: {TModel}
        
        
        :param prefix: The prefix to use when looking up values in the .
        
        :type prefix: System.String
        
        
        :param httpContext: The  for the current executing request.
        
        :type httpContext: Microsoft.AspNet.Http.HttpContext
        
        
        :param modelState: The  used for maintaining state and
            results of model-binding validation.
        
        :type modelState: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary
        
        
        :param metadataProvider: The provider used for reading metadata for the model type.
        
        :type metadataProvider: Microsoft.AspNet.Mvc.ModelBinding.IModelMetadataProvider
        
        
        :param modelBinder: The  used for binding.
        
        :type modelBinder: Microsoft.AspNet.Mvc.ModelBinding.IModelBinder
        
        
        :param valueProvider: The  used for looking up values.
        
        :type valueProvider: Microsoft.AspNet.Mvc.ModelBinding.IValueProvider
        
        
        :param inputFormatters: The set of  instances for deserializing the body.
        
        :type inputFormatters: System.Collections.Generic.IList{Microsoft.AspNet.Mvc.Formatters.IInputFormatter}
        
        
        :param objectModelValidator: The  used for validating the
            bound values.
        
        :type objectModelValidator: Microsoft.AspNet.Mvc.ModelBinding.Validation.IObjectModelValidator
        
        
        :param validatorProvider: The  used for executing validation
            on the model
            instance.
        
        :type validatorProvider: Microsoft.AspNet.Mvc.ModelBinding.Validation.IModelValidatorProvider
        
        
        :param includeExpressions: Expression(s) which represent top level properties
            which need to be included for the current model.
        
        :type includeExpressions: System.Linq.Expressions.Expression{System.Func{{TModel},System.Object}}[]
        :rtype: System.Threading.Tasks.Task{System.Boolean}
        :return: A <see cref="T:System.Threading.Tasks.Task" /> that on completion returns <c>true</c> if the update is successful
    
        
        .. code-block:: csharp
    
           public static Task<bool> TryUpdateModelAsync<TModel>(TModel model, string prefix, HttpContext httpContext, ModelStateDictionary modelState, IModelMetadataProvider metadataProvider, IModelBinder modelBinder, IValueProvider valueProvider, IList<IInputFormatter> inputFormatters, IObjectModelValidator objectModelValidator, IModelValidatorProvider validatorProvider, params Expression<Func<TModel, object>>[] includeExpressions)where TModel : class
    

