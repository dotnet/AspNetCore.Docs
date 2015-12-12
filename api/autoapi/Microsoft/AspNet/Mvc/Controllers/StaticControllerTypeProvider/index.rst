

StaticControllerTypeProvider Class
==================================



.. contents:: 
   :local:



Summary
-------

A :any:`Microsoft.AspNet.Mvc.Controllers.IControllerTypeProvider` with a fixed set of types that are used as controllers.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Controllers.StaticControllerTypeProvider`








Syntax
------

.. code-block:: csharp

   public class StaticControllerTypeProvider : IControllerTypeProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/Controllers/StaticControllerTypeProvider.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Controllers.StaticControllerTypeProvider

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Controllers.StaticControllerTypeProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Controllers.StaticControllerTypeProvider.StaticControllerTypeProvider()
    
        
    
        Initializes a new instance of :any:`Microsoft.AspNet.Mvc.Controllers.StaticControllerTypeProvider`\.
    
        
    
        
        .. code-block:: csharp
    
           public StaticControllerTypeProvider()
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Controllers.StaticControllerTypeProvider.StaticControllerTypeProvider(System.Collections.Generic.IEnumerable<System.Reflection.TypeInfo>)
    
        
    
        Initializes a new instance of :any:`Microsoft.AspNet.Mvc.Controllers.StaticControllerTypeProvider`\.
    
        
        
        
        :param controllerTypes: The sequence of controller .
        
        :type controllerTypes: System.Collections.Generic.IEnumerable{System.Reflection.TypeInfo}
    
        
        .. code-block:: csharp
    
           public StaticControllerTypeProvider(IEnumerable<TypeInfo> controllerTypes)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Controllers.StaticControllerTypeProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Controllers.StaticControllerTypeProvider.ControllerTypes
    
        
    
        Gets the list of controller :any:`System.Reflection.TypeInfo`\s.
    
        
        :rtype: System.Collections.Generic.IList{System.Reflection.TypeInfo}
    
        
        .. code-block:: csharp
    
           public IList<TypeInfo> ControllerTypes { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Controllers.StaticControllerTypeProvider.Microsoft.AspNet.Mvc.Controllers.IControllerTypeProvider.ControllerTypes
    
        
        :rtype: System.Collections.Generic.IEnumerable{System.Reflection.TypeInfo}
    
        
        .. code-block:: csharp
    
           IEnumerable<TypeInfo> IControllerTypeProvider.ControllerTypes { get; }
    

