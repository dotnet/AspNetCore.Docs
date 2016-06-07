

HttpPutAttribute Class
======================






Identifies an action that only supports the HTTP PUT method.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.HttpPutAttribute`








Syntax
------

.. code-block:: csharp

    public class HttpPutAttribute : HttpMethodAttribute, _Attribute, IActionHttpMethodProvider, IRouteTemplateProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.HttpPutAttribute
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.HttpPutAttribute

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.HttpPutAttribute
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.HttpPutAttribute.HttpPutAttribute()
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.HttpPutAttribute`\.
    
        
    
        
        .. code-block:: csharp
    
            public HttpPutAttribute()
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.HttpPutAttribute.HttpPutAttribute(System.String)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.HttpPutAttribute` with the given route template.
    
        
    
        
        :param template: The route template. May not be null.
        
        :type template: System.String
    
        
        .. code-block:: csharp
    
            public HttpPutAttribute(string template)
    

