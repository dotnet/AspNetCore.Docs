

HttpPostAttribute Class
=======================






Identifies an action that only supports the HTTP POST method.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.HttpPostAttribute`








Syntax
------

.. code-block:: csharp

    public class HttpPostAttribute : HttpMethodAttribute, _Attribute, IActionHttpMethodProvider, IRouteTemplateProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.HttpPostAttribute
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.HttpPostAttribute

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.HttpPostAttribute
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.HttpPostAttribute.HttpPostAttribute()
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.HttpPostAttribute`\.
    
        
    
        
        .. code-block:: csharp
    
            public HttpPostAttribute()
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.HttpPostAttribute.HttpPostAttribute(System.String)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.HttpPostAttribute` with the given route template.
    
        
    
        
        :param template: The route template. May not be null.
        
        :type template: System.String
    
        
        .. code-block:: csharp
    
            public HttpPostAttribute(string template)
    

