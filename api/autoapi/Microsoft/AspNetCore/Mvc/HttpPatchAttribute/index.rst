

HttpPatchAttribute Class
========================






Identifies an action that only supports the HTTP PATCH method.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.HttpPatchAttribute`








Syntax
------

.. code-block:: csharp

    public class HttpPatchAttribute : HttpMethodAttribute, _Attribute, IActionHttpMethodProvider, IRouteTemplateProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.HttpPatchAttribute
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.HttpPatchAttribute

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.HttpPatchAttribute
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.HttpPatchAttribute.HttpPatchAttribute()
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.HttpPatchAttribute`\.
    
        
    
        
        .. code-block:: csharp
    
            public HttpPatchAttribute()
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.HttpPatchAttribute.HttpPatchAttribute(System.String)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.HttpPatchAttribute` with the given route template.
    
        
    
        
        :param template: The route template. May not be null.
        
        :type template: System.String
    
        
        .. code-block:: csharp
    
            public HttpPatchAttribute(string template)
    

