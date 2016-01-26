

Microsoft.AspNet.Mvc.Formatters Namespace
=========================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNet/Mvc/Formatters/FormatFilter/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Formatters/FormatterCollection-TFormatter/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Formatters/FormatterMappings/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Formatters/HttpNoContentOutputFormatter/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Formatters/HttpNotAcceptableOutputFormatter/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Formatters/IFormatFilter/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Formatters/IInputFormatter/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Formatters/IOutputFormatter/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Formatters/InputFormatter/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Formatters/InputFormatterContext/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Formatters/InputFormatterResult/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Formatters/JsonInputFormatter/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Formatters/JsonOutputFormatter/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Formatters/JsonPatchInputFormatter/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Formatters/OutputFormatter/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Formatters/OutputFormatterCanWriteContext/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Formatters/OutputFormatterWriteContext/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Formatters/StreamOutputFormatter/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Formatters/StringOutputFormatter/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Formatters/XmlDataContractSerializerInputFormatter/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Formatters/XmlDataContractSerializerOutputFormatter/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Formatters/XmlSerializerInputFormatter/index
   
   
   
   /autoapi/Microsoft/AspNet/Mvc/Formatters/XmlSerializerOutputFormatter/index
   
   











.. dn:namespace:: Microsoft.AspNet.Mvc.Formatters


    .. rubric:: Classes


    class :dn:cls:`Microsoft.AspNet.Mvc.Formatters.FormatFilter`
        A filter which will use the format value in the route data or query string to set the content type on an 
        :any:`Microsoft.AspNet.Mvc.ObjectResult` returned from an action.


    class :dn:cls:`Microsoft.AspNet.Mvc.Formatters.FormatterCollection\<TFormatter>`
        Represents a collection of formatters.


    class :dn:cls:`Microsoft.AspNet.Mvc.Formatters.FormatterMappings`
        Used to specify mapping between the URL Format and corresponding :any:`Microsoft.Net.Http.Headers.MediaTypeHeaderValue`\.


    class :dn:cls:`Microsoft.AspNet.Mvc.Formatters.HttpNoContentOutputFormatter`
        Sets the status code to 204 if the content is null.


    class :dn:cls:`Microsoft.AspNet.Mvc.Formatters.HttpNotAcceptableOutputFormatter`
        A formatter which selects itself when content-negotiation has failed and writes a 406 Not Acceptable response.


    class :dn:cls:`Microsoft.AspNet.Mvc.Formatters.InputFormatter`
        Reads an object from the request body.


    class :dn:cls:`Microsoft.AspNet.Mvc.Formatters.InputFormatterContext`
        A context object used by an input formatter for deserializing the request body into an object.


    class :dn:cls:`Microsoft.AspNet.Mvc.Formatters.InputFormatterResult`
        Result of a :dn:meth:`Microsoft.AspNet.Mvc.Formatters.IInputFormatter.ReadAsync(Microsoft.AspNet.Mvc.Formatters.InputFormatterContext)` operation.


    class :dn:cls:`Microsoft.AspNet.Mvc.Formatters.JsonInputFormatter`
        


    class :dn:cls:`Microsoft.AspNet.Mvc.Formatters.JsonOutputFormatter`
        An output formatter that specializes in writing JSON content.


    class :dn:cls:`Microsoft.AspNet.Mvc.Formatters.JsonPatchInputFormatter`
        


    class :dn:cls:`Microsoft.AspNet.Mvc.Formatters.OutputFormatter`
        Writes an object to the output stream.


    class :dn:cls:`Microsoft.AspNet.Mvc.Formatters.OutputFormatterCanWriteContext`
        A context object for :dn:meth:`Microsoft.AspNet.Mvc.Formatters.IOutputFormatter.CanWriteResult(Microsoft.AspNet.Mvc.Formatters.OutputFormatterCanWriteContext)`\.


    class :dn:cls:`Microsoft.AspNet.Mvc.Formatters.OutputFormatterWriteContext`
        A context object for :dn:meth:`Microsoft.AspNet.Mvc.Formatters.IOutputFormatter.WriteAsync(Microsoft.AspNet.Mvc.Formatters.OutputFormatterWriteContext)`\.


    class :dn:cls:`Microsoft.AspNet.Mvc.Formatters.StreamOutputFormatter`
        Always copies the stream to the response, regardless of requested content type.


    class :dn:cls:`Microsoft.AspNet.Mvc.Formatters.StringOutputFormatter`
        Always writes a string value to the response, regardless of requested content type.


    class :dn:cls:`Microsoft.AspNet.Mvc.Formatters.XmlDataContractSerializerInputFormatter`
        This class handles deserialization of input XML data
        to strongly-typed objects using :any:`System.Runtime.Serialization.DataContractSerializer`\.


    class :dn:cls:`Microsoft.AspNet.Mvc.Formatters.XmlDataContractSerializerOutputFormatter`
        This class handles serialization of objects
        to XML using :any:`System.Runtime.Serialization.DataContractSerializer`


    class :dn:cls:`Microsoft.AspNet.Mvc.Formatters.XmlSerializerInputFormatter`
        This class handles deserialization of input XML data
        to strongly-typed objects using :any:`System.Xml.Serialization.XmlSerializer`


    class :dn:cls:`Microsoft.AspNet.Mvc.Formatters.XmlSerializerOutputFormatter`
        This class handles serialization of objects
        to XML using :any:`System.Xml.Serialization.XmlSerializer`


    .. rubric:: Interfaces


    interface :dn:iface:`Microsoft.AspNet.Mvc.Formatters.IFormatFilter`
        A filter which produces a desired content type for the current request.


    interface :dn:iface:`Microsoft.AspNet.Mvc.Formatters.IInputFormatter`
        Reads an object from the request body.


    interface :dn:iface:`Microsoft.AspNet.Mvc.Formatters.IOutputFormatter`
        Writes an object to the output stream.


