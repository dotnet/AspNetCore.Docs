

HttpRequestFeature Class
========================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Http.Features`
Assemblies
    * Microsoft.AspNetCore.Http

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Http.Features.HttpRequestFeature`








Syntax
------

.. code-block:: csharp

    public class HttpRequestFeature : IHttpRequestFeature








.. dn:class:: Microsoft.AspNetCore.Http.Features.HttpRequestFeature
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Http.Features.HttpRequestFeature

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Http.Features.HttpRequestFeature
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.HttpRequestFeature.Body
    
        
        :rtype: System.IO.Stream
    
        
        .. code-block:: csharp
    
            public Stream Body
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.HttpRequestFeature.Headers
    
        
        :rtype: Microsoft.AspNetCore.Http.IHeaderDictionary
    
        
        .. code-block:: csharp
    
            public IHeaderDictionary Headers
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.HttpRequestFeature.Method
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Method
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.HttpRequestFeature.Path
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Path
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.HttpRequestFeature.PathBase
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string PathBase
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.HttpRequestFeature.Protocol
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Protocol
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.HttpRequestFeature.QueryString
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string QueryString
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Http.Features.HttpRequestFeature.Scheme
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Scheme
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Http.Features.HttpRequestFeature
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Http.Features.HttpRequestFeature.HttpRequestFeature()
    
        
    
        
        .. code-block:: csharp
    
            public HttpRequestFeature()
    

