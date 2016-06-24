

DefaultFilesOptions Class
=========================






Options for selecting default file names.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Builder`
Assemblies
    * Microsoft.AspNetCore.StaticFiles

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.StaticFiles.Infrastructure.SharedOptionsBase`
* :dn:cls:`Microsoft.AspNetCore.Builder.DefaultFilesOptions`








Syntax
------

.. code-block:: csharp

    public class DefaultFilesOptions : SharedOptionsBase








.. dn:class:: Microsoft.AspNetCore.Builder.DefaultFilesOptions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Builder.DefaultFilesOptions

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Builder.DefaultFilesOptions
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Builder.DefaultFilesOptions.DefaultFilesOptions()
    
        
    
        
        Configuration for the DefaultFilesMiddleware.
    
        
    
        
        .. code-block:: csharp
    
            public DefaultFilesOptions()
    
    .. dn:constructor:: Microsoft.AspNetCore.Builder.DefaultFilesOptions.DefaultFilesOptions(Microsoft.AspNetCore.StaticFiles.Infrastructure.SharedOptions)
    
        
    
        
        Configuration for the DefaultFilesMiddleware.
    
        
    
        
        :type sharedOptions: Microsoft.AspNetCore.StaticFiles.Infrastructure.SharedOptions
    
        
        .. code-block:: csharp
    
            public DefaultFilesOptions(SharedOptions sharedOptions)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Builder.DefaultFilesOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Builder.DefaultFilesOptions.DefaultFileNames
    
        
    
        
        An ordered list of file names to select by default. List length and ordering may affect performance.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public IList<string> DefaultFileNames { get; set; }
    

