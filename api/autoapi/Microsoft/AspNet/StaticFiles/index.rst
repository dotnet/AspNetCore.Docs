

Microsoft.AspNet.StaticFiles Namespace
======================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNet/StaticFiles/DefaultFilesMiddleware/index
   
   
   
   /autoapi/Microsoft/AspNet/StaticFiles/DefaultFilesOptions/index
   
   
   
   /autoapi/Microsoft/AspNet/StaticFiles/DirectoryBrowserMiddleware/index
   
   
   
   /autoapi/Microsoft/AspNet/StaticFiles/DirectoryBrowserOptions/index
   
   
   
   /autoapi/Microsoft/AspNet/StaticFiles/FileExtensionContentTypeProvider/index
   
   
   
   /autoapi/Microsoft/AspNet/StaticFiles/FileServerOptions/index
   
   
   
   /autoapi/Microsoft/AspNet/StaticFiles/HtmlDirectoryFormatter/index
   
   
   
   /autoapi/Microsoft/AspNet/StaticFiles/IContentTypeProvider/index
   
   
   
   /autoapi/Microsoft/AspNet/StaticFiles/IDirectoryFormatter/index
   
   
   
   /autoapi/Microsoft/AspNet/StaticFiles/SendFileExtensions/index
   
   
   
   /autoapi/Microsoft/AspNet/StaticFiles/SendFileMiddleware/index
   
   
   
   /autoapi/Microsoft/AspNet/StaticFiles/StaticFileMiddleware/index
   
   
   
   /autoapi/Microsoft/AspNet/StaticFiles/StaticFileOptions/index
   
   
   
   /autoapi/Microsoft/AspNet/StaticFiles/StaticFileResponseContext/index
   
   











.. dn:namespace:: Microsoft.AspNet.StaticFiles


    .. rubric:: Classes


    class :dn:cls:`Microsoft.AspNet.StaticFiles.DefaultFilesMiddleware`
        This examines a directory path and determines if there is a default file present.
        If so the file name is appended to the path and execution continues.
        Note we don't just serve the file because it may require interpretation.


    class :dn:cls:`Microsoft.AspNet.StaticFiles.DefaultFilesOptions`
        Options for selecting default file names.


    class :dn:cls:`Microsoft.AspNet.StaticFiles.DirectoryBrowserMiddleware`
        Enables directory browsing


    class :dn:cls:`Microsoft.AspNet.StaticFiles.DirectoryBrowserOptions`
        Directory browsing options


    class :dn:cls:`Microsoft.AspNet.StaticFiles.FileExtensionContentTypeProvider`
        Provides a mapping between file extensions and MIME types.


    class :dn:cls:`Microsoft.AspNet.StaticFiles.FileServerOptions`
        Options for all of the static file middleware components


    class :dn:cls:`Microsoft.AspNet.StaticFiles.HtmlDirectoryFormatter`
        Generates an HTML view for a directory.


    class :dn:cls:`Microsoft.AspNet.StaticFiles.SendFileExtensions`
        Extension methods for the SendFileMiddleware


    class :dn:cls:`Microsoft.AspNet.StaticFiles.SendFileMiddleware`
        This middleware provides an efficient fallback mechanism for sending static files
        when the server does not natively support such a feature.
        The caller is responsible for setting all headers in advance.
        The caller is responsible for performing the correct impersonation to give access to the file.


    class :dn:cls:`Microsoft.AspNet.StaticFiles.StaticFileMiddleware`
        Enables serving static files for a given request path


    class :dn:cls:`Microsoft.AspNet.StaticFiles.StaticFileOptions`
        Options for serving static files


    class :dn:cls:`Microsoft.AspNet.StaticFiles.StaticFileResponseContext`
        Contains information about the request and the file that will be served in response.


    .. rubric:: Interfaces


    interface :dn:iface:`Microsoft.AspNet.StaticFiles.IContentTypeProvider`
        Used to look up MIME types given a file path


    interface :dn:iface:`Microsoft.AspNet.StaticFiles.IDirectoryFormatter`
        Generates the view for a directory


