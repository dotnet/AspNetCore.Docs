

IBindingSourceValueProvider Interface
=====================================



.. contents:: 
   :local:



Summary
-------

A value provider which can filter its contents based on :any:`Microsoft.AspNet.Mvc.ModelBinding.BindingSource`\.











Syntax
------

.. code-block:: csharp

   public interface IBindingSourceValueProvider : IValueProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/ModelBinding/IBindingSourceValueProvider.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.ModelBinding.IBindingSourceValueProvider

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.ModelBinding.IBindingSourceValueProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ModelBinding.IBindingSourceValueProvider.Filter(Microsoft.AspNet.Mvc.ModelBinding.BindingSource)
    
        
    
        Filters the value provider based on ``bindingSource``.
    
        
        
        
        :param bindingSource: The  associated with a model.
        
        :type bindingSource: Microsoft.AspNet.Mvc.ModelBinding.BindingSource
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.IValueProvider
        :return: The filtered value provider, or <c>null</c> if the value provider does not match
            <paramref name="bindingSource" />.
    
        
        .. code-block:: csharp
    
           IValueProvider Filter(BindingSource bindingSource)
    

