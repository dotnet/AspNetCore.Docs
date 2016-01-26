

SerializerSettingsProvider Class
================================



.. contents:: 
   :local:



Summary
-------

Helper class which provides :any:`Newtonsoft.Json.JsonSerializerSettings`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Internal.SerializerSettingsProvider`








Syntax
------

.. code-block:: csharp

   public class SerializerSettingsProvider





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Formatters.Json/Internal/SerializerSettingsProvider.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Internal.SerializerSettingsProvider

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Internal.SerializerSettingsProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Internal.SerializerSettingsProvider.CreateSerializerSettings()
    
        
    
        Creates default :any:`Newtonsoft.Json.JsonSerializerSettings`\.
    
        
        :rtype: Newtonsoft.Json.JsonSerializerSettings
        :return: Default <see cref="T:Newtonsoft.Json.JsonSerializerSettings" />.
    
        
        .. code-block:: csharp
    
           public static JsonSerializerSettings CreateSerializerSettings()
    

