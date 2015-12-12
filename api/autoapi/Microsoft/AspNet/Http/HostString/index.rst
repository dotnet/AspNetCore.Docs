

HostString Struct
=================



.. contents:: 
   :local:



Summary
-------

Represents the host portion of a URI can be used to construct URI's properly formatted and encoded for use in
HTTP headers.











Syntax
------

.. code-block:: csharp

   public struct HostString : IEquatable<HostString>





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/httpabstractions/src/Microsoft.AspNet.Http.Abstractions/HostString.cs>`_





.. dn:structure:: Microsoft.AspNet.Http.HostString

Constructors
------------

.. dn:structure:: Microsoft.AspNet.Http.HostString
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Http.HostString.HostString(System.String)
    
        
    
        Creates a new HostString without modification. The value should be Unicode rather than punycode, and may have a port.
        IPv4 and IPv6 addresses are also allowed, and also may have ports.
    
        
        
        
        :type value: System.String
    
        
        .. code-block:: csharp
    
           public HostString(string value)
    

Methods
-------

.. dn:structure:: Microsoft.AspNet.Http.HostString
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Http.HostString.Equals(Microsoft.AspNet.Http.HostString)
    
        
    
        Compares the equality of the Value property, ignoring case.
    
        
        
        
        :type other: Microsoft.AspNet.Http.HostString
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool Equals(HostString other)
    
    .. dn:method:: Microsoft.AspNet.Http.HostString.Equals(System.Object)
    
        
    
        Compares against the given object only if it is a HostString.
    
        
        
        
        :type obj: System.Object
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool Equals(object obj)
    
    .. dn:method:: Microsoft.AspNet.Http.HostString.FromUriComponent(System.String)
    
        
    
        Creates a new HostString from the given URI component.
        Any punycode will be converted to Unicode.
    
        
        
        
        :type uriComponent: System.String
        :rtype: Microsoft.AspNet.Http.HostString
    
        
        .. code-block:: csharp
    
           public static HostString FromUriComponent(string uriComponent)
    
    .. dn:method:: Microsoft.AspNet.Http.HostString.FromUriComponent(System.Uri)
    
        
    
        Creates a new HostString from the host and port of the give Uri instance.
        Punycode will be converted to Unicode.
    
        
        
        
        :type uri: System.Uri
        :rtype: Microsoft.AspNet.Http.HostString
    
        
        .. code-block:: csharp
    
           public static HostString FromUriComponent(Uri uri)
    
    .. dn:method:: Microsoft.AspNet.Http.HostString.GetHashCode()
    
        
    
        Gets a hash code for the value.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public override int GetHashCode()
    
    .. dn:method:: Microsoft.AspNet.Http.HostString.ToString()
    
        
    
        Returns the value as normalized by ToUriComponent().
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public override string ToString()
    
    .. dn:method:: Microsoft.AspNet.Http.HostString.ToUriComponent()
    
        
    
        Returns the value properly formatted and encoded for use in a URI in a HTTP header.
        Any Unicode is converted to punycode. IPv6 addresses will have brackets added if they are missing.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ToUriComponent()
    

Properties
----------

.. dn:structure:: Microsoft.AspNet.Http.HostString
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Http.HostString.HasValue
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool HasValue { get; }
    
    .. dn:property:: Microsoft.AspNet.Http.HostString.Value
    
        
    
        Returns the original value from the constructor.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Value { get; }
    

