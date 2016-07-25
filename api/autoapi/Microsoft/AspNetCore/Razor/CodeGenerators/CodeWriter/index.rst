

CodeWriter Class
================





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








Syntax
------

.. code-block:: csharp

    public class CodeWriter : IDisposable








.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.CodeWriter
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.CodeWriter

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.CodeWriter
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.CodeWriter.Builder
    
        
        :rtype: System.Text.StringBuilder
    
        
        .. code-block:: csharp
    
            public StringBuilder Builder { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.CodeWriter.CurrentIndent
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int CurrentIndent { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.CodeWriter.IsAfterNewLine
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsAfterNewLine { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.CodeWriter.NewLine
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string NewLine { get; set; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.CodeWriter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CodeWriter.DecreaseIndent(System.Int32)
    
        
    
        
        :type size: System.Int32
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.CodeWriter
    
        
        .. code-block:: csharp
    
            public CodeWriter DecreaseIndent(int size)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CodeWriter.Dispose()
    
        
    
        
        .. code-block:: csharp
    
            public void Dispose()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CodeWriter.Dispose(System.Boolean)
    
        
    
        
        :type disposing: System.Boolean
    
        
        .. code-block:: csharp
    
            protected virtual void Dispose(bool disposing)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CodeWriter.GenerateCode()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string GenerateCode()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CodeWriter.GetCurrentSourceLocation()
    
        
        :rtype: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        .. code-block:: csharp
    
            public SourceLocation GetCurrentSourceLocation()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CodeWriter.IncreaseIndent(System.Int32)
    
        
    
        
        :type size: System.Int32
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.CodeWriter
    
        
        .. code-block:: csharp
    
            public CodeWriter IncreaseIndent(int size)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CodeWriter.Indent(System.Int32)
    
        
    
        
        :type size: System.Int32
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.CodeWriter
    
        
        .. code-block:: csharp
    
            public CodeWriter Indent(int size)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CodeWriter.ResetIndent()
    
        
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.CodeWriter
    
        
        .. code-block:: csharp
    
            public CodeWriter ResetIndent()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CodeWriter.SetIndent(System.Int32)
    
        
    
        
        :type size: System.Int32
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.CodeWriter
    
        
        .. code-block:: csharp
    
            public CodeWriter SetIndent(int size)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CodeWriter.Write(System.String)
    
        
    
        
        :type data: System.String
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.CodeWriter
    
        
        .. code-block:: csharp
    
            public CodeWriter Write(string data)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CodeWriter.Write(System.String, System.Int32, System.Int32)
    
        
    
        
        :type data: System.String
    
        
        :type index: System.Int32
    
        
        :type count: System.Int32
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.CodeWriter
    
        
        .. code-block:: csharp
    
            public CodeWriter Write(string data, int index, int count)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CodeWriter.WriteLine()
    
        
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.CodeWriter
    
        
        .. code-block:: csharp
    
            public CodeWriter WriteLine()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.CodeGenerators.CodeWriter.WriteLine(System.String)
    
        
    
        
        :type data: System.String
        :rtype: Microsoft.AspNetCore.Razor.CodeGenerators.CodeWriter
    
        
        .. code-block:: csharp
    
            public CodeWriter WriteLine(string data)
    

