

IValueProvider Interface
========================



.. contents:: 
   :local:



Summary
-------

Defines the methods that are required for a value provider.











Syntax
------

.. code-block:: csharp

   public interface IValueProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Abstractions/ModelBinding/IValueProvider.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.ModelBinding.IValueProvider

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.ModelBinding.IValueProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.IValueProvider.ContainsPrefix(System.String)
    
        
    
        Determines whether the collection contains the specified prefix.
    
        
        
        
        :param prefix: The prefix to search for.
        
        :type prefix: System.String
        :rtype: System.Boolean
        :return: true if the collection contains the specified prefix; otherwise, false.
    
        
        .. code-block:: csharp
    
           bool ContainsPrefix(string prefix)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.IValueProvider.GetValue(System.String)
    
        
    
        Retrieves a value object using the specified key.
    
        
        
        
        :param key: The key of the value object to retrieve.
        
        :type key: System.String
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.ValueProviderResult
        :return: The value object for the specified key. If the exact key is not found, null.
    
        
        .. code-block:: csharp
    
           ValueProviderResult GetValue(string key)
    

