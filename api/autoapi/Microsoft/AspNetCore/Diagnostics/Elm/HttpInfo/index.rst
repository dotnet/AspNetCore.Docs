

HttpInfo Class
==============





Namespace
    :dn:ns:`Microsoft.AspNetCore.Diagnostics.Elm`
Assemblies
    * Microsoft.AspNetCore.Diagnostics.Elm

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Diagnostics.Elm.HttpInfo`








Syntax
------

.. code-block:: csharp

    public class HttpInfo








.. dn:class:: Microsoft.AspNetCore.Diagnostics.Elm.HttpInfo
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Diagnostics.Elm.HttpInfo

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Diagnostics.Elm.HttpInfo
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.Elm.HttpInfo.ContentType
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ContentType
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.Elm.HttpInfo.Cookies
    
        
        :rtype: Microsoft.AspNetCore.Http.IRequestCookieCollection
    
        
        .. code-block:: csharp
    
            public IRequestCookieCollection Cookies
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.Elm.HttpInfo.Headers
    
        
        :rtype: Microsoft.AspNetCore.Http.IHeaderDictionary
    
        
        .. code-block:: csharp
    
            public IHeaderDictionary Headers
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.Elm.HttpInfo.Host
    
        
        :rtype: Microsoft.AspNetCore.Http.HostString
    
        
        .. code-block:: csharp
    
            public HostString Host
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.Elm.HttpInfo.Method
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Method
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.Elm.HttpInfo.Path
    
        
        :rtype: Microsoft.AspNetCore.Http.PathString
    
        
        .. code-block:: csharp
    
            public PathString Path
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.Elm.HttpInfo.Protocol
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Protocol
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.Elm.HttpInfo.Query
    
        
        :rtype: Microsoft.AspNetCore.Http.QueryString
    
        
        .. code-block:: csharp
    
            public QueryString Query
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.Elm.HttpInfo.RequestID
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string RequestID
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.Elm.HttpInfo.Scheme
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Scheme
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.Elm.HttpInfo.StatusCode
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int StatusCode
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.Elm.HttpInfo.User
    
        
        :rtype: System.Security.Claims.ClaimsPrincipal
    
        
        .. code-block:: csharp
    
            public ClaimsPrincipal User
            {
                get;
                set;
            }
    

