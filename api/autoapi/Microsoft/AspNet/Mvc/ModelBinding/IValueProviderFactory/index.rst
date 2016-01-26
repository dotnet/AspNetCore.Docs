

IValueProviderFactory Interface
===============================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IValueProviderFactory





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Abstractions/ModelBinding/IValueProviderFactory.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.ModelBinding.IValueProviderFactory

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.ModelBinding.IValueProviderFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.IValueProviderFactory.GetValueProviderAsync(Microsoft.AspNet.Mvc.ModelBinding.ValueProviderFactoryContext)
    
        
    
        Gets a :any:`Microsoft.AspNet.Mvc.ModelBinding.IValueProvider` with values from the current request.
    
        
        
        
        :param context: The .
        
        :type context: Microsoft.AspNet.Mvc.ModelBinding.ValueProviderFactoryContext
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Mvc.ModelBinding.IValueProvider}
        :return: A <see cref="T:System.Threading.Tasks.Task" /> that when completed will yield a <see cref="T:Microsoft.AspNet.Mvc.ModelBinding.IValueProvider" /> instance or <c>null</c>.
    
        
        .. code-block:: csharp
    
           Task<IValueProvider> GetValueProviderAsync(ValueProviderFactoryContext context)
    

