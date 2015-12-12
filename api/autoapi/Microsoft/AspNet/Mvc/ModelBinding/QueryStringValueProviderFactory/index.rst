

QueryStringValueProviderFactory Class
=====================================



.. contents:: 
   :local:



Summary
-------

A :any:`Microsoft.AspNet.Mvc.ModelBinding.IValueProviderFactory` that creates :any:`Microsoft.AspNet.Mvc.ModelBinding.IValueProvider` instances that
read values from the request query-string.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ModelBinding.QueryStringValueProviderFactory`








Syntax
------

.. code-block:: csharp

   public class QueryStringValueProviderFactory : IValueProviderFactory





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/ModelBinding/QueryStringValueProviderFactory.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.QueryStringValueProviderFactory

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ModelBinding.QueryStringValueProviderFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.QueryStringValueProviderFactory.GetValueProviderAsync(Microsoft.AspNet.Mvc.ModelBinding.ValueProviderFactoryContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.ModelBinding.ValueProviderFactoryContext
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Mvc.ModelBinding.IValueProvider}
    
        
        .. code-block:: csharp
    
           public Task<IValueProvider> GetValueProviderAsync(ValueProviderFactoryContext context)
    

