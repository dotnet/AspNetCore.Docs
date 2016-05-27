

IJsonHelper Interface
=====================






Base JSON helpers.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Rendering`
Assemblies
    * Microsoft.AspNetCore.Mvc.ViewFeatures

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IJsonHelper








.. dn:interface:: Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper.Serialize(System.Object)
    
        
    
        
        Returns serialized JSON for the <em>value</em>.
    
        
    
        
        :param value: The value to serialize as JSON.
        
        :type value: System.Object
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the serialized JSON.
    
        
        .. code-block:: csharp
    
            IHtmlContent Serialize(object value)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper.Serialize(System.Object, Newtonsoft.Json.JsonSerializerSettings)
    
        
    
        
        Returns serialized JSON for the <em>value</em>.
    
        
    
        
        :param value: The value to serialize as JSON.
        
        :type value: System.Object
    
        
        :param serializerSettings: 
            The :any:`Newtonsoft.Json.JsonSerializerSettings` to be used by the serializer.
        
        :type serializerSettings: Newtonsoft.Json.JsonSerializerSettings
        :rtype: Microsoft.AspNetCore.Html.IHtmlContent
        :return: A new :any:`Microsoft.AspNetCore.Html.IHtmlContent` containing the serialized JSON.
    
        
        .. code-block:: csharp
    
            IHtmlContent Serialize(object value, JsonSerializerSettings serializerSettings)
    

