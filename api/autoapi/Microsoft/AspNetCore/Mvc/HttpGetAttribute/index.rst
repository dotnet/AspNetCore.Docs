

HttpGetAttribute Class
======================






Identifies an action that only supports the HTTP GET method.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.HttpGetAttribute`








Syntax
------

.. code-block:: csharp

    public class HttpGetAttribute : HttpMethodAttribute, _Attribute, IActionHttpMethodProvider, IRouteTemplateProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.HttpGetAttribute
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.HttpGetAttribute

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.HttpGetAttribute
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.HttpGetAttribute.HttpGetAttribute()
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.HttpGetAttribute`\.
    
        
    
        
        .. code-block:: csharp
    
            public HttpGetAttribute()
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.HttpGetAttribute.HttpGetAttribute(System.String)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.HttpGetAttribute` with the given route template.
    
        
    
        
        :param template: The route template. May not be null.
        
        :type template: System.String
    
        
        .. code-block:: csharp
    
            public HttpGetAttribute(string template)
    

