

ValueProviderResultExtensions Class
===================================






Extensions methods for :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ValueProviderResult`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ModelBinding`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ModelBinding.ValueProviderResultExtensions`








Syntax
------

.. code-block:: csharp

    public class ValueProviderResultExtensions








.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.ValueProviderResultExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.ValueProviderResultExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ModelBinding.ValueProviderResultExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.ValueProviderResultExtensions.ConvertTo(Microsoft.AspNetCore.Mvc.ModelBinding.ValueProviderResult, System.Type)
    
        
    
        
        Attempts to convert the values in <em>result</em> to the specified type.
    
        
    
        
        :param result: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ValueProviderResult`\.
        
        :type result: Microsoft.AspNetCore.Mvc.ModelBinding.ValueProviderResult
    
        
        :param type: The :any:`System.Type` for conversion.
        
        :type type: System.Type
        :rtype: System.Object
        :return: 
            The converted value, or the default value of <em>type</em> if the value could not be converted.
    
        
        .. code-block:: csharp
    
            public static object ConvertTo(this ValueProviderResult result, Type type)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.ValueProviderResultExtensions.ConvertTo<T>(Microsoft.AspNetCore.Mvc.ModelBinding.ValueProviderResult)
    
        
    
        
        Attempts to convert the values in <em>result</em> to the specified type.
    
        
    
        
        :param result: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ValueProviderResult`\.
        
        :type result: Microsoft.AspNetCore.Mvc.ModelBinding.ValueProviderResult
        :rtype: T
        :return: 
            The converted value, or the default value of <em>T</em> if the value could not be converted.
    
        
        .. code-block:: csharp
    
            public static T ConvertTo<T>(this ValueProviderResult result)
    

