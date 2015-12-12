

JsonHelper Class
================



.. contents:: 
   :local:



Summary
-------

Default implementation of :any:`Microsoft.AspNet.Mvc.Rendering.IJsonHelper`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ViewFeatures.JsonHelper`








Syntax
------

.. code-block:: csharp

   public class JsonHelper : IJsonHelper





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.ViewFeatures/ViewFeatures/JsonHelper.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.JsonHelper

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.JsonHelper
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ViewFeatures.JsonHelper.JsonHelper(Microsoft.AspNet.Mvc.Formatters.JsonOutputFormatter)
    
        
    
        Initializes a new instance of :any:`Microsoft.AspNet.Mvc.ViewFeatures.JsonHelper` that is backed by ``jsonOutputFormatter``.
    
        
        
        
        :param jsonOutputFormatter: The  used to serialize JSON.
        
        :type jsonOutputFormatter: Microsoft.AspNet.Mvc.Formatters.JsonOutputFormatter
    
        
        .. code-block:: csharp
    
           public JsonHelper(JsonOutputFormatter jsonOutputFormatter)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.JsonHelper
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.JsonHelper.Serialize(System.Object)
    
        
        
        
        :type value: System.Object
        :rtype: Microsoft.AspNet.Mvc.Rendering.HtmlString
    
        
        .. code-block:: csharp
    
           public HtmlString Serialize(object value)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.JsonHelper.Serialize(System.Object, Newtonsoft.Json.JsonSerializerSettings)
    
        
        
        
        :type value: System.Object
        
        
        :type serializerSettings: Newtonsoft.Json.JsonSerializerSettings
        :rtype: Microsoft.AspNet.Mvc.Rendering.HtmlString
    
        
        .. code-block:: csharp
    
           public HtmlString Serialize(object value, JsonSerializerSettings serializerSettings)
    

