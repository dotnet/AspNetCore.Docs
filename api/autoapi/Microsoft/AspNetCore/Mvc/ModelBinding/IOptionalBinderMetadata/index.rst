

IOptionalBinderMetadata Interface
=================================






<p>
An type that designates an optional parameter for the purposes
of ASP.NET Web API action overloading. Optional parameters do not participate in overloading, and
do not have to have a value for the action to be selected.
</p>
<p>
This has no impact when used without ASP.NET Web API action overloading.
</p>


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
    
        
    
        
        Gets a value indicating whether the parameter participates in ASP.NET Web API action overloading. If
        <code>true</code>, the parameter does not participate in overloading. Otherwise, it does.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            bool IsOptional { get; }
    

