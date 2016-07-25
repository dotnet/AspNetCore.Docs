

Microsoft.AspNetCore.Razor.Runtime.TagHelpers Namespace
=======================================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNetCore/Razor/Runtime/TagHelpers/ITagHelperDescriptorFactory/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Razor/Runtime/TagHelpers/ITagHelperTypeResolver/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Razor/Runtime/TagHelpers/TagHelperConventions/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Razor/Runtime/TagHelpers/TagHelperDescriptorFactory/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Razor/Runtime/TagHelpers/TagHelperDescriptorResolver/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Razor/Runtime/TagHelpers/TagHelperDesignTimeDescriptorFactory/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Razor/Runtime/TagHelpers/TagHelperExecutionContext/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Razor/Runtime/TagHelpers/TagHelperRunner/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Razor/Runtime/TagHelpers/TagHelperScopeManager/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Razor/Runtime/TagHelpers/TagHelperTypeResolver/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Razor/Runtime/TagHelpers/XmlDocumentationProvider/index
   
   






.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   








.. dn:namespace:: Microsoft.AspNetCore.Razor.Runtime.TagHelpers


    .. rubric:: Interfaces


    interface :dn:iface:`ITagHelperDescriptorFactory`
        .. object: type=interface name=Microsoft.AspNetCore.Razor.Runtime.TagHelpers.ITagHelperDescriptorFactory

        
        Factory for :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor` instances.


    interface :dn:iface:`ITagHelperTypeResolver`
        .. object: type=interface name=Microsoft.AspNetCore.Razor.Runtime.TagHelpers.ITagHelperTypeResolver

        
        Locates valid :any:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper`\s within an assembly.


    .. rubric:: Classes


    class :dn:cls:`TagHelperConventions`
        .. object: type=class name=Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperConventions

        
        Default convention for determining if a type is a tag helper.


    class :dn:cls:`TagHelperDescriptorFactory`
        .. object: type=class name=Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperDescriptorFactory

        
        Factory for :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor`\s from :any:`System.Type`\s.


    class :dn:cls:`TagHelperDescriptorResolver`
        .. object: type=class name=Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperDescriptorResolver

        
        Used to resolve :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor`\s.


    class :dn:cls:`TagHelperDesignTimeDescriptorFactory`
        .. object: type=class name=Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperDesignTimeDescriptorFactory

        
        Factory for providing :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDesignTimeDescriptor`\s from :any:`System.Type`\s and 
        :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperAttributeDesignTimeDescriptor`\s from :any:`System.Reflection.PropertyInfo`\s.


    class :dn:cls:`TagHelperExecutionContext`
        .. object: type=class name=Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext

        
        Class used to store information about a :any:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper`\'s execution lifetime.


    class :dn:cls:`TagHelperRunner`
        .. object: type=class name=Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner

        
        A class used to run :any:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper`\s.


    class :dn:cls:`TagHelperScopeManager`
        .. object: type=class name=Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager

        
        Class that manages :any:`Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext` scopes.


    class :dn:cls:`TagHelperTypeResolver`
        .. object: type=class name=Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperTypeResolver

        
        Class that locates valid :any:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper`\s within an assembly.


    class :dn:cls:`XmlDocumentationProvider`
        .. object: type=class name=Microsoft.AspNetCore.Razor.Runtime.TagHelpers.XmlDocumentationProvider

        
        Extracts summary and remarks XML documentation from an XML documentation file.


