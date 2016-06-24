

JsonResult Class
================






An action result which formats the given object as JSON.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.ActionResult`
* :dn:cls:`Microsoft.AspNetCore.Mvc.JsonResult`








Syntax
------

.. code-block:: csharp

    public class JsonResult : ActionResult, IActionResult








.. dn:class:: Microsoft.AspNetCore.Mvc.JsonResult
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.JsonResult

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.JsonResult
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.JsonResult.JsonResult(System.Object)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.JsonResult` with the given <em>value</em>.
    
        
    
        
        :param value: The value to format as JSON.
        
        :type value: System.Object
    
        
        .. code-block:: csharp
    
            public JsonResult(object value)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.JsonResult.JsonResult(System.Object, Newtonsoft.Json.JsonSerializerSettings)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.JsonResult` with the given <em>value</em>.
    
        
    
        
        :param value: The value to format as JSON.
        
        :type value: System.Object
    
        
        :param serializerSettings: The :any:`Newtonsoft.Json.JsonSerializerSettings` to be used by
            the formatter.
        
        :type serializerSettings: Newtonsoft.Json.JsonSerializerSettings
    
        
        .. code-block:: csharp
    
            public JsonResult(object value, JsonSerializerSettings serializerSettings)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.JsonResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.JsonResult.ContentType
    
        
    
        
        Gets or sets the :any:`Microsoft.Net.Http.Headers.MediaTypeHeaderValue` representing the Content-Type header of the response.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ContentType { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.JsonResult.SerializerSettings
    
        
    
        
        Gets or sets the :any:`Newtonsoft.Json.JsonSerializerSettings`\.
    
        
        :rtype: Newtonsoft.Json.JsonSerializerSettings
    
        
        .. code-block:: csharp
    
            public JsonSerializerSettings SerializerSettings { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.JsonResult.StatusCode
    
        
    
        
        Gets or sets the HTTP status code.
    
        
        :rtype: System.Nullable<System.Nullable`1>{System.Int32<System.Int32>}
    
        
        .. code-block:: csharp
    
            public int ? StatusCode { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.JsonResult.Value
    
        
    
        
        Gets or sets the value to be formatted.
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            public object Value { get; set; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.JsonResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.JsonResult.ExecuteResultAsync(Microsoft.AspNetCore.Mvc.ActionContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Mvc.ActionContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public override Task ExecuteResultAsync(ActionContext context)
    

