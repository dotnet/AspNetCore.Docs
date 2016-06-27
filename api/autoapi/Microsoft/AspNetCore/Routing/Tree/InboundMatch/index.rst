

InboundMatch Class
==================






A candidate route to match incoming URLs in a :any:`Microsoft.AspNetCore.Routing.Tree.TreeRouter`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Routing.Tree`
Assemblies
    * Microsoft.AspNetCore.Routing

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Routing.Tree.InboundMatch`








Syntax
------

.. code-block:: csharp

    [DebuggerDisplay("{DebuggerToString(),nq}")]
    public class InboundMatch








.. dn:class:: Microsoft.AspNetCore.Routing.Tree.InboundMatch
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Routing.Tree.InboundMatch

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Routing.Tree.InboundMatch
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Routing.Tree.InboundMatch.Entry
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Routing.Tree.InboundRouteEntry`\.
    
        
        :rtype: Microsoft.AspNetCore.Routing.Tree.InboundRouteEntry
    
        
        .. code-block:: csharp
    
            public InboundRouteEntry Entry { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.Tree.InboundMatch.TemplateMatcher
    
        
    
        
        Gets or sets the :dn:prop:`Microsoft.AspNetCore.Routing.Tree.InboundMatch.TemplateMatcher`\.
    
        
        :rtype: Microsoft.AspNetCore.Routing.Template.TemplateMatcher
    
        
        .. code-block:: csharp
    
            public TemplateMatcher TemplateMatcher { get; set; }
    

