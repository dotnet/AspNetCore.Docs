

TemplateMatcher Class
=====================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Routing.Template.TemplateMatcher`








Syntax
------

.. code-block:: csharp

   public class TemplateMatcher





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/routing/src/Microsoft.AspNet.Routing/Template/TemplateMatcher.cs>`_





.. dn:class:: Microsoft.AspNet.Routing.Template.TemplateMatcher

Constructors
------------

.. dn:class:: Microsoft.AspNet.Routing.Template.TemplateMatcher
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Routing.Template.TemplateMatcher.TemplateMatcher(Microsoft.AspNet.Routing.Template.RouteTemplate, System.Collections.Generic.IReadOnlyDictionary<System.String, System.Object>)
    
        
        
        
        :type template: Microsoft.AspNet.Routing.Template.RouteTemplate
        
        
        :type defaults: System.Collections.Generic.IReadOnlyDictionary{System.String,System.Object}
    
        
        .. code-block:: csharp
    
           public TemplateMatcher(RouteTemplate template, IReadOnlyDictionary<string, object> defaults)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Routing.Template.TemplateMatcher
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Routing.Template.TemplateMatcher.Match(Microsoft.AspNet.Http.PathString)
    
        
        
        
        :type path: Microsoft.AspNet.Http.PathString
        :rtype: System.Collections.Generic.IDictionary{System.String,System.Object}
    
        
        .. code-block:: csharp
    
           public IDictionary<string, object> Match(PathString path)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Routing.Template.TemplateMatcher
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Routing.Template.TemplateMatcher.Defaults
    
        
        :rtype: System.Collections.Generic.IReadOnlyDictionary{System.String,System.Object}
    
        
        .. code-block:: csharp
    
           public IReadOnlyDictionary<string, object> Defaults { get; }
    
    .. dn:property:: Microsoft.AspNet.Routing.Template.TemplateMatcher.Template
    
        
        :rtype: Microsoft.AspNet.Routing.Template.RouteTemplate
    
        
        .. code-block:: csharp
    
           public RouteTemplate Template { get; }
    

