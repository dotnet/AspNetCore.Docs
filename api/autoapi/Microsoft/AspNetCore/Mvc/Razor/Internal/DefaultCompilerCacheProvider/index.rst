

DefaultCompilerCacheProvider Class
==================================






Default implementation for :any:`Microsoft.AspNetCore.Mvc.Razor.Internal.ICompilerCacheProvider`\.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Razor.Internal.DefaultCompilerCacheProvider`








Syntax
------

.. code-block:: csharp

    public class DefaultCompilerCacheProvider : ICompilerCacheProvider








.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Internal.DefaultCompilerCacheProvider
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Internal.DefaultCompilerCacheProvider

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Internal.DefaultCompilerCacheProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.Internal.DefaultCompilerCacheProvider.Cache
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Razor.Internal.ICompilerCache
    
        
        .. code-block:: csharp
    
            public ICompilerCache Cache
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.Internal.DefaultCompilerCacheProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Razor.Internal.DefaultCompilerCacheProvider.DefaultCompilerCacheProvider(Microsoft.AspNetCore.Mvc.Razor.Internal.IRazorViewEngineFileProviderAccessor)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.Razor.Internal.DefaultCompilerCacheProvider`\.
    
        
    
        
        :param fileProviderAccessor: The :any:`Microsoft.AspNetCore.Mvc.Razor.Internal.IRazorViewEngineFileProviderAccessor`\.
        
        :type fileProviderAccessor: Microsoft.AspNetCore.Mvc.Razor.Internal.IRazorViewEngineFileProviderAccessor
    
        
        .. code-block:: csharp
    
            public DefaultCompilerCacheProvider(IRazorViewEngineFileProviderAccessor fileProviderAccessor)
    

