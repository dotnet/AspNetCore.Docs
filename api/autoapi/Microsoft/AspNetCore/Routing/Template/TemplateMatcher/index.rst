

TemplateMatcher Class
=====================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Routing.Template`
Assemblies
    * Microsoft.AspNetCore.Routing

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Routing.Template.TemplateMatcher`








Syntax
------

.. code-block:: csharp

    public class TemplateMatcher








.. dn:class:: Microsoft.AspNetCore.Routing.Template.TemplateMatcher
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Routing.Template.TemplateMatcher

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Routing.Template.TemplateMatcher
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Routing.Template.TemplateMatcher.Defaults
    
        
        :rtype: Microsoft.AspNetCore.Routing.RouteValueDictionary
    
        
        .. code-block:: csharp
    
            public RouteValueDictionary Defaults
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.Template.TemplateMatcher.Template
    
        
        :rtype: Microsoft.AspNetCore.Routing.Template.RouteTemplate
    
        
        .. code-block:: csharp
    
            public RouteTemplate Template
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Routing.Template.TemplateMatcher
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Routing.Template.TemplateMatcher.TemplateMatcher(Microsoft.AspNetCore.Routing.Template.RouteTemplate, Microsoft.AspNetCore.Routing.RouteValueDictionary)
    
        
    
        
        :type template: Microsoft.AspNetCore.Routing.Template.RouteTemplate
    
        
        :type defaults: Microsoft.AspNetCore.Routing.RouteValueDictionary
    
        
        .. code-block:: csharp
    
            public TemplateMatcher(RouteTemplate template, RouteValueDictionary defaults)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Routing.Template.TemplateMatcher
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Routing.Template.TemplateMatcher.Match(Microsoft.AspNetCore.Http.PathString)
    
        
    
        
        :type path: Microsoft.AspNetCore.Http.PathString
        :rtype: Microsoft.AspNetCore.Routing.RouteValueDictionary
    
        
        .. code-block:: csharp
    
            public RouteValueDictionary Match(PathString path)
    

