

Microsoft.AspNetCore.Razor.Compilation.TagHelpers Namespace
===========================================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNetCore/Razor/Compilation/TagHelpers/ITagHelperDescriptorResolver/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Razor/Compilation/TagHelpers/TagHelperAttributeDescriptor/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Razor/Compilation/TagHelpers/TagHelperAttributeDesignTimeDescriptor/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Razor/Compilation/TagHelpers/TagHelperDescriptor/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Razor/Compilation/TagHelpers/TagHelperDescriptorComparer/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Razor/Compilation/TagHelpers/TagHelperDescriptorProvider/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Razor/Compilation/TagHelpers/TagHelperDescriptorResolutionContext/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Razor/Compilation/TagHelpers/TagHelperDesignTimeDescriptor/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Razor/Compilation/TagHelpers/TagHelperDirectiveDescriptor/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Razor/Compilation/TagHelpers/TagHelperDirectiveType/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Razor/Compilation/TagHelpers/TagHelperRequiredAttributeDescriptor/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Razor/Compilation/TagHelpers/TagHelperRequiredAttributeDescriptorComparer/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Razor/Compilation/TagHelpers/TagHelperRequiredAttributeNameComparison/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Razor/Compilation/TagHelpers/TagHelperRequiredAttributeValueComparison/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Razor/Compilation/TagHelpers/TypeBasedTagHelperDescriptorComparer/index
   
   






.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   








.. dn:namespace:: Microsoft.AspNetCore.Razor.Compilation.TagHelpers


    .. rubric:: Interfaces


    interface :dn:iface:`ITagHelperDescriptorResolver`
        .. object: type=interface name=Microsoft.AspNetCore.Razor.Compilation.TagHelpers.ITagHelperDescriptorResolver

        
        Contract used to resolve :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor`\s.


    .. rubric:: Classes


    class :dn:cls:`TagHelperAttributeDescriptor`
        .. object: type=class name=Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperAttributeDescriptor

        
        A metadata class describing a tag helper attribute.


    class :dn:cls:`TagHelperAttributeDesignTimeDescriptor`
        .. object: type=class name=Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperAttributeDesignTimeDescriptor

        
        A metadata class containing information about tag helper use.


    class :dn:cls:`TagHelperDescriptor`
        .. object: type=class name=Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor

        
        A metadata class describing a tag helper.


    class :dn:cls:`TagHelperDescriptorComparer`
        .. object: type=class name=Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptorComparer

        
        An :any:`System.Collections.Generic.IEqualityComparer\`1` used to check equality between
        two :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor`\s.


    class :dn:cls:`TagHelperDescriptorProvider`
        .. object: type=class name=Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptorProvider

        
        Enables retrieval of :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor`\'s.


    class :dn:cls:`TagHelperDescriptorResolutionContext`
        .. object: type=class name=Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptorResolutionContext

        
        Contains information needed to resolve :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor`\s.


    class :dn:cls:`TagHelperDesignTimeDescriptor`
        .. object: type=class name=Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDesignTimeDescriptor

        
        A metadata class containing design time information about a tag helper.


    class :dn:cls:`TagHelperDirectiveDescriptor`
        .. object: type=class name=Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDirectiveDescriptor

        
        Contains information needed to resolve :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor`\s.


    class :dn:cls:`TagHelperRequiredAttributeDescriptor`
        .. object: type=class name=Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperRequiredAttributeDescriptor

        
        A metadata class describing a required tag helper attribute.


    class :dn:cls:`TagHelperRequiredAttributeDescriptorComparer`
        .. object: type=class name=Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperRequiredAttributeDescriptorComparer

        
        An :any:`System.Collections.Generic.IEqualityComparer\`1` used to check equality between
        two :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperRequiredAttributeDescriptor`\s.


    class :dn:cls:`TypeBasedTagHelperDescriptorComparer`
        .. object: type=class name=Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TypeBasedTagHelperDescriptorComparer

        
        An :any:`System.Collections.Generic.IEqualityComparer\`1` that checks equality between two 
        :any:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor`\s using only their :dn:prop:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor.AssemblyName`\s and 
        :dn:prop:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDescriptor.TypeName`\s.


    .. rubric:: Enumerations


    enum :dn:enum:`TagHelperDirectiveType`
        .. object: type=enum name=Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperDirectiveType

        
        The type of tag helper directive.


    enum :dn:enum:`TagHelperRequiredAttributeNameComparison`
        .. object: type=enum name=Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperRequiredAttributeNameComparison

        
        Acceptable :dn:prop:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperRequiredAttributeDescriptor.Name` comparison modes.


    enum :dn:enum:`TagHelperRequiredAttributeValueComparison`
        .. object: type=enum name=Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperRequiredAttributeValueComparison

        
        Acceptable :dn:prop:`Microsoft.AspNetCore.Razor.Compilation.TagHelpers.TagHelperRequiredAttributeDescriptor.Value` comparison modes.


