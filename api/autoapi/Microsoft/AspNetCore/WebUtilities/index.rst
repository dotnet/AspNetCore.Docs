

Microsoft.AspNetCore.WebUtilities Namespace
===========================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNetCore/WebUtilities/FileBufferingReadStream/index
   
   
   
   /autoapi/Microsoft/AspNetCore/WebUtilities/FormReader/index
   
   
   
   /autoapi/Microsoft/AspNetCore/WebUtilities/HttpRequestStreamReader/index
   
   
   
   /autoapi/Microsoft/AspNetCore/WebUtilities/HttpResponseStreamWriter/index
   
   
   
   /autoapi/Microsoft/AspNetCore/WebUtilities/KeyValueAccumulator/index
   
   
   
   /autoapi/Microsoft/AspNetCore/WebUtilities/MultipartReader/index
   
   
   
   /autoapi/Microsoft/AspNetCore/WebUtilities/MultipartSection/index
   
   
   
   /autoapi/Microsoft/AspNetCore/WebUtilities/QueryHelpers/index
   
   
   
   /autoapi/Microsoft/AspNetCore/WebUtilities/ReasonPhrases/index
   
   
   
   /autoapi/Microsoft/AspNetCore/WebUtilities/StreamHelperExtensions/index
   
   
   
   /autoapi/Microsoft/AspNetCore/WebUtilities/WebEncoders/index
   
   






.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   








.. dn:namespace:: Microsoft.AspNetCore.WebUtilities


    .. rubric:: Classes


    class :dn:cls:`FileBufferingReadStream`
        .. object: type=class name=Microsoft.AspNetCore.WebUtilities.FileBufferingReadStream

        
        A Stream that wraps another stream and enables rewinding by buffering the content as it is read.
        The content is buffered in memory up to a certain size and then spooled to a temp file on disk.
        The temp file will be deleted on Dispose.


    class :dn:cls:`FormReader`
        .. object: type=class name=Microsoft.AspNetCore.WebUtilities.FormReader

        
        Used to read an 'application/x-www-form-urlencoded' form.


    class :dn:cls:`HttpRequestStreamReader`
        .. object: type=class name=Microsoft.AspNetCore.WebUtilities.HttpRequestStreamReader

        


    class :dn:cls:`HttpResponseStreamWriter`
        .. object: type=class name=Microsoft.AspNetCore.WebUtilities.HttpResponseStreamWriter

        
        Writes to the :any:`System.IO.Stream` using the supplied :dn:prop:`Microsoft.AspNetCore.WebUtilities.HttpResponseStreamWriter.Encoding`\.
        It does not write the BOM and also does not close the stream.


    class :dn:cls:`MultipartReader`
        .. object: type=class name=Microsoft.AspNetCore.WebUtilities.MultipartReader

        


    class :dn:cls:`MultipartSection`
        .. object: type=class name=Microsoft.AspNetCore.WebUtilities.MultipartSection

        


    class :dn:cls:`QueryHelpers`
        .. object: type=class name=Microsoft.AspNetCore.WebUtilities.QueryHelpers

        


    class :dn:cls:`ReasonPhrases`
        .. object: type=class name=Microsoft.AspNetCore.WebUtilities.ReasonPhrases

        


    class :dn:cls:`StreamHelperExtensions`
        .. object: type=class name=Microsoft.AspNetCore.WebUtilities.StreamHelperExtensions

        


    class :dn:cls:`WebEncoders`
        .. object: type=class name=Microsoft.AspNetCore.WebUtilities.WebEncoders

        
        Contains utility APIs to assist with common encoding and decoding operations.


    .. rubric:: Structures


    struct :dn:struct:`KeyValueAccumulator`
        .. object: type=struct name=Microsoft.AspNetCore.WebUtilities.KeyValueAccumulator

        


