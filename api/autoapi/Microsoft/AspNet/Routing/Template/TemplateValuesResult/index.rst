

TemplateValuesResult Class
==========================



.. contents:: 
   :local:



Summary
-------

The values used as inputs for constraints and link generation.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Routing.Template.TemplateValuesResult`








Syntax
------

.. code-block:: csharp

   public class TemplateValuesResult





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/routing/src/Microsoft.AspNet.Routing/Template/TemplateValuesResult.cs>`_





.. dn:class:: Microsoft.AspNet.Routing.Template.TemplateValuesResult

Properties
----------

.. dn:class:: Microsoft.AspNet.Routing.Template.TemplateValuesResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Routing.Template.TemplateValuesResult.AcceptedValues
    
        
    
        The set of values that will appear in the URL.
    
        
        :rtype: System.Collections.Generic.IDictionary{System.String,System.Object}
    
        
        .. code-block:: csharp
    
           public IDictionary<string, object> AcceptedValues { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Routing.Template.TemplateValuesResult.CombinedValues
    
        
    
        The set of values that that were supplied for URL generation.
    
        
        :rtype: System.Collections.Generic.IDictionary{System.String,System.Object}
    
        
        .. code-block:: csharp
    
           public IDictionary<string, object> CombinedValues { get; set; }
    

