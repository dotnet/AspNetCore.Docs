

JsonPatchProperty Class
=======================






Metadata for JsonProperty.


Namespace
    :dn:ns:`Microsoft.AspNetCore.JsonPatch`
Assemblies
    * Microsoft.AspNetCore.JsonPatch

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.JsonPatch.JsonPatchProperty`








Syntax
------

.. code-block:: csharp

    public class JsonPatchProperty








.. dn:class:: Microsoft.AspNetCore.JsonPatch.JsonPatchProperty
    :hidden:

.. dn:class:: Microsoft.AspNetCore.JsonPatch.JsonPatchProperty

Properties
----------

.. dn:class:: Microsoft.AspNetCore.JsonPatch.JsonPatchProperty
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.JsonPatch.JsonPatchProperty.Parent
    
        
    
        
        Gets or sets Parent.
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            public object Parent
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.JsonPatch.JsonPatchProperty.Property
    
        
    
        
        Gets or sets JsonProperty.
    
        
        :rtype: Newtonsoft.Json.Serialization.JsonProperty
    
        
        .. code-block:: csharp
    
            public JsonProperty Property
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.JsonPatch.JsonPatchProperty
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.JsonPatch.JsonPatchProperty.JsonPatchProperty(Newtonsoft.Json.Serialization.JsonProperty, System.Object)
    
        
    
        
        Initializes a new instance.
    
        
    
        
        :type property: Newtonsoft.Json.Serialization.JsonProperty
    
        
        :type parent: System.Object
    
        
        .. code-block:: csharp
    
            public JsonPatchProperty(JsonProperty property, object parent)
    

