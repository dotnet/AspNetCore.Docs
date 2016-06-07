

HttpOptionsAttribute Class
==========================






Identifies an action that only supports the HTTP OPTIONS method.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.HttpOptionsAttribute`








Syntax
------

.. code-block:: csharp

    public class HttpOptionsAttribute : HttpMethodAttribute, _Attribute, IActionHttpMethodProvider, IRouteTemplateProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.HttpOptionsAttribute
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.HttpOptionsAttribute

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.HttpOptionsAttribute
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.HttpOptionsAttribute.HttpOptionsAttribute()
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.HttpOptionsAttribute`\.
    
        
    
        
        .. code-block:: csharp
    
            public HttpOptionsAttribute()
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.HttpOptionsAttribute.HttpOptionsAttribute(System.String)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.HttpOptionsAttribute` with the given route template.
    
        
    
        
        :param template: The route template. May not be null.
        
        :type template: System.String
    
        
        .. code-block:: csharp
    
            public HttpOptionsAttribute(string template)
    

