

WebListenerOptionsSetup Class
=============================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Server.WebListener.Internal`
Assemblies
    * Microsoft.AspNetCore.Server.WebListener

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Server.WebListener.Internal.WebListenerOptionsSetup`








Syntax
------

.. code-block:: csharp

    public class WebListenerOptionsSetup : IConfigureOptions<WebListenerOptions>








.. dn:class:: Microsoft.AspNetCore.Server.WebListener.Internal.WebListenerOptionsSetup
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.WebListener.Internal.WebListenerOptionsSetup

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Server.WebListener.Internal.WebListenerOptionsSetup
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Server.WebListener.Internal.WebListenerOptionsSetup.WebListenerOptionsSetup(Microsoft.Extensions.Logging.ILoggerFactory)
    
        
    
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        .. code-block:: csharp
    
            public WebListenerOptionsSetup(ILoggerFactory loggerFactory)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.WebListener.Internal.WebListenerOptionsSetup
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.WebListener.Internal.WebListenerOptionsSetup.Configure(Microsoft.AspNetCore.Server.WebListener.WebListenerOptions)
    
        
    
        
        :type options: Microsoft.AspNetCore.Server.WebListener.WebListenerOptions
    
        
        .. code-block:: csharp
    
            public void Configure(WebListenerOptions options)
    

