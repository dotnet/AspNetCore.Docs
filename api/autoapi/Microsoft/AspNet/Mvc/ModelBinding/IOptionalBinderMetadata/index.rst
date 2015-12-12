

IOptionalBinderMetadata Interface
=================================



.. contents:: 
   :local:



Summary
-------

An type that designates an optional parameter for the purposes
of WebAPI action overloading. Optional parameters do not participate in overloading, and
do not have to have a value for the action to be selected.


This has no impact when used without WebAPI action overloading.











Syntax
------

.. code-block:: csharp

   public interface IOptionalBinderMetadata





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.WebApiCompatShim/ParameterBinding/IOptionalBinderMetadata.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.ModelBinding.IOptionalBinderMetadata

Properties
----------

.. dn:interface:: Microsoft.AspNet.Mvc.ModelBinding.IOptionalBinderMetadata
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ModelBinding.IOptionalBinderMetadata.IsOptional
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           bool IsOptional { get; }
    

