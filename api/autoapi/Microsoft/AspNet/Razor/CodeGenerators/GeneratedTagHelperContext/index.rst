

GeneratedTagHelperContext Class
===============================



.. contents:: 
   :local:



Summary
-------

Contains necessary information for the tag helper code generation process.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.CodeGenerators.GeneratedTagHelperContext`








Syntax
------

.. code-block:: csharp

   public class GeneratedTagHelperContext





GitHub
------

`View on GitHub <https://github.com/aspnet/razor/blob/master/src/Microsoft.AspNet.Razor/CodeGenerators/GeneratedTagHelperContext.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.GeneratedTagHelperContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.GeneratedTagHelperContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Razor.CodeGenerators.GeneratedTagHelperContext.GeneratedTagHelperContext()
    
        
    
        Instantiates a new instance of the :any:`Microsoft.AspNet.Razor.CodeGenerators.GeneratedTagHelperContext` with default values.
    
        
    
        
        .. code-block:: csharp
    
           public GeneratedTagHelperContext()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.CodeGenerators.GeneratedTagHelperContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.CodeGenerators.GeneratedTagHelperContext.AddHtmlAttributeValueMethodName
    
        
    
        Method name used to add individual components of an unbound, complex tag helper attribute to
        TagHelperExecutionContexts.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string AddHtmlAttributeValueMethodName { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.CodeGenerators.GeneratedTagHelperContext.BeginAddHtmlAttributeValuesMethodName
    
        
    
        The name of the method used to begin the addition of unbound, complex tag helper attributes to
        TagHelperExecutionContexts.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string BeginAddHtmlAttributeValuesMethodName { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.CodeGenerators.GeneratedTagHelperContext.CreateTagHelperMethodName
    
        
    
        The name of the method used to create a tag helper.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string CreateTagHelperMethodName { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.CodeGenerators.GeneratedTagHelperContext.EndAddHtmlAttributeValuesMethodName
    
        
    
        Method name used to end addition of unbound, complex tag helper attributes to TagHelperExecutionContexts.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string EndAddHtmlAttributeValuesMethodName { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.CodeGenerators.GeneratedTagHelperContext.EndTagHelperWritingScopeMethodName
    
        
    
        The name of the method used to end a writing scope.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string EndTagHelperWritingScopeMethodName { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.CodeGenerators.GeneratedTagHelperContext.ExecutionContextAddHtmlAttributeMethodName
    
        
    
        The name of the :dn:prop:`Microsoft.AspNet.Razor.CodeGenerators.GeneratedTagHelperContext.ExecutionContextTypeName` method used to add HTML attributes.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ExecutionContextAddHtmlAttributeMethodName { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.CodeGenerators.GeneratedTagHelperContext.ExecutionContextAddMethodName
    
        
    
        The name of the :dn:prop:`Microsoft.AspNet.Razor.CodeGenerators.GeneratedTagHelperContext.ExecutionContextTypeName` method used to add tag helpers.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ExecutionContextAddMethodName { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.CodeGenerators.GeneratedTagHelperContext.ExecutionContextAddMinimizedHtmlAttributeMethodName
    
        
    
        The name of the :dn:prop:`Microsoft.AspNet.Razor.CodeGenerators.GeneratedTagHelperContext.ExecutionContextTypeName` method used to add minimized HTML attributes.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ExecutionContextAddMinimizedHtmlAttributeMethodName { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.CodeGenerators.GeneratedTagHelperContext.ExecutionContextAddTagHelperAttributeMethodName
    
        
    
        The name of the :dn:prop:`Microsoft.AspNet.Razor.CodeGenerators.GeneratedTagHelperContext.ExecutionContextTypeName` method used to add tag helper attributes.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ExecutionContextAddTagHelperAttributeMethodName { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.CodeGenerators.GeneratedTagHelperContext.ExecutionContextOutputPropertyName
    
        
    
        The property accessor for the tag helper's output.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ExecutionContextOutputPropertyName { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.CodeGenerators.GeneratedTagHelperContext.ExecutionContextTypeName
    
        
    
        The name of the type describing a specific tag helper scope.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ExecutionContextTypeName { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.CodeGenerators.GeneratedTagHelperContext.FormatInvalidIndexerAssignmentMethodName
    
        
    
        The name of the method used to format an error message about using an indexer when the tag helper property
        is <c>null</c>.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string FormatInvalidIndexerAssignmentMethodName { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.CodeGenerators.GeneratedTagHelperContext.HtmlEncoderPropertyName
    
        
    
        The name of the property containing the <c>IHtmlEncoder</c>.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string HtmlEncoderPropertyName { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.CodeGenerators.GeneratedTagHelperContext.MarkAsHtmlEncodedMethodName
    
        
    
        The name of the method used to wrap a :any:`System.String` value and mark it as HTML-encoded.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string MarkAsHtmlEncodedMethodName { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.CodeGenerators.GeneratedTagHelperContext.RunnerRunAsyncMethodName
    
        
    
        The name of the :dn:prop:`Microsoft.AspNet.Razor.CodeGenerators.GeneratedTagHelperContext.RunnerTypeName` method used to run tag helpers.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string RunnerRunAsyncMethodName { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.CodeGenerators.GeneratedTagHelperContext.RunnerTypeName
    
        
    
        The name of the type used to run tag helpers.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string RunnerTypeName { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.CodeGenerators.GeneratedTagHelperContext.ScopeManagerBeginMethodName
    
        
    
        The name of the :dn:prop:`Microsoft.AspNet.Razor.CodeGenerators.GeneratedTagHelperContext.ExecutionContextTypeName` method used to start a scope.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ScopeManagerBeginMethodName { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.CodeGenerators.GeneratedTagHelperContext.ScopeManagerEndMethodName
    
        
    
        The name of the :dn:prop:`Microsoft.AspNet.Razor.CodeGenerators.GeneratedTagHelperContext.ExecutionContextTypeName` method used to end a scope.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ScopeManagerEndMethodName { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.CodeGenerators.GeneratedTagHelperContext.ScopeManagerTypeName
    
        
    
        The name of the type used to create scoped :dn:prop:`Microsoft.AspNet.Razor.CodeGenerators.GeneratedTagHelperContext.ExecutionContextTypeName` instances.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ScopeManagerTypeName { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.CodeGenerators.GeneratedTagHelperContext.StartTagHelperWritingScopeMethodName
    
        
    
        The name of the method used to start a new writing scope.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string StartTagHelperWritingScopeMethodName { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.CodeGenerators.GeneratedTagHelperContext.TagHelperContentGetContentMethodName
    
        
    
        The name of the method used to convert a <c>TagHelperContent</c> into a :any:`System.String`\.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string TagHelperContentGetContentMethodName { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.CodeGenerators.GeneratedTagHelperContext.TagHelperContentTypeName
    
        
    
        The name of the type containing tag helper content.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string TagHelperContentTypeName { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.CodeGenerators.GeneratedTagHelperContext.WriteTagHelperAsyncMethodName
    
        
    
        The name of the method used to write :dn:prop:`Microsoft.AspNet.Razor.CodeGenerators.GeneratedTagHelperContext.ExecutionContextTypeName`\.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string WriteTagHelperAsyncMethodName { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Razor.CodeGenerators.GeneratedTagHelperContext.WriteTagHelperToAsyncMethodName
    
        
    
        The name of the method used to write :dn:prop:`Microsoft.AspNet.Razor.CodeGenerators.GeneratedTagHelperContext.ExecutionContextTypeName` to a specified 
        :any:`System.IO.TextWriter`\.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string WriteTagHelperToAsyncMethodName { get; set; }
    

