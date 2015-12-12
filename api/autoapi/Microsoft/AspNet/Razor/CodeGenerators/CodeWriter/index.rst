

CodeWriter Class
================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.CodeGenerators.CodeWriter`








Syntax
------

.. code-block:: csharp

   public class CodeWriter : IDisposable





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/razor/src/Microsoft.AspNet.Razor/CodeGenerators/CodeWriter.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.CodeWriter

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.CodeWriter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.CodeWriter.DecreaseIndent(System.Int32)
    
        
        
        
        :type size: System.Int32
        :rtype: Microsoft.AspNet.Razor.CodeGenerators.CodeWriter
    
        
        .. code-block:: csharp
    
           public CodeWriter DecreaseIndent(int size)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.CodeWriter.Dispose()
    
        
    
        
        .. code-block:: csharp
    
           public void Dispose()
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.CodeWriter.Dispose(System.Boolean)
    
        
        
        
        :type disposing: System.Boolean
    
        
        .. code-block:: csharp
    
           protected virtual void Dispose(bool disposing)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.CodeWriter.Flush()
    
        
        :rtype: Microsoft.AspNet.Razor.CodeGenerators.CodeWriter
    
        
        .. code-block:: csharp
    
           public CodeWriter Flush()
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.CodeWriter.GenerateCode()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string GenerateCode()
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.CodeWriter.GetCurrentSourceLocation()
    
        
        :rtype: Microsoft.AspNet.Razor.SourceLocation
    
        
        .. code-block:: csharp
    
           public SourceLocation GetCurrentSourceLocation()
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.CodeWriter.IncreaseIndent(System.Int32)
    
        
        
        
        :type size: System.Int32
        :rtype: Microsoft.AspNet.Razor.CodeGenerators.CodeWriter
    
        
        .. code-block:: csharp
    
           public CodeWriter IncreaseIndent(int size)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.CodeWriter.Indent(System.Int32)
    
        
        
        
        :type size: System.Int32
        :rtype: Microsoft.AspNet.Razor.CodeGenerators.CodeWriter
    
        
        .. code-block:: csharp
    
           public CodeWriter Indent(int size)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.CodeWriter.ResetIndent()
    
        
        :rtype: Microsoft.AspNet.Razor.CodeGenerators.CodeWriter
    
        
        .. code-block:: csharp
    
           public CodeWriter ResetIndent()
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.CodeWriter.SetIndent(System.Int32)
    
        
        
        
        :type size: System.Int32
        :rtype: Microsoft.AspNet.Razor.CodeGenerators.CodeWriter
    
        
        .. code-block:: csharp
    
           public CodeWriter SetIndent(int size)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.CodeWriter.Write(System.String)
    
        
        
        
        :type data: System.String
        :rtype: Microsoft.AspNet.Razor.CodeGenerators.CodeWriter
    
        
        .. code-block:: csharp
    
           public CodeWriter Write(string data)
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.CodeWriter.WriteLine()
    
        
        :rtype: Microsoft.AspNet.Razor.CodeGenerators.CodeWriter
    
        
        .. code-block:: csharp
    
           public CodeWriter WriteLine()
    
    .. dn:method:: Microsoft.AspNet.Razor.CodeGenerators.CodeWriter.WriteLine(System.String)
    
        
        
        
        :type data: System.String
        :rtype: Microsoft.AspNet.Razor.CodeGenerators.CodeWriter
    
        
        .. code-block:: csharp
    
           public CodeWriter WriteLine(string data)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.CodeWriter
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.CodeGenerators.CodeWriter.CurrentIndent
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int CurrentIndent { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.CodeGenerators.CodeWriter.LastWrite
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string LastWrite { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.CodeGenerators.CodeWriter.NewLine
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string NewLine { get; set; }
    

