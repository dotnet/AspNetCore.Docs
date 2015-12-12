

IJsonHelper Interface
=====================



.. contents:: 
   :local:



Summary
-------

Base JSON helpers.











Syntax
------

.. code-block:: csharp

   public interface IJsonHelper





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.ViewFeatures/Rendering/IJsonHelper.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.Rendering.IJsonHelper

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.Rendering.IJsonHelper
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.IJsonHelper.Serialize(System.Object)
    
        
    
        Returns serialized JSON for the ``value``.
    
        
        
        
        :param value: The value to serialize as JSON.
        
        :type value: System.Object
        :rtype: Microsoft.AspNet.Mvc.Rendering.HtmlString
        :return: A new <see cref="T:Microsoft.AspNet.Mvc.Rendering.HtmlString" /> containing the serialized JSON.
    
        
        .. code-block:: csharp
    
           HtmlString Serialize(object value)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Rendering.IJsonHelper.Serialize(System.Object, Newtonsoft.Json.JsonSerializerSettings)
    
        
    
        Returns serialized JSON for the ``value``.
    
        
        
        
        :param value: The value to serialize as JSON.
        
        :type value: System.Object
        
        
        :param serializerSettings: The  to be used by the serializer.
        
        :type serializerSettings: Newtonsoft.Json.JsonSerializerSettings
        :rtype: Microsoft.AspNet.Mvc.Rendering.HtmlString
        :return: A new <see cref="T:Microsoft.AspNet.Mvc.Rendering.HtmlString" /> containing the serialized JSON.
    
        
        .. code-block:: csharp
    
           HtmlString Serialize(object value, JsonSerializerSettings serializerSettings)
    

