

ApplicationModelProviderContext Class
=====================================






A context object for :any:`Microsoft.AspNetCore.Mvc.ApplicationModels.IApplicationModelProvider`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ApplicationModels`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ApplicationModels.ApplicationModelProviderContext`








Syntax
------

.. code-block:: csharp

    public class ApplicationModelProviderContext








.. dn:class:: Microsoft.AspNetCore.Mvc.ApplicationModels.ApplicationModelProviderContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ApplicationModels.ApplicationModelProviderContext

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ApplicationModels.ApplicationModelProviderContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ApplicationModels.ApplicationModelProviderContext.ApplicationModelProviderContext(System.Collections.Generic.IEnumerable<System.Reflection.TypeInfo>)
    
        
    
        
        :type controllerTypes: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.Reflection.TypeInfo<System.Reflection.TypeInfo>}
    
        
        .. code-block:: csharp
    
            public ApplicationModelProviderContext(IEnumerable<TypeInfo> controllerTypes)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ApplicationModels.ApplicationModelProviderContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApplicationModels.ApplicationModelProviderContext.ControllerTypes
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.Reflection.TypeInfo<System.Reflection.TypeInfo>}
    
        
        .. code-block:: csharp
    
            public IEnumerable<TypeInfo> ControllerTypes { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ApplicationModels.ApplicationModelProviderContext.Result
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Mvc.ApplicationModels.ApplicationModel`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ApplicationModels.ApplicationModel
    
        
        .. code-block:: csharp
    
            public ApplicationModel Result { get; }
    

