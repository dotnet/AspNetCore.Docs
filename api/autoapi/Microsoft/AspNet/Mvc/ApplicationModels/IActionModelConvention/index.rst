

IActionModelConvention Interface
================================



.. contents:: 
   :local:



Summary
-------

Allows customization of the of the :any:`Microsoft.AspNet.Mvc.ApplicationModels.ActionModel`\.











Syntax
------

.. code-block:: csharp

   public interface IActionModelConvention





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/ApplicationModels/IActionModelConvention.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.ApplicationModels.IActionModelConvention

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.ApplicationModels.IActionModelConvention
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ApplicationModels.IActionModelConvention.Apply(Microsoft.AspNet.Mvc.ApplicationModels.ActionModel)
    
        
    
        Called to apply the convention to the :any:`Microsoft.AspNet.Mvc.ApplicationModels.ActionModel`\.
    
        
        
        
        :param action: The .
        
        :type action: Microsoft.AspNet.Mvc.ApplicationModels.ActionModel
    
        
        .. code-block:: csharp
    
           void Apply(ActionModel action)
    

