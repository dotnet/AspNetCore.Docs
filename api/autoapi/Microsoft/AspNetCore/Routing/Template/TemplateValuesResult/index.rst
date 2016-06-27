

TemplateValuesResult Class
==========================






The values used as inputs for constraints and link generation.


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
* :dn:cls:`Microsoft.AspNetCore.Routing.Template.TemplateValuesResult`








Syntax
------

.. code-block:: csharp

    public class TemplateValuesResult








.. dn:class:: Microsoft.AspNetCore.Routing.Template.TemplateValuesResult
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Routing.Template.TemplateValuesResult

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Routing.Template.TemplateValuesResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Routing.Template.TemplateValuesResult.AcceptedValues
    
        
    
        
        The set of values that will appear in the URL.
    
        
        :rtype: Microsoft.AspNetCore.Routing.RouteValueDictionary
    
        
        .. code-block:: csharp
    
            public RouteValueDictionary AcceptedValues { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Routing.Template.TemplateValuesResult.CombinedValues
    
        
    
        
        The set of values that that were supplied for URL generation.
    
        
        :rtype: Microsoft.AspNetCore.Routing.RouteValueDictionary
    
        
        .. code-block:: csharp
    
            public RouteValueDictionary CombinedValues { get; set; }
    

