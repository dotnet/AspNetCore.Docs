

IHtmlEncoder Interface
======================



.. contents:: 
   :local:



Summary
-------

Provides services for HTML-encoding input.











Syntax
------

.. code-block:: csharp

   public interface IHtmlEncoder





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/httpabstractions/src/Microsoft.Extensions.WebEncoders.Core/IHtmlEncoder.cs>`_





.. dn:interface:: Microsoft.Extensions.WebEncoders.IHtmlEncoder

Methods
-------

.. dn:interface:: Microsoft.Extensions.WebEncoders.IHtmlEncoder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.WebEncoders.IHtmlEncoder.HtmlEncode(System.Char[], System.Int32, System.Int32, System.IO.TextWriter)
    
        
    
        HTML-encodes a character array and writes the result to the supplied
        output.
    
        
        
        
        :type value: System.Char[]
        
        
        :type startIndex: System.Int32
        
        
        :type charCount: System.Int32
        
        
        :type output: System.IO.TextWriter
    
        
        .. code-block:: csharp
    
           void HtmlEncode(char[] value, int startIndex, int charCount, TextWriter output)
    
    .. dn:method:: Microsoft.Extensions.WebEncoders.IHtmlEncoder.HtmlEncode(System.String)
    
        
    
        HTML-encodes a given input string.
    
        
        
        
        :type value: System.String
        :rtype: System.String
        :return: The HTML-encoded value, or null if the input string was null.
    
        
        .. code-block:: csharp
    
           string HtmlEncode(string value)
    
    .. dn:method:: Microsoft.Extensions.WebEncoders.IHtmlEncoder.HtmlEncode(System.String, System.Int32, System.Int32, System.IO.TextWriter)
    
        
    
        HTML-encodes a given input string and writes the result to the
        supplied output.
    
        
        
        
        :type value: System.String
        
        
        :type startIndex: System.Int32
        
        
        :type charCount: System.Int32
        
        
        :type output: System.IO.TextWriter
    
        
        .. code-block:: csharp
    
           void HtmlEncode(string value, int startIndex, int charCount, TextWriter output)
    

