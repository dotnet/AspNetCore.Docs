

Base64UrlTextEncoder Class
==========================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Authentication`
Assemblies
    * Microsoft.AspNetCore.Authentication

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Authentication.Base64UrlTextEncoder`








Syntax
------

.. code-block:: csharp

    public class Base64UrlTextEncoder








.. dn:class:: Microsoft.AspNetCore.Authentication.Base64UrlTextEncoder
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authentication.Base64UrlTextEncoder

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Authentication.Base64UrlTextEncoder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Authentication.Base64UrlTextEncoder.Decode(System.String)
    
        
    
        
        :type text: System.String
        :rtype: System.Byte<System.Byte>[]
    
        
        .. code-block:: csharp
    
            public static byte[] Decode(string text)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.Base64UrlTextEncoder.Encode(System.Byte[])
    
        
    
        
        :type data: System.Byte<System.Byte>[]
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static string Encode(byte[] data)
    

