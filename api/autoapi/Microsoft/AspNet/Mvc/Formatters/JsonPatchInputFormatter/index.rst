

JsonPatchInputFormatter Class
=============================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Formatters.InputFormatter`
* :dn:cls:`Microsoft.AspNet.Mvc.Formatters.JsonInputFormatter`
* :dn:cls:`Microsoft.AspNet.Mvc.Formatters.JsonPatchInputFormatter`








Syntax
------

.. code-block:: csharp

   public class JsonPatchInputFormatter : JsonInputFormatter, IInputFormatter





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Formatters.Json/JsonPatchInputFormatter.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Formatters.JsonPatchInputFormatter

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Formatters.JsonPatchInputFormatter
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Formatters.JsonPatchInputFormatter.JsonPatchInputFormatter()
    
        
    
        
        .. code-block:: csharp
    
           public JsonPatchInputFormatter()
    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Formatters.JsonPatchInputFormatter.JsonPatchInputFormatter(Newtonsoft.Json.JsonSerializerSettings)
    
        
        
        
        :type serializerSettings: Newtonsoft.Json.JsonSerializerSettings
    
        
        .. code-block:: csharp
    
           public JsonPatchInputFormatter(JsonSerializerSettings serializerSettings)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Formatters.JsonPatchInputFormatter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.JsonPatchInputFormatter.CanRead(Microsoft.AspNet.Mvc.Formatters.InputFormatterContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Formatters.InputFormatterContext
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool CanRead(InputFormatterContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Formatters.JsonPatchInputFormatter.ReadRequestBodyAsync(Microsoft.AspNet.Mvc.Formatters.InputFormatterContext)
    
        
        
        
        :type context: Microsoft.AspNet.Mvc.Formatters.InputFormatterContext
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Mvc.Formatters.InputFormatterResult}
    
        
        .. code-block:: csharp
    
           public override Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context)
    

