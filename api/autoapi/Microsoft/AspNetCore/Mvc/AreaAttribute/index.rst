

AreaAttribute Class
===================






Specifies the area containing a controller or action.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Routing.RouteValueAttribute`
* :dn:cls:`Microsoft.AspNetCore.Mvc.AreaAttribute`








Syntax
------

.. code-block:: csharp

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class AreaAttribute : RouteValueAttribute, _Attribute, IRouteValueProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.AreaAttribute
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.AreaAttribute

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.AreaAttribute
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.AreaAttribute.AreaAttribute(System.String)
    
        
    
        
        Initializes a new :any:`Microsoft.AspNetCore.Mvc.AreaAttribute` instance.
    
        
    
        
        :param areaName: The area containing the controller or action.
        
        :type areaName: System.String
    
        
        .. code-block:: csharp
    
            public AreaAttribute(string areaName)
    

