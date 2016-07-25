

MvcJsonOptions Class
====================






Provides programmatic configuration for JSON in the MVC framework.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc`
Assemblies
    * Microsoft.AspNetCore.Mvc.Formatters.Json

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.MvcJsonOptions`








Syntax
------

.. code-block:: csharp

    public class MvcJsonOptions








.. dn:class:: Microsoft.AspNetCore.Mvc.MvcJsonOptions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.MvcJsonOptions

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.MvcJsonOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.MvcJsonOptions.SerializerSettings
    
        
    
        
        Gets the :any:`Newtonsoft.Json.JsonSerializerSettings` that are used by this application.
    
        
        :rtype: Newtonsoft.Json.JsonSerializerSettings
    
        
        .. code-block:: csharp
    
            public JsonSerializerSettings SerializerSettings { get; }
    

