

EncoderExtensions Class
=======================



.. contents:: 
   :local:



Summary
-------

Helpful extension methods for the encoder classes.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.WebEncoders.EncoderExtensions`








Syntax
------

.. code-block:: csharp

   public class EncoderExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/httpabstractions/src/Microsoft.Extensions.WebEncoders.Core/EncoderExtensions.cs>`_





.. dn:class:: Microsoft.Extensions.WebEncoders.EncoderExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.WebEncoders.EncoderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.WebEncoders.EncoderExtensions.HtmlEncode(Microsoft.Extensions.WebEncoders.IHtmlEncoder, System.String, System.IO.TextWriter)
    
        
    
        HTML-encodes a string and writes the result to the supplied output.
    
        
        
        
        :type htmlEncoder: Microsoft.Extensions.WebEncoders.IHtmlEncoder
        
        
        :type value: System.String
        
        
        :type output: System.IO.TextWriter
    
        
        .. code-block:: csharp
    
           public static void HtmlEncode(IHtmlEncoder htmlEncoder, string value, TextWriter output)
    
    .. dn:method:: Microsoft.Extensions.WebEncoders.EncoderExtensions.JavaScriptStringEncode(Microsoft.Extensions.WebEncoders.IJavaScriptStringEncoder, System.String, System.IO.TextWriter)
    
        
    
        JavaScript-escapes a string and writes the result to the supplied output.
    
        
        
        
        :type javaScriptStringEncoder: Microsoft.Extensions.WebEncoders.IJavaScriptStringEncoder
        
        
        :type value: System.String
        
        
        :type output: System.IO.TextWriter
    
        
        .. code-block:: csharp
    
           public static void JavaScriptStringEncode(IJavaScriptStringEncoder javaScriptStringEncoder, string value, TextWriter output)
    
    .. dn:method:: Microsoft.Extensions.WebEncoders.EncoderExtensions.UrlEncode(Microsoft.Extensions.WebEncoders.IUrlEncoder, System.String, System.IO.TextWriter)
    
        
    
        URL-encodes a string and writes the result to the supplied output.
    
        
        
        
        :type urlEncoder: Microsoft.Extensions.WebEncoders.IUrlEncoder
        
        
        :type value: System.String
        
        
        :type output: System.IO.TextWriter
    
        
        .. code-block:: csharp
    
           public static void UrlEncode(IUrlEncoder urlEncoder, string value, TextWriter output)
    

