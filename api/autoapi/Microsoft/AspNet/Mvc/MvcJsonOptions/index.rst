

MvcJsonOptions Class
====================



.. contents:: 
   :local:



Summary
-------

Provides programmatic configuration for JSON in the MVC framework.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.MvcJsonOptions`








Syntax
------

.. code-block:: csharp

   public class MvcJsonOptions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Formatters.Json/MvcJsonOptions.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.MvcJsonOptions

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.MvcJsonOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.MvcJsonOptions.SerializerSettings
    
        
    
        Gets the :any:`Newtonsoft.Json.JsonSerializerSettings` that are used by this application.
    
        
        :rtype: Newtonsoft.Json.JsonSerializerSettings
    
        
        .. code-block:: csharp
    
           public JsonSerializerSettings SerializerSettings { get; }
    

