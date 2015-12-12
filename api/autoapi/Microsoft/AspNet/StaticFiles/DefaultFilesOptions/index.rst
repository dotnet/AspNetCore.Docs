

DefaultFilesOptions Class
=========================



.. contents:: 
   :local:



Summary
-------

Options for selecting default file names.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.StaticFiles.Infrastructure.SharedOptionsBase{Microsoft.AspNet.StaticFiles.DefaultFilesOptions}`
* :dn:cls:`Microsoft.AspNet.StaticFiles.DefaultFilesOptions`








Syntax
------

.. code-block:: csharp

   public class DefaultFilesOptions : SharedOptionsBase<DefaultFilesOptions>





GitHub
------

`View on GitHub <https://github.com/aspnet/staticfiles/blob/master/src/Microsoft.AspNet.StaticFiles/DefaultFilesOptions.cs>`_





.. dn:class:: Microsoft.AspNet.StaticFiles.DefaultFilesOptions

Constructors
------------

.. dn:class:: Microsoft.AspNet.StaticFiles.DefaultFilesOptions
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.StaticFiles.DefaultFilesOptions.DefaultFilesOptions()
    
        
    
        Configuration for the DefaultFilesMiddleware.
    
        
    
        
        .. code-block:: csharp
    
           public DefaultFilesOptions()
    
    .. dn:constructor:: Microsoft.AspNet.StaticFiles.DefaultFilesOptions.DefaultFilesOptions(Microsoft.AspNet.StaticFiles.Infrastructure.SharedOptions)
    
        
    
        Configuration for the DefaultFilesMiddleware.
    
        
        
        
        :type sharedOptions: Microsoft.AspNet.StaticFiles.Infrastructure.SharedOptions
    
        
        .. code-block:: csharp
    
           public DefaultFilesOptions(SharedOptions sharedOptions)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.StaticFiles.DefaultFilesOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.StaticFiles.DefaultFilesOptions.DefaultFileNames
    
        
    
        An ordered list of file names to select by default. List length and ordering may affect performance.
    
        
        :rtype: System.Collections.Generic.IList{System.String}
    
        
        .. code-block:: csharp
    
           public IList<string> DefaultFileNames { get; set; }
    

