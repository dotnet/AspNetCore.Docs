

HttpDeleteAttribute Class
=========================






Identifies an action that only supports the HTTP DELETE method.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.HttpDeleteAttribute`








Syntax
------

.. code-block:: csharp

    public class HttpDeleteAttribute : HttpMethodAttribute, _Attribute, IActionHttpMethodProvider, IRouteTemplateProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.HttpDeleteAttribute
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.HttpDeleteAttribute

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.HttpDeleteAttribute
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.HttpDeleteAttribute.HttpDeleteAttribute()
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.HttpDeleteAttribute`\.
    
        
    
        
        .. code-block:: csharp
    
            public HttpDeleteAttribute()
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.HttpDeleteAttribute.HttpDeleteAttribute(System.String)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.HttpDeleteAttribute` with the given route template.
    
        
    
        
        :param template: The route template. May not be null.
        
        :type template: System.String
    
        
        .. code-block:: csharp
    
            public HttpDeleteAttribute(string template)
    

