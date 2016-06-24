

CompilationFailure Class
========================






Describes a failure compiling a specific file.


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
* :dn:cls:`Microsoft.AspNetCore.Diagnostics.CompilationFailure`








Syntax
------

.. code-block:: csharp

    public class CompilationFailure








.. dn:class:: Microsoft.AspNetCore.Diagnostics.CompilationFailure
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Diagnostics.CompilationFailure

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Diagnostics.CompilationFailure
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Diagnostics.CompilationFailure.CompilationFailure(System.String, System.String, System.String, System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Diagnostics.DiagnosticMessage>)
    
        
    
        
        :type sourceFilePath: System.String
    
        
        :type sourceFileContent: System.String
    
        
        :type compiledContent: System.String
    
        
        :type messages: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Diagnostics.DiagnosticMessage<Microsoft.AspNetCore.Diagnostics.DiagnosticMessage>}
    
        
        .. code-block:: csharp
    
            public CompilationFailure(string sourceFilePath, string sourceFileContent, string compiledContent, IEnumerable<DiagnosticMessage> messages)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Diagnostics.CompilationFailure
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.CompilationFailure.CompiledContent
    
        
    
        
        Contents being compiled.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string CompiledContent { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.CompilationFailure.Messages
    
        
    
        
        Gets a sequence of :any:`Microsoft.AspNetCore.Diagnostics.DiagnosticMessage` produced as a result of compilation.
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Diagnostics.DiagnosticMessage<Microsoft.AspNetCore.Diagnostics.DiagnosticMessage>}
    
        
        .. code-block:: csharp
    
            public IEnumerable<DiagnosticMessage> Messages { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.CompilationFailure.SourceFileContent
    
        
    
        
        Contents of the file.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string SourceFileContent { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.CompilationFailure.SourceFilePath
    
        
    
        
        Path of the file that produced the compilation failure.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string SourceFilePath { get; }
    

