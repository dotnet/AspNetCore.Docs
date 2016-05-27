

WebEncoders Class
=================






Contains utility APIs to assist with common encoding and decoding operations.


Namespace
    :dn:ns:`Microsoft.AspNetCore.WebUtilities`
Assemblies
    * Microsoft.AspNetCore.WebUtilities

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.WebUtilities.WebEncoders`








Syntax
------

.. code-block:: csharp

    public class WebEncoders








.. dn:class:: Microsoft.AspNetCore.WebUtilities.WebEncoders
    :hidden:

.. dn:class:: Microsoft.AspNetCore.WebUtilities.WebEncoders

Methods
-------

.. dn:class:: Microsoft.AspNetCore.WebUtilities.WebEncoders
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.WebUtilities.WebEncoders.Base64UrlDecode(System.String)
    
        
    
        
        Decodes a base64url-encoded string.
    
        
    
        
        :param input: The base64url-encoded input to decode.
        
        :type input: System.String
        :rtype: System.Byte<System.Byte>[]
        :return: The base64url-decoded form of the input.
    
        
        .. code-block:: csharp
    
            public static byte[] Base64UrlDecode(string input)
    
    .. dn:method:: Microsoft.AspNetCore.WebUtilities.WebEncoders.Base64UrlDecode(System.String, System.Int32, System.Char[], System.Int32, System.Int32)
    
        
    
        
        Decodes a base64url-encoded <em>input</em> into a <code>byte[]</code>.
    
        
    
        
        :param input: A string containing the base64url-encoded input to decode.
        
        :type input: System.String
    
        
        :param offset: The position in <em>input</em> at which decoding should begin.
        
        :type offset: System.Int32
    
        
        :param buffer: 
            Scratch buffer to hold the :any:`System.Char`\s to decode. Array must be large enough to hold
            <em>bufferOffset</em> and <em>count</em> characters as well as Base64 padding
            characters. Content is not preserved.
        
        :type buffer: System.Char<System.Char>[]
    
        
        :param bufferOffset: 
            The offset into <em>buffer</em> at which to begin writing the :any:`System.Char`\s to decode.
        
        :type bufferOffset: System.Int32
    
        
        :param count: The number of characters in <em>input</em> to decode.
        
        :type count: System.Int32
        :rtype: System.Byte<System.Byte>[]
        :return: The base64url-decoded form of the <em>input</em>.
    
        
        .. code-block:: csharp
    
            public static byte[] Base64UrlDecode(string input, int offset, char[] buffer, int bufferOffset, int count)
    
    .. dn:method:: Microsoft.AspNetCore.WebUtilities.WebEncoders.Base64UrlDecode(System.String, System.Int32, System.Int32)
    
        
    
        
        Decodes a base64url-encoded substring of a given string.
    
        
    
        
        :param input: A string containing the base64url-encoded input to decode.
        
        :type input: System.String
    
        
        :param offset: The position in <em>input</em> at which decoding should begin.
        
        :type offset: System.Int32
    
        
        :param count: The number of characters in <em>input</em> to decode.
        
        :type count: System.Int32
        :rtype: System.Byte<System.Byte>[]
        :return: The base64url-decoded form of the input.
    
        
        .. code-block:: csharp
    
            public static byte[] Base64UrlDecode(string input, int offset, int count)
    
    .. dn:method:: Microsoft.AspNetCore.WebUtilities.WebEncoders.Base64UrlEncode(System.Byte[])
    
        
    
        
        Encodes <em>input</em> using base64url encoding.
    
        
    
        
        :param input: The binary input to encode.
        
        :type input: System.Byte<System.Byte>[]
        :rtype: System.String
        :return: The base64url-encoded form of <em>input</em>.
    
        
        .. code-block:: csharp
    
            public static string Base64UrlEncode(byte[] input)
    
    .. dn:method:: Microsoft.AspNetCore.WebUtilities.WebEncoders.Base64UrlEncode(System.Byte[], System.Int32, System.Char[], System.Int32, System.Int32)
    
        
    
        
        Encodes <em>input</em> using base64url encoding.
    
        
    
        
        :param input: The binary input to encode.
        
        :type input: System.Byte<System.Byte>[]
    
        
        :param offset: The offset into <em>input</em> at which to begin encoding.
        
        :type offset: System.Int32
    
        
        :param output: 
            Buffer to receive the base64url-encoded form of <em>input</em>. Array must be large enough to
            hold <em>outputOffset</em> characters and the full base64-encoded form of
            <em>input</em>, including padding characters.
        
        :type output: System.Char<System.Char>[]
    
        
        :param outputOffset: 
            The offset into <em>output</em> at which to begin writing the base64url-encoded form of
            <em>input</em>.
        
        :type outputOffset: System.Int32
    
        
        :param count: The number of <code>byte</code>s from <em>input</em> to encode.
        
        :type count: System.Int32
        :rtype: System.Int32
        :return: 
            The number of characters written to <em>output</em>, less any padding characters.
    
        
        .. code-block:: csharp
    
            public static int Base64UrlEncode(byte[] input, int offset, char[] output, int outputOffset, int count)
    
    .. dn:method:: Microsoft.AspNetCore.WebUtilities.WebEncoders.Base64UrlEncode(System.Byte[], System.Int32, System.Int32)
    
        
    
        
        Encodes <em>input</em> using base64url encoding.
    
        
    
        
        :param input: The binary input to encode.
        
        :type input: System.Byte<System.Byte>[]
    
        
        :param offset: The offset into <em>input</em> at which to begin encoding.
        
        :type offset: System.Int32
    
        
        :param count: The number of bytes from <em>input</em> to encode.
        
        :type count: System.Int32
        :rtype: System.String
        :return: The base64url-encoded form of <em>input</em>.
    
        
        .. code-block:: csharp
    
            public static string Base64UrlEncode(byte[] input, int offset, int count)
    
    .. dn:method:: Microsoft.AspNetCore.WebUtilities.WebEncoders.GetArraySizeRequiredToDecode(System.Int32)
    
        
    
        
        Gets the minimum <code>char[]</code> size required for decoding of <em>count</em> characters
        with the :dn:meth:`Microsoft.AspNetCore.WebUtilities.WebEncoders.Base64UrlDecode(System.String,System.Int32,System.Char[],System.Int32,System.Int32)` method.
    
        
    
        
        :param count: The number of characters to decode.
        
        :type count: System.Int32
        :rtype: System.Int32
        :return: 
            The minimum <code>char[]</code> size required for decoding  of <em>count</em> characters.
    
        
        .. code-block:: csharp
    
            public static int GetArraySizeRequiredToDecode(int count)
    
    .. dn:method:: Microsoft.AspNetCore.WebUtilities.WebEncoders.GetArraySizeRequiredToEncode(System.Int32)
    
        
    
        
        Get the minimum output <code>char[]</code> size required for encoding <em>count</em>
        :any:`System.Byte`\s with the :dn:meth:`Microsoft.AspNetCore.WebUtilities.WebEncoders.Base64UrlEncode(System.Byte[],System.Int32,System.Char[],System.Int32,System.Int32)` method.
    
        
    
        
        :param count: The number of characters to encode.
        
        :type count: System.Int32
        :rtype: System.Int32
        :return: 
            The minimum output <code>char[]</code> size required for encoding <em>count</em> :any:`System.Byte`\s.
    
        
        .. code-block:: csharp
    
            public static int GetArraySizeRequiredToEncode(int count)
    

