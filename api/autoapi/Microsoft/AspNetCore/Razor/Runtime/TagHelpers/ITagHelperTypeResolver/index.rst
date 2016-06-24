

ITagHelperTypeResolver Interface
================================






Locates valid :any:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper`\s within an assembly.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Razor.Runtime.TagHelpers`
Assemblies
    * Microsoft.AspNetCore.Razor.Runtime

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface ITagHelperTypeResolver








.. dn:interface:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.ITagHelperTypeResolver
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.ITagHelperTypeResolver

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.ITagHelperTypeResolver
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.ITagHelperTypeResolver.Resolve(System.String, Microsoft.AspNetCore.Razor.SourceLocation, Microsoft.AspNetCore.Razor.ErrorSink)
    
        
    
        
        Locates valid :any:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper` types from the :any:`System.Reflection.Assembly` named <em>name</em>.
    
        
    
        
        :param name: The name of an :any:`System.Reflection.Assembly` to search.
        
        :type name: System.String
    
        
        :param documentLocation: The :any:`Microsoft.AspNetCore.Razor.SourceLocation` of the associated 
            :any:`Microsoft.AspNetCore.Razor.Parser.SyntaxTree.SyntaxTreeNode` responsible for the current :dn:meth:`Microsoft.AspNetCore.Razor.Runtime.TagHelpers.ITagHelperTypeResolver.Resolve(System.String,Microsoft.AspNetCore.Razor.SourceLocation,Microsoft.AspNetCore.Razor.ErrorSink)` call.
        
        :type documentLocation: Microsoft.AspNetCore.Razor.SourceLocation
    
        
        :param errorSink: The :any:`Microsoft.AspNetCore.Razor.ErrorSink` used to record errors found when resolving 
            :any:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper` types.
        
        :type errorSink: Microsoft.AspNetCore.Razor.ErrorSink
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.Type<System.Type>}
        :return: An :any:`System.Collections.Generic.IEnumerable\`1` of valid :any:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper` types.
    
        
        .. code-block:: csharp
    
            IEnumerable<Type> Resolve(string name, SourceLocation documentLocation, ErrorSink errorSink)
    

