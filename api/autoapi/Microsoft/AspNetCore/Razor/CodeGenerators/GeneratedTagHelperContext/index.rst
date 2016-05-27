

GeneratedTagHelperContext Class
===============================






Contains necessary information for the tag helper code generation process.


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
* :dn:cls:`Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedTagHelperContext`








Syntax
------

.. code-block:: csharp

    public class GeneratedTagHelperContext








.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedTagHelperContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedTagHelperContext

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedTagHelperContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedTagHelperContext.AddHtmlAttributeValueMethodName
    
        
    
        
        Method name used to add individual components of an unbound, complex tag helper attribute to
        TagHelperExecutionContexts.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string AddHtmlAttributeValueMethodName
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedTagHelperContext.BeginAddHtmlAttributeValuesMethodName
    
        
    
        
        The name of the method used to begin the addition of unbound, complex tag helper attributes to
        TagHelperExecutionContexts.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string BeginAddHtmlAttributeValuesMethodName
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedTagHelperContext.CreateTagHelperMethodName
    
        
    
        
        The name of the method used to create a tag helper.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string CreateTagHelperMethodName
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedTagHelperContext.EncodedHtmlStringTypeName
    
        
    
        
        The name of the type used to represent encoded content.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string EncodedHtmlStringTypeName
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedTagHelperContext.EndAddHtmlAttributeValuesMethodName
    
        
    
        
        Method name used to end addition of unbound, complex tag helper attributes to TagHelperExecutionContexts.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string EndAddHtmlAttributeValuesMethodName
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedTagHelperContext.EndTagHelperWritingScopeMethodName
    
        
    
        
        The name of the method used to end a writing scope.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string EndTagHelperWritingScopeMethodName
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedTagHelperContext.ExecutionContextAddHtmlAttributeMethodName
    
        
    
        
        The name of the :dn:prop:`Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedTagHelperContext.ExecutionContextTypeName` method used to add HTML attributes.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ExecutionContextAddHtmlAttributeMethodName
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedTagHelperContext.ExecutionContextAddMethodName
    
        
    
        
        The name of the :dn:prop:`Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedTagHelperContext.ExecutionContextTypeName` method used to add tag helpers.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ExecutionContextAddMethodName
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedTagHelperContext.ExecutionContextAddMinimizedHtmlAttributeMethodName
    
        
    
        
        The name of the :dn:prop:`Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedTagHelperContext.ExecutionContextTypeName` method used to add minimized HTML attributes.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ExecutionContextAddMinimizedHtmlAttributeMethodName
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedTagHelperContext.ExecutionContextAddTagHelperAttributeMethodName
    
        
    
        
        The name of the :dn:prop:`Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedTagHelperContext.ExecutionContextTypeName` method used to add tag helper attributes.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ExecutionContextAddTagHelperAttributeMethodName
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedTagHelperContext.ExecutionContextOutputPropertyName
    
        
    
        
        The property name for the tag helper's output.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ExecutionContextOutputPropertyName
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedTagHelperContext.ExecutionContextSetOutputContentAsyncMethodName
    
        
    
        
        The name of the method on the property :dn:prop:`Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedTagHelperContext.ExecutionContextOutputPropertyName` used to execute
        child content and set the rendered results on its :dn:prop:`Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedTagHelperContext.ExecutionContextOutputPropertyName` property.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ExecutionContextSetOutputContentAsyncMethodName
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedTagHelperContext.ExecutionContextTypeName
    
        
    
        
        The name of the type describing a specific tag helper scope.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ExecutionContextTypeName
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedTagHelperContext.FormatInvalidIndexerAssignmentMethodName
    
        
    
        
        The name of the method used to format an error message about using an indexer when the tag helper property
        is <code>null</code>.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string FormatInvalidIndexerAssignmentMethodName
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedTagHelperContext.HtmlEncoderPropertyName
    
        
    
        
        The name of the property containing the <code>HtmlEncoder</code>.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string HtmlEncoderPropertyName
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedTagHelperContext.MarkAsHtmlEncodedMethodName
    
        
    
        
        The name of the method used to wrap a :any:`System.String` value and mark it as HTML-encoded.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string MarkAsHtmlEncodedMethodName
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedTagHelperContext.RunnerRunAsyncMethodName
    
        
    
        
        The name of the :dn:prop:`Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedTagHelperContext.RunnerTypeName` method used to run tag helpers.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string RunnerRunAsyncMethodName
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedTagHelperContext.RunnerTypeName
    
        
    
        
        The name of the type used to run tag helpers.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string RunnerTypeName
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedTagHelperContext.ScopeManagerBeginMethodName
    
        
    
        
        The name of the :dn:prop:`Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedTagHelperContext.ExecutionContextTypeName` method used to start a scope.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ScopeManagerBeginMethodName
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedTagHelperContext.ScopeManagerEndMethodName
    
        
    
        
        The name of the :dn:prop:`Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedTagHelperContext.ExecutionContextTypeName` method used to end a scope.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ScopeManagerEndMethodName
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedTagHelperContext.ScopeManagerTypeName
    
        
    
        
        The name of the type used to create scoped :dn:prop:`Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedTagHelperContext.ExecutionContextTypeName` instances.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ScopeManagerTypeName
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedTagHelperContext.StartTagHelperWritingScopeMethodName
    
        
    
        
        The name of the method used to start a new writing scope.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string StartTagHelperWritingScopeMethodName
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedTagHelperContext.TagHelperAttributeTypeName
    
        
    
        
        The name of the type used to represent tag helper attributes.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string TagHelperAttributeTypeName
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedTagHelperContext.TagHelperContentGetContentMethodName
    
        
    
        
        The name of the method used to convert a <code>TagHelperContent</code> into a :any:`System.String`\.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string TagHelperContentGetContentMethodName
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedTagHelperContext.TagHelperContentTypeName
    
        
    
        
        The name of the type containing tag helper content.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string TagHelperContentTypeName
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedTagHelperContext.TagHelperOutputContentPropertyName
    
        
    
        
        The name of the property for the tag helper's output content.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string TagHelperOutputContentPropertyName
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedTagHelperContext.TagHelperOutputIsContentModifiedPropertyName
    
        
    
        
        The name of the property used to indicate the tag helper's content has been modified.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string TagHelperOutputIsContentModifiedPropertyName
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedTagHelperContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedTagHelperContext.GeneratedTagHelperContext()
    
        
    
        
        Instantiates a new instance of the :any:`Microsoft.AspNetCore.Razor.CodeGenerators.GeneratedTagHelperContext` with default values.
    
        
    
        
        .. code-block:: csharp
    
            public GeneratedTagHelperContext()
    

