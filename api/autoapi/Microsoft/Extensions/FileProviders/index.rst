

Microsoft.Extensions.FileProviders Namespace
============================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/Extensions/FileProviders/CompositeFileProvider/index
   
   
   
   /autoapi/Microsoft/Extensions/FileProviders/EmbeddedFileProvider/index
   
   
   
   /autoapi/Microsoft/Extensions/FileProviders/FileSystemInfoHelper/index
   
   
   
   /autoapi/Microsoft/Extensions/FileProviders/IDirectoryContents/index
   
   
   
   /autoapi/Microsoft/Extensions/FileProviders/IFileInfo/index
   
   
   
   /autoapi/Microsoft/Extensions/FileProviders/IFileProvider/index
   
   
   
   /autoapi/Microsoft/Extensions/FileProviders/NotFoundDirectoryContents/index
   
   
   
   /autoapi/Microsoft/Extensions/FileProviders/NotFoundFileInfo/index
   
   
   
   /autoapi/Microsoft/Extensions/FileProviders/NullChangeToken/index
   
   
   
   /autoapi/Microsoft/Extensions/FileProviders/NullFileProvider/index
   
   
   
   /autoapi/Microsoft/Extensions/FileProviders/PhysicalFileProvider/index
   
   






.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   








.. dn:namespace:: Microsoft.Extensions.FileProviders


    .. rubric:: Interfaces


    interface :dn:iface:`IDirectoryContents`
        .. object: type=interface name=Microsoft.Extensions.FileProviders.IDirectoryContents

        
        Represents a directory's content in the file provider.


    interface :dn:iface:`IFileInfo`
        .. object: type=interface name=Microsoft.Extensions.FileProviders.IFileInfo

        
        Represents a file in the given file provider.


    interface :dn:iface:`IFileProvider`
        .. object: type=interface name=Microsoft.Extensions.FileProviders.IFileProvider

        
        A read-only file provider abstraction.


    .. rubric:: Classes


    class :dn:cls:`CompositeFileProvider`
        .. object: type=class name=Microsoft.Extensions.FileProviders.CompositeFileProvider

        
        Looks up files using a list of :any:`Microsoft.Extensions.FileProviders.IFileProvider`\.


    class :dn:cls:`EmbeddedFileProvider`
        .. object: type=class name=Microsoft.Extensions.FileProviders.EmbeddedFileProvider

        
        Looks up files using embedded resources in the specified assembly.
        This file provider is case sensitive.


    class :dn:cls:`FileSystemInfoHelper`
        .. object: type=class name=Microsoft.Extensions.FileProviders.FileSystemInfoHelper

        


    class :dn:cls:`NotFoundDirectoryContents`
        .. object: type=class name=Microsoft.Extensions.FileProviders.NotFoundDirectoryContents

        
        Represents a non-existing directory


    class :dn:cls:`NotFoundFileInfo`
        .. object: type=class name=Microsoft.Extensions.FileProviders.NotFoundFileInfo

        
        Represents a non-existing file.


    class :dn:cls:`NullChangeToken`
        .. object: type=class name=Microsoft.Extensions.FileProviders.NullChangeToken

        
        An empty change token that doesn't raise any change callbacks


    class :dn:cls:`NullFileProvider`
        .. object: type=class name=Microsoft.Extensions.FileProviders.NullFileProvider

        
        An empty file provider with no contents.


    class :dn:cls:`PhysicalFileProvider`
        .. object: type=class name=Microsoft.Extensions.FileProviders.PhysicalFileProvider

        
        Looks up files using the on-disk file system


