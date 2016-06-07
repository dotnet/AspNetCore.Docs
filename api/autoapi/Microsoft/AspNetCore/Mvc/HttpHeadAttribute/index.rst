

HttpHeadAttribute Class
=======================






Identifies an action that only supports the HTTP HEAD method.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Routing.HttpMethodAttribute`
* :dn:cls:`Microsoft.AspNetCore.Mvc.HttpHeadAttribute`








Syntax
------

.. code-block:: csharp

    public class HttpHeadAttribute : HttpMethodAttribute, _Attribute, IActionHttpMethodProvider, IRouteTemplateProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.HttpHeadAttribute
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.HttpHeadAttribute

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.HttpHeadAttribute
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.HttpHeadAttribute.HttpHeadAttribute()
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.HttpHeadAttribute`\.
    
        
    
        
        .. code-block:: csharp
    
            public HttpHeadAttribute()
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.HttpHeadAttribute.HttpHeadAttribute(System.String)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.HttpHeadAttribute` with the given route template.
    
        
    
        
        :param template: The route template. May not be null.
        
        :type template: System.String
    
        
        .. code-block:: csharp
    
            public HttpHeadAttribute(string template)
    

