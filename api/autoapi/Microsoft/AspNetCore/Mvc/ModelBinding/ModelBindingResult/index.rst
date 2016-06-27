

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

Operators
---------

.. dn:structure:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult
    :noindex:
    :hidden:

    
    .. dn:operator:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult.Equality(Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult, Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult)
    
        
    
        
        Compares :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult` objects for equality.
    
        
    
        
        :param x: A :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult`\.
        
        :type x: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult
    
        
        :param y: A :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult`\.
        
        :type y: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult
        :rtype: System.Boolean
        :return: <code>true</code> if the objects are equal, otherwise <code>false</code>.
    
        
        .. code-block:: csharp
    
            public static bool operator ==(ModelBindingResult x, ModelBindingResult y)
    
    .. dn:operator:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult.Inequality(Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult, Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult)
    
        
    
        
        Compares :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult` objects for inequality.
    
        
    
        
        :param x: A :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult`\.
        
        :type x: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult
    
        
        :param y: A :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult`\.
        
        :type y: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult
        :rtype: System.Boolean
        :return: <code>true</code> if the objects are not equal, otherwise <code>false</code>.
    
        
        .. code-block:: csharp
    
            public static bool operator !=(ModelBindingResult x, ModelBindingResult y)
    

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
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult.Failed()
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult` representing a failed model binding operation.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult
        :return: A :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult` representing a failed model binding operation.
    
        
        .. code-block:: csharp
    
            public static ModelBindingResult Failed()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int GetHashCode()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult.Success(System.Object)
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult` representing a successful model binding operation.
    
        
    
        
        :param model: The model value. May be <code>null.</code>
        
        :type model: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult
        :return: A :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult` representing a successful model bind.
    
        
        .. code-block:: csharp
    
            public static ModelBindingResult Success(object model)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string ToString()
    

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
    
            public bool IsModelSet { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult.Model
    
        
    
        
        Gets the model associated with this context.
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            public object Model { get; }
    

