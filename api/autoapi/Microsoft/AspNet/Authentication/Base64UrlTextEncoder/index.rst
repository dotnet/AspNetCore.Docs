

Base64UrlTextEncoder Class
==========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authentication.Base64UrlTextEncoder`








Syntax
------

.. code-block:: csharp

   public class Base64UrlTextEncoder





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/security/src/Microsoft.AspNet.Authentication/DataHandler/TextEncoder.cs>`_





.. dn:class:: Microsoft.AspNet.Authentication.Base64UrlTextEncoder

Methods
-------

.. dn:class:: Microsoft.AspNet.Authentication.Base64UrlTextEncoder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Authentication.Base64UrlTextEncoder.Decode(System.String)
    
        
        
        
        :type text: System.String
        :rtype: System.Byte[]
    
        
        .. code-block:: csharp
    
           public static byte[] Decode(string text)
    
    .. dn:method:: Microsoft.AspNet.Authentication.Base64UrlTextEncoder.Encode(System.Byte[])
    
        
        
        
        :type data: System.Byte[]
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public static string Encode(byte[] data)
    

