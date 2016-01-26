

Microsoft.AspNet.Razor.Runtime.TagHelpers Namespace
===================================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNet/Razor/Runtime/TagHelpers/IMemberInfo/index
   
   
   
   /autoapi/Microsoft/AspNet/Razor/Runtime/TagHelpers/IPropertyInfo/index
   
   
   
   /autoapi/Microsoft/AspNet/Razor/Runtime/TagHelpers/ITypeInfo/index
   
   
   
   /autoapi/Microsoft/AspNet/Razor/Runtime/TagHelpers/RuntimePropertyInfo/index
   
   
   
   /autoapi/Microsoft/AspNet/Razor/Runtime/TagHelpers/RuntimeTypeInfo/index
   
   
   
   /autoapi/Microsoft/AspNet/Razor/Runtime/TagHelpers/TagHelperDescriptorFactory/index
   
   
   
   /autoapi/Microsoft/AspNet/Razor/Runtime/TagHelpers/TagHelperDescriptorResolver/index
   
   
   
   /autoapi/Microsoft/AspNet/Razor/Runtime/TagHelpers/TagHelperDesignTimeDescriptorFactory/index
   
   
   
   /autoapi/Microsoft/AspNet/Razor/Runtime/TagHelpers/TagHelperExecutionContext/index
   
   
   
   /autoapi/Microsoft/AspNet/Razor/Runtime/TagHelpers/TagHelperRunner/index
   
   
   
   /autoapi/Microsoft/AspNet/Razor/Runtime/TagHelpers/TagHelperScopeManager/index
   
   
   
   /autoapi/Microsoft/AspNet/Razor/Runtime/TagHelpers/TagHelperTypeResolver/index
   
   
   
   /autoapi/Microsoft/AspNet/Razor/Runtime/TagHelpers/XmlDocumentationProvider/index
   
   











.. dn:namespace:: Microsoft.AspNet.Razor.Runtime.TagHelpers


    .. rubric:: Classes


    class :dn:cls:`Microsoft.AspNet.Razor.Runtime.TagHelpers.RuntimePropertyInfo`
        :any:`Microsoft.AspNet.Razor.Runtime.TagHelpers.IPropertyInfo` adapter for :any:`System.Reflection.PropertyInfo` instances.


    class :dn:cls:`Microsoft.AspNet.Razor.Runtime.TagHelpers.RuntimeTypeInfo`
        :any:`Microsoft.AspNet.Razor.Runtime.TagHelpers.ITypeInfo` adapter for :any:`System.Reflection.TypeInfo` instances.


    class :dn:cls:`Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperDescriptorFactory`
        Factory for :any:`Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor`\s from :any:`Microsoft.AspNet.Razor.Runtime.TagHelpers.ITypeInfo`\s.


    class :dn:cls:`Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperDescriptorResolver`
        Used to resolve :any:`Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor`\s.


    class :dn:cls:`Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperDesignTimeDescriptorFactory`
        Factory for providing :any:`Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDesignTimeDescriptor`\s from :any:`System.Type`\s and 
        :any:`Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperAttributeDesignTimeDescriptor`\s from :any:`System.Reflection.PropertyInfo`\s.


    class :dn:cls:`Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperExecutionContext`
        Class used to store information about a :any:`Microsoft.AspNet.Razor.TagHelpers.ITagHelper`\'s execution lifetime.


    class :dn:cls:`Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperRunner`
        A class used to run :any:`Microsoft.AspNet.Razor.TagHelpers.ITagHelper`\s.


    class :dn:cls:`Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperScopeManager`
        Class that manages :any:`Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperExecutionContext` scopes.


    class :dn:cls:`Microsoft.AspNet.Razor.Runtime.TagHelpers.TagHelperTypeResolver`
        Class that locates valid :any:`Microsoft.AspNet.Razor.TagHelpers.ITagHelper`\s within an assembly.


    class :dn:cls:`Microsoft.AspNet.Razor.Runtime.TagHelpers.XmlDocumentationProvider`
        Extracts summary and remarks XML documentation from an XML documentation file.


    .. rubric:: Interfaces


    interface :dn:iface:`Microsoft.AspNet.Razor.Runtime.TagHelpers.IMemberInfo`
        Metadata common to types and properties.


    interface :dn:iface:`Microsoft.AspNet.Razor.Runtime.TagHelpers.IPropertyInfo`
        Contains property metadata.


    interface :dn:iface:`Microsoft.AspNet.Razor.Runtime.TagHelpers.ITypeInfo`
        Contains type metadata.


