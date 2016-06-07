

IControllerModelConvention Interface
====================================






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

    public interface IControllerModelConvention








.. dn:interface:: Microsoft.AspNetCore.Mvc.ApplicationModels.IControllerModelConvention
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.ApplicationModels.IControllerModelConvention

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.ApplicationModels.IControllerModelConvention
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ApplicationModels.IControllerModelConvention.Apply(Microsoft.AspNetCore.Mvc.ApplicationModels.ControllerModel)
    
        
    
        
        Called to apply the convention to the :any:`Microsoft.AspNetCore.Mvc.ApplicationModels.ControllerModel`\.
    
        
    
        
        :param controller: The :any:`Microsoft.AspNetCore.Mvc.ApplicationModels.ControllerModel`\.
        
        :type controller: Microsoft.AspNetCore.Mvc.ApplicationModels.ControllerModel
    
        
        .. code-block:: csharp
    
            void Apply(ControllerModel controller)
    

