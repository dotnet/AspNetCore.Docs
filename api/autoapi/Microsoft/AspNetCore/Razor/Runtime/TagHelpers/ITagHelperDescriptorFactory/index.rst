

ITagHelperDescriptorFactory Interface
=====================================






Factory for :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor` instances.


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

    public interface ITagHelperDescriptorFactory








.. dn:interface:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.ITagHelperDescriptorFactory
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.ITagHelperDescriptorFactory

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.ITagHelperDescriptorFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers.ITagHelperDescriptorFactory.CreateDescriptors(System.String, System.Type, Microsoft.AspNetCore.Razor.ErrorSink)
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor` from the given <em>type</em>.
    
        
    
        
        :param assemblyName: The assembly name that contains <em>type</em>.
        
        :type assemblyName: System.String
    
        
        :param type: The :any:`System.Type` to create a :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor` from.
            
        
        :type type: System.Type
    
        
        :param errorSink: The :any:`Microsoft.AspNetCore.Razor.ErrorSink` used to collect :any:`Microsoft.AspNetCore.Razor.RazorError`\s encountered
            when creating :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor`\s for the given <em>type</em>.
        
        :type errorSink: Microsoft.AspNetCore.Razor.ErrorSink
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor<Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor>}
        :return: 
            A collection of :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor`\s that describe the given <em>type</em>.
    
        
        .. code-block:: csharp
    
            IEnumerable<TagHelperDescriptor> CreateDescriptors(string assemblyName, Type type, ErrorSink errorSink)
    

