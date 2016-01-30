

ParserHelpers Class
===================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.Parser.ParserHelpers`








Syntax
------

.. code-block:: csharp

   public class ParserHelpers





GitHub
------

`View on GitHub <https://github.com/aspnet/razor/blob/master/src/Microsoft.AspNet.Razor/Parser/ParserHelpers.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.Parser.ParserHelpers

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.Parser.ParserHelpers
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.ParserHelpers.IsCombining(System.Char)
    
        
        
        
        :type value: System.Char
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public static bool IsCombining(char value)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.ParserHelpers.IsConnecting(System.Char)
    
        
        
        
        :type value: System.Char
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public static bool IsConnecting(char value)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.ParserHelpers.IsDecimalDigit(System.Char)
    
        
        
        
        :type value: System.Char
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public static bool IsDecimalDigit(char value)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.ParserHelpers.IsEmailPart(System.Char)
    
        
        
        
        :type character: System.Char
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public static bool IsEmailPart(char character)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.ParserHelpers.IsFormatting(System.Char)
    
        
        
        
        :type value: System.Char
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public static bool IsFormatting(char value)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.ParserHelpers.IsHexDigit(System.Char)
    
        
        
        
        :type value: System.Char
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public static bool IsHexDigit(char value)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.ParserHelpers.IsIdentifier(System.String)
    
        
        
        
        :type value: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public static bool IsIdentifier(string value)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.ParserHelpers.IsIdentifier(System.String, System.Boolean)
    
        
        
        
        :type value: System.String
        
        
        :type requireIdentifierStart: System.Boolean
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public static bool IsIdentifier(string value, bool requireIdentifierStart)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.ParserHelpers.IsIdentifierPart(System.Char)
    
        
        
        
        :type value: System.Char
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public static bool IsIdentifierPart(char value)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.ParserHelpers.IsIdentifierStart(System.Char)
    
        
        
        
        :type value: System.Char
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public static bool IsIdentifierStart(char value)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.ParserHelpers.IsLetter(System.Char)
    
        
        
        
        :type value: System.Char
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public static bool IsLetter(char value)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.ParserHelpers.IsLetterOrDecimalDigit(System.Char)
    
        
        
        
        :type value: System.Char
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public static bool IsLetterOrDecimalDigit(char value)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.ParserHelpers.IsNewLine(System.Char)
    
        
        
        
        :type value: System.Char
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public static bool IsNewLine(char value)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.ParserHelpers.IsNewLine(System.String)
    
        
        
        
        :type value: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public static bool IsNewLine(string value)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.ParserHelpers.IsTerminatingCharToken(System.Char)
    
        
        
        
        :type value: System.Char
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public static bool IsTerminatingCharToken(char value)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.ParserHelpers.IsTerminatingQuotedStringToken(System.Char)
    
        
        
        
        :type value: System.Char
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public static bool IsTerminatingQuotedStringToken(char value)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.ParserHelpers.IsWhitespace(System.Char)
    
        
        
        
        :type value: System.Char
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public static bool IsWhitespace(char value)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.ParserHelpers.IsWhitespaceOrNewLine(System.Char)
    
        
        
        
        :type value: System.Char
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public static bool IsWhitespaceOrNewLine(char value)
    
    .. dn:method:: Microsoft.AspNet.Razor.Parser.ParserHelpers.SanitizeClassName(System.String)
    
        
        
        
        :type inputName: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public static string SanitizeClassName(string inputName)
    

