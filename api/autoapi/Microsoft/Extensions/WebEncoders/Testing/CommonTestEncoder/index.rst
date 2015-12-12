

CommonTestEncoder Class
=======================



.. contents:: 
   :local:



Summary
-------

Dummy encoder used for unit testing.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.WebEncoders.Testing.CommonTestEncoder`








Syntax
------

.. code-block:: csharp

   public sealed class CommonTestEncoder : IHtmlEncoder, IJavaScriptStringEncoder, IUrlEncoder





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/testing/src/Microsoft.Extensions.WebEncoders.Testing/CommonTestEncoder.cs>`_





.. dn:class:: Microsoft.Extensions.WebEncoders.Testing.CommonTestEncoder

Methods
-------

.. dn:class:: Microsoft.Extensions.WebEncoders.Testing.CommonTestEncoder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.WebEncoders.Testing.CommonTestEncoder.HtmlEncode(System.Char[], System.Int32, System.Int32, System.IO.TextWriter)
    
        
    
        Writes "HtmlEncode[[value]]".
    
        
        
        
        :type value: System.Char[]
        
        
        :type startIndex: System.Int32
        
        
        :type charCount: System.Int32
        
        
        :type output: System.IO.TextWriter
    
        
        .. code-block:: csharp
    
           public void HtmlEncode(char[] value, int startIndex, int charCount, TextWriter output)
    
    .. dn:method:: Microsoft.Extensions.WebEncoders.Testing.CommonTestEncoder.HtmlEncode(System.String)
    
        
    
        Returns "HtmlEncode[[value]]".
    
        
        
        
        :type value: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string HtmlEncode(string value)
    
    .. dn:method:: Microsoft.Extensions.WebEncoders.Testing.CommonTestEncoder.HtmlEncode(System.String, System.Int32, System.Int32, System.IO.TextWriter)
    
        
    
        Writes "HtmlEncode[[value]]".
    
        
        
        
        :type value: System.String
        
        
        :type startIndex: System.Int32
        
        
        :type charCount: System.Int32
        
        
        :type output: System.IO.TextWriter
    
        
        .. code-block:: csharp
    
           public void HtmlEncode(string value, int startIndex, int charCount, TextWriter output)
    
    .. dn:method:: Microsoft.Extensions.WebEncoders.Testing.CommonTestEncoder.JavaScriptStringEncode(System.Char[], System.Int32, System.Int32, System.IO.TextWriter)
    
        
    
        Writes "JavaScriptStringEncode[[value]]".
    
        
        
        
        :type value: System.Char[]
        
        
        :type startIndex: System.Int32
        
        
        :type charCount: System.Int32
        
        
        :type output: System.IO.TextWriter
    
        
        .. code-block:: csharp
    
           public void JavaScriptStringEncode(char[] value, int startIndex, int charCount, TextWriter output)
    
    .. dn:method:: Microsoft.Extensions.WebEncoders.Testing.CommonTestEncoder.JavaScriptStringEncode(System.String)
    
        
    
        Returns "JavaScriptStringEncode[[value]]".
    
        
        
        
        :type value: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string JavaScriptStringEncode(string value)
    
    .. dn:method:: Microsoft.Extensions.WebEncoders.Testing.CommonTestEncoder.JavaScriptStringEncode(System.String, System.Int32, System.Int32, System.IO.TextWriter)
    
        
    
        Writes "JavaScriptStringEncode[[value]]".
    
        
        
        
        :type value: System.String
        
        
        :type startIndex: System.Int32
        
        
        :type charCount: System.Int32
        
        
        :type output: System.IO.TextWriter
    
        
        .. code-block:: csharp
    
           public void JavaScriptStringEncode(string value, int startIndex, int charCount, TextWriter output)
    
    .. dn:method:: Microsoft.Extensions.WebEncoders.Testing.CommonTestEncoder.UrlEncode(System.Char[], System.Int32, System.Int32, System.IO.TextWriter)
    
        
    
        Writes "UrlEncode[[value]]".
    
        
        
        
        :type value: System.Char[]
        
        
        :type startIndex: System.Int32
        
        
        :type charCount: System.Int32
        
        
        :type output: System.IO.TextWriter
    
        
        .. code-block:: csharp
    
           public void UrlEncode(char[] value, int startIndex, int charCount, TextWriter output)
    
    .. dn:method:: Microsoft.Extensions.WebEncoders.Testing.CommonTestEncoder.UrlEncode(System.String)
    
        
    
        Returns "UrlEncode[[value]]".
    
        
        
        
        :type value: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string UrlEncode(string value)
    
    .. dn:method:: Microsoft.Extensions.WebEncoders.Testing.CommonTestEncoder.UrlEncode(System.String, System.Int32, System.Int32, System.IO.TextWriter)
    
        
    
        Writes "UrlEncode[[value]]".
    
        
        
        
        :type value: System.String
        
        
        :type startIndex: System.Int32
        
        
        :type charCount: System.Int32
        
        
        :type output: System.IO.TextWriter
    
        
        .. code-block:: csharp
    
           public void UrlEncode(string value, int startIndex, int charCount, TextWriter output)
    

