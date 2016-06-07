

Microsoft.AspNetCore.Mvc.Formatters Namespace
=============================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Formatters/FormatFilter/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Formatters/FormatterCollection-TFormatter/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Formatters/FormatterMappings/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Formatters/HttpNoContentOutputFormatter/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Formatters/HttpNotAcceptableOutputFormatter/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Formatters/IInputFormatter/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Formatters/IOutputFormatter/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Formatters/InputFormatter/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Formatters/InputFormatterContext/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Formatters/InputFormatterResult/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Formatters/JsonInputFormatter/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Formatters/JsonOutputFormatter/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Formatters/JsonPatchInputFormatter/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Formatters/MediaType/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Formatters/MediaTypeCollection/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Formatters/OutputFormatter/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Formatters/OutputFormatterCanWriteContext/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Formatters/OutputFormatterWriteContext/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Formatters/StreamOutputFormatter/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Formatters/StringOutputFormatter/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Formatters/TextInputFormatter/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Formatters/TextOutputFormatter/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Formatters/XmlDataContractSerializerInputFormatter/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Formatters/XmlDataContractSerializerOutputFormatter/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Formatters/XmlSerializerInputFormatter/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Mvc/Formatters/XmlSerializerOutputFormatter/index
   
   






.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   








.. dn:namespace:: Microsoft.AspNetCore.Mvc.Formatters


    .. rubric:: Classes


    class :dn:cls:`FormatFilter`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Formatters.FormatFilter

        
        A filter that will use the format value in the route data or query string to set the content type on an
        :any:`Microsoft.AspNetCore.Mvc.ObjectResult` returned from an action.


    class :dn:cls:`FormatterCollection\<TFormatter>`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Formatters.FormatterCollection\<TFormatter>

        
        Represents a collection of formatters.


    class :dn:cls:`FormatterMappings`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Formatters.FormatterMappings

        
        Used to specify mapping between the URL Format and corresponding media type.


    class :dn:cls:`HttpNoContentOutputFormatter`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Formatters.HttpNoContentOutputFormatter

        
        Sets the status code to 204 if the content is null.


    class :dn:cls:`HttpNotAcceptableOutputFormatter`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Formatters.HttpNotAcceptableOutputFormatter

        
        A formatter which selects itself when content-negotiation has failed and writes a 406 Not Acceptable response.


    class :dn:cls:`InputFormatter`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Formatters.InputFormatter

        
        Reads an object from the request body.


    class :dn:cls:`InputFormatterContext`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Formatters.InputFormatterContext

        
        A context object used by an input formatter for deserializing the request body into an object.


    class :dn:cls:`InputFormatterResult`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Formatters.InputFormatterResult

        
        Result of a :dn:meth:`Microsoft.AspNetCore.Mvc.Formatters.IInputFormatter.ReadAsync(Microsoft.AspNetCore.Mvc.Formatters.InputFormatterContext)` operation.


    class :dn:cls:`JsonInputFormatter`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Formatters.JsonInputFormatter

        
        An :any:`Microsoft.AspNetCore.Mvc.Formatters.TextInputFormatter` for JSON content.


    class :dn:cls:`JsonOutputFormatter`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Formatters.JsonOutputFormatter

        
        An output formatter that specializes in writing JSON content.


    class :dn:cls:`JsonPatchInputFormatter`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Formatters.JsonPatchInputFormatter

        


    class :dn:cls:`MediaTypeCollection`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Formatters.MediaTypeCollection

        
        A collection of media types.


    class :dn:cls:`OutputFormatter`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Formatters.OutputFormatter

        
        Writes an object to the output stream.


    class :dn:cls:`OutputFormatterCanWriteContext`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterCanWriteContext

        
        A context object for :dn:meth:`Microsoft.AspNetCore.Mvc.Formatters.IOutputFormatter.CanWriteResult(Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterCanWriteContext)`\.


    class :dn:cls:`OutputFormatterWriteContext`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterWriteContext

        
        A context object for :dn:meth:`Microsoft.AspNetCore.Mvc.Formatters.IOutputFormatter.WriteAsync(Microsoft.AspNetCore.Mvc.Formatters.OutputFormatterWriteContext)`\.


    class :dn:cls:`StreamOutputFormatter`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Formatters.StreamOutputFormatter

        
        Always copies the stream to the response, regardless of requested content type.


    class :dn:cls:`StringOutputFormatter`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Formatters.StringOutputFormatter

        
        Always writes a string value to the response, regardless of requested content type.


    class :dn:cls:`TextInputFormatter`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Formatters.TextInputFormatter

        
        Reads an object from a request body with a text format.


    class :dn:cls:`TextOutputFormatter`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Formatters.TextOutputFormatter

        
        Writes an object in a given text format to the output stream.


    class :dn:cls:`XmlDataContractSerializerInputFormatter`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Formatters.XmlDataContractSerializerInputFormatter

        
        This class handles deserialization of input XML data
        to strongly-typed objects using :any:`System.Runtime.Serialization.DataContractSerializer`\.


    class :dn:cls:`XmlDataContractSerializerOutputFormatter`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Formatters.XmlDataContractSerializerOutputFormatter

        
        This class handles serialization of objects
        to XML using :any:`System.Runtime.Serialization.DataContractSerializer`


    class :dn:cls:`XmlSerializerInputFormatter`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Formatters.XmlSerializerInputFormatter

        
        This class handles deserialization of input XML data
        to strongly-typed objects using :any:`System.Xml.Serialization.XmlSerializer`


    class :dn:cls:`XmlSerializerOutputFormatter`
        .. object: type=class name=Microsoft.AspNetCore.Mvc.Formatters.XmlSerializerOutputFormatter

        
        This class handles serialization of objects
        to XML using :any:`System.Xml.Serialization.XmlSerializer`


    .. rubric:: Structures


    struct :dn:struct:`MediaType`
        .. object: type=struct name=Microsoft.AspNetCore.Mvc.Formatters.MediaType

        
        A media type value.


    .. rubric:: Interfaces


    interface :dn:iface:`IInputFormatter`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.Formatters.IInputFormatter

        
        Reads an object from the request body.


    interface :dn:iface:`IOutputFormatter`
        .. object: type=interface name=Microsoft.AspNetCore.Mvc.Formatters.IOutputFormatter

        
        Writes an object to the output stream.


