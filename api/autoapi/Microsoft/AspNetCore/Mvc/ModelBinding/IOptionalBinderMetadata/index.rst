

IOptionalBinderMetadata Interface
=================================






An type that designates an optional parameter for the purposes
of WebAPI action overloading. Optional parameters do not participate in overloading, and 
do not have to have a value for the action to be selected.

This has no impact when used without WebAPI action overloading.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ModelBinding`
Assemblies
    * Microsoft.AspNetCore.Mvc.WebApiCompatShim

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IOptionalBinderMetadata








.. dn:interface:: Microsoft.AspNetCore.Mvc.ModelBinding.IOptionalBinderMetadata
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.ModelBinding.IOptionalBinderMetadata

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.Mvc.ModelBinding.IOptionalBinderMetadata
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ModelBinding.IOptionalBinderMetadata.IsOptional
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            bool IsOptional
            {
                get;
            }
    

