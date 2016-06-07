

AspNetTicketSerializer Class
============================





Namespace
    :dn:ns:`Microsoft.Owin.Security.Interop`
Assemblies
    * Microsoft.Owin.Security.Interop

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Owin.Security.Interop.AspNetTicketSerializer`








Syntax
------

.. code-block:: csharp

    public class AspNetTicketSerializer : IDataSerializer<AuthenticationTicket>








.. dn:class:: Microsoft.Owin.Security.Interop.AspNetTicketSerializer
    :hidden:

.. dn:class:: Microsoft.Owin.Security.Interop.AspNetTicketSerializer

Properties
----------

.. dn:class:: Microsoft.Owin.Security.Interop.AspNetTicketSerializer
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Owin.Security.Interop.AspNetTicketSerializer.Default
    
        
        :rtype: Microsoft.Owin.Security.Interop.AspNetTicketSerializer
    
        
        .. code-block:: csharp
    
            public static AspNetTicketSerializer Default
            {
                get;
            }
    

Methods
-------

.. dn:class:: Microsoft.Owin.Security.Interop.AspNetTicketSerializer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Owin.Security.Interop.AspNetTicketSerializer.Deserialize(System.Byte[])
    
        
    
        
        :type data: System.Byte<System.Byte>[]
        :rtype: Microsoft.Owin.Security.AuthenticationTicket
    
        
        .. code-block:: csharp
    
            public virtual AuthenticationTicket Deserialize(byte[] data)
    
    .. dn:method:: Microsoft.Owin.Security.Interop.AspNetTicketSerializer.Read(System.IO.BinaryReader)
    
        
    
        
        :type reader: System.IO.BinaryReader
        :rtype: Microsoft.Owin.Security.AuthenticationTicket
    
        
        .. code-block:: csharp
    
            public virtual AuthenticationTicket Read(BinaryReader reader)
    
    .. dn:method:: Microsoft.Owin.Security.Interop.AspNetTicketSerializer.ReadClaim(System.IO.BinaryReader, System.Security.Claims.ClaimsIdentity)
    
        
    
        
        :type reader: System.IO.BinaryReader
    
        
        :type identity: System.Security.Claims.ClaimsIdentity
        :rtype: System.Security.Claims.Claim
    
        
        .. code-block:: csharp
    
            protected virtual Claim ReadClaim(BinaryReader reader, ClaimsIdentity identity)
    
    .. dn:method:: Microsoft.Owin.Security.Interop.AspNetTicketSerializer.ReadIdentity(System.IO.BinaryReader)
    
        
    
        
        :type reader: System.IO.BinaryReader
        :rtype: System.Security.Claims.ClaimsIdentity
    
        
        .. code-block:: csharp
    
            protected virtual ClaimsIdentity ReadIdentity(BinaryReader reader)
    
    .. dn:method:: Microsoft.Owin.Security.Interop.AspNetTicketSerializer.Serialize(Microsoft.Owin.Security.AuthenticationTicket)
    
        
    
        
        :type ticket: Microsoft.Owin.Security.AuthenticationTicket
        :rtype: System.Byte<System.Byte>[]
    
        
        .. code-block:: csharp
    
            public virtual byte[] Serialize(AuthenticationTicket ticket)
    
    .. dn:method:: Microsoft.Owin.Security.Interop.AspNetTicketSerializer.Write(System.IO.BinaryWriter, Microsoft.Owin.Security.AuthenticationTicket)
    
        
    
        
        :type writer: System.IO.BinaryWriter
    
        
        :type ticket: Microsoft.Owin.Security.AuthenticationTicket
    
        
        .. code-block:: csharp
    
            public virtual void Write(BinaryWriter writer, AuthenticationTicket ticket)
    
    .. dn:method:: Microsoft.Owin.Security.Interop.AspNetTicketSerializer.WriteClaim(System.IO.BinaryWriter, System.Security.Claims.Claim)
    
        
    
        
        :type writer: System.IO.BinaryWriter
    
        
        :type claim: System.Security.Claims.Claim
    
        
        .. code-block:: csharp
    
            protected virtual void WriteClaim(BinaryWriter writer, Claim claim)
    
    .. dn:method:: Microsoft.Owin.Security.Interop.AspNetTicketSerializer.WriteIdentity(System.IO.BinaryWriter, System.Security.Claims.ClaimsIdentity)
    
        
    
        
        :type writer: System.IO.BinaryWriter
    
        
        :type identity: System.Security.Claims.ClaimsIdentity
    
        
        .. code-block:: csharp
    
            protected virtual void WriteIdentity(BinaryWriter writer, ClaimsIdentity identity)
    

