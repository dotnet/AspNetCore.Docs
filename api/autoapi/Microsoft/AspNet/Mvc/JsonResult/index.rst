

JsonResult Class
================



.. contents:: 
   :local:



Summary
-------

An action result which formats the given object as JSON.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ActionResult`
* :dn:cls:`Microsoft.AspNet.Mvc.JsonResult`








Syntax
------

.. code-block:: csharp

   public class JsonResult : ActionResult, IActionResult





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Formatters.Json/JsonResult.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.JsonResult

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.JsonResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.JsonResult.JsonResult(System.Object)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.JsonResult` with the given ``value``.
    
        
        
        
        :param value: The value to format as JSON.
        
        :type value: System.Object
    
        
        .. code-block:: csharp
    
           public JsonResult(object value)
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.JsonResult.JsonResult(System.Object, Newtonsoft.Json.JsonSerializerSettings)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.JsonResult` with the given ``value``.
    
        
        
        
        :param value: The value to format as JSON.
        
        :type value: System.Object
        
        
        :param serializerSettings: The  to be used by
            the formatter.
        
        :type serializerSettings: Newtonsoft.Json.JsonSerializerSettings
    
        
        .. code-block:: csharp
    
           public JsonResult(object value, JsonSerializerSettings serializerSettings)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.JsonResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.JsonResult.ExecuteResultAsync(Microsoft.AspNet.Mvc.ActionContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.ActionContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public override Task ExecuteResultAsync(ActionContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.JsonResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.JsonResult.ContentType
    
        
    
        Gets or sets the :any:`Microsoft.Net.Http.Headers.MediaTypeHeaderValue` representing the Content-Type header of the response.
    
        
        :rtype: Microsoft.Net.Http.Headers.MediaTypeHeaderValue
    
        
        .. code-block:: csharp
    
           public MediaTypeHeaderValue ContentType { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.JsonResult.StatusCode
    
        
    
        Gets or sets the HTTP status code.
    
        
        :rtype: System.Nullable{System.Int32}
    
        
        .. code-block:: csharp
    
           public int ? StatusCode { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.JsonResult.Value
    
        
    
        Gets or sets the value to be formatted.
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           public object Value { get; set; }
    

