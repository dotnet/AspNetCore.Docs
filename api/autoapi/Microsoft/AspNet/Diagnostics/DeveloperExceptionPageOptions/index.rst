

DeveloperExceptionPageOptions Class
===================================



.. contents:: 
   :local:



Summary
-------

Options for the DeveloperExceptionPageMiddleware.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Diagnostics.DeveloperExceptionPageOptions`








Syntax
------

.. code-block:: csharp

   public class DeveloperExceptionPageOptions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/diagnostics/src/Microsoft.AspNet.Diagnostics/DeveloperExceptionPage/DeveloperExceptionPageOptions.cs>`_





.. dn:class:: Microsoft.AspNet.Diagnostics.DeveloperExceptionPageOptions

Constructors
------------

.. dn:class:: Microsoft.AspNet.Diagnostics.DeveloperExceptionPageOptions
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Diagnostics.DeveloperExceptionPageOptions.DeveloperExceptionPageOptions()
    
        
    
        Create an instance with the default options settings.
    
        
    
        
        .. code-block:: csharp
    
           public DeveloperExceptionPageOptions()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Diagnostics.DeveloperExceptionPageOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Diagnostics.DeveloperExceptionPageOptions.FileProvider
    
        
    
        Provides files containing source code used to display contextual information of an exception.
    
        
        :rtype: Microsoft.AspNet.FileProviders.IFileProvider
    
        
        .. code-block:: csharp
    
           public IFileProvider FileProvider { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Diagnostics.DeveloperExceptionPageOptions.SourceCodeLineCount
    
        
    
        Determines how many lines of code to include before and after the line of code
        present in an exception's stack frame. Only applies when symbols are available and
        source code referenced by the exception stack trace is present on the server.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int SourceCodeLineCount { get; set; }
    

