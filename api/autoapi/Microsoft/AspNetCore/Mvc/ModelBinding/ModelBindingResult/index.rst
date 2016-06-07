

ModelBindingResult Struct
=========================






Contains the result of model binding.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ModelBinding`
Assemblies
    * Microsoft.AspNetCore.Mvc.Abstractions

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public struct ModelBindingResult : IEquatable<ModelBindingResult>








.. dn:structure:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult
    :hidden:

.. dn:structure:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult

Properties
----------

.. dn:structure:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult.IsModelSet
    
        
    
        
        <p>
        Gets a value indicating whether or not the :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult.Model` value has been set.
        </p>
        <p>
        This property can be used to distinguish between a model binder which does not find a value and
        the case where a model binder sets the <code>null</code> value.
        </p>
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsModelSet
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult.Key
    
        
    
        
        <p>
        Gets the model name which was used to bind the model.
        </p>
        <p>
        This property can be used during validation to add model state for a bound model.
        </p>
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Key
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult.Model
    
        
    
        
        Gets the model associated with this context.
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            public object Model
            {
                get;
            }
    

Methods
-------

.. dn:structure:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult.Equals(Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult)
    
        
    
        
        :type other: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Equals(ModelBindingResult other)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult.Equals(System.Object)
    
        
    
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult.Failed(System.String)
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult` representing a failed model binding operation.
    
        
    
        
        :param key: The key of the current model binding operation.
        
        :type key: System.String
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult
        :return: A :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult` representing a failed model binding operation.
    
        
        .. code-block:: csharp
    
            public static ModelBindingResult Failed(string key)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int GetHashCode()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult.Success(System.String, System.Object)
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult` representing a successful model binding operation.
    
        
    
        
        :param key: The key of the current model binding operation.
        
        :type key: System.String
    
        
        :param model: The model value. May be <code>null.</code>
        
        :type model: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult
        :return: A :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult` representing a successful model bind.
    
        
        .. code-block:: csharp
    
            public static ModelBindingResult Success(string key, object model)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string ToString()
    

