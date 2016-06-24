

DiagnosticMessage Class
=======================






A single diagnostic message.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Diagnostics`
Assemblies
    * Microsoft.AspNetCore.Diagnostics.Abstractions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Diagnostics.DiagnosticMessage`








Syntax
------

.. code-block:: csharp

    public class DiagnosticMessage








.. dn:class:: Microsoft.AspNetCore.Diagnostics.DiagnosticMessage
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Diagnostics.DiagnosticMessage

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Diagnostics.DiagnosticMessage
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Diagnostics.DiagnosticMessage.DiagnosticMessage(System.String, System.String, System.String, System.Int32, System.Int32, System.Int32, System.Int32)
    
        
    
        
        :type message: System.String
    
        
        :type formattedMessage: System.String
    
        
        :type filePath: System.String
    
        
        :type startLine: System.Int32
    
        
        :type startColumn: System.Int32
    
        
        :type endLine: System.Int32
    
        
        :type endColumn: System.Int32
    
        
        .. code-block:: csharp
    
            public DiagnosticMessage(string message, string formattedMessage, string filePath, int startLine, int startColumn, int endLine, int endColumn)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Diagnostics.DiagnosticMessage
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.DiagnosticMessage.EndColumn
    
        
    
        
        Gets the zero-based column index for the end of the compilation error.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int EndColumn { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.DiagnosticMessage.EndLine
    
        
    
        
        Gets the one-based line index for the end of the compilation error.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int EndLine { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.DiagnosticMessage.FormattedMessage
    
        
    
        
        Gets the formatted error message.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string FormattedMessage { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.DiagnosticMessage.Message
    
        
    
        
        Gets the error message.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Message { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.DiagnosticMessage.SourceFilePath
    
        
    
        
        Path of the file that produced the message.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string SourceFilePath { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.DiagnosticMessage.StartColumn
    
        
    
        
        Gets the zero-based column index for the start of the compilation error.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int StartColumn { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.DiagnosticMessage.StartLine
    
        
    
        
        Gets the one-based line index for the start of the compilation error.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int StartLine { get; }
    

