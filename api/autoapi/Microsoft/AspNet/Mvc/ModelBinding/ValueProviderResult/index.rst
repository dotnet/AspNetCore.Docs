

ValueProviderResult Struct
==========================



.. contents:: 
   :local:



Summary
-------

Result of an :dn:meth:`Microsoft.AspNet.Mvc.ModelBinding.IValueProvider.GetValue(System.String)` operation.











Syntax
------

.. code-block:: csharp

   public struct ValueProviderResult : IEquatable<ValueProviderResult>, IEnumerable<string>, IEnumerable





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Abstractions/ModelBinding/ValueProviderResult.cs>`_





.. dn:structure:: Microsoft.AspNet.Mvc.ModelBinding.ValueProviderResult

Constructors
------------

.. dn:structure:: Microsoft.AspNet.Mvc.ModelBinding.ValueProviderResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ModelBinding.ValueProviderResult.ValueProviderResult(Microsoft.Extensions.Primitives.StringValues)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.ModelBinding.ValueProviderResult` using :dn:prop:`System.Globalization.CultureInfo.InvariantCulture`\.
    
        
        
        
        :param values: The submitted values.
        
        :type values: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public ValueProviderResult(StringValues values)
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ModelBinding.ValueProviderResult.ValueProviderResult(Microsoft.Extensions.Primitives.StringValues, System.Globalization.CultureInfo)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.ModelBinding.ValueProviderResult`\.
    
        
        
        
        :type values: Microsoft.Extensions.Primitives.StringValues
        
        
        :param culture: The  associated with this value.
        
        :type culture: System.Globalization.CultureInfo
    
        
        .. code-block:: csharp
    
           public ValueProviderResult(StringValues values, CultureInfo culture)
    

Methods
-------

.. dn:structure:: Microsoft.AspNet.Mvc.ModelBinding.ValueProviderResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ValueProviderResult.Equals(Microsoft.AspNet.Mvc.ModelBinding.ValueProviderResult)
    
        
        
        
        :type other: Microsoft.AspNet.Mvc.ModelBinding.ValueProviderResult
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool Equals(ValueProviderResult other)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ValueProviderResult.Equals(System.Object)
    
        
        
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ValueProviderResult.GetEnumerator()
    
        
    
        Gets an :any:`System.Collections.Generic.IEnumerator\`1` for this :any:`Microsoft.AspNet.Mvc.ModelBinding.ValueProviderResult`\.
    
        
        :rtype: System.Collections.Generic.IEnumerator{System.String}
        :return: An <see cref="T:System.Collections.Generic.IEnumerator`1" />.
    
        
        .. code-block:: csharp
    
           public IEnumerator<string> GetEnumerator()
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ValueProviderResult.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public override int GetHashCode()
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ValueProviderResult.System.Collections.IEnumerable.GetEnumerator()
    
        
        :rtype: System.Collections.IEnumerator
    
        
        .. code-block:: csharp
    
           IEnumerator IEnumerable.GetEnumerator()
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ValueProviderResult.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public override string ToString()
    

Fields
------

.. dn:structure:: Microsoft.AspNet.Mvc.ModelBinding.ValueProviderResult
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNet.Mvc.ModelBinding.ValueProviderResult.None
    
        
    
        A :any:`Microsoft.AspNet.Mvc.ModelBinding.ValueProviderResult` that represents a lack of data.
    
        
    
        
        .. code-block:: csharp
    
           public static ValueProviderResult None
    

Properties
----------

.. dn:structure:: Microsoft.AspNet.Mvc.ModelBinding.ValueProviderResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ValueProviderResult.Culture
    
        
    
        Gets or sets the :any:`System.Globalization.CultureInfo` associated with the values.
    
        
        :rtype: System.Globalization.CultureInfo
    
        
        .. code-block:: csharp
    
           public CultureInfo Culture { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ValueProviderResult.FirstValue
    
        
    
        Gets the first value based on the order values were provided in the request. Use :dn:prop:`Microsoft.AspNet.Mvc.ModelBinding.ValueProviderResult.FirstValue`
        to get a single value for processing regardless of whether a single or multiple values were provided
        in the request.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string FirstValue { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ValueProviderResult.Length
    
        
    
        Gets the number of submitted values.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int Length { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.ValueProviderResult.Values
    
        
    
        Gets or sets the values.
    
        
        :rtype: Microsoft.Extensions.Primitives.StringValues
    
        
        .. code-block:: csharp
    
           public StringValues Values { get; }
    

