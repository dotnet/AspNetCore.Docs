

IApplicationModelConvention Interface
=====================================



.. contents:: 
   :local:



Summary
-------

Allows customization of the of the :any:`Microsoft.AspNet.Mvc.ApplicationModels.ApplicationModel`\.











Syntax
------

.. code-block:: csharp

   public interface IApplicationModelConvention





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/ApplicationModels/IApplicationModelConvention.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.ApplicationModels.IApplicationModelConvention

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.ApplicationModels.IApplicationModelConvention
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ApplicationModels.IApplicationModelConvention.Apply(Microsoft.AspNet.Mvc.ApplicationModels.ApplicationModel)
    
        
    
        Called to apply the convention to the :any:`Microsoft.AspNet.Mvc.ApplicationModels.ApplicationModel`\.
    
        
        
        
        :param application: The .
        
        :type application: Microsoft.AspNet.Mvc.ApplicationModels.ApplicationModel
    
        
        .. code-block:: csharp
    
           void Apply(ApplicationModel application)
    

