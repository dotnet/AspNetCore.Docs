

Message Class
=============



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Dnx.TestHost.Message`








Syntax
------

.. code-block:: csharp

   public class Message





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/testing/src/Microsoft.Dnx.TestHost/Messages/Message.cs>`_





.. dn:class:: Microsoft.Dnx.TestHost.Message

Methods
-------

.. dn:class:: Microsoft.Dnx.TestHost.Message
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Dnx.TestHost.Message.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public override string ToString()
    

Properties
----------

.. dn:class:: Microsoft.Dnx.TestHost.Message
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Dnx.TestHost.Message.MessageType
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string MessageType { get; set; }
    
    .. dn:property:: Microsoft.Dnx.TestHost.Message.Payload
    
        
        :rtype: Newtonsoft.Json.Linq.JToken
    
        
        .. code-block:: csharp
    
           public JToken Payload { get; set; }
    

