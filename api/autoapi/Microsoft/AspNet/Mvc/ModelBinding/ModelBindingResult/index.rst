

ModelBindingResult Struct
=========================



.. contents:: 
   :local:



Summary
-------

Contains the result of model binding.











Syntax
------

.. code-block:: csharp

   public struct ModelBindingResult : IEquatable<ModelBindingResult>





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Abstractions/ModelBinding/ModelBindingResult.cs>`_





.. dn:structure:: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingResult

Methods
-------

.. dn:structure:: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingResult.Equals(Microsoft.AspNet.Mvc.ModelBinding.ModelBindingResult)
    
        
        
        
        :type other: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingResult
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool Equals(ModelBindingResult other)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingResult.Equals(System.Object)
    
        
        
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingResult.Failed(System.String)
    
        
    
        Creates a :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelBindingResult` representing a failed model binding operation.
    
        
        
        
        :param key: The key of the current model binding operation.
        
        :type key: System.String
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingResult
        :return: A <see cref="T:Microsoft.AspNet.Mvc.ModelBinding.ModelBindingResult" /> representing a failed model binding operation.
    
        
        .. code-block:: csharp
    
           public static ModelBindingResult Failed(string key)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingResult.FailedAsync(System.String)
    
        
    
        Creates a completed :any:`System.Threading.Tasks.Task\`1` representing a failed model binding operation.
    
        
        
        
        :param key: The key of the current model binding operation.
        
        :type key: System.String
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Mvc.ModelBinding.ModelBindingResult}
        :return: A completed <see cref="T:System.Threading.Tasks.Task`1" /> representing a failed model binding operation.
    
        
        .. code-block:: csharp
    
           public static Task<ModelBindingResult> FailedAsync(string key)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingResult.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public override int GetHashCode()
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingResult.Success(System.String, System.Object)
    
        
    
        Creates a :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelBindingResult` representing a successful model binding operation.
    
        
        
        
        :param key: The key of the current model binding operation.
        
        :type key: System.String
        
        
        :param model: The model value. May be null.
        
        :type model: System.Object
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingResult
        :return: A <see cref="T:Microsoft.AspNet.Mvc.ModelBinding.ModelBindingResult" /> representing a successful model bind.
    
        
        .. code-block:: csharp
    
           public static ModelBindingResult Success(string key, object model)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingResult.SuccessAsync(System.String, System.Object)
    
        
    
        Creates a completed :any:`System.Threading.Tasks.Task\`1` representing a successful model binding
        operation.
    
        
        
        
        :param key: The key of the current model binding operation.
        
        :type key: System.String
        
        
        :param model: The model value. May be null.
        
        :type model: System.Object
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Mvc.ModelBinding.ModelBindingResult}
        :return: A completed <see cref="T:System.Threading.Tasks.Task`1" /> representing a successful model bind.
    
        
        .. code-block:: csharp
    
           public static Task<ModelBindingResult> SuccessAsync(string key, object model)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingResult.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public override string ToString()
    

Fields
------

.. dn:structure:: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingResult
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingResult.NoResult
    
        
    
        A :dn:ns:`Microsoft.AspNet.Mvc.ModelBinding` representing the lack of a result. The model binding
        system will continue to execute other model binders.
    
        
    
        
        .. code-block:: csharp
    
           public static readonly ModelBindingResult NoResult
    
    .. dn:field:: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingResult.NoResultAsync
    
        
    
        Returns a completed :any:`System.Threading.Tasks.Task\`1` representing the lack of a result. The model
        binding system will continue to execute other model binders.
    
        
    
        
        .. code-block:: csharp
    
           public static readonly Task<ModelBindingResult> NoResultAsync
    

Properties
----------

.. dn:structure:: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingResult.IsModelSet
    
        
    
        <para>
        Gets a value indicating whether or not the :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ModelBindingResult.Model` value has been set.
        </para>
        <para>
        This property can be used to distinguish between a model binder which does not find a value and
        the case where a model binder sets the <c>null</c> value.
        </para>
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsModelSet { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingResult.Key
    
        
    
        <para>
        Gets the model name which was used to bind the model.
        </para>
        <para>
        This property can be used during validation to add model state for a bound model.
        </para>
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Key { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ModelBindingResult.Model
    
        
    
        Gets the model associated with this context.
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           public object Model { get; }
    

