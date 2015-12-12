

ApiExplorerSettingsAttribute Class
==================================



.. contents:: 
   :local:



Summary
-------

Controls the visibility and group name for an <c>ApiDescription</c>
of the associated controller class or action method.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Attribute`
* :dn:cls:`Microsoft.AspNet.Mvc.ApiExplorerSettingsAttribute`








Syntax
------

.. code-block:: csharp

   public class ApiExplorerSettingsAttribute : Attribute, _Attribute, IApiDescriptionGroupNameProvider, IApiDescriptionVisibilityProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/ApiExplorerSettingsAttribute.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ApiExplorerSettingsAttribute

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ApiExplorerSettingsAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ApiExplorerSettingsAttribute.GroupName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string GroupName { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ApiExplorerSettingsAttribute.IgnoreApi
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IgnoreApi { get; set; }
    

