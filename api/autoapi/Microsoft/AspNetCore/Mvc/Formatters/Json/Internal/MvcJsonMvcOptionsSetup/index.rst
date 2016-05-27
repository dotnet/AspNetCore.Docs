

MvcJsonMvcOptionsSetup Class
============================






Sets up JSON formatter options for :any:`Microsoft.AspNetCore.Mvc.MvcOptions`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Formatters.Json.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.Formatters.Json

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Options.ConfigureOptions{Microsoft.AspNetCore.Mvc.MvcOptions}`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Formatters.Json.Internal.MvcJsonMvcOptionsSetup`








Syntax
------

.. code-block:: csharp

    public class MvcJsonMvcOptionsSetup : ConfigureOptions<MvcOptions>, IConfigureOptions<MvcOptions>








.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.Json.Internal.MvcJsonMvcOptionsSetup
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.Json.Internal.MvcJsonMvcOptionsSetup

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.Json.Internal.MvcJsonMvcOptionsSetup
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Formatters.Json.Internal.MvcJsonMvcOptionsSetup.MvcJsonMvcOptionsSetup(Microsoft.Extensions.Logging.ILoggerFactory, Microsoft.Extensions.Options.IOptions<Microsoft.AspNetCore.Mvc.MvcJsonOptions>, System.Buffers.ArrayPool<System.Char>, Microsoft.Extensions.ObjectPool.ObjectPoolProvider)
    
        
    
        
        Intiailizes a new instance of :any:`Microsoft.AspNetCore.Mvc.Formatters.Json.Internal.MvcJsonMvcOptionsSetup`\.
    
        
    
        
        :param loggerFactory: The :any:`Microsoft.Extensions.Logging.ILoggerFactory`\.
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        :type jsonOptions: Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Options.IOptions`1>{Microsoft.AspNetCore.Mvc.MvcJsonOptions<Microsoft.AspNetCore.Mvc.MvcJsonOptions>}
    
        
        :type charPool: System.Buffers.ArrayPool<System.Buffers.ArrayPool`1>{System.Char<System.Char>}
    
        
        :type objectPoolProvider: Microsoft.Extensions.ObjectPool.ObjectPoolProvider
    
        
        .. code-block:: csharp
    
            public MvcJsonMvcOptionsSetup(ILoggerFactory loggerFactory, IOptions<MvcJsonOptions> jsonOptions, ArrayPool<char> charPool, ObjectPoolProvider objectPoolProvider)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Formatters.Json.Internal.MvcJsonMvcOptionsSetup
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Formatters.Json.Internal.MvcJsonMvcOptionsSetup.ConfigureMvc(Microsoft.AspNetCore.Mvc.MvcOptions, Newtonsoft.Json.JsonSerializerSettings, Microsoft.Extensions.Logging.ILoggerFactory, System.Buffers.ArrayPool<System.Char>, Microsoft.Extensions.ObjectPool.ObjectPoolProvider)
    
        
    
        
        :type options: Microsoft.AspNetCore.Mvc.MvcOptions
    
        
        :type serializerSettings: Newtonsoft.Json.JsonSerializerSettings
    
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        :type charPool: System.Buffers.ArrayPool<System.Buffers.ArrayPool`1>{System.Char<System.Char>}
    
        
        :type objectPoolProvider: Microsoft.Extensions.ObjectPool.ObjectPoolProvider
    
        
        .. code-block:: csharp
    
            public static void ConfigureMvc(MvcOptions options, JsonSerializerSettings serializerSettings, ILoggerFactory loggerFactory, ArrayPool<char> charPool, ObjectPoolProvider objectPoolProvider)
    

