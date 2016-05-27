

IApplicationModelConvention Interface
=====================================






Allows customization of the of the :any:`Microsoft.AspNetCore.Mvc.ApplicationModels.ApplicationModel`\.


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

    public interface IApplicationModelConvention








.. dn:interface:: Microsoft.AspNetCore.Mvc.ApplicationModels.IApplicationModelConvention
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.ApplicationModels.IApplicationModelConvention

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.ApplicationModels.IApplicationModelConvention
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ApplicationModels.IApplicationModelConvention.Apply(Microsoft.AspNetCore.Mvc.ApplicationModels.ApplicationModel)
    
        
    
        
        Called to apply the convention to the :any:`Microsoft.AspNetCore.Mvc.ApplicationModels.ApplicationModel`\.
    
        
    
        
        :param application: The :any:`Microsoft.AspNetCore.Mvc.ApplicationModels.ApplicationModel`\.
        
        :type application: Microsoft.AspNetCore.Mvc.ApplicationModels.ApplicationModel
    
        
        .. code-block:: csharp
    
            void Apply(ApplicationModel application)
    

