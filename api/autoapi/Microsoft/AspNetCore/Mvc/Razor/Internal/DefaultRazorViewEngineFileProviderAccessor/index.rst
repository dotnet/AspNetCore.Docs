

DefaultRazorViewEngineFileProviderAccessor Class
================================================






Default implementation of :any:`Microsoft.AspNetCore.Mvc.Razor.Internal.IRazorViewEngineFileProviderAccessor`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Razor.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.Razor

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Razor.Internal.DefaultRazorViewEngineFileProviderAccessor`








Syntax
------

.. code-block:: csharp

    public class DefaultRazorViewEngineFileProviderAccessor : IRazorViewEngineFileProviderAccessor








.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Internal.DefaultRazorViewEngineFileProviderAccessor
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Internal.DefaultRazorViewEngineFileProviderAccessor

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Internal.DefaultRazorViewEngineFileProviderAccessor
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Razor.Internal.DefaultRazorViewEngineFileProviderAccessor.DefaultRazorViewEngineFileProviderAccessor(Microsoft.Extensions.Options.IOptions<Microsoft.AspNetCore.Mvc.Razor.RazorViewEngineOptions>)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.Razor.Internal.DefaultRazorViewEngineFileProviderAccessor`\.
    
        
    
        
        :param optionsAccessor: Accessor to :any:`Microsoft.AspNetCore.Mvc.Razor.RazorViewEngineOptions`\.
        
        :type optionsAccessor: Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Options.IOptions`1>{Microsoft.AspNetCore.Mvc.Razor.RazorViewEngineOptions<Microsoft.AspNetCore.Mvc.Razor.RazorViewEngineOptions>}
    
        
        .. code-block:: csharp
    
            public DefaultRazorViewEngineFileProviderAccessor(IOptions<RazorViewEngineOptions> optionsAccessor)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Internal.DefaultRazorViewEngineFileProviderAccessor
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.Internal.DefaultRazorViewEngineFileProviderAccessor.FileProvider
    
        
    
        
        Gets the :any:`Microsoft.Extensions.FileProviders.IFileProvider` used to look up Razor files.
    
        
        :rtype: Microsoft.Extensions.FileProviders.IFileProvider
    
        
        .. code-block:: csharp
    
            public IFileProvider FileProvider { get; }
    

