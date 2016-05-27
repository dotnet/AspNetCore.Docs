

HandshakeHelpers Class
======================





Namespace
    :dn:ns:`Microsoft.AspNetCore.WebSockets.Protocol`
Assemblies
    * Microsoft.AspNetCore.WebSockets.Protocol

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.WebSockets.Protocol.HandshakeHelpers`








Syntax
------

.. code-block:: csharp

    public class HandshakeHelpers








.. dn:class:: Microsoft.AspNetCore.WebSockets.Protocol.HandshakeHelpers
    :hidden:

.. dn:class:: Microsoft.AspNetCore.WebSockets.Protocol.HandshakeHelpers

Properties
----------

.. dn:class:: Microsoft.AspNetCore.WebSockets.Protocol.HandshakeHelpers
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.WebSockets.Protocol.HandshakeHelpers.NeededHeaders
    
        
    
        
        Gets request headers needed process the handshake on the server.
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public static IEnumerable<string> NeededHeaders
            {
                get;
            }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.WebSockets.Protocol.HandshakeHelpers
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.WebSockets.Protocol.HandshakeHelpers.CheckSupportedWebSocketRequest(System.String, System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<System.String, System.String>>)
    
        
    
        
        :type method: System.String
    
        
        :type headers: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair`2>{System.String<System.String>, System.String<System.String>}}
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public static bool CheckSupportedWebSocketRequest(string method, IEnumerable<KeyValuePair<string, string>> headers)
    
    .. dn:method:: Microsoft.AspNetCore.WebSockets.Protocol.HandshakeHelpers.CreateRequestKey()
    
        
    
        
        "The value of this header field MUST be a nonce consisting of a randomly selected 16-byte value that has been base64-encoded."
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static string CreateRequestKey()
    
    .. dn:method:: Microsoft.AspNetCore.WebSockets.Protocol.HandshakeHelpers.CreateResponseKey(System.String)
    
        
    
        
        "...the base64-encoded SHA-1 of the concatenation of the \|Sec-WebSocket-Key\| (as a string, not base64-decoded) with the string
        '258EAFA5-E914-47DA-95CA-C5AB0DC85B11'"
    
        
    
        
        :type requestKey: System.String
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public static string CreateResponseKey(string requestKey)
    
    .. dn:method:: Microsoft.AspNetCore.WebSockets.Protocol.HandshakeHelpers.GenerateResponseHeaders(System.String, System.String)
    
        
    
        
        :type key: System.String
    
        
        :type subProtocol: System.String
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.Collections.Generic.KeyValuePair<System.Collections.Generic.KeyValuePair`2>{System.String<System.String>, System.String<System.String>}}
    
        
        .. code-block:: csharp
    
            public static IEnumerable<KeyValuePair<string, string>> GenerateResponseHeaders(string key, string subProtocol)
    
    .. dn:method:: Microsoft.AspNetCore.WebSockets.Protocol.HandshakeHelpers.IsRequestKeyValid(System.String)
    
        
    
        
        Validates the Sec-WebSocket-Key request header
        "The value of this header field MUST be a nonce consisting of a randomly selected 16-byte value that has been base64-encoded."
    
        
    
        
        :type value: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public static bool IsRequestKeyValid(string value)
    
    .. dn:method:: Microsoft.AspNetCore.WebSockets.Protocol.HandshakeHelpers.IsResponseKeyValid(System.String)
    
        
    
        
        :type value: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public static bool IsResponseKeyValid(string value)
    

