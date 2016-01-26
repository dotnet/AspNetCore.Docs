

Microsoft.AspNet.Razor.Compilation.TagHelpers Namespace
=======================================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNet/Razor/Compilation/TagHelpers/ITagHelperDescriptorResolver/index
   
   
   
   /autoapi/Microsoft/AspNet/Razor/Compilation/TagHelpers/TagHelperAttributeDescriptor/index
   
   
   
   /autoapi/Microsoft/AspNet/Razor/Compilation/TagHelpers/TagHelperAttributeDesignTimeDescriptor/index
   
   
   
   /autoapi/Microsoft/AspNet/Razor/Compilation/TagHelpers/TagHelperDescriptor/index
   
   
   
   /autoapi/Microsoft/AspNet/Razor/Compilation/TagHelpers/TagHelperDescriptorComparer/index
   
   
   
   /autoapi/Microsoft/AspNet/Razor/Compilation/TagHelpers/TagHelperDescriptorProvider/index
   
   
   
   /autoapi/Microsoft/AspNet/Razor/Compilation/TagHelpers/TagHelperDescriptorResolutionContext/index
   
   
   
   /autoapi/Microsoft/AspNet/Razor/Compilation/TagHelpers/TagHelperDesignTimeDescriptor/index
   
   
   
   /autoapi/Microsoft/AspNet/Razor/Compilation/TagHelpers/TagHelperDirectiveDescriptor/index
   
   
   
   /autoapi/Microsoft/AspNet/Razor/Compilation/TagHelpers/TagHelperDirectiveType/index
   
   
   
   /autoapi/Microsoft/AspNet/Razor/Compilation/TagHelpers/TypeBasedTagHelperDescriptorComparer/index
   
   











.. dn:namespace:: Microsoft.AspNet.Razor.Compilation.TagHelpers


    .. rubric:: Classes


    class :dn:cls:`Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperAttributeDescriptor`
        A metadata class describing a tag helper attribute.


    class :dn:cls:`Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperAttributeDesignTimeDescriptor`
        A metadata class containing information about tag helper use.


    class :dn:cls:`Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor`
        A metadata class describing a tag helper.


    class :dn:cls:`Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptorComparer`
        An :any:`System.Collections.Generic.IEqualityComparer\`1` used to check equality between
        two :any:`Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor`\s.


    class :dn:cls:`Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptorProvider`
        Enables retrieval of :any:`Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor`\'s.


    class :dn:cls:`Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptorResolutionContext`
        Contains information needed to resolve :any:`Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor`\s.


    class :dn:cls:`Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDesignTimeDescriptor`
        A metadata class containing design time information about a tag helper.


    class :dn:cls:`Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDirectiveDescriptor`
        Contains information needed to resolve :any:`Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor`\s.


    class :dn:cls:`Microsoft.AspNet.Razor.Compilation.TagHelpers.TypeBasedTagHelperDescriptorComparer`
        An :any:`System.Collections.Generic.IEqualityComparer\`1` that checks equality between two 
        :any:`Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor`\s using only their :dn:prop:`Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor.AssemblyName`\s and 
        :dn:prop:`Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor.TypeName`\s.


    .. rubric:: Interfaces


    interface :dn:iface:`Microsoft.AspNet.Razor.Compilation.TagHelpers.ITagHelperDescriptorResolver`
        Contract used to resolve :any:`Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDescriptor`\s.


    .. rubric:: Enumerations


    enum :dn:enum:`Microsoft.AspNet.Razor.Compilation.TagHelpers.TagHelperDirectiveType`
        The type of tag helper directive.


