

TemplateBinder Class
====================





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
* :dn:cls:`Microsoft.AspNetCore.Routing.Template.TemplateBinder`








Syntax
------

.. code-block:: csharp

    public class TemplateBinder








.. dn:class:: Microsoft.AspNetCore.Routing.Template.TemplateBinder
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Routing.Template.TemplateBinder

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Routing.Template.TemplateBinder
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Routing.Template.TemplateBinder.TemplateBinder(System.Text.Encodings.Web.UrlEncoder, Microsoft.Extensions.ObjectPool.ObjectPool<Microsoft.AspNetCore.Routing.Internal.UriBuildingContext>, Microsoft.AspNetCore.Routing.Template.RouteTemplate, Microsoft.AspNetCore.Routing.RouteValueDictionary)
    
        
    
        
        :type urlEncoder: System.Text.Encodings.Web.UrlEncoder
    
        
        :type pool: Microsoft.Extensions.ObjectPool.ObjectPool<Microsoft.Extensions.ObjectPool.ObjectPool`1>{Microsoft.AspNetCore.Routing.Internal.UriBuildingContext<Microsoft.AspNetCore.Routing.Internal.UriBuildingContext>}
    
        
        :type template: Microsoft.AspNetCore.Routing.Template.RouteTemplate
    
        
        :type defaults: Microsoft.AspNetCore.Routing.RouteValueDictionary
    
        
        .. code-block:: csharp
    
            public TemplateBinder(UrlEncoder urlEncoder, ObjectPool<UriBuildingContext> pool, RouteTemplate template, RouteValueDictionary defaults)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Routing.Template.TemplateBinder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Routing.Template.TemplateBinder.BindValues(Microsoft.AspNetCore.Routing.RouteValueDictionary)
    
        
    
        
        :type acceptedValues: Microsoft.AspNetCore.Routing.RouteValueDictionary
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string BindValues(RouteValueDictionary acceptedValues)
    
    .. dn:method:: Microsoft.AspNetCore.Routing.Template.TemplateBinder.GetValues(Microsoft.AspNetCore.Routing.RouteValueDictionary, Microsoft.AspNetCore.Routing.RouteValueDictionary)
    
        
    
        
        :type ambientValues: Microsoft.AspNetCore.Routing.RouteValueDictionary
    
        
        :type values: Microsoft.AspNetCore.Routing.RouteValueDictionary
        :rtype: Microsoft.AspNetCore.Routing.Template.TemplateValuesResult
    
        
        .. code-block:: csharp
    
            public TemplateValuesResult GetValues(RouteValueDictionary ambientValues, RouteValueDictionary values)
    
    .. dn:method:: Microsoft.AspNetCore.Routing.Template.TemplateBinder.RoutePartsEqual(System.Object, System.Object)
    
        
    
        
        Compares two objects for equality as parts of a case-insensitive path.
    
        
    
        
        :param a: An object to compare.
        
        :type a: System.Object
    
        
        :param b: An object to compare.
        
        :type b: System.Object
        :rtype: System.Boolean
        :return: True if the object are equal, otherwise false.
    
        
        .. code-block:: csharp
    
            public static bool RoutePartsEqual(object a, object b)
    

