

IBindingSourceValueProvider Interface
=====================================






A value provider which can filter its contents based on :any:`Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ModelBinding`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IBindingSourceValueProvider : IValueProvider








.. dn:interface:: Microsoft.AspNetCore.Mvc.ModelBinding.IBindingSourceValueProvider
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.ModelBinding.IBindingSourceValueProvider

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.ModelBinding.IBindingSourceValueProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ModelBinding.IBindingSourceValueProvider.Filter(Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource)
    
        
    
        
        Filters the value provider based on <em>bindingSource</em>.
    
        
    
        
        :param bindingSource: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource` associated with a model.
        
        :type bindingSource: Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.IValueProvider
        :return: 
            The filtered value provider, or <code>null</code> if the value provider does not match
            <em>bindingSource</em>.
    
        
        .. code-block:: csharp
    
            IValueProvider Filter(BindingSource bindingSource)
    

