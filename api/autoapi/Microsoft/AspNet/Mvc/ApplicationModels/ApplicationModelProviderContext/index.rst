

ApplicationModelProviderContext Class
=====================================



.. contents:: 
   :local:



Summary
-------

A context object for :any:`Microsoft.AspNet.Mvc.ApplicationModels.IApplicationModelProvider`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ApplicationModels.ApplicationModelProviderContext`








Syntax
------

.. code-block:: csharp

   public class ApplicationModelProviderContext





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/ApplicationModels/ApplicationModelProviderContext.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ApplicationModels.ApplicationModelProviderContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ApplicationModels.ApplicationModelProviderContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ApplicationModels.ApplicationModelProviderContext.ApplicationModelProviderContext(System.Collections.Generic.IEnumerable<System.Reflection.TypeInfo>)
    
        
        
        
        :type controllerTypes: System.Collections.Generic.IEnumerable{System.Reflection.TypeInfo}
    
        
        .. code-block:: csharp
    
           public ApplicationModelProviderContext(IEnumerable<TypeInfo> controllerTypes)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ApplicationModels.ApplicationModelProviderContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ApplicationModels.ApplicationModelProviderContext.ControllerTypes
    
        
        :rtype: System.Collections.Generic.IEnumerable{System.Reflection.TypeInfo}
    
        
        .. code-block:: csharp
    
           public IEnumerable<TypeInfo> ControllerTypes { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ApplicationModels.ApplicationModelProviderContext.Result
    
        
    
        Gets the :any:`Microsoft.AspNet.Mvc.ApplicationModels.ApplicationModel`\.
    
        
        :rtype: Microsoft.AspNet.Mvc.ApplicationModels.ApplicationModel
    
        
        .. code-block:: csharp
    
           public ApplicationModel Result { get; }
    

