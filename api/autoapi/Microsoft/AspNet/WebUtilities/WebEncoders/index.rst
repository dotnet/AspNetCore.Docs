

WebEncoders Class
=================



.. contents:: 
   :local:



Summary
-------

Contains utility APIs to assist with common encoding and decoding operations.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.WebUtilities.WebEncoders`








Syntax
------

.. code-block:: csharp

   public class WebEncoders





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/httpabstractions/src/Microsoft.AspNet.WebUtilities/WebEncoders.cs>`_





.. dn:class:: Microsoft.AspNet.WebUtilities.WebEncoders

Methods
-------

.. dn:class:: Microsoft.AspNet.WebUtilities.WebEncoders
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.WebUtilities.WebEncoders.Base64UrlDecode(System.String)
    
        
    
        Decodes a base64url-encoded string.
    
        
        
        
        :param input: The base64url-encoded input to decode.
        
        :type input: System.String
        :rtype: System.Byte[]
        :return: The base64url-decoded form of the input.
    
        
        .. code-block:: csharp
    
           public static byte[] Base64UrlDecode(string input)
    
    .. dn:method:: Microsoft.AspNet.WebUtilities.WebEncoders.Base64UrlDecode(System.String, System.Int32, System.Int32)
    
        
    
        Decodes a base64url-encoded substring of a given string.
    
        
        
        
        :param input: A string containing the base64url-encoded input to decode.
        
        :type input: System.String
        
        
        :param offset: The position in  at which decoding should begin.
        
        :type offset: System.Int32
        
        
        :param count: The number of characters in  to decode.
        
        :type count: System.Int32
        :rtype: System.Byte[]
        :return: The base64url-decoded form of the input.
    
        
        .. code-block:: csharp
    
           public static byte[] Base64UrlDecode(string input, int offset, int count)
    
    .. dn:method:: Microsoft.AspNet.WebUtilities.WebEncoders.Base64UrlEncode(System.Byte[])
    
        
    
        Encodes an input using base64url encoding.
    
        
        
        
        :param input: The binary input to encode.
        
        :type input: System.Byte[]
        :rtype: System.String
        :return: The base64url-encoded form of the input.
    
        
        .. code-block:: csharp
    
           public static string Base64UrlEncode(byte[] input)
    
    .. dn:method:: Microsoft.AspNet.WebUtilities.WebEncoders.Base64UrlEncode(System.Byte[], System.Int32, System.Int32)
    
        
    
        Encodes an input using base64url encoding.
    
        
        
        
        :param input: The binary input to encode.
        
        :type input: System.Byte[]
        
        
        :param offset: The offset into  at which to begin encoding.
        
        :type offset: System.Int32
        
        
        :param count: The number of bytes of  to encode.
        
        :type count: System.Int32
        :rtype: System.String
        :return: The base64url-encoded form of the input.
    
        
        .. code-block:: csharp
    
           public static string Base64UrlEncode(byte[] input, int offset, int count)
    

