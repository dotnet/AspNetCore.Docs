

TypedJsonPatchDocumentConverter Class
=====================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Newtonsoft.Json.JsonConverter`
* :dn:cls:`Microsoft.AspNet.JsonPatch.Converters.JsonPatchDocumentConverter`
* :dn:cls:`Microsoft.AspNet.JsonPatch.Converters.TypedJsonPatchDocumentConverter`








Syntax
------

.. code-block:: csharp

   public class TypedJsonPatchDocumentConverter : JsonPatchDocumentConverter





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/jsonpatch/src/Microsoft.AspNet.JsonPatch/Converters/TypedJsonPatchDocumentConverter.cs>`_





.. dn:class:: Microsoft.AspNet.JsonPatch.Converters.TypedJsonPatchDocumentConverter

Methods
-------

.. dn:class:: Microsoft.AspNet.JsonPatch.Converters.TypedJsonPatchDocumentConverter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.JsonPatch.Converters.TypedJsonPatchDocumentConverter.ReadJson(Newtonsoft.Json.JsonReader, System.Type, System.Object, Newtonsoft.Json.JsonSerializer)
    
        
        
        
        :type reader: Newtonsoft.Json.JsonReader
        
        
        :type objectType: System.Type
        
        
        :type existingValue: System.Object
        
        
        :type serializer: Newtonsoft.Json.JsonSerializer
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    

