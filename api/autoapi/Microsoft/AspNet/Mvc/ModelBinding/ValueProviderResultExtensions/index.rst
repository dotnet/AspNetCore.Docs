

ValueProviderResultExtensions Class
===================================



.. contents:: 
   :local:



Summary
-------

Extensions methods for :any:`Microsoft.AspNet.Mvc.ModelBinding.ValueProviderResult`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.ValueProviderResultExtensions`








Syntax
------

.. code-block:: csharp

   public class ValueProviderResultExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/ModelBinding/ValueProviderResultExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.ValueProviderResultExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.ValueProviderResultExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ValueProviderResultExtensions.ConvertTo(Microsoft.AspNet.Mvc.ModelBinding.ValueProviderResult, System.Type)
    
        
    
        Attempts to convert the values in ``result`` to the specified type.
    
        
        
        
        :param result: The .
        
        :type result: Microsoft.AspNet.Mvc.ModelBinding.ValueProviderResult
        
        
        :param type: The  for conversion.
        
        :type type: System.Type
        :rtype: System.Object
        :return: The converted value, or the default value of <paramref name="type" /> if the value could not be converted.
    
        
        .. code-block:: csharp
    
           public static object ConvertTo(ValueProviderResult result, Type type)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.ValueProviderResultExtensions.ConvertTo<T>(Microsoft.AspNet.Mvc.ModelBinding.ValueProviderResult)
    
        
    
        Attempts to convert the values in ``result`` to the specified type.
    
        
        
        
        :param result: The .
        
        :type result: Microsoft.AspNet.Mvc.ModelBinding.ValueProviderResult
        :rtype: {T}
        :return: The converted value, or the default value of <typeparamref name="T" /> if the value could not be converted.
    
        
        .. code-block:: csharp
    
           public static T ConvertTo<T>(ValueProviderResult result)
    

