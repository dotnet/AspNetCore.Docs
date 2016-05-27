

RequestTokenSerializer Class
============================






Serializes and deserializes Twitter request and access tokens so that they can be used by other application components.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Authentication.Twitter`
Assemblies
    * Microsoft.AspNetCore.Authentication.Twitter

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Authentication.Twitter.RequestTokenSerializer`








Syntax
------

.. code-block:: csharp

    public class RequestTokenSerializer : IDataSerializer<RequestToken>








.. dn:class:: Microsoft.AspNetCore.Authentication.Twitter.RequestTokenSerializer
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authentication.Twitter.RequestTokenSerializer

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Authentication.Twitter.RequestTokenSerializer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Authentication.Twitter.RequestTokenSerializer.Deserialize(System.Byte[])
    
        
    
        
        Deserializes a request token.
    
        
    
        
        :param data: A byte array containing the serialized token
        
        :type data: System.Byte<System.Byte>[]
        :rtype: Microsoft.AspNetCore.Authentication.Twitter.RequestToken
        :return: The Twitter request token
    
        
        .. code-block:: csharp
    
            public virtual RequestToken Deserialize(byte[] data)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.Twitter.RequestTokenSerializer.Read(System.IO.BinaryReader)
    
        
    
        
        Reads a Twitter request token from a series of bytes. Used by the :dn:meth:`Microsoft.AspNetCore.Authentication.Twitter.RequestTokenSerializer.Deserialize(System.Byte[])` method.
    
        
    
        
        :param reader: The reader to use in reading the token bytes
        
        :type reader: System.IO.BinaryReader
        :rtype: Microsoft.AspNetCore.Authentication.Twitter.RequestToken
        :return: The token
    
        
        .. code-block:: csharp
    
            public static RequestToken Read(BinaryReader reader)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.Twitter.RequestTokenSerializer.Serialize(Microsoft.AspNetCore.Authentication.Twitter.RequestToken)
    
        
    
        
        Serialize a request token.
    
        
    
        
        :param model: The token to serialize
        
        :type model: Microsoft.AspNetCore.Authentication.Twitter.RequestToken
        :rtype: System.Byte<System.Byte>[]
        :return: A byte array containing the serialized token
    
        
        .. code-block:: csharp
    
            public virtual byte[] Serialize(RequestToken model)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.Twitter.RequestTokenSerializer.Write(System.IO.BinaryWriter, Microsoft.AspNetCore.Authentication.Twitter.RequestToken)
    
        
    
        
        Writes a Twitter request token as a series of bytes. Used by the :dn:meth:`Microsoft.AspNetCore.Authentication.Twitter.RequestTokenSerializer.Serialize(Microsoft.AspNetCore.Authentication.Twitter.RequestToken)` method.
    
        
    
        
        :param writer: The writer to use in writing the token
        
        :type writer: System.IO.BinaryWriter
    
        
        :param token: The token to write
        
        :type token: Microsoft.AspNetCore.Authentication.Twitter.RequestToken
    
        
        .. code-block:: csharp
    
            public static void Write(BinaryWriter writer, RequestToken token)
    

