

IParameterModelConvention Interface
===================================






Allows customization of the of the :any:`Microsoft.AspNetCore.Mvc.ApplicationModels.ControllerModel`\.


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

    public interface IParameterModelConvention








.. dn:interface:: Microsoft.AspNetCore.Mvc.ApplicationModels.IParameterModelConvention
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.ApplicationModels.IParameterModelConvention

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.ApplicationModels.IParameterModelConvention
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ApplicationModels.IParameterModelConvention.Apply(Microsoft.AspNetCore.Mvc.ApplicationModels.ParameterModel)
    
        
    
        
        Called to apply the convention to the :any:`Microsoft.AspNetCore.Mvc.ApplicationModels.ParameterModel`\.
    
        
    
        
        :param parameter: The :any:`Microsoft.AspNetCore.Mvc.ApplicationModels.ParameterModel`\.
        
        :type parameter: Microsoft.AspNetCore.Mvc.ApplicationModels.ParameterModel
    
        
        .. code-block:: csharp
    
            void Apply(ParameterModel parameter)
    

