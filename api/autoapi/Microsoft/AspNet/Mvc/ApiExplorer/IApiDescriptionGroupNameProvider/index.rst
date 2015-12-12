

IApiDescriptionGroupNameProvider Interface
==========================================



.. contents:: 
   :local:



Summary
-------

Represents group name metadata for an <c>ApiDescription</c>.











Syntax
------

.. code-block:: csharp

   public interface IApiDescriptionGroupNameProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/ApiExplorer/IApiDescriptionGroupNameProvider.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.ApiExplorer.IApiDescriptionGroupNameProvider

Properties
----------

.. dn:interface:: Microsoft.AspNet.Mvc.ApiExplorer.IApiDescriptionGroupNameProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ApiExplorer.IApiDescriptionGroupNameProvider.GroupName
    
        
    
        The group name for the <c>ApiDescription</c> of the associated action or controller.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           string GroupName { get; }
    

