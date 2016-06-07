

IValueProviderFactory Interface
===============================






A factory for creating :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IValueProvider` instances.


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

    public interface IValueProviderFactory








.. dn:interface:: Microsoft.AspNetCore.Mvc.ModelBinding.IValueProviderFactory
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.ModelBinding.IValueProviderFactory

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.ModelBinding.IValueProviderFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.IValueProviderFactory.CreateValueProviderAsync(Microsoft.AspNetCore.Mvc.ModelBinding.ValueProviderFactoryContext)
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IValueProvider` with values from the current request
        and adds it to :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ValueProviderFactoryContext.ValueProviders` list.
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ValueProviderFactoryContext`\.
        
        :type context: Microsoft.AspNetCore.Mvc.ModelBinding.ValueProviderFactoryContext
        :rtype: System.Threading.Tasks.Task
        :return: A :any:`System.Threading.Tasks.Task` that when completed will add an :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IValueProvider` instance
            to :dn:prop:`Microsoft.AspNetCore.Mvc.ModelBinding.ValueProviderFactoryContext.ValueProviders` list if applicable.
    
        
        .. code-block:: csharp
    
            Task CreateValueProviderAsync(ValueProviderFactoryContext context)
    

