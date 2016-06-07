

Microsoft.AspNetCore.Razor.TagHelpers Namespace
===============================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNetCore/Razor/TagHelpers/DefaultTagHelperContent/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Razor/TagHelpers/HtmlAttributeNameAttribute/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Razor/TagHelpers/HtmlAttributeNotBoundAttribute/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Razor/TagHelpers/HtmlTargetElementAttribute/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Razor/TagHelpers/ITagHelper/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Razor/TagHelpers/NullHtmlEncoder/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Razor/TagHelpers/OutputElementHintAttribute/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Razor/TagHelpers/ReadOnlyTagHelperAttributeList/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Razor/TagHelpers/RestrictChildrenAttribute/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Razor/TagHelpers/TagHelper/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Razor/TagHelpers/TagHelperAttribute/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Razor/TagHelpers/TagHelperAttributeList/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Razor/TagHelpers/TagHelperContent/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Razor/TagHelpers/TagHelperContext/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Razor/TagHelpers/TagHelperOutput/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Razor/TagHelpers/TagMode/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Razor/TagHelpers/TagStructure/index
   
   






.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   








.. dn:namespace:: Microsoft.AspNetCore.Razor.TagHelpers


    .. rubric:: Classes


    class :dn:cls:`DefaultTagHelperContent`
        .. object: type=class name=Microsoft.AspNetCore.Razor.TagHelpers.DefaultTagHelperContent

        
        Default concrete :any:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContent`\.


    class :dn:cls:`HtmlAttributeNameAttribute`
        .. object: type=class name=Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeNameAttribute

        
        Used to override an :any:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper` property's HTML attribute name.


    class :dn:cls:`HtmlAttributeNotBoundAttribute`
        .. object: type=class name=Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeNotBoundAttribute

        
        Indicates the associated :any:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper` property should not be bound to HTML attributes.


    class :dn:cls:`HtmlTargetElementAttribute`
        .. object: type=class name=Microsoft.AspNetCore.Razor.TagHelpers.HtmlTargetElementAttribute

        
        Provides an :any:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper`\'s target.


    class :dn:cls:`NullHtmlEncoder`
        .. object: type=class name=Microsoft.AspNetCore.Razor.TagHelpers.NullHtmlEncoder

        
        A :any:`System.Text.Encodings.Web.HtmlEncoder` that does not encode. Should not be used when writing directly to a response
        expected to contain valid HTML.


    class :dn:cls:`OutputElementHintAttribute`
        .. object: type=class name=Microsoft.AspNetCore.Razor.TagHelpers.OutputElementHintAttribute

        
        Provides a hint of the :any:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper`\'s output element.


    class :dn:cls:`ReadOnlyTagHelperAttributeList`
        .. object: type=class name=Microsoft.AspNetCore.Razor.TagHelpers.ReadOnlyTagHelperAttributeList

        
        A read-only collection of :any:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute`\s.


    class :dn:cls:`RestrictChildrenAttribute`
        .. object: type=class name=Microsoft.AspNetCore.Razor.TagHelpers.RestrictChildrenAttribute

        
        Restricts children of the :any:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper`\'s element.


    class :dn:cls:`TagHelper`
        .. object: type=class name=Microsoft.AspNetCore.Razor.TagHelpers.TagHelper

        
        Class used to filter matching HTML elements.


    class :dn:cls:`TagHelperAttribute`
        .. object: type=class name=Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute

        
        An HTML tag helper attribute.


    class :dn:cls:`TagHelperAttributeList`
        .. object: type=class name=Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttributeList

        
        A collection of :any:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute`\s.


    class :dn:cls:`TagHelperContent`
        .. object: type=class name=Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContent

        
        Abstract class used to buffer content returned by :any:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper`\s.


    class :dn:cls:`TagHelperContext`
        .. object: type=class name=Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext

        
        Contains information related to the execution of :any:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper`\s.


    class :dn:cls:`TagHelperOutput`
        .. object: type=class name=Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput

        
        Class used to represent the output of an :any:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper`\.


    .. rubric:: Enumerations


    enum :dn:enum:`TagMode`
        .. object: type=enum name=Microsoft.AspNetCore.Razor.TagHelpers.TagMode

        
        The mode in which an element should render.


    enum :dn:enum:`TagStructure`
        .. object: type=enum name=Microsoft.AspNetCore.Razor.TagHelpers.TagStructure

        
        The structure the element should be written in.


    .. rubric:: Interfaces


    interface :dn:iface:`ITagHelper`
        .. object: type=interface name=Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper

        
        Contract used to filter matching HTML elements.


