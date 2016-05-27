

CSharpLineMappingWriter Class
=============================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Razor.CodeGenerators`
Assemblies
    * Microsoft.AspNetCore.Razor

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Razor.CodeGenerators.CSharpLineMappingWriter`








Syntax
------

.. code-block:: csharp

    public class CSharpLineMappingWriter : IDisposable








.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpLineMappingWriter
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpLineMappingWriter

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpLineMappingWriter
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpLineMappingWriter.CSharpLineMappingWriter(Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter, Microsoft.AspNetCore.Razor.SourceLocation, System.Int32)
    
        
    
        
        :type writer: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter
    
        
        :type documentLocation: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        :type contentLength: System.Int32
    
        
        .. code-block:: csharp
    
            public CSharpLineMappingWriter(CSharpCodeWriter writer, SourceLocation documentLocation, int contentLength)
    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpLineMappingWriter.CSharpLineMappingWriter(Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter, Microsoft.AspNetCore.Razor.SourceLocation, System.Int32, System.String)
    
        
    
        
        :type writer: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter
    
        
        :type documentLocation: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        :type contentLength: System.Int32
    
        
        :type sourceFilename: System.String
    
        
        .. code-block:: csharp
    
            public CSharpLineMappingWriter(CSharpCodeWriter writer, SourceLocation documentLocation, int contentLength, string sourceFilename)
    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpLineMappingWriter.CSharpLineMappingWriter(Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter, Microsoft.AspNetCore.Razor.SourceLocation, System.String)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Razor.CodeGenerators.CSharpLineMappingWriter` used for generation of runtime
        line mappings. The constructed instance of :any:`Microsoft.AspNetCore.Razor.CodeGenerators.CSharpLineMappingWriter` does not track
        mappings between the Razor content and the generated content.
    
        
    
        
        :param writer: The :any:`Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter` to write output to.
        
        :type writer: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter
    
        
        :param documentLocation: The :any:`Microsoft.AspNetCore.Razor.SourceLocation` of the Razor content being mapping.
        
        :type documentLocation: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        :param sourceFileName: The input file path.
        
        :type sourceFileName: System.String
    
        
        .. code-block:: csharp
    
            public CSharpLineMappingWriter(CSharpCodeWriter writer, SourceLocation documentLocation, string sourceFileName)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpLineMappingWriter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpLineMappingWriter.Dispose()
    
        
    
        
        .. code-block:: csharp
    
            public void Dispose()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpLineMappingWriter.MarkLineMappingEnd()
    
        
    
        
        .. code-block:: csharp
    
            public void MarkLineMappingEnd()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpLineMappingWriter.MarkLineMappingStart()
    
        
    
        
        .. code-block:: csharp
    
            public void MarkLineMappingStart()
    

