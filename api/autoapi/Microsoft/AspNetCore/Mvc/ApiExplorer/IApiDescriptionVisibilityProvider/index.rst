

IApiDescriptionVisibilityProvider Interface
===========================================






Represents visibility metadata for an <code>ApiDescription</code>.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ApiExplorer`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IApiDescriptionVisibilityProvider








.. dn:interface:: Microsoft.AspNetCore.Mvc.ApiExplorer.IApiDescriptionVisibilityProvider
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.ApiExplorer.IApiDescriptionVisibilityProvider

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.Mvc.ApiExplorer.IApiDescriptionVisibilityProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApiExplorer.IApiDescriptionVisibilityProvider.IgnoreApi
    
        
    
        
        If <code>false</code> then no <code>ApiDescription</code> objects will be created for the associated controller
        or action.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            bool IgnoreApi { get; }
    

