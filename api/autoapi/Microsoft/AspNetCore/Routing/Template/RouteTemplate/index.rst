

RouteTemplate Class
===================





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
* :dn:cls:`Microsoft.AspNetCore.Routing.Template.RouteTemplate`








Syntax
------

.. code-block:: csharp

    [DebuggerDisplay("{DebuggerToString()}")]
    public class RouteTemplate








.. dn:class:: Microsoft.AspNetCore.Routing.Template.RouteTemplate
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Routing.Template.RouteTemplate

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Routing.Template.RouteTemplate
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Routing.Template.RouteTemplate.Parameters
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Routing.Template.TemplatePart<Microsoft.AspNetCore.Routing.Template.TemplatePart>}
    
        
        .. code-block:: csharp
    
            public IList<TemplatePart> Parameters
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.Template.RouteTemplate.Segments
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Routing.Template.TemplateSegment<Microsoft.AspNetCore.Routing.Template.TemplateSegment>}
    
        
        .. code-block:: csharp
    
            public IList<TemplateSegment> Segments
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.Template.RouteTemplate.TemplateText
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string TemplateText
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Routing.Template.RouteTemplate
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Routing.Template.RouteTemplate.RouteTemplate(System.String, System.Collections.Generic.List<Microsoft.AspNetCore.Routing.Template.TemplateSegment>)
    
        
    
        
        :type template: System.String
    
        
        :type segments: System.Collections.Generic.List<System.Collections.Generic.List`1>{Microsoft.AspNetCore.Routing.Template.TemplateSegment<Microsoft.AspNetCore.Routing.Template.TemplateSegment>}
    
        
        .. code-block:: csharp
    
            public RouteTemplate(string template, List<TemplateSegment> segments)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Routing.Template.RouteTemplate
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Routing.Template.RouteTemplate.GetParameter(System.String)
    
        
    
        
        Gets the parameter matching the given name.
    
        
    
        
        :param name: The name of the parameter to match.
        
        :type name: System.String
        :rtype: Microsoft.AspNetCore.Routing.Template.TemplatePart
        :return: The matching parameter or <code>null</code> if no parameter matches the given name.
    
        
        .. code-block:: csharp
    
            public TemplatePart GetParameter(string name)
    
    .. dn:method:: Microsoft.AspNetCore.Routing.Template.RouteTemplate.GetSegment(System.Int32)
    
        
    
        
        :type index: System.Int32
        :rtype: Microsoft.AspNetCore.Routing.Template.TemplateSegment
    
        
        .. code-block:: csharp
    
            public TemplateSegment GetSegment(int index)
    

