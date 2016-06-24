

IBinderTypeProviderMetadata Interface
=====================================






Provides a :any:`System.Type` which implements :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinder`\.


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

    public interface IBinderTypeProviderMetadata : IBindingSourceMetadata








.. dn:interface:: Microsoft.AspNetCore.Mvc.ModelBinding.IBinderTypeProviderMetadata
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.ModelBinding.IBinderTypeProviderMetadata

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.Mvc.ModelBinding.IBinderTypeProviderMetadata
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.IBinderTypeProviderMetadata.BinderType
    
        
    
        
        A :any:`System.Type` which implements either :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinder`\.
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
            Type BinderType { get; }
    

