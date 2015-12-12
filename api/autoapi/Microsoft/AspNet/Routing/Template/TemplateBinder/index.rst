

TemplateBinder Class
====================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Routing.Template.TemplateBinder`








Syntax
------

.. code-block:: csharp

   public class TemplateBinder





GitHub
------

`View on GitHub <https://github.com/aspnet/routing/blob/master/src/Microsoft.AspNet.Routing/Template/TemplateBinder.cs>`_





.. dn:class:: Microsoft.AspNet.Routing.Template.TemplateBinder

Constructors
------------

.. dn:class:: Microsoft.AspNet.Routing.Template.TemplateBinder
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Routing.Template.TemplateBinder.TemplateBinder(Microsoft.AspNet.Routing.Template.RouteTemplate, System.Collections.Generic.IReadOnlyDictionary<System.String, System.Object>)
    
        
        
        
        :type template: Microsoft.AspNet.Routing.Template.RouteTemplate
        
        
        :type defaults: System.Collections.Generic.IReadOnlyDictionary{System.String,System.Object}
    
        
        .. code-block:: csharp
    
           public TemplateBinder(RouteTemplate template, IReadOnlyDictionary<string, object> defaults)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Routing.Template.TemplateBinder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Routing.Template.TemplateBinder.BindValues(System.Collections.Generic.IDictionary<System.String, System.Object>)
    
        
        
        
        :type acceptedValues: System.Collections.Generic.IDictionary{System.String,System.Object}
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string BindValues(IDictionary<string, object> acceptedValues)
    
    .. dn:method:: Microsoft.AspNet.Routing.Template.TemplateBinder.GetValues(System.Collections.Generic.IDictionary<System.String, System.Object>, System.Collections.Generic.IDictionary<System.String, System.Object>)
    
        
        
        
        :type ambientValues: System.Collections.Generic.IDictionary{System.String,System.Object}
        
        
        :type values: System.Collections.Generic.IDictionary{System.String,System.Object}
        :rtype: Microsoft.AspNet.Routing.Template.TemplateValuesResult
    
        
        .. code-block:: csharp
    
           public TemplateValuesResult GetValues(IDictionary<string, object> ambientValues, IDictionary<string, object> values)
    
    .. dn:method:: Microsoft.AspNet.Routing.Template.TemplateBinder.RoutePartsEqual(System.Object, System.Object)
    
        
    
        Compares two objects for equality as parts of a case-insensitive path.
    
        
        
        
        :param a: An object to compare.
        
        :type a: System.Object
        
        
        :param b: An object to compare.
        
        :type b: System.Object
        :rtype: System.Boolean
        :return: True if the object are equal, otherwise false.
    
        
        .. code-block:: csharp
    
           public static bool RoutePartsEqual(object a, object b)
    

