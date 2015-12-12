

RouteTemplate Class
===================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Routing.Template.RouteTemplate`








Syntax
------

.. code-block:: csharp

   public class RouteTemplate





GitHub
------

`View on GitHub <https://github.com/aspnet/routing/blob/master/src/Microsoft.AspNet.Routing/Template/RouteTemplate.cs>`_





.. dn:class:: Microsoft.AspNet.Routing.Template.RouteTemplate

Constructors
------------

.. dn:class:: Microsoft.AspNet.Routing.Template.RouteTemplate
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Routing.Template.RouteTemplate.RouteTemplate(System.Collections.Generic.List<Microsoft.AspNet.Routing.Template.TemplateSegment>)
    
        
        
        
        :type segments: System.Collections.Generic.List{Microsoft.AspNet.Routing.Template.TemplateSegment}
    
        
        .. code-block:: csharp
    
           public RouteTemplate(List<TemplateSegment> segments)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Routing.Template.RouteTemplate
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Routing.Template.RouteTemplate.GetSegment(System.Int32)
    
        
        
        
        :type index: System.Int32
        :rtype: Microsoft.AspNet.Routing.Template.TemplateSegment
    
        
        .. code-block:: csharp
    
           public TemplateSegment GetSegment(int index)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Routing.Template.RouteTemplate
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Routing.Template.RouteTemplate.Parameters
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.AspNet.Routing.Template.TemplatePart}
    
        
        .. code-block:: csharp
    
           public IList<TemplatePart> Parameters { get; }
    
    .. dn:property:: Microsoft.AspNet.Routing.Template.RouteTemplate.Segments
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.AspNet.Routing.Template.TemplateSegment}
    
        
        .. code-block:: csharp
    
           public IList<TemplateSegment> Segments { get; }
    

