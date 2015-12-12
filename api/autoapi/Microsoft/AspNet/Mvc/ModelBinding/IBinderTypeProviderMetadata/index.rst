

IBinderTypeProviderMetadata Interface
=====================================



.. contents:: 
   :local:



Summary
-------

Provides a :any:`System.Type` which implements :any:`Microsoft.AspNet.Mvc.ModelBinding.IModelBinder`\.











Syntax
------

.. code-block:: csharp

   public interface IBinderTypeProviderMetadata : IBindingSourceMetadata





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Abstractions/ModelBinding/IBinderTypeProviderMetadata.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.ModelBinding.IBinderTypeProviderMetadata

Properties
----------

.. dn:interface:: Microsoft.AspNet.Mvc.ModelBinding.IBinderTypeProviderMetadata
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.IBinderTypeProviderMetadata.BinderType
    
        
    
        A :any:`System.Type` which implements either :any:`Microsoft.AspNet.Mvc.ModelBinding.IModelBinder`\.
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
           Type BinderType { get; }
    

