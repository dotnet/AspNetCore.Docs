

IParameterModelConvention Interface
===================================



.. contents:: 
   :local:



Summary
-------

Allows customization of the of the :any:`Microsoft.AspNet.Mvc.ApplicationModels.ControllerModel`\.











Syntax
------

.. code-block:: csharp

   public interface IParameterModelConvention





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/ApplicationModels/IParameterModelConvention.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.ApplicationModels.IParameterModelConvention

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.ApplicationModels.IParameterModelConvention
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ApplicationModels.IParameterModelConvention.Apply(Microsoft.AspNet.Mvc.ApplicationModels.ParameterModel)
    
        
    
        Called to apply the convention to the :any:`Microsoft.AspNet.Mvc.ApplicationModels.ParameterModel`\.
    
        
        
        
        :param parameter: The .
        
        :type parameter: Microsoft.AspNet.Mvc.ApplicationModels.ParameterModel
    
        
        .. code-block:: csharp
    
           void Apply(ParameterModel parameter)
    

