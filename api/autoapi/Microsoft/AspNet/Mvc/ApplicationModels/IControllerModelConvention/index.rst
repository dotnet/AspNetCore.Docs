

IControllerModelConvention Interface
====================================



.. contents:: 
   :local:



Summary
-------

Allows customization of the of the :any:`Microsoft.AspNet.Mvc.ApplicationModels.ControllerModel`\.











Syntax
------

.. code-block:: csharp

   public interface IControllerModelConvention





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/ApplicationModels/IControllerModelConvention.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.ApplicationModels.IControllerModelConvention

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.ApplicationModels.IControllerModelConvention
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ApplicationModels.IControllerModelConvention.Apply(Microsoft.AspNet.Mvc.ApplicationModels.ControllerModel)
    
        
    
        Called to apply the convention to the :any:`Microsoft.AspNet.Mvc.ApplicationModels.ControllerModel`\.
    
        
        
        
        :param controller: The .
        
        :type controller: Microsoft.AspNet.Mvc.ApplicationModels.ControllerModel
    
        
        .. code-block:: csharp
    
           void Apply(ControllerModel controller)
    

