

CSharpCodeWriter Class
======================





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
* :dn:cls:`Microsoft.AspNetCore.Razor.CodeGenerators.CodeWriter`
* :dn:cls:`Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter`








Syntax
------

.. code-block:: csharp

    public class CSharpCodeWriter : CodeWriter, IDisposable








.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter.CSharpCodeWriter()
    
        
    
        
        .. code-block:: csharp
    
            public CSharpCodeWriter()
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter.BuildAsyncLambda(System.Boolean, System.String[])
    
        
    
        
        :type endLine: System.Boolean
    
        
        :type parameterNames: System.String<System.String>[]
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWritingScope
    
        
        .. code-block:: csharp
    
            public CSharpCodeWritingScope BuildAsyncLambda(bool endLine, params string[] parameterNames)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter.BuildClassDeclaration(System.String, System.String)
    
        
    
        
        :type accessibility: System.String
    
        
        :type name: System.String
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWritingScope
    
        
        .. code-block:: csharp
    
            public CSharpCodeWritingScope BuildClassDeclaration(string accessibility, string name)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter.BuildClassDeclaration(System.String, System.String, System.Collections.Generic.IEnumerable<System.String>)
    
        
    
        
        :type accessibility: System.String
    
        
        :type name: System.String
    
        
        :type baseTypes: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.String<System.String>}
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWritingScope
    
        
        .. code-block:: csharp
    
            public CSharpCodeWritingScope BuildClassDeclaration(string accessibility, string name, IEnumerable<string> baseTypes)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter.BuildClassDeclaration(System.String, System.String, System.String)
    
        
    
        
        :type accessibility: System.String
    
        
        :type name: System.String
    
        
        :type baseType: System.String
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWritingScope
    
        
        .. code-block:: csharp
    
            public CSharpCodeWritingScope BuildClassDeclaration(string accessibility, string name, string baseType)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter.BuildConstructor(System.String)
    
        
    
        
        :type name: System.String
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWritingScope
    
        
        .. code-block:: csharp
    
            public CSharpCodeWritingScope BuildConstructor(string name)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter.BuildConstructor(System.String, System.String)
    
        
    
        
        :type accessibility: System.String
    
        
        :type name: System.String
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWritingScope
    
        
        .. code-block:: csharp
    
            public CSharpCodeWritingScope BuildConstructor(string accessibility, string name)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter.BuildConstructor(System.String, System.String, System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<System.String, System.String>>)
    
        
    
        
        :type accessibility: System.String
    
        
        :type name: System.String
    
        
        :type parameters: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair`2>{System.String<System.String>, System.String<System.String>}}
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWritingScope
    
        
        .. code-block:: csharp
    
            public CSharpCodeWritingScope BuildConstructor(string accessibility, string name, IEnumerable<KeyValuePair<string, string>> parameters)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter.BuildDisableWarningScope(System.Int32)
    
        
    
        
        :type warning: System.Int32
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpDisableWarningScope
    
        
        .. code-block:: csharp
    
            public CSharpDisableWarningScope BuildDisableWarningScope(int warning)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter.BuildLambda(System.Boolean, System.String[])
    
        
    
        
        :type endLine: System.Boolean
    
        
        :type parameterNames: System.String<System.String>[]
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWritingScope
    
        
        .. code-block:: csharp
    
            public CSharpCodeWritingScope BuildLambda(bool endLine, params string[] parameterNames)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter.BuildLineMapping(Microsoft.AspNetCore.Razor.SourceLocation, System.Int32, System.String)
    
        
    
        
        :type documentLocation: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        :type contentLength: System.Int32
    
        
        :type sourceFilename: System.String
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpLineMappingWriter
    
        
        .. code-block:: csharp
    
            public CSharpLineMappingWriter BuildLineMapping(SourceLocation documentLocation, int contentLength, string sourceFilename)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter.BuildMethodDeclaration(System.String, System.String, System.String)
    
        
    
        
        :type accessibility: System.String
    
        
        :type returnType: System.String
    
        
        :type name: System.String
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWritingScope
    
        
        .. code-block:: csharp
    
            public CSharpCodeWritingScope BuildMethodDeclaration(string accessibility, string returnType, string name)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter.BuildMethodDeclaration(System.String, System.String, System.String, System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<System.String, System.String>>)
    
        
    
        
        :type accessibility: System.String
    
        
        :type returnType: System.String
    
        
        :type name: System.String
    
        
        :type parameters: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair`2>{System.String<System.String>, System.String<System.String>}}
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWritingScope
    
        
        .. code-block:: csharp
    
            public CSharpCodeWritingScope BuildMethodDeclaration(string accessibility, string returnType, string name, IEnumerable<KeyValuePair<string, string>> parameters)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter.BuildNamespace(System.String)
    
        
    
        
        :type name: System.String
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWritingScope
    
        
        .. code-block:: csharp
    
            public CSharpCodeWritingScope BuildNamespace(string name)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter.BuildScope()
    
        
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWritingScope
    
        
        .. code-block:: csharp
    
            public CSharpCodeWritingScope BuildScope()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter.DecreaseIndent(System.Int32)
    
        
    
        
        :type size: System.Int32
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter
    
        
        .. code-block:: csharp
    
            public CSharpCodeWriter DecreaseIndent(int size)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter.IncreaseIndent(System.Int32)
    
        
    
        
        :type size: System.Int32
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter
    
        
        .. code-block:: csharp
    
            public CSharpCodeWriter IncreaseIndent(int size)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter.Indent(System.Int32)
    
        
    
        
        :type size: System.Int32
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter
    
        
        .. code-block:: csharp
    
            public CSharpCodeWriter Indent(int size)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter.ResetIndent()
    
        
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter
    
        
        .. code-block:: csharp
    
            public CSharpCodeWriter ResetIndent()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter.SetIndent(System.Int32)
    
        
    
        
        :type size: System.Int32
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter
    
        
        .. code-block:: csharp
    
            public CSharpCodeWriter SetIndent(int size)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter.Write(System.String)
    
        
    
        
        :type data: System.String
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter
    
        
        .. code-block:: csharp
    
            public CSharpCodeWriter Write(string data)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter.WriteBooleanLiteral(System.Boolean)
    
        
    
        
        :type value: System.Boolean
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter
    
        
        .. code-block:: csharp
    
            public CSharpCodeWriter WriteBooleanLiteral(bool value)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter.WriteComment(System.String)
    
        
    
        
        :type comment: System.String
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter
    
        
        .. code-block:: csharp
    
            public CSharpCodeWriter WriteComment(string comment)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter.WriteEndInstrumentationContext(Microsoft.AspNetCore.Razor.Chunks.Generators.ChunkGeneratorContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Razor.Chunks.Generators.ChunkGeneratorContext
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter
    
        
        .. code-block:: csharp
    
            public CSharpCodeWriter WriteEndInstrumentationContext(ChunkGeneratorContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter.WriteEndMethodInvocation()
    
        
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter
    
        
        .. code-block:: csharp
    
            public CSharpCodeWriter WriteEndMethodInvocation()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter.WriteEndMethodInvocation(System.Boolean)
    
        
    
        
        :type endLine: System.Boolean
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter
    
        
        .. code-block:: csharp
    
            public CSharpCodeWriter WriteEndMethodInvocation(bool endLine)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter.WriteInstanceMethodInvocation(System.String, System.String, System.Boolean, System.String[])
    
        
    
        
        :type instanceName: System.String
    
        
        :type methodName: System.String
    
        
        :type endLine: System.Boolean
    
        
        :type parameters: System.String<System.String>[]
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter
    
        
        .. code-block:: csharp
    
            public CSharpCodeWriter WriteInstanceMethodInvocation(string instanceName, string methodName, bool endLine, params string[] parameters)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter.WriteInstanceMethodInvocation(System.String, System.String, System.String[])
    
        
    
        
        :type instanceName: System.String
    
        
        :type methodName: System.String
    
        
        :type parameters: System.String<System.String>[]
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter
    
        
        .. code-block:: csharp
    
            public CSharpCodeWriter WriteInstanceMethodInvocation(string instanceName, string methodName, params string[] parameters)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter.WriteLine()
    
        
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter
    
        
        .. code-block:: csharp
    
            public CSharpCodeWriter WriteLine()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter.WriteLine(System.String)
    
        
    
        
        :type data: System.String
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter
    
        
        .. code-block:: csharp
    
            public CSharpCodeWriter WriteLine(string data)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter.WriteLineDefaultDirective()
    
        
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter
    
        
        .. code-block:: csharp
    
            public CSharpCodeWriter WriteLineDefaultDirective()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter.WriteLineHiddenDirective()
    
        
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter
    
        
        .. code-block:: csharp
    
            public CSharpCodeWriter WriteLineHiddenDirective()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter.WriteLineNumberDirective(Microsoft.AspNetCore.Razor.SourceLocation, System.String)
    
        
    
        
        Writes a <code>#line</code> pragma directive for the line number at the specified <em>location</em>.
    
        
    
        
        :param location: The location to generate the line pragma for.
        
        :type location: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        :param file: The file to generate the line pragma for.
        
        :type file: System.String
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter
        :return: The current instance of :any:`Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter`\.
    
        
        .. code-block:: csharp
    
            public CSharpCodeWriter WriteLineNumberDirective(SourceLocation location, string file)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter.WriteLocationTaggedString(Microsoft.AspNetCore.Razor.Text.LocationTagged<System.String>)
    
        
    
        
        :type value: Microsoft.AspNetCore.Razor.Text.LocationTagged<Microsoft.AspNetCore.Razor.Text.LocationTagged`1>{System.String<System.String>}
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter
    
        
        .. code-block:: csharp
    
            public CSharpCodeWriter WriteLocationTaggedString(LocationTagged<string> value)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter.WriteMethodInvocation(System.String, System.Boolean, System.String[])
    
        
    
        
        :type methodName: System.String
    
        
        :type endLine: System.Boolean
    
        
        :type parameters: System.String<System.String>[]
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter
    
        
        .. code-block:: csharp
    
            public CSharpCodeWriter WriteMethodInvocation(string methodName, bool endLine, params string[] parameters)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter.WriteMethodInvocation(System.String, System.String[])
    
        
    
        
        :type methodName: System.String
    
        
        :type parameters: System.String<System.String>[]
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter
    
        
        .. code-block:: csharp
    
            public CSharpCodeWriter WriteMethodInvocation(string methodName, params string[] parameters)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter.WriteParameterSeparator()
    
        
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter
    
        
        .. code-block:: csharp
    
            public CSharpCodeWriter WriteParameterSeparator()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter.WritePragma(System.String)
    
        
    
        
        :type value: System.String
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter
    
        
        .. code-block:: csharp
    
            public CSharpCodeWriter WritePragma(string value)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter.WriteReturn(System.String)
    
        
    
        
        :type value: System.String
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter
    
        
        .. code-block:: csharp
    
            public CSharpCodeWriter WriteReturn(string value)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter.WriteReturn(System.String, System.Boolean)
    
        
    
        
        :type value: System.String
    
        
        :type endLine: System.Boolean
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter
    
        
        .. code-block:: csharp
    
            public CSharpCodeWriter WriteReturn(string value, bool endLine)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter.WriteStartAssignment(System.String)
    
        
    
        
        :type name: System.String
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter
    
        
        .. code-block:: csharp
    
            public CSharpCodeWriter WriteStartAssignment(string name)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter.WriteStartInstanceMethodInvocation(System.String, System.String)
    
        
    
        
        :type instanceName: System.String
    
        
        :type methodName: System.String
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter
    
        
        .. code-block:: csharp
    
            public CSharpCodeWriter WriteStartInstanceMethodInvocation(string instanceName, string methodName)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter.WriteStartInstrumentationContext(Microsoft.AspNetCore.Razor.Chunks.Generators.ChunkGeneratorContext, Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SyntaxTreeNode, System.Boolean)
    
        
    
        
        :type context: Microsoft.AspNetCore.Razor.Chunks.Generators.ChunkGeneratorContext
    
        
        :type syntaxNode: Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SyntaxTreeNode
    
        
        :type isLiteral: System.Boolean
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter
    
        
        .. code-block:: csharp
    
            public CSharpCodeWriter WriteStartInstrumentationContext(ChunkGeneratorContext context, SyntaxTreeNode syntaxNode, bool isLiteral)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter.WriteStartInstrumentationContext(Microsoft.AspNetCore.Razor.Chunks.Generators.ChunkGeneratorContext, System.Int32, System.Int32, System.Boolean)
    
        
    
        
        :type context: Microsoft.AspNetCore.Razor.Chunks.Generators.ChunkGeneratorContext
    
        
        :type absoluteIndex: System.Int32
    
        
        :type length: System.Int32
    
        
        :type isLiteral: System.Boolean
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter
    
        
        .. code-block:: csharp
    
            public CSharpCodeWriter WriteStartInstrumentationContext(ChunkGeneratorContext context, int absoluteIndex, int length, bool isLiteral)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter.WriteStartMethodInvocation(System.String)
    
        
    
        
        :type methodName: System.String
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter
    
        
        .. code-block:: csharp
    
            public CSharpCodeWriter WriteStartMethodInvocation(string methodName)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter.WriteStartMethodInvocation(System.String, System.String[])
    
        
    
        
        :type methodName: System.String
    
        
        :type genericArguments: System.String<System.String>[]
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter
    
        
        .. code-block:: csharp
    
            public CSharpCodeWriter WriteStartMethodInvocation(string methodName, params string[] genericArguments)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter.WriteStartNewObject(System.String)
    
        
    
        
        :type typeName: System.String
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter
    
        
        .. code-block:: csharp
    
            public CSharpCodeWriter WriteStartNewObject(string typeName)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter.WriteStartReturn()
    
        
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter
    
        
        .. code-block:: csharp
    
            public CSharpCodeWriter WriteStartReturn()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter.WriteStringLiteral(System.String)
    
        
    
        
        :type literal: System.String
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter
    
        
        .. code-block:: csharp
    
            public CSharpCodeWriter WriteStringLiteral(string literal)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter.WriteUsing(System.String)
    
        
    
        
        :type name: System.String
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter
    
        
        .. code-block:: csharp
    
            public CSharpCodeWriter WriteUsing(string name)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter.WriteUsing(System.String, System.Boolean)
    
        
    
        
        :type name: System.String
    
        
        :type endLine: System.Boolean
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter
    
        
        .. code-block:: csharp
    
            public CSharpCodeWriter WriteUsing(string name, bool endLine)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter.WriteVariableDeclaration(System.String, System.String, System.String)
    
        
    
        
        :type type: System.String
    
        
        :type name: System.String
    
        
        :type value: System.String
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter
    
        
        .. code-block:: csharp
    
            public CSharpCodeWriter WriteVariableDeclaration(string type, string name, string value)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.CSharpCodeWriter.LineMappingManager
    
        
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.LineMappingManager
    
        
        .. code-block:: csharp
    
            public LineMappingManager LineMappingManager { get; }
    

