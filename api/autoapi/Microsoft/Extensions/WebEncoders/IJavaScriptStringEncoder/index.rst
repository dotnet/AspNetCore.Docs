

IJavaScriptStringEncoder Interface
==================================



.. contents:: 
   :local:



Summary
-------

Provides services for JavaScript-escaping strings.











Syntax
------

.. code-block:: csharp

   public interface IJavaScriptStringEncoder





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/httpabstractions/src/Microsoft.Extensions.WebEncoders.Core/IJavaScriptStringEncoder.cs>`_





.. dn:interface:: Microsoft.Extensions.WebEncoders.IJavaScriptStringEncoder

Methods
-------

.. dn:interface:: Microsoft.Extensions.WebEncoders.IJavaScriptStringEncoder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.WebEncoders.IJavaScriptStringEncoder.JavaScriptStringEncode(System.Char[], System.Int32, System.Int32, System.IO.TextWriter)
    
        
    
        JavaScript-escapes a character array and writes the result to the
        supplied output.
    
        
        
        
        :type value: System.Char[]
        
        
        :type startIndex: System.Int32
        
        
        :type charCount: System.Int32
        
        
        :type output: System.IO.TextWriter
    
        
        .. code-block:: csharp
    
           void JavaScriptStringEncode(char[] value, int startIndex, int charCount, TextWriter output)
    
    .. dn:method:: Microsoft.Extensions.WebEncoders.IJavaScriptStringEncoder.JavaScriptStringEncode(System.String)
    
        
    
        JavaScript-escapes a given input string.
    
        
        
        
        :type value: System.String
        :rtype: System.String
        :return: The JavaScript-escaped value, or null if the input string was null.
            The encoded value is appropriately encoded for inclusion inside a quoted JSON string.
    
        
        .. code-block:: csharp
    
           string JavaScriptStringEncode(string value)
    
    .. dn:method:: Microsoft.Extensions.WebEncoders.IJavaScriptStringEncoder.JavaScriptStringEncode(System.String, System.Int32, System.Int32, System.IO.TextWriter)
    
        
    
        JavaScript-escapes a given input string and writes the
        result to the supplied output.
    
        
        
        
        :type value: System.String
        
        
        :type startIndex: System.Int32
        
        
        :type charCount: System.Int32
        
        
        :type output: System.IO.TextWriter
    
        
        .. code-block:: csharp
    
           void JavaScriptStringEncode(string value, int startIndex, int charCount, TextWriter output)
    

