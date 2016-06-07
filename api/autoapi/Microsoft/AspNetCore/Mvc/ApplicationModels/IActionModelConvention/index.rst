

IActionModelConvention Interface
================================






Allows customization of the of the :any:`Microsoft.AspNetCore.Mvc.ApplicationModels.ActionModel`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ApplicationModels`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IActionModelConvention








.. dn:interface:: Microsoft.AspNetCore.Mvc.ApplicationModels.IActionModelConvention
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.ApplicationModels.IActionModelConvention

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.ApplicationModels.IActionModelConvention
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ApplicationModels.IActionModelConvention.Apply(Microsoft.AspNetCore.Mvc.ApplicationModels.ActionModel)
    
        
    
        
        Called to apply the convention to the :any:`Microsoft.AspNetCore.Mvc.ApplicationModels.ActionModel`\.
    
        
    
        
        :param action: The :any:`Microsoft.AspNetCore.Mvc.ApplicationModels.ActionModel`\.
        
        :type action: Microsoft.AspNetCore.Mvc.ApplicationModels.ActionModel
    
        
        .. code-block:: csharp
    
            void Apply(ActionModel action)
    

