

CSharpLineMappingWriter Class
=============================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.CodeGenerators.CSharpLineMappingWriter`








Syntax
------

.. code-block:: csharp

   public class CSharpLineMappingWriter : IDisposable





GitHub
------

`View on GitHub <https://github.com/aspnet/razor/blob/master/src/Microsoft.AspNet.Razor/CodeGenerators/CSharpLineMappingWriter.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.CSharpLineMappingWriter

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.CSharpLineMappingWriter
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.CodeGenerators.CSharpLineMappingWriter.CSharpLineMappingWriter(Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter, Microsoft.AspNet.Razor.SourceLocation, System.Int32)
    
        
        
        
        :type writer: Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter
        
        
        :type documentLocation: Microsoft.AspNet.Razor.SourceLocation
        
        
        :type contentLength: System.Int32
    
        
        .. code-block:: csharp
    
           public CSharpLineMappingWriter(CSharpCodeWriter writer, SourceLocation documentLocation, int contentLength)
    
    .. dn:constructor:: Microsoft.AspNet.Razor.CodeGenerators.CSharpLineMappingWriter.CSharpLineMappingWriter(Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter, Microsoft.AspNet.Razor.SourceLocation, System.Int32, System.String)
    
        
        
        
        :type writer: Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter
        
        
        :type documentLocation: Microsoft.AspNet.Razor.SourceLocation
        
        
        :type contentLength: System.Int32
        
        
        :type sourceFilename: System.String
    
        
        .. code-block:: csharp
    
           public CSharpLineMappingWriter(CSharpCodeWriter writer, SourceLocation documentLocation, int contentLength, string sourceFilename)
    
    .. dn:constructor:: Microsoft.AspNet.Razor.CodeGenerators.CSharpLineMappingWriter.CSharpLineMappingWriter(Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter, Microsoft.AspNet.Razor.SourceLocation, System.String)
    
        
    
        Initializes a new instance of :any:`Microsoft.AspNet.Razor.CodeGenerators.CSharpLineMappingWriter` used for generation of runtime
        line mappings. The constructed instance of :any:`Microsoft.AspNet.Razor.CodeGenerators.CSharpLineMappingWriter` does not track
        mappings between the Razor content and the generated content.
    
        
        
        
        :param writer: The  to write output to.
        
        :type writer: Microsoft.AspNet.Razor.CodeGenerators.CSharpCodeWriter
        
        
        :param documentLocation: The  of the Razor content being mapping.
        
        :type documentLocation: Microsoft.AspNet.Razor.SourceLocation
        
        
        :param sourceFileName: The input file path.
        
        :type sourceFileName: System.String
    
        
        .. code-block:: csharp
    
           public CSharpLineMappingWriter(CSharpCodeWriter writer, SourceLocation documentLocation, string sourceFileName)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.CSharpLineMappingWriter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.CSharpLineMappingWriter.Dispose()
    
        
    
        
        .. code-block:: csharp
    
           public void Dispose()
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.CSharpLineMappingWriter.MarkLineMappingEnd()
    
        
    
        
        .. code-block:: csharp
    
           public void MarkLineMappingEnd()
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.CSharpLineMappingWriter.MarkLineMappingStart()
    
        
    
        
        .. code-block:: csharp
    
           public void MarkLineMappingStart()
    

