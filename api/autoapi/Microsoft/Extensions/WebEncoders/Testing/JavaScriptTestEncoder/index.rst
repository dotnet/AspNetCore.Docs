

JavaScriptTestEncoder Class
===========================






Encoder used for unit testing.


Namespace
    :dn:ns:`Microsoft.Extensions.WebEncoders.Testing`
Assemblies
    * Microsoft.Extensions.WebEncoders

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Text.Encodings.Web.TextEncoder`
* :dn:cls:`System.Text.Encodings.Web.JavaScriptEncoder`
* :dn:cls:`Microsoft.Extensions.WebEncoders.Testing.JavaScriptTestEncoder`








Syntax
------

.. code-block:: csharp

    public class JavaScriptTestEncoder : JavaScriptEncoder








.. dn:class:: Microsoft.Extensions.WebEncoders.Testing.JavaScriptTestEncoder
    :hidden:

.. dn:class:: Microsoft.Extensions.WebEncoders.Testing.JavaScriptTestEncoder

Properties
----------

.. dn:class:: Microsoft.Extensions.WebEncoders.Testing.JavaScriptTestEncoder
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.WebEncoders.Testing.JavaScriptTestEncoder.MaxOutputCharactersPerInputCharacter
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int MaxOutputCharactersPerInputCharacter
            {
                get;
            }
    

Methods
-------

.. dn:class:: Microsoft.Extensions.WebEncoders.Testing.JavaScriptTestEncoder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.WebEncoders.Testing.JavaScriptTestEncoder.Encode(System.IO.TextWriter, System.Char[], System.Int32, System.Int32)
    
        
    
        
        :type output: System.IO.TextWriter
    
        
        :type value: System.Char<System.Char>[]
    
        
        :type startIndex: System.Int32
    
        
        :type characterCount: System.Int32
    
        
        .. code-block:: csharp
    
            public override void Encode(TextWriter output, char[] value, int startIndex, int characterCount)
    
    .. dn:method:: Microsoft.Extensions.WebEncoders.Testing.JavaScriptTestEncoder.Encode(System.IO.TextWriter, System.String, System.Int32, System.Int32)
    
        
    
        
        :type output: System.IO.TextWriter
    
        
        :type value: System.String
    
        
        :type startIndex: System.Int32
    
        
        :type characterCount: System.Int32
    
        
        .. code-block:: csharp
    
            public override void Encode(TextWriter output, string value, int startIndex, int characterCount)
    
    .. dn:method:: Microsoft.Extensions.WebEncoders.Testing.JavaScriptTestEncoder.Encode(System.String)
    
        
    
        
        :type value: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string Encode(string value)
    
    .. dn:method:: Microsoft.Extensions.WebEncoders.Testing.JavaScriptTestEncoder.FindFirstCharacterToEncode(System.Char*, System.Int32)
    
        
    
        
        :type text: System.Char<System.Char>*
    
        
        :type textLength: System.Int32
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int FindFirstCharacterToEncode(char *text, int textLength)
    
    .. dn:method:: Microsoft.Extensions.WebEncoders.Testing.JavaScriptTestEncoder.TryEncodeUnicodeScalar(System.Int32, System.Char*, System.Int32, out System.Int32)
    
        
    
        
        :type unicodeScalar: System.Int32
    
        
        :type buffer: System.Char<System.Char>*
    
        
        :type bufferLength: System.Int32
    
        
        :type numberOfCharactersWritten: System.Int32
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool TryEncodeUnicodeScalar(int unicodeScalar, char *buffer, int bufferLength, out int numberOfCharactersWritten)
    
    .. dn:method:: Microsoft.Extensions.WebEncoders.Testing.JavaScriptTestEncoder.WillEncode(System.Int32)
    
        
    
        
        :type unicodeScalar: System.Int32
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool WillEncode(int unicodeScalar)
    

