

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
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Routing.Template.TemplateMatcher
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Routing.Template.TemplateMatcher.Defaults
    
        
        :rtype: Microsoft.AspNetCore.Routing.RouteValueDictionary
    
        
        .. code-block:: csharp
    
            public RouteValueDictionary Defaults { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.Template.TemplateMatcher.Template
    
        
        :rtype: Microsoft.AspNetCore.Routing.Template.RouteTemplate
    
        
        .. code-block:: csharp
    
            public RouteTemplate Template { get; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Routing.Template.TemplateMatcher
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Routing.Template.TemplateMatcher.TryMatch(Microsoft.AspNetCore.Http.PathString, Microsoft.AspNetCore.Routing.RouteValueDictionary)
    
        
    
        
        :type path: Microsoft.AspNetCore.Http.PathString
    
        
        :type values: Microsoft.AspNetCore.Routing.RouteValueDictionary
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool TryMatch(PathString path, RouteValueDictionary values)
    

