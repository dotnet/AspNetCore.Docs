

IUrlEncoder Interface
=====================



.. contents:: 
   :local:



Summary
-------

Provides services for URL-escaping strings.











Syntax
------

.. code-block:: csharp

   public interface IUrlEncoder





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/httpabstractions/src/Microsoft.Extensions.WebEncoders.Core/IUrlEncoder.cs>`_





.. dn:interface:: Microsoft.Extensions.WebEncoders.IUrlEncoder

Methods
-------

.. dn:interface:: Microsoft.Extensions.WebEncoders.IUrlEncoder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.WebEncoders.IUrlEncoder.UrlEncode(System.Char[], System.Int32, System.Int32, System.IO.TextWriter)
    
        
    
        URL-escapes a character array and writes the result to the supplied
        output.
    
        
        
        
        :type value: System.Char[]
        
        
        :type startIndex: System.Int32
        
        
        :type charCount: System.Int32
        
        
        :type output: System.IO.TextWriter
    
        
        .. code-block:: csharp
    
           void UrlEncode(char[] value, int startIndex, int charCount, TextWriter output)
    
    .. dn:method:: Microsoft.Extensions.WebEncoders.IUrlEncoder.UrlEncode(System.String)
    
        
    
        URL-escapes a given input string.
    
        
        
        
        :type value: System.String
        :rtype: System.String
        :return: The URL-escaped value, or null if the input string was null.
    
        
        .. code-block:: csharp
    
           string UrlEncode(string value)
    
    .. dn:method:: Microsoft.Extensions.WebEncoders.IUrlEncoder.UrlEncode(System.String, System.Int32, System.Int32, System.IO.TextWriter)
    
        
    
        URL-escapes a string and writes the result to the supplied output.
    
        
        
        
        :type value: System.String
        
        
        :type startIndex: System.Int32
        
        
        :type charCount: System.Int32
        
        
        :type output: System.IO.TextWriter
    
        
        .. code-block:: csharp
    
           void UrlEncode(string value, int startIndex, int charCount, TextWriter output)
    

