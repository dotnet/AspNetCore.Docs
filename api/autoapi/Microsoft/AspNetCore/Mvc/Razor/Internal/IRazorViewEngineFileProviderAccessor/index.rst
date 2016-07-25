

IRazorViewEngineFileProviderAccessor Interface
==============================================






Accessor to the :any:`Microsoft.Extensions.FileProviders.IFileProvider` used by :any:`Microsoft.AspNetCore.Mvc.Razor.RazorViewEngine`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Razor.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.Razor

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IRazorViewEngineFileProviderAccessor








.. dn:interface:: Microsoft.AspNetCore.Mvc.Razor.Internal.IRazorViewEngineFileProviderAccessor
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.Razor.Internal.IRazorViewEngineFileProviderAccessor

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.Mvc.Razor.Internal.IRazorViewEngineFileProviderAccessor
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.Internal.IRazorViewEngineFileProviderAccessor.FileProvider
    
        
    
        
        Gets the :any:`Microsoft.Extensions.FileProviders.IFileProvider` used to look up Razor files.
    
        
        :rtype: Microsoft.Extensions.FileProviders.IFileProvider
    
        
        .. code-block:: csharp
    
            IFileProvider FileProvider { get; }
    

