

HostString Struct
=================






Represents the host portion of a URI can be used to construct URI's properly formatted and encoded for use in
HTTP headers.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Http`
Assemblies
    * Microsoft.AspNetCore.Http.Abstractions

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public struct HostString : IEquatable<HostString>








.. dn:structure:: Microsoft.AspNetCore.Http.HostString
    :hidden:

.. dn:structure:: Microsoft.AspNetCore.Http.HostString

Properties
----------

.. dn:structure:: Microsoft.AspNetCore.Http.HostString
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Http.HostString.HasValue
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool HasValue
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Http.HostString.Host
    
        
    
        
        Returns the value of the host part of the value. The port is removed if it was present.
        IPv6 addresses will have brackets added if they are missing.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Host
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Http.HostString.Port
    
        
    
        
        Returns the value of the port part of the host, or <returns>null</returns> if none is found.
    
        
        :rtype: System.Nullable<System.Nullable`1>{System.Int32<System.Int32>}
    
        
        .. code-block:: csharp
    
            public int ? Port
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Http.HostString.Value
    
        
    
        
        Returns the original value from the constructor.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Value
            {
                get;
            }
    

Constructors
------------

.. dn:structure:: Microsoft.AspNetCore.Http.HostString
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Http.HostString.HostString(System.String)
    
        
    
        
        Creates a new HostString without modification. The value should be Unicode rather than punycode, and may have a port.
        IPv4 and IPv6 addresses are also allowed, and also may have ports.
    
        
    
        
        :type value: System.String
    
        
        .. code-block:: csharp
    
            public HostString(string value)
    
    .. dn:constructor:: Microsoft.AspNetCore.Http.HostString.HostString(System.String, System.Int32)
    
        
    
        
        Creates a new HostString from its host and port parts.
    
        
    
        
        :param host: The value should be Unicode rather than punycode. IPv6 addresses must use square braces.
        
        :type host: System.String
    
        
        :param port: A positive, greater than 0 value representing the port in the host string.
        
        :type port: System.Int32
    
        
        .. code-block:: csharp
    
            public HostString(string host, int port)
    

Methods
-------

.. dn:structure:: Microsoft.AspNetCore.Http.HostString
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Http.HostString.Equals(Microsoft.AspNetCore.Http.HostString)
    
        
    
        
        Compares the equality of the Value property, ignoring case.
    
        
    
        
        :type other: Microsoft.AspNetCore.Http.HostString
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Equals(HostString other)
    
    .. dn:method:: Microsoft.AspNetCore.Http.HostString.Equals(System.Object)
    
        
    
        
        Compares against the given object only if it is a HostString.
    
        
    
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.AspNetCore.Http.HostString.FromUriComponent(System.String)
    
        
    
        
        Creates a new HostString from the given URI component.
        Any punycode will be converted to Unicode.
    
        
    
        
        :type uriComponent: System.String
        :rtype: Microsoft.AspNetCore.Http.HostString
    
        
        .. code-block:: csharp
    
            public static HostString FromUriComponent(string uriComponent)
    
    .. dn:method:: Microsoft.AspNetCore.Http.HostString.FromUriComponent(System.Uri)
    
        
    
        
        Creates a new HostString from the host and port of the give Uri instance.
        Punycode will be converted to Unicode.
    
        
    
        
        :type uri: System.Uri
        :rtype: Microsoft.AspNetCore.Http.HostString
    
        
        .. code-block:: csharp
    
            public static HostString FromUriComponent(Uri uri)
    
    .. dn:method:: Microsoft.AspNetCore.Http.HostString.GetHashCode()
    
        
    
        
        Gets a hash code for the value.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int GetHashCode()
    
    .. dn:method:: Microsoft.AspNetCore.Http.HostString.ToString()
    
        
    
        
        Returns the value as normalized by ToUriComponent().
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string ToString()
    
    .. dn:method:: Microsoft.AspNetCore.Http.HostString.ToUriComponent()
    
        
    
        
        Returns the value properly formatted and encoded for use in a URI in a HTTP header.
        Any Unicode is converted to punycode. IPv6 addresses will have brackets added if they are missing.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ToUriComponent()
    

