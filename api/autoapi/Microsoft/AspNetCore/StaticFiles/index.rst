

Microsoft.AspNetCore.StaticFiles Namespace
==========================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNetCore/StaticFiles/DefaultFilesMiddleware/index
   
   
   
   /autoapi/Microsoft/AspNetCore/StaticFiles/DirectoryBrowserMiddleware/index
   
   
   
   /autoapi/Microsoft/AspNetCore/StaticFiles/FileExtensionContentTypeProvider/index
   
   
   
   /autoapi/Microsoft/AspNetCore/StaticFiles/HtmlDirectoryFormatter/index
   
   
   
   /autoapi/Microsoft/AspNetCore/StaticFiles/IContentTypeProvider/index
   
   
   
   /autoapi/Microsoft/AspNetCore/StaticFiles/IDirectoryFormatter/index
   
   
   
   /autoapi/Microsoft/AspNetCore/StaticFiles/StaticFileMiddleware/index
   
   
   
   /autoapi/Microsoft/AspNetCore/StaticFiles/StaticFileResponseContext/index
   
   






.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   








.. dn:namespace:: Microsoft.AspNetCore.StaticFiles


    .. rubric:: Classes


    class :dn:cls:`DefaultFilesMiddleware`
        .. object: type=class name=Microsoft.AspNetCore.StaticFiles.DefaultFilesMiddleware

        
        This examines a directory path and determines if there is a default file present.
        If so the file name is appended to the path and execution continues.
        Note we don't just serve the file because it may require interpretation.


    class :dn:cls:`DirectoryBrowserMiddleware`
        .. object: type=class name=Microsoft.AspNetCore.StaticFiles.DirectoryBrowserMiddleware

        
        Enables directory browsing


    class :dn:cls:`FileExtensionContentTypeProvider`
        .. object: type=class name=Microsoft.AspNetCore.StaticFiles.FileExtensionContentTypeProvider

        
        Provides a mapping between file extensions and MIME types.


    class :dn:cls:`HtmlDirectoryFormatter`
        .. object: type=class name=Microsoft.AspNetCore.StaticFiles.HtmlDirectoryFormatter

        
        Generates an HTML view for a directory.


    class :dn:cls:`StaticFileMiddleware`
        .. object: type=class name=Microsoft.AspNetCore.StaticFiles.StaticFileMiddleware

        
        Enables serving static files for a given request path


    class :dn:cls:`StaticFileResponseContext`
        .. object: type=class name=Microsoft.AspNetCore.StaticFiles.StaticFileResponseContext

        
        Contains information about the request and the file that will be served in response.


    .. rubric:: Interfaces


    interface :dn:iface:`IContentTypeProvider`
        .. object: type=interface name=Microsoft.AspNetCore.StaticFiles.IContentTypeProvider

        
        Used to look up MIME types given a file path


    interface :dn:iface:`IDirectoryFormatter`
        .. object: type=interface name=Microsoft.AspNetCore.StaticFiles.IDirectoryFormatter

        
        Generates the view for a directory


