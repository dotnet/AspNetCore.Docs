

ApiExplorerSettingsAttribute Class
==================================






Controls the visibility and group name for an <code>ApiDescription</code>
of the associated controller class or action method.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Attribute`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ApiExplorerSettingsAttribute`








Syntax
------

.. code-block:: csharp

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class ApiExplorerSettingsAttribute : Attribute, _Attribute, IApiDescriptionGroupNameProvider, IApiDescriptionVisibilityProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.ApiExplorerSettingsAttribute
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ApiExplorerSettingsAttribute

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ApiExplorerSettingsAttribute
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApiExplorerSettingsAttribute.GroupName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string GroupName
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApiExplorerSettingsAttribute.IgnoreApi
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IgnoreApi
            {
                get;
                set;
            }
    

