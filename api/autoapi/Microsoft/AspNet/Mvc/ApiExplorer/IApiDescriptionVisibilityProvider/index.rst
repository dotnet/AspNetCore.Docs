

IApiDescriptionVisibilityProvider Interface
===========================================



.. contents:: 
   :local:



Summary
-------

Represents visibility metadata for an <c>ApiDescription</c>.











Syntax
------

.. code-block:: csharp

   public interface IApiDescriptionVisibilityProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/ApiExplorer/IApiDescriptionVisibilityProvider.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.ApiExplorer.IApiDescriptionVisibilityProvider

Properties
----------

.. dn:interface:: Microsoft.AspNet.Mvc.ApiExplorer.IApiDescriptionVisibilityProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ApiExplorer.IApiDescriptionVisibilityProvider.IgnoreApi
    
        
    
        If <c>false</c> then no <c>ApiDescription</c> objects will be created for the associated controller
        or action.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           bool IgnoreApi { get; }
    

