

MvcCoreMvcOptionsSetup Class
============================






Sets up default options for :any:`Microsoft.AspNetCore.Mvc.MvcOptions`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Internal.MvcCoreMvcOptionsSetup`








Syntax
------

.. code-block:: csharp

    public class MvcCoreMvcOptionsSetup : IConfigureOptions<MvcOptions>








.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreMvcOptionsSetup
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreMvcOptionsSetup

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreMvcOptionsSetup
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreMvcOptionsSetup.MvcCoreMvcOptionsSetup(Microsoft.AspNetCore.Mvc.Internal.IHttpRequestStreamReaderFactory)
    
        
    
        
        :type readerFactory: Microsoft.AspNetCore.Mvc.Internal.IHttpRequestStreamReaderFactory
    
        
        .. code-block:: csharp
    
            public MvcCoreMvcOptionsSetup(IHttpRequestStreamReaderFactory readerFactory)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreMvcOptionsSetup
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.MvcCoreMvcOptionsSetup.Configure(Microsoft.AspNetCore.Mvc.MvcOptions)
    
        
    
        
        :type options: Microsoft.AspNetCore.Mvc.MvcOptions
    
        
        .. code-block:: csharp
    
            public void Configure(MvcOptions options)
    

