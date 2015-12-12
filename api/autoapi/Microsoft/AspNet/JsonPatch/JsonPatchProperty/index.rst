

JsonPatchProperty Class
=======================



.. contents:: 
   :local:



Summary
-------

Metadata for JsonProperty.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.JsonPatch.JsonPatchProperty`








Syntax
------

.. code-block:: csharp

   public class JsonPatchProperty





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/jsonpatch/src/Microsoft.AspNet.JsonPatch/Helpers/JsonPatchProperty.cs>`_





.. dn:class:: Microsoft.AspNet.JsonPatch.JsonPatchProperty

Constructors
------------

.. dn:class:: Microsoft.AspNet.JsonPatch.JsonPatchProperty
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.JsonPatch.JsonPatchProperty.JsonPatchProperty(Newtonsoft.Json.Serialization.JsonProperty, System.Object)
    
        
    
        Initializes a new instance.
    
        
        
        
        :type property: Newtonsoft.Json.Serialization.JsonProperty
        
        
        :type parent: System.Object
    
        
        .. code-block:: csharp
    
           public JsonPatchProperty(JsonProperty property, object parent)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.JsonPatch.JsonPatchProperty
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.JsonPatch.JsonPatchProperty.Parent
    
        
    
        Gets or sets Parent.
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           public object Parent { get; set; }
    
    .. dn:property:: Microsoft.AspNet.JsonPatch.JsonPatchProperty.Property
    
        
    
        Gets or sets JsonProperty.
    
        
        :rtype: Newtonsoft.Json.Serialization.JsonProperty
    
        
        .. code-block:: csharp
    
           public JsonProperty Property { get; set; }
    

