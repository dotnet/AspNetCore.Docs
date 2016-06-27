

DeveloperExceptionPageOptions Class
===================================






Options for the :any:`Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddleware`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Builder`
Assemblies
    * Microsoft.AspNetCore.Diagnostics

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Builder.DeveloperExceptionPageOptions`








Syntax
------

.. code-block:: csharp

    public class DeveloperExceptionPageOptions








.. dn:class:: Microsoft.AspNetCore.Builder.DeveloperExceptionPageOptions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Builder.DeveloperExceptionPageOptions

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Builder.DeveloperExceptionPageOptions
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Builder.DeveloperExceptionPageOptions.DeveloperExceptionPageOptions()
    
        
    
        
        Create an instance with the default options settings.
    
        
    
        
        .. code-block:: csharp
    
            public DeveloperExceptionPageOptions()
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Builder.DeveloperExceptionPageOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Builder.DeveloperExceptionPageOptions.FileProvider
    
        
    
        
        Provides files containing source code used to display contextual information of an exception.
    
        
        :rtype: Microsoft.Extensions.FileProviders.IFileProvider
    
        
        .. code-block:: csharp
    
            public IFileProvider FileProvider { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.DeveloperExceptionPageOptions.SourceCodeLineCount
    
        
    
        
        Determines how many lines of code to include before and after the line of code
        present in an exception's stack frame. Only applies when symbols are available and
        source code referenced by the exception stack trace is present on the server.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int SourceCodeLineCount { get; set; }
    

