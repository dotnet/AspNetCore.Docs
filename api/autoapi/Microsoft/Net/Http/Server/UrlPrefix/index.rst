

UrlPrefix Class
===============





Namespace
    :dn:ns:`Microsoft.Net.Http.Server`
Assemblies
    * Microsoft.Net.Http.Server

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Net.Http.Server.UrlPrefix`








Syntax
------

.. code-block:: csharp

    public class UrlPrefix








.. dn:class:: Microsoft.Net.Http.Server.UrlPrefix
    :hidden:

.. dn:class:: Microsoft.Net.Http.Server.UrlPrefix

Properties
----------

.. dn:class:: Microsoft.Net.Http.Server.UrlPrefix
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Net.Http.Server.UrlPrefix.Host
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Host
            {
                get;
            }
    
    .. dn:property:: Microsoft.Net.Http.Server.UrlPrefix.IsHttps
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsHttps
            {
                get;
            }
    
    .. dn:property:: Microsoft.Net.Http.Server.UrlPrefix.Path
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Path
            {
                get;
            }
    
    .. dn:property:: Microsoft.Net.Http.Server.UrlPrefix.Port
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Port
            {
                get;
            }
    
    .. dn:property:: Microsoft.Net.Http.Server.UrlPrefix.PortValue
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int PortValue
            {
                get;
            }
    
    .. dn:property:: Microsoft.Net.Http.Server.UrlPrefix.Scheme
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Scheme
            {
                get;
            }
    
    .. dn:property:: Microsoft.Net.Http.Server.UrlPrefix.Whole
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Whole
            {
                get;
            }
    

Methods
-------

.. dn:class:: Microsoft.Net.Http.Server.UrlPrefix
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Net.Http.Server.UrlPrefix.Create(System.String)
    
        
    
        
        :type prefix: System.String
        :rtype: Microsoft.Net.Http.Server.UrlPrefix
    
        
        .. code-block:: csharp
    
            public static UrlPrefix Create(string prefix)
    
    .. dn:method:: Microsoft.Net.Http.Server.UrlPrefix.Create(System.String, System.String, System.Nullable<System.Int32>, System.String)
    
        
    
        
        http://msdn.microsoft.com/en-us/library/windows/desktop/aa364698(v=vs.85).aspx
    
        
    
        
        :param scheme: http or https. Will be normalized to lower case.
        
        :type scheme: System.String
    
        
        :param host: +, \*, IPv4, [IPv6], or a dns name. Http.Sys does not permit punycode (xn--), use Unicode instead.
        
        :type host: System.String
    
        
        :param portValue: If empty, the default port for the given scheme will be used (80 or 443).
        
        :type portValue: System.Nullable<System.Nullable`1>{System.Int32<System.Int32>}
    
        
        :param path: Should start and end with a '/', though a missing trailing slash will be added. This value must be un-escaped.
        
        :type path: System.String
        :rtype: Microsoft.Net.Http.Server.UrlPrefix
    
        
        .. code-block:: csharp
    
            public static UrlPrefix Create(string scheme, string host, int ? portValue, string path)
    
    .. dn:method:: Microsoft.Net.Http.Server.UrlPrefix.Create(System.String, System.String, System.String, System.String)
    
        
    
        
        http://msdn.microsoft.com/en-us/library/windows/desktop/aa364698(v=vs.85).aspx
    
        
    
        
        :param scheme: http or https. Will be normalized to lower case.
        
        :type scheme: System.String
    
        
        :param host: +, \*, IPv4, [IPv6], or a dns name. Http.Sys does not permit punycode (xn--), use Unicode instead.
        
        :type host: System.String
    
        
        :param port: If empty, the default port for the given scheme will be used (80 or 443).
        
        :type port: System.String
    
        
        :param path: Should start and end with a '/', though a missing trailing slash will be added. This value must be un-escaped.
        
        :type path: System.String
        :rtype: Microsoft.Net.Http.Server.UrlPrefix
    
        
        .. code-block:: csharp
    
            public static UrlPrefix Create(string scheme, string host, string port, string path)
    
    .. dn:method:: Microsoft.Net.Http.Server.UrlPrefix.Equals(System.Object)
    
        
    
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.Net.Http.Server.UrlPrefix.GetHashCode()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int GetHashCode()
    
    .. dn:method:: Microsoft.Net.Http.Server.UrlPrefix.ToString()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string ToString()
    

