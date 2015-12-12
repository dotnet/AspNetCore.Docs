

JsonPatchDocumentConverter Class
================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Newtonsoft.Json.JsonConverter`
* :dn:cls:`Microsoft.AspNet.JsonPatch.Converters.JsonPatchDocumentConverter`








Syntax
------

.. code-block:: csharp

   public class JsonPatchDocumentConverter : JsonConverter





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/jsonpatch/src/Microsoft.AspNet.JsonPatch/Converters/JsonPatchDocumentConverter.cs>`_





.. dn:class:: Microsoft.AspNet.JsonPatch.Converters.JsonPatchDocumentConverter

Methods
-------

.. dn:class:: Microsoft.AspNet.JsonPatch.Converters.JsonPatchDocumentConverter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.JsonPatch.Converters.JsonPatchDocumentConverter.CanConvert(System.Type)
    
        
        
        
        :type objectType: System.Type
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool CanConvert(Type objectType)
    
    .. dn:method:: Microsoft.AspNet.JsonPatch.Converters.JsonPatchDocumentConverter.ReadJson(Newtonsoft.Json.JsonReader, System.Type, System.Object, Newtonsoft.Json.JsonSerializer)
    
        
        
        
        :type reader: Newtonsoft.Json.JsonReader
        
        
        :type objectType: System.Type
        
        
        :type existingValue: System.Object
        
        
        :type serializer: Newtonsoft.Json.JsonSerializer
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    
    .. dn:method:: Microsoft.AspNet.JsonPatch.Converters.JsonPatchDocumentConverter.WriteJson(Newtonsoft.Json.JsonWriter, System.Object, Newtonsoft.Json.JsonSerializer)
    
        
        
        
        :type writer: Newtonsoft.Json.JsonWriter
        
        
        :type value: System.Object
        
        
        :type serializer: Newtonsoft.Json.JsonSerializer
    
        
        .. code-block:: csharp
    
           public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    

